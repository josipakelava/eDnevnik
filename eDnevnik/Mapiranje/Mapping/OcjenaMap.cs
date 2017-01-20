namespace Mapiranje
{
    using FluentNHibernate.Mapping;
    using Domena;

    public class OcjenaMap : ClassMap<Ocjena>
    {
        public OcjenaMap()
        {

            Id(x => x.id).GeneratedBy.Increment();
            Map(x => x.datum).Not.Nullable();
            Map(x => x.ocjena).Not.Nullable();
            References(x => x.kategorija).Column("idKategorija").Not.Nullable();
            References(x => x.predmet).Column("idPredmet").Not.Nullable();
            References(x => x.ucenik).Column("idUcenik").Not.Nullable();

            Table("Ocjena");
        }
    }
}