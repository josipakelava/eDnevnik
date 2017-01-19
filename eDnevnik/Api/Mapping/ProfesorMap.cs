namespace Api.Mapping
{
    using FluentNHibernate.Mapping;
    using Models;
    using NHibernate.Mapping.ByCode.Conformist;

    public class ProfesorMap : SubclassMap<Profesor>
    {
        public ProfesorMap()
        {
            Map(x => x.radiOd);
            Map(x => x.radiDo);
            References(x => x.skola).Column("idSkola");

        }
    }
}
