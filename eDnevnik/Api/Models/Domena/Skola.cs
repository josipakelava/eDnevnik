namespace Api.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Skola
    {  
        public Skola()
        {
            this.razredi = new List<Razred>();
            this.profesori = new List<Profesor>();
        }

        public virtual int idSkola { get; set; }
        public virtual string naziv { get; set; }
        public virtual ICollection<Profesor> profesori { get; set; }
        public virtual ICollection<Razred> razredi { get; set; }

    }
}
