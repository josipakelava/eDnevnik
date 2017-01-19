namespace Api.Mapping
{
    using FluentNHibernate.Mapping;
    using Models;


    public class UcenikMap : ClassMap<Ucenik>
    {
        public UcenikMap()
        {
            Id(x => x.osoba.idOsoba).GeneratedBy.Assigned();
            References(x => x.osoba).Column("idOsoba");
            HasMany(x => x.biljeske).Cascade.SaveUpdate().Inverse();
            HasMany(x => x.izostanci).Cascade.SaveUpdate().Inverse();
            HasMany(x => x.ocjene).Cascade.SaveUpdate().Inverse();


            Table("Ucenici");
        }
    }
}
