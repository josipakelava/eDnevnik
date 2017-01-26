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
        public int idRazednik { get; set; }


    }
}