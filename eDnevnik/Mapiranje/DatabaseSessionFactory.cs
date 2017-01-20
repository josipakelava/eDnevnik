using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using Mapiranje;

namespace Domena
{
    public static class DatabaseSessionFactory
    {
        private static ISessionFactory sessionFactory;

        public static ISession OpenSession()
        {
            if (sessionFactory == null)
            {
                var constr = System.Configuration.ConfigurationManager.ConnectionStrings;

                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["eDnevnik"].ConnectionString;

                sessionFactory = Fluently.Configure().Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(connectionString).ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<OsobaMap>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
                .BuildSessionFactory();
            }

            return sessionFactory.OpenSession();
        }
    }
}