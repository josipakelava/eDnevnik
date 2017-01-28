using Newtonsoft.Json;
using Repository;
using RESTApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace RESTApi.Controllers
{
    public class ProfesorController : Controller
    {
        private IUcenikRepository _ucenikRepository = new UcenikRepository();
        private IPredmetRepository _predmetRepository = new PredmetRepository();
        private IProfesorRepository _profesorRepository = new ProfesorRepository();
        private IEvidencijaNastaveRepository _evidencijaRepository = new EvidencijaNastaveRepository();

        [Autorizacija]
        [HttpGet]
        public string Profil()
        {
            int id = int.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            return JsonConvert.SerializeObject(new Osoba(_profesorRepository.Find(id)));
        }

        //[Autorizacija]
        //[HttpGet]
        //public string Cmn()
        //{
        //    //int id = int.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
        //    //IList<Ocjena> ocjene = Ocjena.toList(_ucenikRepository.GetAllGradesForSubject(id, int.Parse(Url.RequestContext.RouteData.Values["subjectId"].ToString())));
        //    //IList<Biljeska> biljeske = Biljeska.toList(_ucenikRepository.GetAllNotesForSubject(id, int.Parse(Url.RequestContext.RouteData.Values["subjectId"].ToString())));
        //    //ICollection<Domena.Kategorija> kategorije = _predmetRepository.GetAllCategories(int.Parse(Url.RequestContext.RouteData.Values["subjectId"].ToString()));
        //    //return JsonConvert.SerializeObject(new Cmn(ocjene, biljeske, kategorije));
        //}

        [Autorizacija]
        [HttpGet]
        public string Grades()
        {
            int id = int.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            Domena.Profesor profesor = _profesorRepository.Find(id);
            return JsonConvert.SerializeObject(Razred.toList(profesor.evidencijaNastave));
        }


        [Autorizacija]
        [HttpGet]
        public string MyGrade()
        {
            int id = int.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            Domena.Profesor profesor = _profesorRepository.Find(id);
            
            return JsonConvert.SerializeObject(Ucenik.toList(profesor.razrednistvo.ucenici));
        }

        [Autorizacija]
        [HttpGet]
        public string Subjects()
        {
            int id = int.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            return JsonConvert.SerializeObject(Predmet.toList(_evidencijaRepository.GetAllProfesorSubjects(id, int.Parse(Url.RequestContext.RouteData.Values["gradeId"].ToString()))));
        }

    }
}