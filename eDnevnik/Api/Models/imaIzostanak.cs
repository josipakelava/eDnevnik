namespace Api.Models
{
    public class imaIzostanak
    {
        public virtual int id { get; set; }
        public virtual System.DateTime datum { get; set; }
        public virtual string razlog { get; set; }
        public virtual bool opravdanost { get; set; }
        public virtual Predmet predmet { get; set; }
        public virtual Ucenik ucenik { get; set; }
    }
}
