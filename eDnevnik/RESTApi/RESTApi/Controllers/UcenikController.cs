using Repository;
using System;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Threading;
using System.Security.Claims;
using System.Linq;
using RESTApi.Models;

namespace RESTApi.Controllers
{

    public class UcenikController : Controller
    {
        private IUcenikRepository _ucenikRepository = new UcenikRepository();

        [Autorizacija]
        [HttpGet]
        public string Profil()
        {
            int id = int.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            return JsonConvert.SerializeObject(new Ucenik(_ucenikRepository.Find(id)));
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
        public string Marks()
        {
            int id = int.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            return JsonConvert.SerializeObject(Ocjena.toList(_ucenikRepository.GetAllGradesForSubject(id, int.Parse(Url.RequestContext.RouteData.Values["subjectId"].ToString()))));
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