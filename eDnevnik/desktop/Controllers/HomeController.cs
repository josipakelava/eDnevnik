using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Domena;
using System.Windows.Forms;

namespace Desktop.Controllers
{
    public class HomeController
    {
        private IUlogaRepository _ulogaRepository = new UlogaRepository();
        private IAutorizacijaRepository _autorizacijaRepository = new AutorizacijaRepository();

        public IList<string> GetRoles()
        {
            return _ulogaRepository.GetAll();
        }

        public void Login(string email, string password, string uloga)
        {
            Osoba korisnik = _autorizacijaRepository.GetByLoginInfo(email, password, uloga);

            if (korisnik == null)
            {
                Globals.GetFactory().CreateHomeForm(_ulogaRepository.GetAll(), this, false);
                return;
            }

            switch(uloga)
            {
                case "Ucenik":
                    Profil profil = Globals.GetFactory().CreateProfilForm((Ucenik)korisnik);
                    Globals.MakeActive(profil, korisnik);
                    break;
            }
        }
    }
}
