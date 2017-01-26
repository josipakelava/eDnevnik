using Domena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IPredmetRepository
    {
        ICollection<Kategorija> GetAllCategories(int id);
        Predmet GetSubject(int id);
        IList<Predmet> GetAllSubject();

        void InsertSubject(string naziv);

        void InsertKategorijaPredmet(int idPredmet, int idKategorija);
    }
}
