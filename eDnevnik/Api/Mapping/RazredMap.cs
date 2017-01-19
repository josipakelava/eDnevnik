namespace Api.Mapping
{
    using FluentNHibernate.Mapping;
    using Models;

    public class RazredMap : ClassMap<Razred>
    {
        public RazredMap()
        {
            Id(x => x.idRazred).GeneratedBy.Increment();
            Map(x => x.naziv);
            References(x => x.skola).Column("idSkola");
            References(x => x.razrednik).Column("idRazrednik");
            HasMany(x => x.ucenici).Cascade.SaveUpdate().Inverse();
        
            Table("Razred");
        }
    }
}
