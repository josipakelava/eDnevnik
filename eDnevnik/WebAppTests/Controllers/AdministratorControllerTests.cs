using Microsoft.VisualStudio.TestTools.UnitTesting;
using Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Moq;
using Repository;
using Domena;
using Api.Models;

namespace Api.Controllers.Tests
{
    [TestClass()]
    public class AdministratorControllerTests
    {

        [TestMethod()]
        public void RegistracijaKorisnikaTest()
        {
            var osobaRepositoryMock = new Mock<IOsobaRepository>();
            var mjestoRepositoryMock = new Mock<IMjestoRepository>();
            var ulogaRepositoryMock = new Mock<IUlogaRepository>();

            mjestoRepositoryMock.Setup(r => r.GetAll()).Returns(new List<Mjesto>());
            ulogaRepositoryMock.Setup(r => r.GetAllToCreate()).Returns(new List<String>());

            AdministratorController ac = new AdministratorController();
            ac._mjestoRepository = mjestoRepositoryMock.Object;
            ac._ulogaRepository = ulogaRepositoryMock.Object;
            ac._osobaRepository = osobaRepositoryMock.Object;

            DateTime now = DateTime.Now;

            //Model is not valid
            ac.ModelState.AddModelError("key", "error message");

            OsobaViewModel osoba = new OsobaViewModel()
            {
                idOsoba = 5,
                ime = "",
                prezime = "Proba",
                datumRodjenja = now,
                adresa = "Proba",
                OIB = "12345678912",
                email = "proba@fer.hr",
                password = "Proba",
                repeatedPassword = "Proba",
                idMjesto = 10000,
                role = "Profesor"
            };

            ac.RegistrirajKorisnika(osoba);

            osobaRepositoryMock.Verify(r => r.AddProfesor("", "Proba", now, "Proba", "12345678912", "proba@fer.hr", "Proba", 10000), Times.Never());
            osobaRepositoryMock.Verify(r => r.AddUcenik("", "Proba", now, "Proba", "12345678912", "proba@fer.hr", "Proba", 10000), Times.Never());
        }

        [TestMethod()]
        public void RegistracijaProfesoraTest()
        {

            var osobaRepositoryMock = new Mock<IOsobaRepository>();
            var mjestoRepositoryMock = new Mock<IMjestoRepository>();
            var ulogaRepositoryMock = new Mock<IUlogaRepository>();

            mjestoRepositoryMock.Setup(r => r.GetAll()).Returns(new List<Mjesto>());
            ulogaRepositoryMock.Setup(r => r.GetAllToCreate()).Returns(new List<String>());

            AdministratorController ac = new AdministratorController();
            ac._mjestoRepository = mjestoRepositoryMock.Object;
            ac._ulogaRepository = ulogaRepositoryMock.Object;
            ac._osobaRepository = osobaRepositoryMock.Object;

            DateTime now = DateTime.Now;

            OsobaViewModel profesor = new OsobaViewModel()
            {
                idOsoba = 5,
                ime = "Proba",
                prezime = "Proba",
                datumRodjenja = now,
                adresa = "Proba",
                OIB = "12345678912",
                email = "proba@fer.hr",
                password = "Proba",
                repeatedPassword = "Proba",
                idMjesto = 10000,
                role = "Profesor"
            };

            ac.RegistrirajKorisnika(profesor);

            osobaRepositoryMock.Verify(r => r.AddProfesor("Proba", "Proba", now, "Proba", "12345678912", "proba@fer.hr", "Proba", 10000), Times.Once());
            osobaRepositoryMock.Verify(r => r.AddUcenik("Proba", "Proba", now, "Proba", "12345678912", "proba@fer.hr", "Proba", 10000), Times.Never());
        }

