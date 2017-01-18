namespace Api.Models
{
    public class Predaje
    {
        public virtual Predmet predmet { get; set; }
        public virtual Profesor profesor { get; set; }
        public virtual Razred razred { get; set; }
    }
}
