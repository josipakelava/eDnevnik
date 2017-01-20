using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Controllers
{
    public class NavController
    {
        public void Logout()
        {
            HomeController controller = new HomeController();
            Home home = Globals.GetFactory().CreateHomeForm(controller.GetRoles(), controller, true);
            Globals.MakeActive(home);
        }

        public void Profil()
        {
            Profil profil = Globals.GetFactory().CreateProfilForm(Globals.GetKorisnik());
            Globals.MakeActive(profil);
        }
    }
}
