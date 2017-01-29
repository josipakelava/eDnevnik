using Domena;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Api.Models
{
    public class NoviRazredViewModel
    {
        [Required(ErrorMessage = "Obavezno polje")]
        [Remote("doesNazivRazredExist", "Administrator", HttpMethod = "POST", ErrorMessage = "Razred s tim imenom vec postoji, molim vas unesite drugacije ime")]
        public string naziv { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public int idSkola { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public int idRazrednik { get; set; }
        public int idRazred { get; set; }

        public string nazivSkola { get; set; }

        public string skolaRazred
        {
            get
            {
                return nazivSkola + ", " + naziv;
            }
        }

        public static List<NoviRazredViewModel> toList(IList<Razred> razredi)
        {
            List<NoviRazredViewModel> lista = new List<NoviRazredViewModel>();
            foreach (Razred razred in razredi)
            {
                NoviRazredViewModel novi = new NoviRazredViewModel();

                novi.naziv = razred.naziv;
                novi.idRazred = razred.idRazred;
                novi.nazivSkola = razred.skola.naziv;
                novi.idSkola = razred.skola.idSkola;


                lista.Add(novi);
            }
            return lista;
        }
    }
}