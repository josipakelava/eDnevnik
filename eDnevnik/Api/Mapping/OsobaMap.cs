namespace Api.Mapping
{
    using FluentNHibernate.Mapping;
    using Models;

    public class OsobaMap : ClassMap<Osoba>
    {
        public OsobaMap()
        {

            Id(x => x.idOsoba);
            Map(x => x.ime);
            Map(x => x.prezime);
            Map(x => x.datumRodjenja);
            Map(x => x.adresa);
            Map(x => x.OIB);
            Map(x => x.email);
            Map(x => x.password);
            References(x => x.mjesto).Column("idMjesto");

            Table("Osoba");
        }
    }
}
