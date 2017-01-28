using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTApi.Models
{
    public class Ucenik : Osoba
    {
        private Razred grade;
        public Ucenik(Domena.Ucenik ucenik) : base(ucenik)
        {
            grade = new Razred(ucenik.razred);
        }
        public static IList<Ucenik> toList(ICollection<Domena.Ucenik> ucenici)
        {
            IList<Ucenik> studenti = new List<Ucenik>();
            foreach (Domena.Ucenik u in ucenici)
            {
                Ucenik ucenik = new Ucenik(u);
                studenti.Add(ucenik);
            }
            return studenti;
        }

    }
}