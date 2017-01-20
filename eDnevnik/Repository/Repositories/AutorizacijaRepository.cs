using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domena;
using NHibernate;

namespace Repository
{
    public class AutorizacijaRepository : IAutorizacijaRepository
    {
        private ISession _session = DatabaseSessionFactory.OpenSession();

        public void Add(Osoba o)
        {
            throw new NotImplementedException();
        }

        public Osoba GetByLoginInfo(string email, string password, string uloga)
        {
            using (var transaction = _session.BeginTransaction())
            {
                Osoba korisnik = null;

                try
                {
                    switch (uloga)
                    {
                        case "Ucenik":
                            korisnik = _session.QueryOver<Ucenik>().Where(u => u.email == email && u.password == password).List()[0];
                            break;
                        case "Razrednik":
                            korisnik = _session.QueryOver<Profesor>().Where(u => u.email == email && u.password == password).List()[0];
                            break;
                        case "Profesor":
                            korisnik = _session.QueryOver<Profesor>().Where(u => u.email == email && u.password == password).List()[0];
                            break;
                        case "Administrator":
                            korisnik = _session.QueryOver<Administrator>().Where(u => u.email == email && u.password == password).List()[0];
                            break;
                        default:
                            return null;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    // Nema traženih zapisa
                    return null;
                }

                transaction.Commit();

                return korisnik;
            }
        }

        public void Remove(Osoba o)
        {
            throw new NotImplementedException();
        }
    }
}
