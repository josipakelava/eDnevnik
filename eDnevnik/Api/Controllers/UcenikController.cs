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
        public IUcenikRepository _repository;
        private Func<int> _currentId;
        public UcenikController()
        {
            _repository = new UcenikRepository();
            _currentId = () => int.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
        }
        
        public UcenikController(Func<int> getId) : base()
        {
            _currentId = getId;
        }

        public int GetCurrentId()
        {
            return _currentId();
        }

        // GET: Student
        public ActionResult Index()
        {
            int id = GetCurrentId();
            ViewBag.podaci = _repository.Find(id);
            return View();
        }

        public ActionResult Predmeti()
        {
            int id = GetCurrentId();
            ViewBag.evidencija = _repository.GetSchedule(id);
            ViewBag.ocjene = OcjenaViewModel.toList(_repository.GetAllGrades(id));
            ViewBag.biljeske = _repository.GetAllNotes(id);
            return View();
        }

        public ActionResult Izostanci()
        {
            int id = GetCurrentId();
            ViewBag.izostanci = _repository.GetAllAbesnces(id);
            
            return View();
        }
    }
}