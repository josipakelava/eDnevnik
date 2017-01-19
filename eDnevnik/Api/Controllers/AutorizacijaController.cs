using Api.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Api.Mapping;
using Microsoft.Owin.Security;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using System.Threading;

namespace Api.Controllers
{
    [Authorize]
    public class AutorizacijaController : Controller
    {

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
            bool uspjeh = true;
            Osoba korisnik;

            if (ModelState.IsValid)
            {
                using (var session = DatabaseHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        try
                        {
                            switch (model.Uloga)
                            {
                                case "Ucenik":
                                    korisnik = session.QueryOver<Ucenik>().Where(u => u.email == model.Email && u.password == model.Password).List()[0];
                                    Prijava(korisnik, "Ucenik", model.ZapamtiMe);
                                    break;
                                case "Razrednik":
                                    korisnik = session.QueryOver<Profesor>().Where(u => u.email == model.Email && u.password == model.Password).List()[0];
                                    Prijava(korisnik, "Razrednik", model.ZapamtiMe);
                                    break;
                                case "Profesor":
                                    korisnik = session.QueryOver<Profesor>().Where(u => u.email == model.Email && u.password == model.Password).List()[0];
                                    Prijava(korisnik, "Profesor", model.ZapamtiMe);
                                    break;
                                    //case "Administrator":
                                    //    korisnik = (Administrator)session.QueryOver<Administrator>().Where(u => u.email == model.Email && u.password == model.Password);
                                    //    Prijava(korisnik, "Administrator", model.ZapamtiMe);
                                    //    break;
                            }
                        } catch (IndexOutOfRangeException)
                        {
                            // Uneseni netočni podatci
                            uspjeh = false;
                        }
                        transaction.Commit();
                    }
                }
            } else
            {
                // Model nije validan
                uspjeh = false;
            }

            if (uspjeh)
            {
                return RedirectToAction("Index", model.Uloga);
            }

            ModelState.AddModelError("", "Uneseni podaci nisu točni. Pokušajte ponovno.");

            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Logout()
        {
            Authentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}