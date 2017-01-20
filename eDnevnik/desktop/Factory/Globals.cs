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

        public static IFormFactory GetFactory()
        {
            return _formFactory;
        }

        public static void MakeActive(Form active, Osoba o = null)
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
        }

        public static Osoba GetKorisnik()
        {
            return _korisnik;
        }
    }
}
