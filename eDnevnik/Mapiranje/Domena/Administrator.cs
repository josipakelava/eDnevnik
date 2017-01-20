using System;
using System.Collections.Generic;

namespace Domena
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