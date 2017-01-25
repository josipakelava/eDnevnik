using Domena;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class IzostanakRepository : IIzostanakRepository
    {
        private ISession _session = DatabaseSessionFactory.OpenSession();

        public void UpdateIzostanak(int id, bool opravdanost, string razlog)
        {
            using (var transaction = _session.BeginTransaction())
            {
                Izostanak izostanak = _session.QueryOver<Izostanak>().Where(r => r.id == id).List()[0];
                izostanak.opravdanost = opravdanost;
                izostanak.razlog = razlog;

                _session.Update(izostanak);

                transaction.Commit();
            }

        }


        public void InsertAbsence(int idPredmet, int idUcenik, DateTime datum)
        {
            using (var transaction = _session.BeginTransaction())
            {
                Izostanak novaiIzostanak = new Izostanak();

                novaiIzostanak.predmet = _session.Load<Predmet>(idPredmet);
                novaiIzostanak.ucenik = _session.Load<Ucenik>(idUcenik);
                novaiIzostanak.datum = datum;

                _session.Save(novaiIzostanak);

                transaction.Commit();
            }
        }

    }
}