        [TestMethod()]
        public void RegistracijaUcenikaTest()
        {

            var osobaRepositoryMock = new Mock<IOsobaRepository>();
            var mjestoRepositoryMock = new Mock<IMjestoRepository>();
            var ulogaRepositoryMock = new Mock<IUlogaRepository>();

            mjestoRepositoryMock.Setup(r => r.GetAll()).Returns(new List<Mjesto>());
            ulogaRepositoryMock.Setup(r => r.GetAllToCreate()).Returns(new List<String>());

            AdministratorController ac = new AdministratorController();
            ac._mjestoRepository = mjestoRepositoryMock.Object;
            ac._ulogaRepository = ulogaRepositoryMock.Object;
            ac._osobaRepository = osobaRepositoryMock.Object;

            DateTime now = DateTime.Now;

            OsobaViewModel ucenik = new OsobaViewModel()
            {
                idOsoba = 5,
                ime = "Proba",
                prezime = "Proba",
                datumRodjenja = now,
                adresa = "Proba",
                OIB = "12345678912",
                email = "proba@fer.hr",
                password = "Proba",
                repeatedPassword = "Proba",
                idMjesto = 10000,
                role = "Ucenik"
            };

            ac.RegistrirajKorisnika(ucenik);

            osobaRepositoryMock.Verify(r => r.AddProfesor("Proba", "Proba", now, "Proba", "12345678912", "proba@fer.hr", "Proba", 10000), Times.Never());
            osobaRepositoryMock.Verify(r => r.AddUcenik("Proba", "Proba", now, "Proba", "12345678912", "proba@fer.hr", "Proba", 10000), Times.Once());
        }

        [TestMethod]
        public void UrediOsobnePodatke()
        {

            var osobaRepositoryMock = new Mock<IOsobaRepository>();
            var mjestoRepositoryMock = new Mock<IMjestoRepository>();

            mjestoRepositoryMock.Setup(r => r.GetAll()).Returns(new List<Mjesto>());
            osobaRepositoryMock.Setup(r => r.GetAll()).Returns(new List<Osoba>());

            AdministratorController ac = new AdministratorController();
            ac._osobaRepository = osobaRepositoryMock.Object;
            ac._mjestoRepository = mjestoRepositoryMock.Object;

            DateTime now = new DateTime();

            OsobaViewModel ucenik = new OsobaViewModel()
            {
                idOsoba = 5,
                ime = "Proba",
                prezime = "Proba",
                datumRodjenja = now,
                adresa = "Proba",
                OIB = "12345678912",
                email = "proba@fer.hr",
                password = "Proba",
                repeatedPassword = "Proba",
                idMjesto = 10000,
                role = "Ucenik"
            };

            ac.UrediOsobne(ucenik);

            osobaRepositoryMock.Verify(r => r.Update(5, "Proba", "Proba", now, "Proba", "12345678912", "proba@fer.hr", "Proba", 10000), Times.Once());
            osobaRepositoryMock.Verify(r => r.Update(10, "Proba", "Proba", now, "Proba", "12345678912", "proba@fer.hr", "Proba", 10000), Times.Never());
        }

        [TestMethod]
        public void UklanjanjeIzRazredaTest()
        {
            var razredRepositoryMock = new Mock<IRazredRepository>();

            AdministratorController ac = new AdministratorController();
            ac._razredRepository = razredRepositoryMock.Object;

            ac.UkloniUcenika(5);

            razredRepositoryMock.Verify(r => r.RemoveStudent(5), Times.Once());
            razredRepositoryMock.Verify(r => r.RemoveStudent(10), Times.Never());
        }

        [TestMethod]
        public void DodavanjeURazredTest()
        {
            var ucenikRepositoryMock = new Mock<IUcenikRepository>();

            AdministratorController ac = new AdministratorController();
            ac._ucenikRepository = ucenikRepositoryMock.Object;

            ac.NoviUcenik(5, 123);

            ucenikRepositoryMock.Verify(r => r.NewClass(5, 123), Times.Once());
            ucenikRepositoryMock.Verify(r => r.NewClass(5, 600), Times.Never());
            ucenikRepositoryMock.Verify(r => r.NewClass(10, 123), Times.Never());
            ucenikRepositoryMock.Verify(r => r.NewClass(10, 600), Times.Never());
        }

