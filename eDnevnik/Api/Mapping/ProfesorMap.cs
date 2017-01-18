namespace Api.Mapping
{

    public class ProfesorMap : ClassMap<Profesor>
    {
        public ProfesorMap()
        {
            
            Map(x => x.radiOd);
            Map(x => x.radiDi);
            References(x => x.osoba).Column("idOsoba");
            References(x => x.skola).Column("idSkola");
            HasMany(x => x.predaje).Cascade.SaveUpdate();


            Table("Profesor");
        }
    }
}
