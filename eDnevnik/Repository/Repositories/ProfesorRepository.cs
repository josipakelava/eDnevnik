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
    }
}
