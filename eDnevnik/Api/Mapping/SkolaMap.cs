namespace Api.Mapping
{
    using System;
    using FluentNHibernate.Mapping;
    using Models;


    public class SkolaMap : ClassMap<Skola>
    {
        public SkolaMap()
        {
            Id(x => x.idSkola).GeneratedBy.Increment();
            Map(x => x.naziv);

            Table("Skola");
        }
    }
}
