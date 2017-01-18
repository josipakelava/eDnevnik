namespace Api.Models
{
    using System;
    
    public class imaBiljesku
    {
        public virtual int id { get; set; }
        public virtual DateTime datum { get; set; }
        public virtual string biljeska { get; set; }
        public virtual Predmet predmet { get; set; }
        public virtual Ucenik ucenik { get; set; }
    }

    public class imaBiljeskuMapa : ClassMap<imaBiljesku>
    {
        public imaBiljeskuMapa()
        {

            Id(x => x.id);
            Map(x => x.datum);
            Map(x => x.biljeska);
            References(x => x.predmet).Column("idPredmet");
            References(x => x.ucenik).Column("idUcenik");

            Table("imaBiljesku");
        }
    }
}
