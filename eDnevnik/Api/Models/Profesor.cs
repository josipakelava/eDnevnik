namespace Api.Models
{
    using System;
    using System.Collections.Generic;
    
    public class Profesor : Osoba
    {
        
        public Profesor()
        {
            this.predaje = new HashSet<Predaje>();
        }
   
        public virtual DateTime radiOd { get; set; }
        public virtual Nullable<DateTime> radiDo { get; set; }
        public virtual Osoba osoba { get; set; }
        public virtual ICollection<Predaje> predaje { get; set; }
        public virtual Skola skola { get; set; }
        public virtual Razred razrednistvo { get; set; }
    }

}
