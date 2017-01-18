namespace Api.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Skola
    {
        public Skola()
        {
            this.profesori = new HashSet<Profesor>();
            this.razredi = new HashSet<Razred>();
        }
    
        public virtual int idSkola { get; set; }
        public virtual string naziv { get; set; }
    
        public virtual ICollection<Profesor> profesori { get; set; }
       
        public virtual ICollection<Razred> razredi { get; set; }
    }
s
}
