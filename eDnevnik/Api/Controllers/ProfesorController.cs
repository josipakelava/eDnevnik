using System;
using System.Collections.Generic;
using System.Linq;
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
            return View();
        }

        public ActionResult Predmeti()
        {
            return View();
        }

        public ActionResult Popis()
        {
            return View();
        }

        public ActionResult Profil()
        {
            return View();
        }

        public ActionResult Izostanci()
        {
            return View();
        }
    }
}