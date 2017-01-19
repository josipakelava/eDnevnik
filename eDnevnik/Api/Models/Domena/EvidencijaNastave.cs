namespace Api.Models
{
    public class EvidencijaNastave
    {
        public virtual Predmet predmet { get; set; }
        public virtual Profesor profesor { get; set; }
        public virtual Razred razred { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is EvidencijaNastave)
            {
                var toCompare = obj as EvidencijaNastave;
                return this.predmet.idPredmet == toCompare.predmet.idPredmet && this.profesor.idOsoba == toCompare.profesor.idOsoba && this.razred.idRazred == toCompare.razred.idRazred;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.predmet.GetHashCode() + this.profesor.GetHashCode() + this.razred.GetHashCode();
        }
    }

}
