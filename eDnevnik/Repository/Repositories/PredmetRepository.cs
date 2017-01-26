using Domena;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PredmetRepository : IPredmetRepository
    {
        private ISession _session = DatabaseSessionFactory.OpenSession();

        public ICollection<Kategorija> GetAllCategories(int id)
        {
            return _session.QueryOver<Predmet>().Where(p => p.idPredmet == id).List()[0].kategorije;
        }
        public Predmet GetSubject(int id)
        {
            return _session.QueryOver<Predmet>().Where(p => p.idPredmet == id).List()[0];
        }

        public IList<Predmet> GetAllSubject()
        {
            return _session.QueryOver<Predmet>().List();
        }

        public void InsertSubject(string naziv)
        {
            using (var transaction = _session.BeginTransaction())
            {
                Predmet predmet = new Predmet();

                predmet.naziv = naziv;
                _session.Save(predmet);

                transaction.Commit();
            }
        }
    }
}
