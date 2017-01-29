using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Unesite E-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Unesite lozinku")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Uloga { get; set; }

        public bool ZapamtiMe { get; set; }
    }
}
