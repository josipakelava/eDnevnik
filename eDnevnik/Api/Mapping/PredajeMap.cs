namespace Api.Mapping
{
    using FluentNHibernate.Mapping;
    using Models;

    public class PredajeMap : ClassMap<Predaje>
    {
        public PredajeMap()
        {

            References(x => x.predmet).Column("idProfesor");
            References(x => x.predmet).Column("idRazred");
            References(x => x.predmet).Column("idPredmet");

            Table("Predaje");
        }
    }
}
