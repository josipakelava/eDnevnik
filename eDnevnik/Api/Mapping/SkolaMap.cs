namespace Api.Mapping
{
    using FluentNHibernate.Mapping;
    using Models;


    public class SkolaMap : ClassMap<Skola>
    {
        public SkolaMap()
        {
            Id(x => x.idSkola).GeneratedBy.Assigned();
            Map(x => x.naziv).Not.Nullable();
            HasMany(x => x.profesori).Cascade.SaveUpdate();
            HasMany(x => x.razredi).Cascade.All();
            References(x => x.administrator).Column("idAdministrator").Not.Nullable();

            Table("Skola");
        }
    }
}