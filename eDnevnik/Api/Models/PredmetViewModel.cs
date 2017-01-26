using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Api.Models
{
    public class PredmetViewModel
    {
        [Required(ErrorMessage = "Obavezno polje")]
        [Remote("doesNazivExist", "Administrator", HttpMethod = "POST", ErrorMessage = "Predmet s tim imenom vec postoji, molim vas unesite drugacije ime")]
        public string naziv { get; set; }
    }
}