using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domena;

namespace Repository
{
    public interface IAutorizacijaRepository
    {
        void Add(Osoba o);
        void Remove(Osoba o);
        Osoba GetByLoginInfo(string email, string password, string uloga);
    }
}
