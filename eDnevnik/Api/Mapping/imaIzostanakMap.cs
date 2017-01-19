using Api.Models;
using FluentNHibernate.Mapping;

namespace Api.Mapping
{
    public class imaIzostanakMap : ClassMap<imaIzostanak>
    {
        public imaIzostanakMap()
        {

            Id(x => x.id).GeneratedBy.Increment();
            Map(x => x.datum);
            Map(x => x.razlog);
            Map(x => x.opravdanost);
            References(x => x.predmet).Column("idPredmet");

            Table("imaIzostanak");
        }
    }
}
