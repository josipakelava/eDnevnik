using Domena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class IzostanakViewModel
    {
        public virtual DateTime datum { get; set; }
        public virtual string razlog { get; set; }
        public virtual bool opravdanost { get; set; }
        public virtual string predmet { get; set; }
        public virtual string ucenik { get; set; }

        public virtual int id { get; set; }

        public static List<IzostanakViewModel> toList(IList<Izostanak> izostanciList)
        {
            List<IzostanakViewModel> lista = new List<IzostanakViewModel>();
            foreach (Izostanak izostanak in izostanciList)
            {
                IzostanakViewModel ivm = new IzostanakViewModel();
                ivm.id = izostanak.id;
                ivm.datum = izostanak.datum;
                ivm.razlog = izostanak.razlog;
                ivm.opravdanost = izostanak.opravdanost;
                ivm.ucenik = izostanak.ucenik.ime + " " + izostanak.ucenik.prezime;
                ivm.predmet = izostanak.predmet.naziv;
                lista.Add(ivm);
            }
            return lista;
        }
    }
}