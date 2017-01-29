using Domena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IIzostanakRepository
    {
        void UpdateIzostanak(int id, bool opravdanost, string razlog);
        void InsertAbsence(int idPredmet, int idUcenik, string razlog, DateTime datum);

       
    }
}
