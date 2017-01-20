using Domena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUcenikRepository
    {
         Ucenik Find(int id);
         IList<Izostanak> GetAllAbesnces(int id);
         IList<Ocjena> GetAllGrades(int id);
         IList<EvidencijaNastave> GetSchedule(int id);
         IList<Biljeska> GetAllNotes(int id);

    }
}
