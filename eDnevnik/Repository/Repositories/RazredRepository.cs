using Domena;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RazredRepository : IRazredRepository
    {
        private ISession _session = DatabaseSessionFactory.OpenSession();

        public Razred GetClass(int idRazred)
        {
            return _session.QueryOver<Razred>().Where(r => r.idRazred == idRazred).List()[0];
        }

    }
}
