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
    }
}