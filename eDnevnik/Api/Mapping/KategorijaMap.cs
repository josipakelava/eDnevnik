namespace Api.Mapping
{
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