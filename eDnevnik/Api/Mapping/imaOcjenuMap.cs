namespace Api.Mapping
{
    using FluentNHibernate.Mapping;
    using Models;

    public class imaOcjenuMap : ClassMap<imaOcjenu>
    {
        public imaOcjenuMap()
        {

            Id(x => x.id).GeneratedBy.Increment();
            Map(x => x.datum);
            Map(x => x.ocjena);
            References(x => x.kategorija).Column("idKategorija");
            References(x => x.predmet).Column("idPredmet");

            Table("imaOcjenu");
        }
    }
}
