namespace Api.Mapping
{
    using FluentNHibernate.Mapping;
    using Models;


    public class SkolaMap : ClassMap<Skola>
    {
        public SkolaMap()
        {
            Id(x => x.idSkola);
            Map(x => x.naziv);
            HasMany(x => x.profesori).Cascade.SaveUpdate();
            HasMany(x => x.razredi).Cascade.SaveUpdate();


            Table("Razred");
        }
    }
}
