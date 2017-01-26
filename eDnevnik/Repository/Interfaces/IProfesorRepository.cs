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
        IList<Izostanak> GetAllAbsencesOfClass(int idRazrednik);

        IList<Profesor> GetAll();
        void UpdateRazrednistvo(int idProfesor, int idRazred, int idSkola);


    }
}
