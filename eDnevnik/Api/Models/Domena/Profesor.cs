namespace Api.Models
{
    using System;
    using System.Collections.Generic;
    
    public class Profesor : Osoba
    {
        public Profesor()
        {
            this.evidencijaNastave = new List<EvidencijaNastave>();
        }
        public virtual DateTime radiOd { get; set; }
        public virtual Nullable<DateTime> radiDo { get; set; }
        public virtual Skola skola { get; set; }
        public virtual Razred razrednistvo { get; set; }
        public virtual ICollection<EvidencijaNastave> evidencijaNastave { get; set; }
    }

}
