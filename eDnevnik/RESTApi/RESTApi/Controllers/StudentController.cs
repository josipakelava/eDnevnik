using Repository;
using Domena;
using System;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace RESTApi.Controllers
{

    public class StudentController : Controller
    {
        private IUcenikRepository _repository = new UcenikRepository();

        [HttpGet]
        public String Get(string id)
        {
            return JsonConvert.SerializeObject(_repository.Find(int.Parse(id)));
        }

        [Authorize]
        public String Index()
        {
            return "MATIJA";
        }
    }
}