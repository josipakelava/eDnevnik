namespace Api.Mapping
{
    using FluentNHibernate.Mapping;
    using Models;

    public class EvidencijaNastaveMap : ClassMap<EvidencijaNastave>
    {
        public EvidencijaNastaveMap()
        {
            CompositeId().KeyReference(x => x.profesor).KeyReference(x => x.razred).KeyReference(x => x.predmet);
            References(x => x.profesor).Column("idProfesor").Not.Nullable(); ;
            References(x => x.razred).Column("idRazred").Not.Nullable(); ;
            References(x => x.predmet).Column("idPredmet").Not.Nullable(); ;

            Table("EvidencijaNastave");
        }
    }
}
