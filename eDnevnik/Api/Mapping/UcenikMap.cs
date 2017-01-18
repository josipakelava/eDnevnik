namespace Api.Mapping
{
    using FluentNHibernate.Mapping;
    using Models;


    public class UcenikMap : ClassMap<Ucenik>
    {
        public UcenikMap()
        {

            References(x => x.osoba).Column("idOsoba");
            References(x => x.razred).Column("idRazred");
            HasMany(x => x.biljeske).Cascade.SaveUpdate();

            HasMany(x => x.izostanci).Cascade.SaveUpdate();

            HasMany(x => x.ocjene).Cascade.SaveUpdate();


            Table("UCenici");
        }
    }
}
