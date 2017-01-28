using Domena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTApi.Models
{
    public class Osoba
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public DateTime birthDate { get; set; }
        public string oib { get; set; }
        public string mail { get; set; }
        public Mjesto city { get; set; }

        public Osoba(Domena.Ucenik ucenik)
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

        public Osoba(Domena.Profesor ucenik)
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