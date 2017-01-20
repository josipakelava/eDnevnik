namespace Mapiranje
{
    using Domena;
    using FluentNHibernate.Mapping;
    using System;

    public class BiljeskaMap : ClassMap<Biljeska>
    {
        public BiljeskaMap()
        {
            Id(x => x.id).GeneratedBy.Assigned();
            Map(x => x.datum).Not.Nullable();
            Map(x => x.biljeska).Not.Nullable();
            References(x => x.predmet).Column("idPredmet").Not.Nullable();
            References(x => x.ucenik).Column("idUcenik").Not.Nullable();

            Table("Biljeska");
        }
    }
}