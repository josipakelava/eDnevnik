using FluentNHibernate.Mapping;
using Domena;

namespace Mapiranje
{
    public class IzostanakMap : ClassMap<Izostanak>
    {
        public IzostanakMap()
        {

            Id(x => x.id).GeneratedBy.Increment();
            Map(x => x.datum).Not.Nullable();
            Map(x => x.razlog);
            Map(x => x.opravdanost);
            References(x => x.predmet).Column("idPredmet").Not.Nullable().Fetch.Join();
            References(x => x.ucenik).Column("idUcenik").Not.Nullable();

            Table("Izostanak");
        }
    }
}
