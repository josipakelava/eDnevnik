using Repository;
using Domena;
using System;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Threading;
using System.Security.Claims;
using System.Linq;

namespace RESTApi.Controllers
{

    public class UcenikController : Controller
    {
        private IUcenikRepository _repository = new UcenikRepository();

        [Autorizacija]
        [HttpGet]
        public String Get()
        {
            int id = Int32.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Identities.ElementAt(0).Claims.ElementAt(0).Value);
            return JsonConvert.SerializeObject(_repository.Find(id));
        }
    }
}