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
        private IProfesorRepository _profesorRepository = new ProfesorRepository();
        private IBiljeskaRepository _biljeskaRepository = new BiljeskaRepository();
        private IIzostanakRepository _izostanakRepository = new IzostanakRepository();
        private IOcjenaRepository _ocjenaRepository = new OcjenaRepository();
        private IPredmetRepository _predmetRepository = new PredmetRepository();
        private IRazredRepository _razredRepository = new RazredRepository();
        private IEvidencijaNastaveRepository _evidencijaNastaveRepository = new EvidencijaNastaveRepository();

        // GET: Profesor
        [Authorize]
        public ActionResult Index()
        {
            int id = int.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            Profesor profesor = _profesorRepository.Find(id);

            if (profesor.razrednistvo == null)
            {
                TempData["razrednistvo"] = 0;
            }
            else TempData["razrednistvo"] = 1;
            ViewBag.profesor = profesor;

            return View();
        }

        // GET: Profesor/Predmeti
        [Authorize]
        public ActionResult Predmeti(int idRazred)
        {
            int id = int.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            ViewBag.evidencija = _evidencijaNastaveRepository.GetAllProfesorSubjects(id, idRazred);
            TempData["idRazred"] = idRazred;
            return View();
        }

        // GET: Profesor/Ucenici
        public ActionResult Popis(int idPredmet, int idRazred)
        {
            int id = int.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            TempData["idPredmet"] = idPredmet;
            Predmet predmet = _predmetRepository.GetSubject(idPredmet);
            Razred razred = _razredRepository.GetClass(idRazred);
            List<RazredViewModel> rvm = RazredViewModel.toList(razred, predmet);
            return View(rvm);
        }

        public ActionResult Profil()
        {
            int id = int.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            ViewBag.profesor = _profesorRepository.Find(id);
            return View();
        }

        public ActionResult Izostanci()
        {
            int id = int.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            List<IzostanakViewModel> izostanci = IzostanakViewModel.toList(_profesorRepository.GetAllAbsencesOfClass(id));
            return View(izostanci);
        }

        public ActionResult MojRazred()
        {
            int id = Int32.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Identities.ElementAt(0).Claims.ElementAt(0).Value);
            Profesor profesor = _profesorRepository.Find(id);
            Razred razred = _razredRepository.GetClass(profesor.razrednistvo.idRazred);
            IList<EvidencijaNastave> evidencija = _evidencijaNastaveRepository.GetAllClassSubjects(razred.idRazred);
            List<MojRazredViewModel> podaciRazreda = MojRazredViewModel.toList(razred, evidencija);
            return View(podaciRazreda);
        }

        [HttpPost]
        public ActionResult SpremiIzostanke(List<IzostanakViewModel> izostanci)
        {
            foreach (IzostanakViewModel izostanak in izostanci)
            {
                _izostanakRepository.UpdateIzostanak(izostanak.id, izostanak.opravdanost, izostanak.razlog);
            }
            return RedirectToAction("Izostanci");
        }


        [HttpPost]
        public ActionResult SpremiRazred(List<RazredViewModel> razred)
        {
            foreach (RazredViewModel ucenik in razred)
            {
                if(ucenik.novabiljeska != null) {
                    _biljeskaRepository.InsertNote(ucenik.idPredmet, ucenik.idUcenik, ucenik.novabiljeska, DateTime.Today);
                }
                if(ucenik.izostanak == true)
                {
                    _izostanakRepository.InsertAbsence(ucenik.idPredmet, ucenik.idUcenik, DateTime.Today);
                }
                foreach (KategorijaView kategorija in ucenik.kategorije)
                {
                    foreach(OcjenaViewModel ovm in kategorija.ocjene)
                    {
                        if(ovm.id >= 0 && ovm.ocjena > 0 && ovm.ocjena < 6)
                        {
                            _ocjenaRepository.UpdateGrade(ovm.id, ovm.ocjena);
                        } else
                        {
                            if(ovm.ocjena != 0 && ovm.ocjena > 0 && ovm.ocjena < 6)
                            {
                                _ocjenaRepository.InsertGrade(ovm.ocjena, ucenik.idUcenik, ucenik.idPredmet, kategorija.id, GenerirajDatum(ovm.mjesecUredivanje));
                            }
                        }
                    }
                }   
            }
            return RedirectToAction("Popis", new { idPredmet = TempData.Peek("idPredmet"), idRazred = TempData.Peek("idRazred") });
        }

        public DateTime GenerirajDatum(int mjesec)
        {
            int godina = DateTime.Today.Year;
            if(mjesec >= 9 && DateTime.Today.Month >= 1)
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