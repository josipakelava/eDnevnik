namespace Api.Models
{
    public class Kategorija
    {
        public virtual int idKategorija { get; set; }
        public virtual string naziv { get; set; }
    }

    public class KategorijaMapa : ClassMap<Kategorija>
    {
        public KategorijaMapa()
        {

            Id(x => x.idKategorija);
            Map(x => x.naziv);

            Table("Kategorija");
        }
    }
}