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
    public class ProfesorControllerTests
    {

        [TestMethod()]
        public void IndexTest()
        {
            var profesorRepositoryMock = new Mock<IProfesorRepository>();
            var profesorMock = new Mock<Profesor>();

            profesorMock.Setup(p => p.evidencijaNastave).Returns(new List<EvidencijaNastave>());
            profesorRepositoryMock.Setup(r => r.Find(5)).Returns(profesorMock.Object);
            ProfesorController pc = new ProfesorController(() => 5);
            pc._profesorRepository = profesorRepositoryMock.Object;

            pc.Index();

            profesorRepositoryMock.Verify(r => r.Find(5), Times.AtLeastOnce());
            profesorMock.Verify(p => p.evidencijaNastave, Times.AtLeastOnce());
            profesorMock.Verify(p => p.razrednistvo, Times.AtLeastOnce());
        }

        [TestMethod()]
        public void PredmetiTest()
        {
            var profesorRepositoryMock = new Mock<IEvidencijaNastaveRepository>();
            profesorRepositoryMock.Setup(r => r.GetAllProfesorSubjects(5, 5)).Returns<EvidencijaNastave>(null);
            ProfesorController pc = new ProfesorController(() => 5);
            pc._evidencijaNastaveRepository = profesorRepositoryMock.Object;

            pc.Predmeti(5);

            profesorRepositoryMock.Verify(r => r.GetAllProfesorSubjects(5, 5), Times.Exactly(1));
            profesorRepositoryMock.Verify(r => r.GetAllProfesorSubjects(5, 10), Times.Never());
        }

        [TestMethod()]
        public void PopisTest()
        {
            var profesorRepositoryMock = new Mock<IPredmetRepository>();
            var profesorRepositoryMock2 = new Mock<IRazredRepository>();
            var razredMock = new Mock<Razred>();

            profesorRepositoryMock.Setup(r => r.GetSubject(5)).Returns<Predmet>(null);

            razredMock.Setup(p => p.ucenici).Returns(new List<Ucenik>());
            profesorRepositoryMock2.Setup(r => r.GetClass(5)).Returns(razredMock.Object);
            ProfesorController pc = new ProfesorController(() => 5);
            pc._predmetRepository = profesorRepositoryMock.Object;
            pc._razredRepository = profesorRepositoryMock2.Object;


            pc.Popis(5, 5);

            profesorRepositoryMock.Verify(r => r.GetSubject(5), Times.Exactly(1));
            profesorRepositoryMock.Verify(r => r.GetSubject(10), Times.Never());

            profesorRepositoryMock2.Verify(r => r.GetClass(5), Times.Exactly(1));
            profesorRepositoryMock2.Verify(r => r.GetClass(10), Times.Never());

            razredMock.Verify(p => p.ucenici, Times.AtLeastOnce());
        }

        [TestMethod()]
        public void ProfilTest()
        {
            var profesorRepositoryMock = new Mock<IProfesorRepository>();
            profesorRepositoryMock.Setup(r => r.Find(5)).Returns<Profesor>(null);
            ProfesorController pc = new ProfesorController(() => 5);
            pc._profesorRepository = profesorRepositoryMock.Object;

            pc.Profil();

            profesorRepositoryMock.Verify(r => r.Find(5), Times.Exactly(1));
            profesorRepositoryMock.Verify(r => r.Find(10), Times.Never());
        }

        [TestMethod()]
        public void IzostanciTest()
        {
            var profesorRepositoryMock = new Mock<IProfesorRepository>();
            var listaMock = new List<Izostanak>();

            profesorRepositoryMock.Setup(r => r.GetAllAbsencesOfClass(5)).Returns(listaMock);
            ProfesorController pc = new ProfesorController(() => 5);
            pc._profesorRepository = profesorRepositoryMock.Object;

            pc.Izostanci();

            profesorRepositoryMock.Verify(r => r.GetAllAbsencesOfClass(5), Times.Exactly(1));
            profesorRepositoryMock.Verify(r => r.GetAllAbsencesOfClass(10), Times.Never());
        }

        [TestMethod()]
        public void MojRazredTest()
        {
            var profesorRepositoryMock = new Mock<IProfesorRepository>();
            var razredRepositoryMock = new Mock<IRazredRepository>();
            var evidencijaRepositoryMock = new Mock<IEvidencijaNastaveRepository>();

            var razredMock = new Mock<Razred>();
            var profesorMock = new Mock<Profesor>();

            profesorMock.Setup(p => p.razrednistvo.idRazred).Returns(0);
            profesorRepositoryMock.Setup(r => r.Find(5)).Returns(profesorMock.Object);

            razredMock.Setup(p => p.idRazred).Returns(0);
            razredMock.Setup(p => p.ucenici).Returns(new List<Ucenik>());

            razredRepositoryMock.Setup(r => r.GetClass(0)).Returns(razredMock.Object);
            evidencijaRepositoryMock.Setup(r => r.GetAllClassSubjects(5)).Returns<IList<EvidencijaNastave>>(null);

            ProfesorController pc = new ProfesorController(() => 5);
            pc._profesorRepository = profesorRepositoryMock.Object;
            pc._razredRepository = razredRepositoryMock.Object;
            pc._evidencijaNastaveRepository = evidencijaRepositoryMock.Object;


            pc.MojRazred();

            profesorRepositoryMock.Verify(r => r.Find(5), Times.Exactly(1));
            profesorRepositoryMock.Verify(r => r.Find(10), Times.Never());

            razredRepositoryMock.Verify(r => r.GetClass(0), Times.Exactly(1));
            razredRepositoryMock.Verify(r => r.GetClass(10), Times.Never());

            evidencijaRepositoryMock.Verify(r => r.GetAllClassSubjects(0), Times.Exactly(1));
            evidencijaRepositoryMock.Verify(r => r.GetAllClassSubjects(10), Times.Never());


            razredMock.Verify(p => p.ucenici, Times.AtLeastOnce());
        }

        [TestMethod()]
        public void SpremiIzostankeTest()
        {
            var izostanakRepositoryMock = new Mock<IIzostanakRepository>();
            ProfesorController pc = new ProfesorController(() => 5);
            pc._izostanakRepository = izostanakRepositoryMock.Object;
            List<IzostanakViewModel> izostanakLista = new List<IzostanakViewModel>();

            izostanakLista.Add(new IzostanakViewModel()
            {
                id = 5,
                opravdanost = false,
                razlog = "test"

            });
            pc.SpremiIzostanke(izostanakLista);

            izostanakRepositoryMock.Verify(r => r.UpdateIzostanak(5, false, "test"), Times.Exactly(1));
            izostanakRepositoryMock.Verify(r => r.UpdateIzostanak(10, false, "test"), Times.Never());

        }

        [TestMethod()]
        public void SpremiRazredTest()
        {
            var biljeskaRepositoryMock = new Mock<IBiljeskaRepository>();
            var ocjenaRepositoryMock = new Mock<IOcjenaRepository>();
            var izostanakRepositoryMock = new Mock<IIzostanakRepository>();

            List<OcjenaViewModel> ocjene = new List<OcjenaViewModel>();
            ocjene.Add(new OcjenaViewModel()
            {
                id = 2,
                ocjena = 3
            });
            ocjene.Add(new OcjenaViewModel()
            {
                id = -1,
                ocjena = 5,
                mjesecUredivanje = 1
            });
            List<KategorijaView> kategorije = new List<KategorijaView>();
            kategorije.Add(new KategorijaView()
            {
                id = 0,
                ocjene = ocjene
            });

            List<RazredViewModel> razred = new List<RazredViewModel>();
            razred.Add(new RazredViewModel()
            {
                idPredmet = 0,
                idUcenik = 0,
                izostanak = true,
                novabiljeska = "biljeskaTest",
                kategorije = kategorije

            });
            ProfesorController pc = new ProfesorController(() => 5);
            pc._biljeskaRepository = biljeskaRepositoryMock.Object;
            pc._ocjenaRepository = ocjenaRepositoryMock.Object;
            pc._izostanakRepository = izostanakRepositoryMock.Object;

            pc.SpremiRazred(razred);

            biljeskaRepositoryMock.Verify(r => r.InsertNote(0, 0, "biljeskaTest", DateTime.Today), Times.Exactly(1));
            biljeskaRepositoryMock.Verify(r => r.InsertNote(10, 5, "biljeskaTest", DateTime.Today), Times.Never());

            ocjenaRepositoryMock.Verify(r => r.UpdateGrade(2, 3), Times.Exactly(1));
            ocjenaRepositoryMock.Verify(r => r.UpdateGrade(10, 8), Times.Never());

            ocjenaRepositoryMock.Verify(r => r.InsertGrade(5, 0, 0, 0, Convert.ToDateTime("15.1.2017")), Times.Exactly(1));
            ocjenaRepositoryMock.Verify(r => r.InsertGrade(3, 4, 5, 2, Convert.ToDateTime("15.1.2017")), Times.Never());

            izostanakRepositoryMock.Verify(r => r.InsertAbsence(0, 0, DateTime.Today), Times.Exactly(1));
            izostanakRepositoryMock.Verify(r => r.InsertAbsence(10, 4, DateTime.Today), Times.Never());
        }

    }
}