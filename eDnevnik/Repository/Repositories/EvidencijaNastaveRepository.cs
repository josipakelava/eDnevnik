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

        public void InsertNew(int idRazred, int idPredmet, int idProfesor)
        {
            using (var transaction = _session.BeginTransaction())
            {
                EvidencijaNastave evidencija = new EvidencijaNastave();

                //evidencija.predmet = _session.Load<Predmet>(idPredmet);
                //evidencija.profesor = _session.Load<Profesor>(idProfesor);
                //evidencija.razred = _session.Load<Razred>(idRazred); 

               var query =  _session.CreateSQLQuery(@"insert into EvidencijaNastave (idProfesor, idRazred,  idPredmet) values (" + idProfesor + "," + idRazred + "," + idPredmet + ")");
                query.ExecuteUpdate();
                //_session.Save(evidencija);

                transaction.Commit();
            }
        }
    }
}
