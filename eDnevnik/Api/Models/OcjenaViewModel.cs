using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domena;

namespace Api.Models
{
    public class OcjenaViewModel
    {
        public virtual DateTime datum { get; set; }
        public virtual int ocjena { get; set; }
        public virtual string kategorija { get; set; }
        public virtual string predmet { get; set; }
        public virtual int id { get; set; }
        public virtual int mjesecUredivanje { get; set; }
        public virtual int mjesec
        {
            get
            {
                return datum.Month;
            }
        }

        public static IList<OcjenaViewModel> toList(IList<Ocjena> ocjene)
        {
            IList<OcjenaViewModel> lista = new List<OcjenaViewModel>();
            foreach (Ocjena o in ocjene){
                OcjenaViewModel ovm = new OcjenaViewModel();
                ovm.id = o.id;
                ovm.datum = o.datum;
                ovm.ocjena = o.ocjena;
                ovm.kategorija = o.kategorija.naziv.Replace(" ", "");
                ovm.predmet = o.predmet.naziv.Replace(" ", "");
                lista.Add(ovm);
            }
            return lista;
        }
    }
}