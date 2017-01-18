namespace Api.Mapping
{
    using System.Collections.Generic;
    

    public class PredmetMap : ClassMap<Predmet>
    {
        public PredmetMap()
        {

            Id(x => x.idPredmet);
            Map(x => x.naziv);
            HasMany(x => x.kategorije).Cascade.SaveUpdate();

            Table("Predmet");
        }
    }
}
