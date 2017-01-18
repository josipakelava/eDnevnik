namespace Api.Mapping
{
    public class imaIzostanakMap : ClassMap<imaIzostanak>
    {
        public imaIzostanakMap()
        {

            Id(x => x.id);
            Map(x => x.datum);
            Map(x => x.razlog);
            Map(x => x.opravdanost);
            References(x => x.predmet).Column("idPredmet");
            References(x => x.ucenik).Column("idUcenik");

            Table("imaIzostanak");
        }
    }
}
