namespace Api.Mapping
{
    using FluentNHibernate.Mapping;
    using Models;

    public class PredajeMap : ClassMap<Predaje>
    {
        public PredajeMap()
        {
            CompositeId().KeyProperty(x => x.profesor).KeyReference(x => x.razred).KeyReference(x => x.predmet);
            References(x => x.profesor).Column("idProfesor");
            References(x => x.razred).Column("idRazred");
            References(x => x.predmet).Column("idPredmet");

            Table("Predaje");
        }
    }
}
