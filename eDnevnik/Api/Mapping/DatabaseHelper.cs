using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool;
using NHibernate.Tool.hbm2ddl;

namespace Api.Mapping

{
    public static class DatabaseHelper
    {

        public static ISession OpenSession()

        {

            //string connectionString = "metadata = res://*/Model.csdl|res://*/Model.ssdl|res://*/Model.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=ednevnik.database.windows.net;initial catalog=eDnevnik;persist security info=True;user id=toor;password=eDnevnik2017;MultipleActiveResultSets=True;App=EntityFramework&quot;";

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["eDnevnik"].ConnectionString;

            ISessionFactory sessionFactory = Fluently.Configure().Database(MsSqlConfiguration.MsSql2012
            .ConnectionString(connectionString).ShowSql())

            .Mappings(m => m.FluentMappings.Add<SkolaMap>())
            .Mappings(m => m.FluentMappings.Add<OsobaMap>())
            .Mappings(m => m.FluentMappings.Add<MjestoMap>())
            .Mappings(m => m.FluentMappings.Add<KategorijaMap>())
            .Mappings(m => m.FluentMappings.Add<PredmetMap>())




                .Mappings(m => m.FluentMappings.Add<ProfesorMap>())


            //    .Mappings(m => m.FluentMappings.Add<imaBiljeskuMap>())
            //   .Mappings(m => m.FluentMappings.Add<imaIzostanakMap>())
            //   .Mappings(m => m.FluentMappings.Add<imaOcjenuMap>())
            //   .Mappings(m => m.FluentMappings.Add<UcenikMap>())
            //    .Mappings(m => m.FluentMappings.Add<RazredMap>())
            //.Mappings(m => m.FluentMappings.Add<PredajeMap>())
            .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
            .BuildSessionFactory();

            return sessionFactory.OpenSession();

        }

    }
}