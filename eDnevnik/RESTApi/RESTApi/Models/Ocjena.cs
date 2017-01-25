using Domena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTApi.Models
{
    public class Ocjena
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public int mark { get; set; }
        public int categoryId { get; set; }
        public int subjectId { get; set; }
        public int studentId { get; set; }

        public static IList<Ocjena> toList(IList<Domena.Ocjena> ocjene)
        {
            IList<Ocjena> list = new List<Ocjena>();
            foreach (Domena.Ocjena o in ocjene)
            {
                Ocjena ocjena = new Ocjena()
                {
                    id = o.id,
                    date = o.datum,
                    mark = o.ocjena,
                    categoryId = o.kategorija.idKategorija,
                    subjectId = o.predmet.idPredmet,
                    studentId = o.ucenik.idOsoba
                };
                list.Add(ocjena);
            }
            return list;
        }
    }
}