using Domena;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MjestoRepository : IMjestoRepository
    {
        private ISession _session = DatabaseSessionFactory.OpenSession();

        public IList<Mjesto> GetAll()
        {
            return _session.QueryOver<Mjesto>().List();
        }
    }
}
