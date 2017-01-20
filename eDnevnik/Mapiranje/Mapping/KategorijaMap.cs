namespace Mapiranje
{
    using FluentNHibernate.Mapping;
    using Domena;

    public class KategorijaMap : ClassMap<Kategorija>
    {
        public KategorijaMap()
        {

            Id(x => x.idKategorija).GeneratedBy.Increment();
            Map(x => x.naziv).Not.Nullable();

            Table("Kategorija");
        }
    }
}