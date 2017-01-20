namespace Domena
{
    using System;
    using System.Collections.Generic;
    
    public class Razred
    {
        public Razred()
        {
            this.ucenici = new List<Ucenik>();
            this.evidencijaNastave = new List<EvidencijaNastave>();
        }
        public virtual int idRazred { get; set; }
        public virtual string naziv { get; set; }
    
        public virtual Profesor razrednik { get; set; }
        public virtual Skola skola { get; set; }
        public virtual ICollection<Ucenik> ucenici { get; set; }
        public virtual ICollection<EvidencijaNastave> evidencijaNastave { get; set; }

    }
 
}
