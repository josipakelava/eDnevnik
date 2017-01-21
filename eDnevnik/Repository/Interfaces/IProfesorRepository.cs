using Domena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IProfesorRepository
    {
        Profesor Find(int id);
        IList<Izostanak> GetAllAbsences(int id);
        IList<EvidencijaNastave> GetAllSubjects(int id, int idRazred);

        Predmet GetSubject(int id);
        Razred GetClass(int id, int idRazred);

        void UpdateIzostanak(int id, bool opravdanost, string razlog);

        void UpdateGrade(int id, int ocjena);
        void InsertGrade(int ocjena, int idUcenik, int idPredmet, int kategorija, DateTime datum);
        void InsertAbsence(int idPredmet, int idUcenik, DateTime datum);

        void InsertNote(int idPredmet, int idUcenik, string biljeska, DateTime datum);
    }
}
