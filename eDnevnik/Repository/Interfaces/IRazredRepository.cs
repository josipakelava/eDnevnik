using Domena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRazredRepository
    {
        Razred GetClass(int idRazred);
        IList<Razred> GetAllClasses();

        void InsertClass(string naziv, int idRazrednik, int idSkola);
    }
}
