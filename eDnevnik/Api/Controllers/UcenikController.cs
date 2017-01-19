using System;
using System.Collections.Generic;
using System.Linq;
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