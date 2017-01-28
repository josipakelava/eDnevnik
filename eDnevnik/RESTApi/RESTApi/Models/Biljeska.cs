using Domena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTApi.Models
{
    public class Biljeska
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string note { get; set; }
        public int subjectId { get; set; }
        public int studentId { get; set; }

        public static IList<Biljeska> toList(IList<Domena.Biljeska> biljeske)
        {
            IList<Biljeska> list = new List<Biljeska>();
            foreach (Domena.Biljeska b in biljeske)
            {
                Biljeska biljeska = new Biljeska()
                {
                    id = b.id,
                    date = b.datum,
                    note = b.biljeska,
                    subjectId = b.predmet.idPredmet,
                    studentId = b.ucenik.idOsoba
                };
                list.Add(biljeska);
            }
            return list;
        }
    }
}