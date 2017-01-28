using Desktop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domena;

namespace Desktop
{
    public class FormFactory : IFormFactory
    {
        public Home CreateHomeForm(IList<string> uloge, HomeController controller, bool uspjeh)
        {
            return new Home(uloge, controller, uspjeh);
        }

        public Izostanci CreateIzostanci(ICollection<Izostanak> i, bool uredivanje = false)
        {
            return new Izostanci(i, uredivanje);
        }

        public ProfesorNaslovna CreateProfesorNaslovna(Profesor p)
        {
            return new ProfesorNaslovna(p);
        }

        public Profil CreateProfilForm(Osoba o)
        {
            return new Profil(o);
        }

        public UcenikNaslovna CreateUcenikNaslovna(Ucenik u)
        {
            return new UcenikNaslovna(u);
        }
    }
}
