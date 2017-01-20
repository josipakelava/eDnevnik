using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domena;
using NHibernate;

namespace Repository
{
    public class ProfesorRepository : IProfesorRepository
    {
        private ISession _session = DatabaseSessionFactory.OpenSession();

        public Profesor Find(int id)
        {
            return _session.QueryOver<Profesor>().Where(u => u.idOsoba == id).List()[0];
        }

        public IList<Izostanak> GetAllAbsences(int id)
        {
            Profesor profesor = Find(id);
            List<Izostanak> izostanci = new List<Izostanak>();
            foreach (var ucenik in profesor.razrednistvo.ucenici)
            {
                izostanci.AddRange(ucenik.izostanci);
            }
            izostanci = izostanci.OrderBy(o => o.datum).ToList();
            return izostanci;
        }

        public IList<EvidencijaNastave> GetAllSubjects(int id, int idRazred)
        {
            return _session.QueryOver<EvidencijaNastave>().Where(p => p.profesor.idOsoba == id).And(p => p.razred.idRazred == idRazred).List();
        }

        public Razred GetClass(int id, int idRazred)
        {
            return _session.QueryOver<Razred>().Where(r => r.idRazred == idRazred).List()[0];
        }

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
    }
}
