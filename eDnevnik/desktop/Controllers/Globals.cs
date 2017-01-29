using Domena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop
{
    public static class Globals
    {
        private static IFormFactory _formFactory = new FormFactory();
        private static Form _active = null;
        private static Osoba _korisnik = null;
        private static string _uloga = null;

        public static IFormFactory GetFactory()
        {
            return _formFactory;
        }

        public static void MakeActive(Form active, Osoba o = null, string uloga = null)
        {
            if (_active != null)
            {
                _active.Hide();
                _active = active;
                _active.Show();
            } else
            {
                _active = active;
            }

            if (o != null)
            {
                _korisnik = o;
            }

            if (uloga != null)
            {
                _uloga = uloga;
            }
        }

        public static Osoba GetKorisnik()
        {
            return _korisnik;
        }

        public static void Naslovna()
        {
            switch (_uloga)
            {
                case "Ucenik" :
                    MakeActive(_formFactory.CreateUcenikNaslovna((Ucenik) _korisnik));
                    return;
                case "Profesor":
                    MakeActive(_formFactory.CreateProfesorNaslovna((Profesor) _korisnik));
                    return;
            }
        }
    }
}
