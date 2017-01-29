using Api.Models;
using Domena;
using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Api.Controllers
{
    public class AdministratorController : Controller
    {
        IUlogaRepository _ulogaRepository = new UlogaRepository();
        IMjestoRepository _mjestoRepository = new MjestoRepository();
        IOsobaRepository _osobaRepository = new OsobaRepository();
        IPredmetRepository _predmetRepository = new PredmetRepository();
        IRazredRepository _razredReopsitory = new RazredRepository();
        ISkolaRepository _skolaRepostiroy = new SkolaRepository();
        IProfesorRepository _profesorRepository = new ProfesorRepository();
        IEvidencijaNastaveRepository _evidencijaRepository = new EvidencijaNastaveRepository();
        IUcenikRepository _ucenikRepository = new UcenikRepository();

        // GET: Administrator
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.uloga = _ulogaRepository.GetAllToCreate();
            ViewBag.mjesta = _mjestoRepository.GetAll();

            return View("RegistrirajKorisnika", new OsobaViewModel());
        }

        [HttpPost]
        [Authorize]
        public ActionResult RegistrirajKorisnika(OsobaViewModel model)
        {
            ViewBag.uloga = _ulogaRepository.GetAllToCreate();
            ViewBag.mjesta = _mjestoRepository.GetAll();

            if (ModelState.IsValid)
            {
                if (model.role.Equals("Ucenik")) _osobaRepository.AddUcenik(model.ime, model.prezime, model.datumRodjenja, model.adresa, model.OIB, model.email, model.password, model.idMjesto);
                else _osobaRepository.AddProfesor(model.ime, model.prezime, model.datumRodjenja, model.adresa, model.OIB, model.email, model.password, model.idMjesto);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [Authorize]
        public ActionResult UrediOsobne()
        {
            ViewBag.osobe = OsobaViewModel.toList(_osobaRepository.GetAll());
            ViewBag.mjesta = _mjestoRepository.GetAll();
            return View();
        }


        [HttpPost]
        [Authorize]
        public ActionResult UrediOsobne(OsobaViewModel model)
        {
            ViewBag.mjesta = _mjestoRepository.GetAll();
            if (ModelState.IsValid)
            {
                _osobaRepository.Update(model.idOsoba, model.ime, model.prezime, model.datumRodjenja, model.adresa, model.OIB, model.email, model.password, model.idMjesto);
                ViewBag.osobe = OsobaViewModel.toList(_osobaRepository.GetAll());
                return View(model);
            }
            return View(model);
        }

        [Authorize]
        public ActionResult EvidencijaNastave()
        {
            ViewBag.razred = _razredReopsitory.GetAllClasses();
            ViewBag.predmet = _predmetRepository.GetAllSubject();

            List<Profesor> profesori =(List<Profesor>) _profesorRepository.GetAll();
            ViewBag.profesori = OsobaViewModel.toListProfesor(_profesorRepository.GetAll());
            return View(new EvidencijaViewModel());
        }

        [HttpPost]
        [Authorize]
        public ActionResult NovaEvidencija(EvidencijaViewModel evidencija)
        {
            _evidencijaRepository.InsertNew(evidencija.idRazred, evidencija.idPredmet, evidencija.idProfesor);
            return RedirectToAction("EvidencijaNastave");
        }

        [Authorize]
        public ActionResult DodajPredmet()
        {
            return View(new PredmetViewModel());
        }

        [Authorize]
        public ActionResult DodajRazred()
        {
            ViewBag.skola = _skolaRepostiroy.GetAllSchool();
            List<Profesor> osoba =(List<Profesor>) _profesorRepository.GetAll();
            osoba = osoba.FindAll(x => x.razrednistvo == null);
            ViewBag.osoba = OsobaViewModel.toListProfesor(osoba);
            ViewBag.skole = _skolaRepostiroy.GetAllSchool();
            return View(new NoviRazredViewModel());
        }

        [HttpPost]
        [Authorize]
        public ActionResult NoviPredmet(PredmetViewModel predmet)
        {
            _predmetRepository.InsertSubject(predmet.naziv);
            return RedirectToAction("DodajPredmet");
        }

        [HttpPost]
        [Authorize]
        public ActionResult NoviRazred(NoviRazredViewModel razred)
        {
            _razredReopsitory.InsertClass(razred.naziv, razred.idRazrednik, razred.idSkola);
            List<Razred> razredi = (List<Razred>)_razredReopsitory.GetAllClasses();
            razredi = razredi.FindAll(x => x.razrednik.idOsoba == razred.idRazrednik);
            _profesorRepository.UpdateRazrednistvo(razred.idRazrednik, razredi[0].idRazred, razred.idSkola);
            return RedirectToAction("DodajRazred");
        }

        [AllowAnonymous]
        public String DohvatiOsobu(int id)
        {
            Osoba osoba = _osobaRepository.Get(id);
            return JsonConvert.SerializeObject(OsobaViewModel.toModel(osoba));
        }

        [Authorize]
        public string PromijeniSkolu(int id)
        {
            TempData["skolaId"] = id;
            List<Profesor> osoba = (List<Profesor>)_profesorRepository.GetAll();
            osoba = osoba.FindAll(x => x.razrednistvo == null);
            osoba = osoba.FindAll(x => x.skola == null || x.skola.idSkola == id);

            return JsonConvert.SerializeObject(OsobaViewModel.toListProfesor(osoba));
        }

        [Authorize]
        public string PromijeniRazred(int id)
        {
            Razred razred = _razredReopsitory.GetClass(id);
            List<Profesor> osoba = (List<Profesor>)_profesorRepository.GetAll();
            osoba = osoba.FindAll(x => x.skola.idSkola == razred.skola.idSkola || x.skola.idSkola == 0);

            List<Predmet> predmeti = (List<Predmet>) _predmetRepository.GetAllSubject();
            List<EvidencijaNastave> evidencija =(List <EvidencijaNastave>) _evidencijaRepository.GetAllClassSubjects(id);
            foreach (EvidencijaNastave item in evidencija)
            {
                predmeti = predmeti.FindAll(x => x.idPredmet != item.predmet.idPredmet);
            }

            
            return JsonConvert.SerializeObject(EvidencijaViewModel.toList(osoba, predmeti));
        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult doesNazivExist(string naziv)
        {

            var predmeti = (List<Predmet>) _predmetRepository.GetAllSubject();
            var postoji = predmeti.Find(x => x.naziv == naziv);
                
            return Json(postoji == null);
        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult doesNazivRazredExist(string naziv)
        {

            var razredi = (List<Razred>)_razredReopsitory.GetAllClasses();
            int skola = (int) TempData.Peek("skolaId");
            var postoji = razredi.Find(x => x.naziv == naziv && x.skola.idSkola == skola);

            return Json(postoji == null);
        }

        [Authorize]
        public void UkloniUcenika(int id)
        {
            _razredReopsitory.RemoveStudent(id);
        }

        [Authorize]
        public String DohvatiSlobodneUcenike()
        {
            return JsonConvert.SerializeObject(OsobaViewModel.toListUcenik(_ucenikRepository.GetAllStudentsWithoutClass()));
        }

        [Authorize]
        [HttpPost]
        public string NoviUcenik(int idOsoba, int idRazred)
        {
            _ucenikRepository.NewClass(idOsoba, idRazred);
            return "DodajRazred";
        }
    }
}