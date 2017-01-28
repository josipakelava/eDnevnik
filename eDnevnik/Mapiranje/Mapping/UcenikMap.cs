namespace Mapiranje
{
    using FluentNHibernate.Mapping;
    using Domena;

    public class UcenikMap : SubclassMap<Ucenik>
    {
        public UcenikMap()
        {
            References(x => x.razred).Column("idRazred");
            HasMany(x => x.biljeske).Cascade.All().Not.LazyLoad();
            HasMany(x => x.izostanci).Cascade.All().Not.LazyLoad();
            HasMany(x => x.ocjene).Cascade.All().Not.LazyLoad();

            Table("Ucenik");
        }
    }
}
