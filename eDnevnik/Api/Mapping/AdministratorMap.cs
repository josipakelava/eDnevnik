namespace Api.Mapping
{
    using FluentNHibernate.Mapping;
    using Models;


    public class AdministratorMap : SubclassMap<Administrator>
    {
        public AdministratorMap()
        {

            HasMany(x => x.skole);

            Table("Administrator");
        }
    }
}
