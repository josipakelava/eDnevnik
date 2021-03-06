﻿using Domena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUcenikRepository
    {
         Ucenik Find(int id);
         IList<Izostanak> GetAllAbesnces(int id);
         IList<Ocjena> GetAllGrades(int id);
         IList<EvidencijaNastave> GetSchedule(int id);
         IList<Biljeska> GetAllNotes(int id);
         IList<Ocjena> GetAllGradesForSubject(int idOsoba, int idPredmet);
         IList<Biljeska> GetAllNotesForSubject(int idOsoba, int idPredmet);
         IList<Ucenik> GetAllStudentsWithoutClass();
         void NewClass(int idOsoba, int idRazred);
    }
}
