using Domena;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OcjenaRepository : IOcjenaRepository
    {
        private ISession _session = DatabaseSessionFactory.OpenSession();
        public void UpdateGrade(int id, int novaOcjena)
        {
            using (var transaction = _session.BeginTransaction())
            {
                Ocjena ocjena = _session.QueryOver<Ocjena>().Where(r => r.id == id).List()[0];
                if (ocjena.ocjena == novaOcjena)
                    return;
                ocjena.ocjena = novaOcjena;
                _session.Update(ocjena);

                transaction.Commit();
            }
        }

        public void InsertGrade(int ocjena, int idUcenik, int idPredmet, int idKategorija, DateTime datum)
        {
            using (var transaction = _session.BeginTransaction())
            {
                Ocjena novaOcjena = new Ocjena();

                novaOcjena.ocjena = ocjena;
                novaOcjena.kategorija = _session.Load<Kategorija>(idKategorija); ;

                novaOcjena.predmet = _session.Load<Predmet>(idPredmet);
                novaOcjena.ucenik = _session.Load<Ucenik>(idUcenik);
                novaOcjena.datum = datum;

                _session.Save(novaOcjena);

                transaction.Commit();
            }
        }

    }
}
