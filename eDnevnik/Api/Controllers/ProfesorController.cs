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
        private IProfesorRepository _repository = new ProfesorRepository();
        // GET: Profesor
        [Authorize]
        public ActionResult Index()
        {
            int id = Int32.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Identities.ElementAt(0).Claims.ElementAt(0).Value);
            Profesor profesor = _repository.Find(id);

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
            int id = Int32.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Identities.ElementAt(0).Claims.ElementAt(0).Value);
            ViewBag.evidencija = _repository.GetAllSubjects(id, idRazred);
            TempData["idRazred"] = idRazred;
            return View();
        }

        // GET: Profesor/Ucenici
        public ActionResult Popis(int idPredmet, int idRazred)
        {
            int id = Int32.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Identities.ElementAt(0).Claims.ElementAt(0).Value);
            TempData["idPredmet"] = idPredmet;
            ViewBag.razred = _repository.GetClass(id, idRazred);
            return View();
        }

        public ActionResult Profil()
        {
            int id = Int32.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Identities.ElementAt(0).Claims.ElementAt(0).Value);
            ViewBag.profesor = _repository.Find(id);
            return View();
        }

        public ActionResult Izostanci()
        {
            int id = Int32.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Identities.ElementAt(0).Claims.ElementAt(0).Value);
            //Profesor profesor;
            //IList<Izostanak> izostanci;
            //List<Izostanak> pomocni = new List<Izostanak>();
            //using (var session = DatabaseHelper.OpenSession())
            //{
            //    using (var transaction = session.BeginTransaction())
            //    {
            //        profesor = session.QueryOver<Profesor>().Where(p => p.idOsoba == id).List()[0];
            //        foreach(var ucenik in profesor.razrednistvo.ucenici)
            //        {
            //            pomocni.AddRange(ucenik.izostanci);
            //        }

            //       // izostanci = session.QueryOver<Izostanak>().Where(p => p.).List();

            //    }

            //}
            //pomocni = pomocni.OrderBy(o => o.datum).ToList();


            List<IzostanakViewModel> izostanci = IzostanakViewModel.toList(_repository.GetAllAbsences(id));
            return View(izostanci);
        }

        [HttpPost]
        public ActionResult SpremiIzostanke(List<IzostanakViewModel> izostanci)
        {
            foreach (IzostanakViewModel izostanak in izostanci)
            {
                _repository.UpdateIzostanak(izostanak.id, izostanak.opravdanost, izostanak.razlog);
            }
            return RedirectToAction("Izostanci");
        }
    }

    }