namespace Domena
{
    public class Izostanak
    {
        public virtual int id { get; set; }
        public virtual System.DateTime datum { get; set; }
        public virtual string razlog { get; set; }
        public virtual bool opravdanost { get; set; }
        public virtual Predmet predmet { get; set; }
        public virtual Ucenik ucenik { get; set; }

        public virtual string datumString
        {
            get
            {
                return datum.ToShortDateString();
            }
        }

        public virtual string opravdanostString
        {
            get
            {
                return opravdanost?"Opravdano":"Neopravdano";
            }
        }

    }
}
