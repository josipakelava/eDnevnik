using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Api.Controllers
{
    public class AdministratorController : Controller
    {
        // GET: Administrator
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UrediOsobne()
        {
            return View();
        }

        public ActionResult UrediProfesor()
        {
            return View();
        }
    }
}