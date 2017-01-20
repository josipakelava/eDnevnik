using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web.Mvc;
using Domena;
using Repository;
using Api.Models;

namespace Api.Controllers
{
    [Authorize(Roles = "Ucenik, Administrator")]
    public class UcenikController : Controller
    {
        private IUcenikRepository _repository = new UcenikRepository();

        // GET: Student
        public ActionResult Index()
        {
            int id = Int32.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Identities.ElementAt(0).Claims.ElementAt(0).Value);
            ViewBag.podaci = _repository.Find(id);
            return View();
        }

        public ActionResult Predmeti()
        {
            int id = Int32.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Identities.ElementAt(0).Claims.ElementAt(0).Value);
            ViewBag.evidencija = _repository.GetSchedule(id);
            ViewBag.ocjene = OcjenaViewModel.toList(_repository.GetAllGrades(id));
            ViewBag.biljeske = _repository.GetAllNotes(id);
            return View();
        }

        public ActionResult Izostanci()
        {
            int id = Int32.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Identities.ElementAt(0).Claims.ElementAt(0).Value);
            ViewBag.izostanci = _repository.GetAllAbesnces(id);
            
            return View();
        }
    }
}