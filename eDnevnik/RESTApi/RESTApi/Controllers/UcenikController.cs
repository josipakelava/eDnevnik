using Repository;
using System;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Threading;
using System.Security.Claims;
using System.Linq;
using RESTApi.Models;
using System.Collections.Generic;

namespace RESTApi.Controllers
{

    public class UcenikController : Controller
    {
        private IUcenikRepository _ucenikRepository = new UcenikRepository();
        private IPredmetRepository _predmetRepository = new PredmetRepository();

        [Autorizacija]
        [HttpGet]
        public string Profil()
        {
            int id = int.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            return JsonConvert.SerializeObject(new Osoba(_ucenikRepository.Find(id)));
        }

        [Autorizacija]
        [HttpGet]
        public string Subjects()
        {
            int id = int.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            return JsonConvert.SerializeObject(Predmet.toList(_ucenikRepository.GetSchedule(id)));
        }

        [Autorizacija]
        [HttpGet]
        public string Cmn()
        {
            int id = int.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            IList<Ocjena> ocjene = Ocjena.toList(_ucenikRepository.GetAllGradesForSubject(id, int.Parse(Url.RequestContext.RouteData.Values["subjectId"].ToString())));
            IList<Biljeska> biljeske = Biljeska.toList(_ucenikRepository.GetAllNotesForSubject(id, int.Parse(Url.RequestContext.RouteData.Values["subjectId"].ToString())));
            ICollection<Domena.Kategorija> kategorije = _predmetRepository.GetAllCategories(int.Parse(Url.RequestContext.RouteData.Values["subjectId"].ToString()));
            return JsonConvert.SerializeObject(new Cmn(ocjene, biljeske, kategorije));
        }

        [Autorizacija]
        [HttpGet]
        public string Absences()
        {
            int id = int.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            return JsonConvert.SerializeObject(Izostanak.toList(_ucenikRepository.GetAllAbesnces(id)));
        }

    }
}