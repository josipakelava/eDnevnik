namespace Api.Models
{
    using System;
    using System.Collections.Generic;
    
    public class Razred
    {
        public virtual int idRazred { get; set; }
        public virtual string naziv { get; set; }
    
        public virtual Profesor razrednik { get; set; }
        public virtual Skola skola { get; set; }
        public virtual ICollection<Ucenik> ucenici { get; set; }
    }
 
}
