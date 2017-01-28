using Domena;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class EvidencijaViewModel
    {
        [Required(ErrorMessage = "Obavezno polje")]
        public int idRazred { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public int idPredmet { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public int idProfesor { get; set; }

        public string nazivRazred { get; set; }

        public string nazivProfesor { get; set; }

        public string nazivPredmet { get; set; }

        public static EvidencijaView toList(List<Profesor> profesori, List<Predmet> predmeti)
        {
            EvidencijaView ev = new EvidencijaView();
            ev.profesori = OsobaViewModel.toListProfesor(profesori);
            List<PredmetViewModel> listaPredmeta = new List<PredmetViewModel>();
            foreach (Predmet item in predmeti)
            {
                PredmetViewModel pvm = new PredmetViewModel();
                pvm.idPredmet = item.idPredmet;
                pvm.naziv = item.naziv;
                listaPredmeta.Add(pvm);
            }
            ev.predmeti = listaPredmeta;
            return ev;
        } 
    }
    public class EvidencijaView
    {
        public List<PredmetViewModel> predmeti { get; set; }
        public IList<OsobaViewModel> profesori { get; set; }
    }
}