using Domena;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class OsobaViewModel
    {
        public int idOsoba { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        public string ime { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        public string prezime { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? datumRodjenja { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        public string adresa { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        public string OIB { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        [EmailAddress(ErrorMessage = "Unesite ispravnu e-mail adresu!")]
        public string email { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        public string password { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        [Compare("password", ErrorMessage = "Lozinke se ne poklapaju!")]
        public string repeatedPassword { get; set; }
        public string role  { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public int idMjesto { get; set; }

        public string oibPrezimeIme
        {
            get
            {
                return OIB + ", " + prezime + " " + ime;
            }
        }
       
        public OsobaViewModel()
        {
            role = "Ucenik";
        }

        public static IList<OsobaViewModel> toList(IList<Osoba> osobe)
        {
            IList<OsobaViewModel> lista = new List<OsobaViewModel>();
            foreach (Osoba o in osobe)
            {
                OsobaViewModel ovm = new OsobaViewModel();
                ovm.idOsoba = o.idOsoba;
                ovm.ime = o.ime;
                ovm.prezime = o.prezime;
                ovm.datumRodjenja = o.datumRodjenja;
                ovm.adresa = o.adresa;
                ovm.OIB = o.OIB;
                ovm.email = o.email;
                ovm.password = o.password;
                ovm.repeatedPassword = o.password;
                ovm.idMjesto = o.mjesto.idMjesto;
                lista.Add(ovm);
            }
            return lista;
        }

        public static OsobaViewModel toModel(Osoba o)
        {
            OsobaViewModel ovm = new OsobaViewModel();
            ovm.idOsoba = o.idOsoba;
            ovm.ime = o.ime;
            ovm.prezime = o.prezime;
            ovm.datumRodjenja = o.datumRodjenja;
            ovm.adresa = o.adresa;
            ovm.OIB = o.OIB;
            ovm.email = o.email;
            ovm.password = o.password;
            ovm.repeatedPassword = o.password;
            ovm.idMjesto = o.mjesto.idMjesto;

            return ovm;

        }
    }
}