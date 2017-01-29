using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
namespace RESTApi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "UcenikPredmet",
                url: "api/Ucenik/Subject/{subjectId}/Cmn",
                defaults: new { controller = "Ucenik", action = "Cmn", subjectId = UrlParameter.Optional },
                namespaces: new[] { "RESTApi.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "api/{controller}/{action}/{id}",
                defaults: new { controller = "", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "RESTApi.Controllers" }
            );

            routes.MapRoute(
                name: "RazredPredmeti",
                url: "api/Profesor/Grades/{gradeId}/Subjects",
                defaults: new { controller = "Profesor", action = "Subjects", gradeId = UrlParameter.Optional },
                namespaces: new[] { "RESTApi.Controllers" }
            );

            routes.MapRoute(
               name: "ProfesorPredmeti",
               url: "api/Profesor/MyGrade/{studentId}/Subjects",
               defaults: new { controller = "Profesor", action = "StudentSubjects", studentId = UrlParameter.Optional },
               namespaces: new[] { "RESTApi.Controllers" }
           );

            routes.MapRoute(
              name: "SubjectAllStudents",
              url: "api/Profesor/Grades/{gradeId}/Subjects/{subjectId}/Students",
              defaults: new { controller = "Profesor", action = "SubjectAllStudents"},
              namespaces: new[] { "RESTApi.Controllers" }
          );

            routes.MapRoute(
             name: "SubjectStudent",
             url: "api/Profesor/Grades/{gradeId}/Subjects/{subjectId}/Students/{studentId}",
             defaults: new { controller = "Profesor", action = "SubjectStudent" },
             namespaces: new[] { "RESTApi.Controllers" }
         );
            routes.MapRoute(
             name: "MyGradeStudentSubject",
             url: "api/Profesor/MyGrade/{studentId}/Subjects/{subjectId}/Cmn",
             defaults: new { controller = "Profesor", action = "MyGradeStudentSubject" },
             namespaces: new[] { "RESTApi.Controllers" }
         );
        }
    }
}
