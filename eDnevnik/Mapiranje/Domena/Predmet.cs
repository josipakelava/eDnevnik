namespace Domena
{
    using System.Collections.Generic;
    
    public class Predmet
    {
       
        public Predmet()
        {
            this.kategorije = new HashSet<Kategorija>();
        }
    
        public virtual int idPredmet { get; set; }
        public virtual string naziv { get; set; }        
        public virtual ICollection<Kategorija> kategorije { get; set; }
    }

}
