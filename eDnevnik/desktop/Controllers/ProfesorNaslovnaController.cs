using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domena;
using Repository;

namespace Desktop.Controllers
{
    public class ProfesorNaslovnaController
    {
        private IProfesorRepository _repo = new ProfesorRepository();

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

        public void SpremiOcjenu(int ocjena, int idUcenik, int idPredmet, int kategorija, DateTime date)
        {
            _repo.InsertGrade(ocjena, idUcenik, idPredmet, kategorija, date);
        }

        public Profesor GetProfesor(int idOsoba)
        {
            return _repo.Find(idOsoba);
        }

        public void SpremiBiljesku(int idPredmet, int idUcenik, string biljeska, DateTime date)
        {
            _repo.InsertNote(idPredmet, idUcenik, biljeska, date);
        }

        public void MojRazred(Profesor profesor)
        {
            Izostanci i = Globals.GetFactory().CreateIzostanci(_repo.GetAllAbsences(profesor.idOsoba), true);
            Globals.MakeActive(i);
        }

        public void Nedostaje(int idPredmet, int idOsoba, DateTime date)
        {
            _repo.InsertAbsence(idPredmet, idOsoba, date);
        }
    }
}
