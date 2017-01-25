using Domena;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BiljeskaRepository : IBiljeskaRepository
    {
        private ISession _session = DatabaseSessionFactory.OpenSession();
        public void InsertNote(int idPredmet, int idUcenik, string biljeska, DateTime datum)
        {
            using (var transaction = _session.BeginTransaction())
            {
                Biljeska novaBiljeska = new Biljeska();

                novaBiljeska.biljeska = biljeska;
                novaBiljeska.predmet = _session.Load<Predmet>(idPredmet);
                novaBiljeska.ucenik = _session.Load<Ucenik>(idUcenik);
                novaBiljeska.datum = datum;

                _session.Save(novaBiljeska);

                transaction.Commit();
            }
        }
    }
}
