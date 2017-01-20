using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class Administrator : Osoba
    {
        public Administrator()
        {
            this.skole = new List<Skola>();
        }

        public virtual ICollection<Skola> skole { get; set; }
    }
}