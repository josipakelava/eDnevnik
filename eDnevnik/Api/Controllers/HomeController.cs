using System;
using System.Web.Mvc;
using Api.Mapping;
using Api.Models;

namespace Api.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (var session = DatabaseHelper.OpenSession())
            {

                using (var transaction = session.BeginTransaction())
                {
                    Profesor profesor =  session.QueryOver<Profesor>().Where(x => x.ime == "Tea").List()[0];
          
                    transaction.Commit();
                }

                return View();
            }
        }
    }
}