namespace Api.Mapping
{
    using FluentNHibernate.Mapping;
    using Models;

    public class RazredMap : ClassMap<Razred>
    {
        public RazredMap()
        {
            Id(x => x.idRazred).GeneratedBy.Assigned();
            Map(x => x.naziv).Not.Nullable();
            References(x => x.razrednik).Column("idRazrednik").Not.Nullable();
            References(x => x.skola).Column("idSkola").Not.Nullable();
            HasMany(x => x.evidencijaNastave).Cascade.All();
            HasMany(x => x.ucenici).Cascade.SaveUpdate();

            Table("Razred");
        }
    }
}