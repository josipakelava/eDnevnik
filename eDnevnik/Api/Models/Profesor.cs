namespace Api.Models
{
    using System;
    using System.Collections.Generic;
    
    public class Profesor : Osoba
    {
   
        public virtual DateTime radiOd { get; set; }
        public virtual Nullable<DateTime> radiDo { get; set; }
        public virtual Skola skola { get; set; }
    }

}
