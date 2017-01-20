using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Desktop.Controllers;

namespace Desktop
{
    static class Startup
    {
        [STAThread]
        static void Main()
        {
            HomeController homeController = new HomeController();
            IList<string> uloge = homeController.GetRoles();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Home home = new Home(uloge, homeController);
            Globals.MakeActive(home);
            Application.Run(home);
        }
    }
}
