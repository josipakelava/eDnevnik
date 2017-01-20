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


        Razred GetClass(int id, int idRazred);

        void UpdateIzostanak(int id, bool opravdanost, string razlog);
    }
}
