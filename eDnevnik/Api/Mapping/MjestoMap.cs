namespace Api.Mapping
{   
    public class MjestoMap : ClassMap<Mjesto>
    {
        public MjestoMap()
        {

            Id(x => x.idMjesto);
            Map(x => x.ime);

            Table("Mjesto");
        }
    }
}
