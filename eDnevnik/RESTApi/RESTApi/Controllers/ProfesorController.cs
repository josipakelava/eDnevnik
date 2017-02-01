using Newtonsoft.Json;
using Repository;
using RESTApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace RESTApi.Controllers
{
    public class ProfesorController : Controller
    {
        private IUcenikRepository _ucenikRepository = new UcenikRepository();
        private IPredmetRepository _predmetRepository = new PredmetRepository();
        private IProfesorRepository _profesorRepository = new ProfesorRepository();
        private IEvidencijaNastaveRepository _evidencijaRepository = new EvidencijaNastaveRepository();
        private IRazredRepository _razredRepository = new RazredRepository();
        private IBiljeskaRepository _biljeskaRepository = new BiljeskaRepository();
        private IIzostanakRepository _izostanakRepository = new IzostanakRepository();
        private IOcjenaRepository _ocjenaRepository = new OcjenaRepository();

        [Autorizacija]
        [HttpGet]
        public string Profil()
        {
            int id = int.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            return JsonConvert.SerializeObject(new Osoba(_profesorRepository.Find(id)));
        }

        //[Autorizacija]
        //[HttpGet]
        //public string Cmn()
        //{
        //    //int id = int.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
        //    //IList<Ocjena> ocjene = Ocjena.toList(_ucenikRepository.GetAllGradesForSubject(id, int.Parse(Url.RequestContext.RouteData.Values["subjectId"].ToString())));
        //    //IList<Biljeska> biljeske = Biljeska.toList(_ucenikRepository.GetAllNotesForSubject(id, int.Parse(Url.RequestContext.RouteData.Values["subjectId"].ToString())));
        //    //ICollection<Domena.Kategorija> kategorije = _predmetRepository.GetAllCategories(int.Parse(Url.RequestContext.RouteData.Values["subjectId"].ToString()));
        //    //return JsonConvert.SerializeObject(new Cmn(ocjene, biljeske, kategorije));
        //}

        [Autorizacija]
        [HttpGet]
        public string Grades()
        {
            int id = int.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            Domena.Profesor profesor = _profesorRepository.Find(id);
            return JsonConvert.SerializeObject(Razred.toList(profesor.evidencijaNastave));
        }


        [Autorizacija]
        [HttpGet]
        public string MyGrade()
        {
            int id = int.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            Domena.Profesor profesor = _profesorRepository.Find(id);

            return JsonConvert.SerializeObject(Ucenik.toList(profesor.razrednistvo.ucenici));
        }

        [Autorizacija]
        [HttpGet]
        public string Subjects()
        {
            int id = int.Parse(((ClaimsPrincipal)Thread.CurrentPrincipal).Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            return JsonConvert.SerializeObject(Predmet.toList(_evidencijaRepository.GetAllProfesorSubjects(id, int.Parse(Url.RequestContext.RouteData.Values["gradeId"].ToString()))));
        }

        [Autorizacija]
        [HttpGet]
        public string StudentSubjects()
        {
            int idUcenik = int.Parse(Url.RequestContext.RouteData.Values["studentId"].ToString());
            return JsonConvert.SerializeObject(Predmet.toList(_ucenikRepository.GetSchedule(idUcenik)));
        }

        [Autorizacija]
        [HttpGet]
        //[Route("Grades/{gradeId}/Subjects/{subjectId}/Students")]
        public string SubjectAllStudents(int gradeId, int subjectId)
        {
            return JsonConvert.SerializeObject(Ucenik.toList(_razredRepository.GetClass(gradeId).ucenici));
        }

        [Autorizacija]
        [HttpGet]
        //[Route("api/Profesor/Grades/{gradeId}/Subjects/{subjectId}/Students/{studentId}")]
        public string SubjectStudent(int gradeId, int subjectId, int studentId)
        {
            Domena.Ucenik ucenik = _ucenikRepository.Find(studentId);
            IList<Ocjena> ocjene = Ocjena.toList(_ucenikRepository.GetAllGradesForSubject(studentId, subjectId));
            IList<Biljeska> biljeske = Biljeska.toList(_ucenikRepository.GetAllNotesForSubject(studentId, subjectId));
            ICollection<Domena.Kategorija> kategorije = _predmetRepository.GetAllCategories(subjectId);
            return JsonConvert.SerializeObject(new Cmn(ocjene, biljeske, kategorije));
        }

        [Autorizacija]
        [HttpGet]
        //[Route("api/Profesor/MyGrade/{studentId}/Subjects/{subjectId}/Cmn")]
        public string MyGradeStudentSubject(int studentId, int subjectId)
        {
            Domena.Ucenik ucenik = _ucenikRepository.Find(studentId);
            IList<Ocjena> ocjene = Ocjena.toList(_ucenikRepository.GetAllGradesForSubject(studentId, subjectId));
            IList<Biljeska> biljeske = Biljeska.toList(_ucenikRepository.GetAllNotesForSubject(studentId, subjectId));
            ICollection<Domena.Kategorija> kategorije = _predmetRepository.GetAllCategories(subjectId);
            return JsonConvert.SerializeObject(new Cmn(ocjene, biljeske, kategorije));
        }

        [Autorizacija]
        [HttpPost]
        public bool AddNote(String Studentid, String SubjectId, String Date, String Note)
        {
            _biljeskaRepository.InsertNote(Int32.Parse(SubjectId), Int32.Parse(Studentid), Note, Convert.ToDateTime(Date));
            return true;
        }

        [Autorizacija]
        [HttpPost]
        public bool AddAbsence(String Studentid, String SubjectId, String Date, String Reason)
        {
            _izostanakRepository.InsertAbsence(Int32.Parse(SubjectId), Int32.Parse(Studentid), Reason, Convert.ToDateTime(Date));
            return true;
        }

        [Autorizacija]
        [HttpPost]
        public bool AddMark(String Studentid, String SubjectId, String CategoryId, String Mark, String Month)
        {
            _ocjenaRepository.InsertGrade(Int32.Parse(Mark), Int32.Parse(Studentid), Int32.Parse(SubjectId), Int32.Parse(CategoryId), GenerirajDatum(Int32.Parse(Month)));
            return true;
        }

        public DateTime GenerirajDatum(int mjesec)
        {
            int godina = DateTime.Today.Year;
            if (mjesec >= 9 && DateTime.Today.Month >= 1)
            {
                godina = DateTime.Today.Year - 1;
            }
            else if (mjesec >= 9 && DateTime.Today.Month >= 9)
            {
                godina = DateTime.Today.Year;
            }
            else if (mjesec <= 6 && DateTime.Today.Month >= 9)
            {
                godina = DateTime.Today.Year - 1;
            }
            else if (mjesec <= 6 && DateTime.Today.Month >= 1)
            {
                godina = DateTime.Today.Year;
            }

            DateTime datum = new DateTime(godina, mjesec, 15);
            return datum;
        }
    }
}