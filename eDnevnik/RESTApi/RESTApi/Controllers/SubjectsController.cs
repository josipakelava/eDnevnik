using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RESTApi.Controllers
{
    public class SubjectsController : Controller
    {
        private IPredmetRepository _predmetRepository = new PredmetRepository();

        [Autorizacija]
        [HttpGet]
        public string Categories()
        {
            return JsonConvert.SerializeObject(_predmetRepository.GetAllCategories(int.Parse(Url.RequestContext.RouteData.Values["subjectId"].ToString())));
        }
    }
}