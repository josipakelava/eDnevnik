namespace Api.Mapping
{
    using System;
    
    public class imaOcjenuMap : ClassMap<imaOcjenu>
    {
        public imaOcjenuMap()
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
