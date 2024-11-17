using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using LoginApp.Persistence.Mappings;
using NHibernate;

namespace LoginApp.Persistence
{
    public static class NHibernateHelper
    {
        private static ISessionFactory? _sessionFactory;

        public static ISessionFactory SessionFactory(IConfiguration configuration)
        {
            if (_sessionFactory == null)
            {
                _sessionFactory = Fluently.Configure()
                    .Database(PostgreSQLConfiguration.Standard
                        .ConnectionString(configuration.GetConnectionString("DefaultConnection"))
                        .ShowSql())
                    .Mappings(m =>
                        m.FluentMappings.AddFromAssemblyOf<UserMap>())
                    .BuildSessionFactory();
            }
            return _sessionFactory;
        }

        public static NHibernate.ISession OpenSession(IConfiguration configuration)
        {
            return SessionFactory(configuration).OpenSession();
        }
    }
}
