using Domena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTApi.Models
{
    public class Razred
    {
        private int id { get; set; }
        private String name { get; set; }
        private int classTeacherId { get; set; }
        private int schoolId { get; set; }

        public Razred(Domena.Razred razred)
        {
            id = razred.idRazred;
            name = razred.naziv;
            classTeacherId = razred.razrednik.idOsoba;
            schoolId = razred.skola.idSkola;
        }

        public static IList<Razred> toList(ICollection<EvidencijaNastave> evidencija)
        {
            IList<Razred> razredi = new List<Razred>();
            foreach (EvidencijaNastave e in evidencija)
                razredi.Add(new Razred(e.razred));

            return razredi;
        }
    }

}