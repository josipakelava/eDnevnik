using Domena;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EvidencijaNastaveRepository : IEvidencijaNastaveRepository
    {
        private ISession _session = DatabaseSessionFactory.OpenSession();

        public IList<EvidencijaNastave> GetAllProfesorSubjects(int idProfesor, int idRazred)
        {
            return _session.QueryOver<EvidencijaNastave>().Where(p => p.profesor.idOsoba == idProfesor).And(p => p.razred.idRazred == idRazred).List();
        }
        public IList<EvidencijaNastave> GetAllClassSubjects(int idRazred)
        {
            return _session.QueryOver<EvidencijaNastave>().Where(p => p.razred.idRazred == idRazred).List();
        }


    }
}
