namespace Api.Models
{
    public class Predaje
    {
        public virtual Predmet predmet { get; set; }
        public virtual Profesor profesor { get; set; }
        public virtual Razred razred { get; set; }
    }

    public class PredajeMapa : ClassMap<Predaje>
    {
        public PredajeMapa()
        {

            References(x => x.predmet).Column("idProfesor");
            References(x => x.predmet).Column("idRazred");
            References(x => x.predmet).Column("idPredmet");

            Table("Predaje");
        }
    }
}
