using Api.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Domena;
using Repository;
using Microsoft.Owin.Security;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using System.Threading;

namespace Api.Controllers
{
    [Authorize]
    public class AutorizacijaController : Controller
    {
        private IAutorizacijaRepository _repository = new AutorizacijaRepository();

        private IAuthenticationManager Authentication
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void Prijava(Osoba o, string uloga, bool zapamtiMe)
        {
            var korisnik = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Sid, o.idOsoba.ToString()),
                    new Claim(ClaimTypes.Name, o.ime),
                    new Claim(ClaimTypes.Surname, o.prezime),
                    new Claim(ClaimTypes.Email, o.email),
                    new Claim(ClaimTypes.Role, uloga)
                },
                DefaultAuthenticationTypes.ApplicationCookie,
                ClaimTypes.Name,
                ClaimTypes.Role
            );

            Thread.CurrentPrincipal = new ClaimsPrincipal(korisnik);

            Authentication.SignIn(new AuthenticationProperties
            {
                IsPersistent = zapamtiMe
            }, korisnik);
        }

        // GET: /Login -> also GET: /
        [AllowAnonymous]
        public ActionResult Index()
        {
            var hasRole = Authentication.User.FindFirst(ClaimTypes.Role);

            if (hasRole == null)
            {
                LoginViewModel model = new LoginViewModel();

                return View(model);
            }

            string role = hasRole.Value;

            return RedirectToAction("Index", role);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Osoba korisnik = _repository.GetByLoginInfo(model.Email, model.Password, model.Uloga);

                if (korisnik != null)
                {
                    Prijava(korisnik, model.Uloga, model.ZapamtiMe);

                    return RedirectToAction("Index", model.Uloga);
                }
            }
               
            ModelState.AddModelError("", "Uneseni podaci nisu točni. Pokušajte ponovno.");

            return RedirectToAction("Index", "Autorizacija");
        }

        [Authorize]
        public ActionResult Logout()
        {
            Authentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}