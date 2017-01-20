using Api.Mapping;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Api.Controllers
{
    [Authorize(Roles = "Profesor, Administrator")]
    public class ProfesorController : Controller
    {
        // GET: Profesor
        [Authorize]
        public ActionResult Index()
        {
            int id = Int32.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Identities.ElementAt(0).Claims.ElementAt(0).Value);
            Profesor profesor;
            IList<EvidencijaNastave> evidencija;
            using (var session = DatabaseHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    profesor = session.QueryOver<Profesor>().Where(p => p.idOsoba == id).List()[0];
                }
            }
            ViewBag.profesor = profesor;
            return View();
        }

        // GET: Profesor/Predmeti
        [Authorize]
        public ActionResult Predmeti(int idRazred)
        {
            int id = Int32.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Identities.ElementAt(0).Claims.ElementAt(0).Value);
            IList<EvidencijaNastave> evidencija;
            using (var session = DatabaseHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    evidencija = session.QueryOver<EvidencijaNastave>().Where(p => p.profesor.idOsoba == id ).And(p => p.razred.idRazred == idRazred).List();
                }
            }
            ViewBag.evidencija = evidencija;
            return View();
        }

        // GET: Profesor/Ucenici
        public ActionResult Ucenici(int idPredmet, int idRazred)
        {
            int id = Int32.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Identities.ElementAt(0).Claims.ElementAt(0).Value);
            Razred razred;

            IList<EvidencijaNastave> evidencija;
            using (var session = DatabaseHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    razred = session.QueryOver<Razred>().Where(r => r.idRazred == 123).List()[0];
                }
            }
            ViewBag.razred = razred;
            return View();
        }
    }


}