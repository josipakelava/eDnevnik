namespace Api.Mapping
{
    using System.Collections.Generic;
    using FluentNHibernate.Mapping;
    using Models;


    public class PredmetMap : ClassMap<Predmet>
    {
        public PredmetMap()
        {

            Id(x => x.idPredmet).GeneratedBy.Assigned();
            Map(x => x.naziv);
            HasMany(x => x.kategorije).Cascade.SaveUpdate();

            Table("Predmet");
        }
    }
}
