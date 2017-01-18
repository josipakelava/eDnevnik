namespace Api.Mapping
{
    using FluentNHibernate.Mapping;
    using Models;

    public class KategorijaMap : ClassMap<Kategorija>
    {
        public KategorijaMap()
        {

            Id(x => x.idKategorija);
            Map(x => x.naziv);

            Table("Kategorija");
        }
    }
}