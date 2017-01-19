namespace Api.Mapping
{
    using FluentNHibernate.Mapping;
    using Models;

    public class KategorijaMap : ClassMap<Kategorija>
    {
        public KategorijaMap()
        {

            Id(x => x.idKategorija).GeneratedBy.Increment();
            Map(x => x.naziv);

            Table("Kategorija");
        }
    }
}