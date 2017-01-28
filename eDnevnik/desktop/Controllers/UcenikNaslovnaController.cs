using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domena;

namespace Desktop.Controllers
{
    public class UcenikNaslovnaController
    {
        public void Profil()
        {
            Profil profil = Globals.GetFactory().CreateProfilForm(Globals.GetKorisnik());
            Globals.MakeActive(profil);
        }

        public void Logout()
        {
            HomeController controller = new HomeController();
            Home home = Globals.GetFactory().CreateHomeForm(controller.GetRoles(), controller, true);
            Globals.MakeActive(home);
        }

        public void Izostanci(ICollection<Izostanak> izostanci)
        {
            Izostanci izost = Globals.GetFactory().CreateIzostanci(izostanci);
            Globals.MakeActive(izost);
        }
    }
}
