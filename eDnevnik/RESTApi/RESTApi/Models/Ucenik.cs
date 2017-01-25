using Domena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTApi.Models
{
    public class Ucenik
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public DateTime birthDate { get; set; }
        public string oib { get; set; }
        public string mail { get; set; }
        public Mjesto city { get; set; }

        public Ucenik(Domena.Ucenik ucenik)
        {
            this.id = ucenik.idOsoba;
            this.firstName = ucenik.ime;
            this.lastName = ucenik.prezime;
            this.address = ucenik.adresa;
            this.birthDate = ucenik.datumRodjenja;
            this.oib = ucenik.OIB;
            this.mail = ucenik.email;
            this.city = ucenik.mjesto;
        }
    }
}