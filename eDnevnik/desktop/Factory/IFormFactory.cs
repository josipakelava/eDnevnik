using Desktop.Controllers;
using Domena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop
{
    public interface IFormFactory
    {
        Home CreateHomeForm(IList<string> uloge, HomeController controller, bool uspjeh);
        Profil CreateProfilForm(Osoba o);
        UcenikNaslovna CreateUcenikNaslovna(Ucenik u);
        Izostanci CreateIzostanci(ICollection<Izostanak> i, bool uredivanje = false);
        ProfesorNaslovna CreateProfesorNaslovna(Profesor p);
    }
}
