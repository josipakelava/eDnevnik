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
                    Administrator admin =  session.QueryOver<Administrator>().Where(x => x.ime == "Matija").List()[0];
          
                    transaction.Commit();
                }

                return View();
            }
        }
    }
}