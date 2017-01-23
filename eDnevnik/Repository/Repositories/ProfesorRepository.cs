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
        public IList<EvidencijaNastave> GetAllClassSubjects(int idRazred)
        {
            return _session.QueryOver<EvidencijaNastave>().Where(p => p.razred.idRazred == idRazred).List();
        }
        public Predmet GetSubject(int id)
        {
            return _session.QueryOver<Predmet>().Where(p => p.idPredmet == id).List()[0];
        }

        public Razred GetClass(int idRazred)
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

        public void InsertNote(int idPredmet, int idUcenik, string biljeska, DateTime datum)
        {
            using (var transaction = _session.BeginTransaction())
            {
                Biljeska novaBiljeska = new Biljeska();

                novaBiljeska.biljeska = biljeska;
                novaBiljeska.predmet = _session.Load<Predmet>(idPredmet);
                novaBiljeska.ucenik= _session.Load<Ucenik>(idUcenik);
                novaBiljeska.datum = datum;

                _session.Save(novaBiljeska);

                transaction.Commit();
            }
        }
    }
}
