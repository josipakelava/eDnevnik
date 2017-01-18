namespace Api.Models
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

    public class PredmetMapa : ClassMap<Predmet>
    {
        public PredmetMapa()
        {

            Id(x => x.idPredmet);
            Map(x => x.naziv);
            HasMany(x => x.kategorije).Cascade.SaveUpdate();

            Table("Predmet");
        }
    }
}
