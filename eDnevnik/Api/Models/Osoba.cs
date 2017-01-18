namespace Api.Models
{
    using System;

    public class Osoba
    {
        public virtual int idOsoba { get; set; }
        public virtual string ime { get; set; }
        public virtual string prezime { get; set; }
        public virtual DateTime datumRodjenja { get; set; }
        public virtual string adresa { get; set; }
        public virtual string OIB { get; set; }
        public virtual string email { get; set; }
        public virtual string password { get; set; }
        public virtual Mjesto mjesto { get; set; }
    }

    public class OsobaMapa : ClassMap<Osoba>
    {
        public OsobaMapa()
        {

            Id(x => x.idOsoba);
            Map(x => x.ime);
            Map(x => x.prezime);
            Map(x => x.datumRodjenja);
            Map(x => x.adresa);
            Map(x => x.OIB);
            Map(x => x.email);
            Map(x => x.passwod);
            References(x => x.mjesto).Column("idMjesto");

            Table("Osoba");
        }
    }
}
