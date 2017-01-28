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
            _session = DatabaseSessionFactory.OpenSession();
            return _session.QueryOver<Profesor>().Where(u => u.idOsoba == id).List()[0];
        }

        public IList<Profesor> GetAll()
        {
            return _session.QueryOver<Profesor>().List();
        }

        public IList<Izostanak> GetAllAbsencesOfClass(int idRazrednik)
        {
            Profesor profesor = Find(idRazrednik);
            List<Izostanak> izostanci = new List<Izostanak>();
            foreach (var ucenik in profesor.razrednistvo.ucenici)
            {
                izostanci.AddRange(ucenik.izostanci);
            }
            izostanci = izostanci.OrderBy(o => o.datum).ToList();
            return izostanci;
        }
        public void UpdateRazrednistvo(int idProfesor, int idRazred, int idSkola)
        {
            using (var transaction = _session.BeginTransaction())
            {
                Profesor profesor = _session.QueryOver<Profesor>().Where(r => r.idOsoba == idProfesor).List()[0];
                profesor.razrednistvo = _session.Load<Razred>(idRazred);
                if(profesor.skola == null)
                {
                    profesor.skola = _session.Load<Skola>(idSkola);
                }
                _session.Update(profesor);

                transaction.Commit();
            }
        }
    }
}
