using Api.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Api.Mapping;
using Api.Models;

namespace Api.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public HomeController()
        {
        }

        public HomeController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        // GET: /Home -> also GET: /
        [AllowAnonymous]
        public ActionResult Index()
        {
            using (var session = DatabaseHelper.OpenSession())
            {

                using (var transaction = session.BeginTransaction())
                {
                    Osoba osoba  = session.QueryOver<Osoba>().Where(x => x.ime == "Tea").List()[0];
                    transaction.Commit();
                }

                return View();
            }
        }
    }
}