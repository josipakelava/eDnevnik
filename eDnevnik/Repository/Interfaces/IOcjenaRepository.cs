using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IOcjenaRepository
    {
        void UpdateGrade(int id, int ocjena);
        void InsertGrade(int ocjena, int idUcenik, int idPredmet, int kategorija, DateTime datum);
    }
}
