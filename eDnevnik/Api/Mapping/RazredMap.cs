namespace Api.Mapping
{
    using FluentNHibernate.Mapping;
    using Models;

    public class RazredMap : ClassMap<Razred>
    {
        public RazredMap()
        {
            Id(x => x.idRazred);
            Map(x => x.naziv);
            References(x => x.razrednik).Column("idRazrednik");
            References(x => x.skola).Column("idSkola");
            HasMany(x => x.evidencijaNastave).Cascade.SaveUpdate();
            HasMany(x => x.ucenici).Cascade.SaveUpdate();


            Table("Razred");
        }
    }
}
