using Domena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IOsobaRepository
    {
        IList<Osoba> GetAll();
        Osoba Get(int id);
        void AddUcenik(string ime, string prezime, DateTime? datumRodjenja, String adresa, string oib, string email, string password, int idMjesto);
        void AddProfesor(string ime, string prezime, DateTime? datumRodjenja, String adresa, string oib, string email, string password, int idMjesto);
    }
}
