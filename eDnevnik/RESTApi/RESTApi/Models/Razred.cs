using Domena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTApi.Models
{
    public class Razred
    {
        public int id { get; set; }
        public String name { get; set; }
        public int classTeacherId { get; set; }
        public int schoolId { get; set; }

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