using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBiljeskaRepository
    {
        void InsertNote(int idPredmet, int idUcenik, string biljeska, DateTime datum);
    }
}
