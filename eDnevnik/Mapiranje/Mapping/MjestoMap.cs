namespace Mapiranje

{
    using FluentNHibernate.Mapping;
    using Domena;

    public class MjestoMap : ClassMap<Mjesto>
    {
        public MjestoMap()
        {

            Id(x => x.idMjesto).GeneratedBy.Assigned();
            Map(x => x.ime).Not.Nullable();

            Table("Mjesto");
        }
    }
}
