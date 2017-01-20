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
        public Profil CreateProfilForm(Osoba o)
        {
            return new Profil(o);
        }
    }
}
