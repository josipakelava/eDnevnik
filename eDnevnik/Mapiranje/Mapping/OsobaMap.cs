namespace Mapiranje
{
    using FluentNHibernate.Mapping;
    using Domena;

    public class OsobaMap : ClassMap<Osoba>
    {
        public OsobaMap()
        {
            Id(x => x.idOsoba).GeneratedBy.Assigned();
            Map(x => x.ime).Not.Nullable();
            Map(x => x.prezime).Not.Nullable(); ;
            Map(x => x.datumRodjenja).Not.Nullable(); ;
            Map(x => x.adresa).Not.Nullable(); ;
            Map(x => x.OIB).Not.Nullable(); ;
            Map(x => x.email).Not.Nullable(); ;
            Map(x => x.password).Not.Nullable(); ;
            References(x => x.mjesto).Column("idMjesto").Not.Nullable().Fetch.Join() ;

            Table("Osoba");
        }
    }
}
