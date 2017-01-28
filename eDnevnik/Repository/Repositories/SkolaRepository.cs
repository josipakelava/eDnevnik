using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domena;
using NHibernate;

namespace Repository
{
    public class SkolaRepository : ISkolaRepository
    {
        private ISession _session = DatabaseSessionFactory.OpenSession();
        public IList<Skola> GetAllSchool()
        {
            return _session.QueryOver<Skola>().List();
        }
    }
}
