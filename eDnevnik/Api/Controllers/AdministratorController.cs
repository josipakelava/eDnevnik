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

        // GET: Administrator
        public ActionResult Index()
        {
            ViewBag.uloga = _ulogaRepository.GetAllToCreate();
            ViewBag.mjesta = _mjestoRepository.GetAll();

            return View("RegistrirajKorisnika", new OsobaViewModel());
        }

        [HttpPost]
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

        public ActionResult UrediOsobne()
        {
            ViewBag.osobe = OsobaViewModel.toList(_osobaRepository.GetAll());
            ViewBag.mjesta = _mjestoRepository.GetAll();
            return View();
        }

        public ActionResult UrediProfesor()
        {
            return View();
        }

        public String DohvatiOsobu(int id)
        {
            Osoba osoba = _osobaRepository.Get(id);
            return JsonConvert.SerializeObject(OsobaViewModel.toModel(osoba));
        }
    }
}