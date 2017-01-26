using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTApi.Models
{
    public class Cmn
    {
        public ICollection<Domena.Kategorija> categories { get; set; }
        public IList<Ocjena> marks { get; set; }
        public IList<Biljeska> notes { get; set; }
       
        public Cmn(IList<Ocjena> ocjene, IList<Biljeska> biljeske, ICollection<Domena.Kategorija> kategorije)
        {
            this.marks = ocjene;
            this.notes = biljeske;
            this.categories = kategorije;
        }
    }
}