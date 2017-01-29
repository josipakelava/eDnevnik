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
        public IList<Razred> GetAllClasses()
        {
            return _session.QueryOver<Razred>().List();
        }

        public void InsertClass(string naziv, int idRazrednik, int idSkola)
        {
            using (var transaction = _session.BeginTransaction())
            {
                Razred noviRazred = new Razred();

                noviRazred.naziv = naziv;
                noviRazred.skola = _session.Load<Skola>(idSkola);
                noviRazred.razrednik = _session.Load<Profesor>(idRazrednik);

                _session.Save(noviRazred);

                transaction.Commit();
            }
        }

        public void RemoveStudent(int idOsoba)
        {
            using (var transaction = _session.BeginTransaction())
            {
                Ucenik ucenik = _session.QueryOver<Ucenik>().Where(u => u.idOsoba == idOsoba).List()[0];
                ucenik.razred = null;

                _session.Update(ucenik);
                transaction.Commit();
            }
        }
    }
    
}
