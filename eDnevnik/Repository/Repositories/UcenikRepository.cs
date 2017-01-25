using Domena;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UcenikRepository : IUcenikRepository
    {
        private ISession _session = DatabaseSessionFactory.OpenSession();

        public Ucenik Find(int id)
        {
            return _session.QueryOver<Ucenik>().Where(u => u.idOsoba == id).List()[0];
        }

        public IList<Izostanak> GetAllAbesnces(int id)
        {
            return _session.QueryOver<Izostanak>().Where(u => u.ucenik.idOsoba == id).List();
        }

        public IList<Ocjena> GetAllGrades(int id)
        {
            return _session.QueryOver<Ocjena>().Where(u => u.ucenik.idOsoba == id).List();
        }

        public IList<Biljeska> GetAllNotes(int id)
        {
            return _session.QueryOver<Biljeska>().Where(u => u.ucenik.idOsoba == id).List();
        }

        public IList<EvidencijaNastave> GetSchedule(int id)
        {
            Ucenik ucenik = Find(id);
            return _session.QueryOver<EvidencijaNastave>().Where(u => u.razred == ucenik.razred).List();
        }

        public IList<Ocjena> GetAllGradesForSubject(int idOsoba, int idPredmet)
        {
            return _session.QueryOver<Ocjena>().Where(u => u.ucenik.idOsoba == idOsoba && u.predmet.idPredmet == idPredmet).List();
        }
    }
}
