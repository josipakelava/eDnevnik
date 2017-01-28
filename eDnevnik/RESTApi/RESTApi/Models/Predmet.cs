using Domena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTApi.Models
{
    public class Predmet
    {
        public int id { get; set; }
        public string name { get; set; }

        public Predmet(Domena.Predmet predmet)
        {
            id = predmet.idPredmet;
            name = predmet.naziv;
        }

        public static IList<Predmet> toList(IList<EvidencijaNastave> evidencija)
        {
            IList<Predmet> predmeti = new List<Predmet>();
            foreach(EvidencijaNastave e in evidencija)
                predmeti.Add(new Predmet(e.predmet));
            
            return predmeti;
        }
    }
}