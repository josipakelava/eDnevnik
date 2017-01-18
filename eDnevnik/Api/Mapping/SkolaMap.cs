namespace Api.Mapping
{

    public class SkolaMap : ClassMap<Skola>
    {
        public SkolaMap()
        {
            Id(x => x.idSKola);
            Map(x => x.naziv);
            HasMany(x => x.profesori).Cascade.SaveUpdate();
            HasMany(x => x.razredi).Cascade.SaveUpdate();


            Table("Razred");
        }
    }
}
