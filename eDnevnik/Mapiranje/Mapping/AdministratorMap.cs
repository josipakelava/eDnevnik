namespace Mapiranje
{
    using FluentNHibernate.Mapping;
    using Domena;

    public class AdministratorMap : SubclassMap<Administrator>
    {
        public AdministratorMap()
        {

            HasMany(x => x.skole);

            Table("Administrator");
        }
    }
}
