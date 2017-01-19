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
    [Authorize(Roles = "Ucenik, Administrator")]
    public class UcenikController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            int id = Int32.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Identities.ElementAt(0).Claims.ElementAt(0).Value);
            Ucenik ucenik;
            using (var session = DatabaseHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    ucenik = session.QueryOver<Ucenik>().Where(u => u.idOsoba == id).List()[0];
                }
            }
            ViewBag.podaci = ucenik;
            return View();
        }

        public ActionResult Predmeti()
        {
            return View();
        }

        public ActionResult Izostanci()
        {
            return View();
        }
    }
}