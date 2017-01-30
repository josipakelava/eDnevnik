using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Domena;
using Repository;
using Api.Models;

namespace Api.Controllers
{
    [Authorize(Roles = "Profesor, Administrator")]
    public class ProfesorController : Controller
    {
        public IProfesorRepository _profesorRepository { get; set; }
        public IBiljeskaRepository _biljeskaRepository { get; set; }
        public IIzostanakRepository _izostanakRepository { get; set; }
        public IOcjenaRepository _ocjenaRepository { get; set; }
        public IPredmetRepository _predmetRepository { get; set; }
        public IRazredRepository _razredRepository { get; set; }
        public IEvidencijaNastaveRepository _evidencijaNastaveRepository { get; set; }

        private Func<int> _currentId;

        public ProfesorController() : base()
        {
            _profesorRepository = new ProfesorRepository();
            _biljeskaRepository = new BiljeskaRepository();
            _izostanakRepository = new IzostanakRepository();
            _ocjenaRepository = new OcjenaRepository();
            _predmetRepository = new PredmetRepository();
            _razredRepository = new RazredRepository();
            _evidencijaNastaveRepository = new EvidencijaNastaveRepository();

            _currentId = () => int.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
        }

        // Used for dependency injection in tests
        public ProfesorController(Func<int> getId) : base()
        {
            _currentId = getId;
        }

        public int GetCurrentId()
        {
            return _currentId();
        }

        // GET: Profesor
        [Authorize]
        public ActionResult Index()
        {
            int id = GetCurrentId();
            Profesor profesor = _profesorRepository.Find(id);

            if (profesor.razrednistvo == null)
            {
                TempData["razrednistvo"] = 0;
            }
            else TempData["razrednistvo"] = 1;
            profesor.evidencijaNastave = profesor.evidencijaNastave.OrderBy(o => o.razred.naziv).Distinct().ToList();
            var razredi = new HashSet<Razred>();
            foreach(var i in profesor.evidencijaNastave) {
                razredi.Add(i.razred);
            }
            ViewBag.razredi = razredi.ToList();

            return View();
        }

        // GET: Profesor/Predmeti
        [Authorize]
        public ActionResult Predmeti(int idRazred)
        {
            int id = GetCurrentId();
            ViewBag.evidencija = _evidencijaNastaveRepository.GetAllProfesorSubjects(id, idRazred);
            TempData["idRazred"] = idRazred;
            return View();
        }

        // GET: Profesor/Ucenici
        [Authorize]
        public ActionResult Popis(int idPredmet, int idRazred)
        {
            int id = GetCurrentId();
            TempData["idPredmet"] = idPredmet;
            Predmet predmet = _predmetRepository.GetSubject(idPredmet);
            Razred razred = _razredRepository.GetClass(idRazred);
            List<RazredViewModel> rvm = RazredViewModel.toList(razred, predmet);
            return View(rvm);
        }
        [Authorize]
        public ActionResult Profil()
        {
            int id = GetCurrentId();
            ViewBag.profesor = _profesorRepository.Find(id);
            return View();
        }
        [Authorize]
        public ActionResult Izostanci()
        {
            int id = GetCurrentId();
            List<IzostanakViewModel> izostanci = IzostanakViewModel.toList(_profesorRepository.GetAllAbsencesOfClass(id));
            return View(izostanci);
        }
        [Authorize]
        public ActionResult MojRazred()
        {
            int id = GetCurrentId();
            Profesor profesor = _profesorRepository.Find(id);
            Razred razred = _razredRepository.GetClass(profesor.razrednistvo.idRazred);
            IList<EvidencijaNastave> evidencija = _evidencijaNastaveRepository.GetAllClassSubjects(razred.idRazred);
            List<MojRazredViewModel> podaciRazreda = MojRazredViewModel.toList(razred, evidencija);
            return View(podaciRazreda);
        }
        [Authorize]
        [HttpPost]
        public ActionResult SpremiIzostanke(List<IzostanakViewModel> izostanci)
        {
            foreach (IzostanakViewModel izostanak in izostanci)
            {
                _izostanakRepository.UpdateIzostanak(izostanak.id, izostanak.opravdanost, izostanak.razlog);
            }
            return RedirectToAction("Izostanci");
        }

        [Authorize]
        [HttpPost]
        public ActionResult SpremiRazred(List<RazredViewModel> razred)
        {
            foreach (RazredViewModel ucenik in razred)
            {
                if (ucenik.novabiljeska != null)
                {
                    _biljeskaRepository.InsertNote(ucenik.idPredmet, ucenik.idUcenik, ucenik.novabiljeska, DateTime.Today);
                }
                if (ucenik.izostanak == true)
                {
                    _izostanakRepository.InsertAbsence(ucenik.idPredmet, ucenik.idUcenik, "",DateTime.Today);
                }
                foreach (KategorijaView kategorija in ucenik.kategorije)
                {
                    foreach (OcjenaViewModel ovm in kategorija.ocjene)
                    {
                        if (ovm.id >= 0 && ovm.ocjena > 0 && ovm.ocjena < 6)
                        {
                            _ocjenaRepository.UpdateGrade(ovm.id, ovm.ocjena);
                        }
                        else
                        {
                            if (ovm.ocjena != 0 && ovm.ocjena > 0 && ovm.ocjena < 6)
                            {
                                _ocjenaRepository.InsertGrade(ovm.ocjena, ucenik.idUcenik, ucenik.idPredmet, kategorija.id, GenerirajDatum(ovm.mjesecUredivanje));
                            }
                        }
                    }
                }
            }
            return RedirectToAction("Popis", new { idPredmet = TempData.Peek("idPredmet"), idRazred = TempData.Peek("idRazred") });
        }
        [Authorize]
        public DateTime GenerirajDatum(int mjesec)
        {
            int godina = DateTime.Today.Year;
            if (mjesec >= 9 && DateTime.Today.Month >= 1)
            {
                godina = DateTime.Today.Year - 1;
            }
            else if (mjesec >= 9 && DateTime.Today.Month >= 9)
            {
                godina = DateTime.Today.Year;
            }
            else if (mjesec <= 6 && DateTime.Today.Month >= 9)
            {
                godina = DateTime.Today.Year - 1;
            }
            else if (mjesec <= 6 && DateTime.Today.Month >= 1)
            {
                godina = DateTime.Today.Year;
            }

            DateTime datum = new DateTime(godina, mjesec, 15);
            return datum;
        }

    }

}