        [TestMethod()]
        public void EvidencijaNastaveTest()
        {
            var predmetRepository = new Mock<IPredmetRepository>();
            var razredRepository = new Mock<IRazredRepository>();
            var profesorRepository = new Mock<IProfesorRepository>();

            predmetRepository.Setup(r => r.GetAllSubject()).Returns(new List<Predmet>());
            razredRepository.Setup(r => r.GetAllClasses()).Returns(new List<Razred>());
            profesorRepository.Setup(r => r.GetAll()).Returns(new List<Profesor>());


            AdministratorController pc = new AdministratorController();
            pc._predmetRepository = predmetRepository.Object;
            pc._razredRepository = razredRepository.Object;

            pc._profesorRepository = profesorRepository.Object;

            pc.EvidencijaNastave();

            predmetRepository.Verify(r => r.GetAllSubject(), Times.Exactly(1));
            razredRepository.Verify(r => r.GetAllClasses(), Times.Exactly(1));
            profesorRepository.Verify(r => r.GetAll(), Times.Exactly(1));

        }
        [TestMethod()]
        public void NovaEviNdencijaNastaveTest()
        {
            var evidencijaRepositoryMock = new Mock<IEvidencijaNastaveRepository>();

            AdministratorController pc = new AdministratorController();
            pc._evidencijaRepository = evidencijaRepositoryMock.Object;

            pc.NovaEvidencija(new EvidencijaViewModel()
            {
                idPredmet = 5,
                idRazred = 5,
                idProfesor = 5
            });

            evidencijaRepositoryMock.Verify(r => r.InsertNew(5, 5, 5), Times.Exactly(1));
            evidencijaRepositoryMock.Verify(r => r.InsertNew(10, 2, 3), Times.Never());

        }
        [TestMethod()]
        public void DodajRazredTest()
        {
            var skolaRepostiroyMock = new Mock<ISkolaRepository>();
            var profesorRepositoryMock = new Mock<IProfesorRepository>();

            var razredMock = new Mock<Razred>();
            List<Profesor> osoba = new List<Profesor>();

            skolaRepostiroyMock.Setup(r => r.GetAllSchool()).Returns(new List<Skola>());
            profesorRepositoryMock.Setup(r => r.GetAll()).Returns(osoba);


            AdministratorController pc = new AdministratorController();
            pc._skolaRepostiroy = skolaRepostiroyMock.Object;
            pc._profesorRepository = profesorRepositoryMock.Object;
            pc.DodajRazred();

            skolaRepostiroyMock.Verify(r => r.GetAllSchool(), Times.Exactly(2));

            profesorRepositoryMock.Verify(r => r.GetAll(), Times.Exactly(1));

        }

        [TestMethod()]
        public void NoviRazredTest()
        {
            var razredRepostiroyMock = new Mock<IRazredRepository>();
            var profesorRepositoryMock = new Mock<IProfesorRepository>();

            NoviRazredViewModel razred = new NoviRazredViewModel()
            {
                naziv = "razred",
                idRazrednik = 0,
                idSkola = 0
            };
            var razredMock = new Mock<Razred>();
            razredMock.Setup(p => p.idRazred).Returns(0);

            razredMock.Setup(p => p.razrednik.idOsoba).Returns(0);

            List<Razred> lista = new List<Razred>();
            lista.Add(razredMock.Object);

            razredRepostiroyMock.Setup(r => r.GetAllClasses()).Returns(lista);
            AdministratorController pc = new AdministratorController();
            pc._razredRepository = razredRepostiroyMock.Object;
            pc._profesorRepository = profesorRepositoryMock.Object;
            pc.NoviRazred(razred);

            razredRepostiroyMock.Verify(r => r.GetAllClasses(), Times.Exactly(1));
            razredRepostiroyMock.Verify(r => r.InsertClass("razred", 0,0 ),Times.Exactly(1));
            razredRepostiroyMock.Verify(r => r.InsertClass("razred", 5, 5), Times.Never());

            profesorRepositoryMock.Verify(r => r.UpdateRazrednistvo(0, 0, 0), Times.Exactly(1));
            profesorRepositoryMock.Verify(r => r.UpdateRazrednistvo(5, 5, 5), Times.Never());

        }
    }
}