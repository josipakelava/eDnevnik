namespace Api.Models
{
    using System;
    
    public class imaOcjenu
    {
        public virtual int id { get; set; }
        public virtual DateTime datum { get; set; }
        public virtual int ocjena { get; set; }
        public virtual Kategorija kategorija { get; set; }
        public virtual Predmet predmet { get; set; }
        public virtual Ucenik ucenik{ get; set; }
    }

    public class imaOcjenuMapa : ClassMap<imaOcjenu>
    {
        public imaOcjenuMapa()
        {

            Id(x => x.id);
            Map(x => x.datum);
            Map(x => x.ocjena);
            References(x => x.kategorija).Column("idKategorija");
            References(x => x.predmet).Column("idPredmet");
            References(x => x.ucenik).Column("idUcenik");

            Table("imaOcjenu");
        }
    }
}
