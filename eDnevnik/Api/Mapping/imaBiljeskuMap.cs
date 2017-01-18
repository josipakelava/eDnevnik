namespace Api.Mapping
{
    using FluentNHibernate.Mapping;
    using Models;
    using System;

    public class imaBiljeskuMap : ClassMap<imaBiljesku>
    {
        public imaBiljeskuMap()
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
