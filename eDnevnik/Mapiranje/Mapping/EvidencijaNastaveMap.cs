namespace Mapiranje
{
    using FluentNHibernate.Mapping;
    using Domena;

    public class EvidencijaNastaveMap : ClassMap<EvidencijaNastave>
    {
        public EvidencijaNastaveMap()
        {
            CompositeId().KeyReference(x => x.profesor, "idProfesor").KeyReference(x => x.razred, "idRazred").KeyReference(x => x.predmet, "idPredmet");
            References(x => x.profesor).Column("idProfesor").Not.Nullable().Fetch.Join();
            References(x => x.razred).Column("idRazred").Not.Nullable().Fetch.Join();
            References(x => x.predmet).Column("idPredmet").Not.Nullable().Fetch.Join();


            Table("EvidencijaNastave");
        }
    }
}
