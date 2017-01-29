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
    public class UcenikControllerTest
    {

        [TestMethod()]
        public void IndexTest()
        {
            var ucenikRepositoryMock = new Mock<IUcenikRepository>();
            var ucenikMock = new Mock<Ucenik>();

            ucenikRepositoryMock.Setup(r => r.Find(5)).Returns(ucenikMock.Object);
            UcenikController uc = new UcenikController(() => 5);
            uc._repository = ucenikRepositoryMock.Object;

            uc.Index();

            ucenikRepositoryMock.Verify(r => r.Find(5), Times.Once());
            ucenikRepositoryMock.Verify(r => r.Find(10), Times.Never());
        }

        [TestMethod()]
        public void IzostanciTest()
        {
            var ucenikRepositoryMock = new Mock<IUcenikRepository>();
            var listaMock = new List<Izostanak>();

            ucenikRepositoryMock.Setup(r => r.GetAllAbesnces(5)).Returns(listaMock);
            UcenikController uc = new UcenikController(() => 5);
            uc._repository = ucenikRepositoryMock.Object;

            uc.Izostanci();

            ucenikRepositoryMock.Verify(r => r.GetAllAbesnces(5), Times.Once());
            ucenikRepositoryMock.Verify(r => r.GetAllAbesnces(10), Times.Never());
        }

        [TestMethod()]
        public void PredmetiTest()
        {
            var ucenikRepositoryMock = new Mock<IUcenikRepository>();
            var ucenikMock = new Mock<Ucenik>();
            var scheduleMock = new List<EvidencijaNastave>();
            var gradesMock = new List<Ocjena>();
            var notesMock = new List<Biljeska>();

            ucenikRepositoryMock.Setup(r => r.GetSchedule(5)).Returns(scheduleMock);
            ucenikRepositoryMock.Setup(r => r.GetAllGrades(5)).Returns(gradesMock);
            ucenikRepositoryMock.Setup(r => r.GetAllNotes(5)).Returns(notesMock);

            UcenikController uc = new UcenikController(() => 5);
            uc._repository = ucenikRepositoryMock.Object;

            uc.Predmeti();

            ucenikRepositoryMock.Verify(r => r.GetSchedule(5), Times.Once());
            ucenikRepositoryMock.Verify(r => r.GetSchedule(10), Times.Never());

            ucenikRepositoryMock.Verify(r => r.GetAllGrades(5), Times.Once());
            ucenikRepositoryMock.Verify(r => r.GetAllGrades(10), Times.Never());

            ucenikRepositoryMock.Verify(r => r.GetAllNotes(5), Times.Once());
            ucenikRepositoryMock.Verify(r => r.GetAllNotes(10), Times.Never());
        }
 
    }
}