namespace Api.Mapping
{
    using FluentNHibernate.Mapping;
    using Models;


    public class ProfesorMap : ClassMap<Profesor>
    {
        public ProfesorMap()
        {
            
            Map(x => x.radiOd);
            Map(x => x.radiDo);
            References(x => x.osoba).Column("idOsoba");
            References(x => x.skola).Column("idSkola");
            HasMany(x => x.predaje).Cascade.SaveUpdate();


            Table("Profesor");
        }
    }
}
