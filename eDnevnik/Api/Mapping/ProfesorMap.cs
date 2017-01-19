namespace Api.Mapping
{
    using FluentNHibernate.Mapping;
    using Models;

    public class ProfesorMap : SubclassMap<Profesor>
    {
        public ProfesorMap()
        {
            Map(x => x.radiOd).Not.Nullable();
            Map(x => x.radiDo);
            References(x => x.razrednistvo).Column("razrednistvo");
            References(x => x.skola).Column("idSkola").Not.Nullable().Cascade.SaveUpdate();
            HasMany(x => x.evidencijaNastave).Cascade.SaveUpdate();

            Table("Profesor");
        }
    }
}
