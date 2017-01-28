using Domena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTApi.Models
{
    public class Izostanak
    {
        public int id { get; set; }
        public DateTime date;
        public string reason;
        public bool validity;
        public Predmet subject;
        public int studentId;

        public static IList<Izostanak> toList(IList<Domena.Izostanak> izostanci)
        {
            IList<Izostanak> list = new List<Izostanak>();
            foreach (Domena.Izostanak i in izostanci)
            {
                Izostanak izostanak = new Izostanak()
                {
                    id = i.id,
                    date = i.datum,
                    reason = i.razlog,
                    validity = i.opravdanost,
                    subject = new Predmet(i.predmet),
                    studentId = i.ucenik.idOsoba
                };
                list.Add(izostanak);
            }
            return list;
        }
    }
}