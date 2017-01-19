using Api.Models;
using FluentNHibernate.Mapping;

namespace Api.Mapping
{
    public class IzostanakMap : ClassMap<Izostanak>
    {
        public IzostanakMap()
        {

            Id(x => x.id).GeneratedBy.Increment();
            Map(x => x.datum).Not.Nullable();
            Map(x => x.razlog);
            Map(x => x.opravdanost);
            References(x => x.predmet).Column("idPredmet").Not.Nullable();
            References(x => x.ucenik).Column("idUcenik").Not.Nullable();

            Table("Izostanak");
        }
    }
}
