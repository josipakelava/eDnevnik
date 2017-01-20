using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Domena;

namespace Api.Controllers
{
    [Authorize(Roles = "Profesor, Administrator")]
    public class ProfesorController : Controller
    {
        // GET: Profesor
        [Authorize]
        public ActionResult Index()
        {
            //int id = Int32.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Identities.ElementAt(0).Claims.ElementAt(0).Value);
            //Profesor profesor;

            //using (var session = databasehelper.opensession())
            //{
            //    using (var transaction = session.begintransaction())
            //    {
            //        profesor = session.queryover<profesor>().where(p => p.idosoba == id).list()[0];


            //    }

            //}
            //if (profesor.razrednistvo == null) {
            //    TempData["razrednistvo"] = 0;
            //} else TempData["razrednistvo"] = 1;
            //ViewBag.profesor = profesor;
            return View();
        }

        // GET: Profesor/Predmeti
        [Authorize]
        public ActionResult Predmeti(int idRazred)
        {
            //int id = Int32.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Identities.ElementAt(0).Claims.ElementAt(0).Value);
            //IList<EvidencijaNastave> evidencija;
            //using (var session = DatabaseHelper.OpenSession())
            //{
            //    using (var transaction = session.BeginTransaction())
            //    {
            //        evidencija = session.QueryOver<EvidencijaNastave>().Where(p => p.profesor.idOsoba == id ).And(p => p.razred.idRazred == idRazred).List();
            //    }
            //}
            //ViewBag.evidencija = evidencija;
            //TempData["idRazred"] = idRazred;
            return View();
        }

        // GET: Profesor/Ucenici
        public ActionResult Popis(int idPredmet, int idRazred)
        {
            //int id = Int32.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Identities.ElementAt(0).Claims.ElementAt(0).Value);
            //Razred razred;

            //IList<EvidencijaNastave> evidencija;
            //using (var session = DatabaseHelper.OpenSession())
            //{
            //    using (var transaction = session.BeginTransaction())
            //    {
            //        razred = session.QueryOver<Razred>().Where(r => r.idRazred == 123).List()[0];
            //    }
            //}
            //TempData["idPredmet"] = idPredmet;
            //ViewBag.razred = razred;
            return View();
        }

        public ActionResult Profil()
        {
            //int id = Int32.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Identities.ElementAt(0).Claims.ElementAt(0).Value);
            //Profesor profesor;
            //using (var session = DatabaseHelper.OpenSession())
            //{
            //    using (var transaction = session.BeginTransaction())
            //    {
            //        profesor = session.QueryOver<Profesor>().Where(u => u.idOsoba == id).List()[0];
            //    }
            //}
            //ViewBag.profesor = profesor;
            return View();
        }

        public ActionResult Izostanci()
        {
            //int id = Int32.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Identities.ElementAt(0).Claims.ElementAt(0).Value);
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
            //ViewBag.izostanci = pomocni;
          
            return View();
        }
    }


}