using Domena;
using NHibernate;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OsobaRepository : IOsobaRepository
    {
        private ISession _session = DatabaseSessionFactory.OpenSession();
        public void AddUcenik(string ime, string prezime, DateTime? datumRodjenja, string adresa, string oib, string email, string password, int idMjesto)
        {
            using (var transaction = _session.BeginTransaction())
            {
                Ucenik ucenik = new Ucenik()
                {
                    ime = ime,
                    prezime = prezime,
                    datumRodjenja = (DateTime) datumRodjenja,
                    adresa = adresa,
                    OIB = oib,
                    email = email,
                    password = password,
                    mjesto = _session.Load<Mjesto>(idMjesto)
                };

                _session.Save(ucenik);

                transaction.Commit();
            }
        }

        public void AddProfesor(string ime, string prezime, DateTime? datumRodjenja, string adresa, string oib, string email, string password, int idMjesto)
        {
            using (var transaction = _session.BeginTransaction())
            {
                Profesor profesor = new Profesor()
                {
                    ime = ime,
                    prezime = prezime,
                    datumRodjenja = (DateTime)datumRodjenja,
                    adresa = adresa,
                    OIB = oib,
                    email = email,
                    password = password,
                    radiOd = DateTime.Now,
                    mjesto = _session.Load<Mjesto>(idMjesto)
                };

                _session.Save(profesor);

                transaction.Commit();
            }
        }

        public Osoba Get(int id)
        {
            return _session.QueryOver<Osoba>().Where(u => u.idOsoba == id).List()[0];
        }

        public IList<Osoba> GetAll()
        {
            return _session.QueryOver<Osoba>().TransformUsing(Transformers.DistinctRootEntity).List();
        }

        public void Update(int idOsoba, string ime, string prezime, DateTime? datumRodjenja, string adresa, string oib, string email, string password, int idMjesto)
        {
            using (var transaction = _session.BeginTransaction())
            {
                Osoba osoba = _session.QueryOver<Osoba>().Where(u => u.idOsoba == idOsoba).List()[0];
                osoba.ime = ime;
                osoba.prezime = prezime;
                osoba.datumRodjenja = (DateTime)datumRodjenja;
                osoba.adresa = adresa;
                osoba.OIB = oib;
                osoba.email = email;
                osoba.password = password;
                osoba.mjesto = _session.Load<Mjesto>(idMjesto);

                _session.Update(osoba);
                transaction.Commit();
            }

        }
    }
}
