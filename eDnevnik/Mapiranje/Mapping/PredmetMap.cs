namespace Mapiranje
{
    using System.Collections.Generic;
    using FluentNHibernate.Mapping;
    using Domena;


    public class PredmetMap : ClassMap<Predmet>
    {
        public PredmetMap()
        {

            Id(x => x.idPredmet).GeneratedBy.Increment();
            Map(x => x.naziv).Not.Nullable();
            HasManyToMany(x => x.kategorije).Not.LazyLoad();

            Table("Predmet");
        }
    }
}