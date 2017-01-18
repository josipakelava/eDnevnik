namespace Api.Mapping
{
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
