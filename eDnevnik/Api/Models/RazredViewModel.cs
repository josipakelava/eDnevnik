using Domena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class RazredViewModel
    {
        public virtual int idUcenik { get; set; }
        public virtual int idPredmet { get; set; }
        public virtual string ucenik { get; set; }
        public virtual string novabiljeska { get; set; }
        public virtual IList<KategorijaView> kategorije { get; set; }

        public virtual IList<BiljeskaView> biljeske { get; set; }
        public virtual bool izostanak { get; set; }
        public static List<RazredViewModel> toList(Razred razred, Predmet predmet)
        {

            List<RazredViewModel> lista = new List<RazredViewModel>();
            foreach (Ucenik ucenik in razred.ucenici)
            {
                RazredViewModel rvm = new RazredViewModel();
                rvm.idUcenik = ucenik.idOsoba;
                rvm.ucenik = ucenik.ime + " " + ucenik.prezime;
                rvm.idPredmet = predmet.idPredmet;
                IList<KategorijaView> kategorije = new List<KategorijaView>();
                foreach (var kategorija in predmet.kategorije)
                {
                    KategorijaView kv = new KategorijaView();
                    kv.id = kategorija.idKategorija;
                    kv.naziv = kategorija.naziv;
                    IList<Ocjena> ocjene = ucenik.ocjene.Where(p => p.kategorija.idKategorija == kategorija.idKategorija && p.predmet.idPredmet == predmet.idPredmet).ToList();
                    ocjene = ocjene.OrderBy(o => o.datum).ToList();
                    List<OcjenaViewModel> ovmList = new List<OcjenaViewModel>();

                    int j = 0;
                    int ocjeneCount = ocjene.Count;
                    for (int i = 0; i < 10; i++)
                    {
                        OcjenaViewModel ovm = new OcjenaViewModel();
                        if (j < ocjeneCount && ocjene[j].datum.Month == (i + 8) % 12 + 1)
                        {
                            ovm.id = ocjene[j].id;
                            ovm.mjesecUredivanje = (i + 8) % 12 + 1;
                            ovm.ocjena = ocjene[j].ocjena;
                            j++;
                        }
                        else
                        {
                            ovm.id = -1;
                            ovm.mjesecUredivanje = (i + 8) % 12 + 1;
                          //  ovm.ocjena = 0;
                        }
                        ovmList.Add(ovm);
                    }

                    kv.ocjene = ovmList;
                    kategorije.Add(kv);
                }
                rvm.kategorije = kategorije;

                IList<BiljeskaView> biljeske = new List<BiljeskaView>();
                foreach (Biljeska biljeska in ucenik.biljeske)
                {
                    if (biljeska.predmet.idPredmet == predmet.idPredmet)
                    {
                        BiljeskaView bv = new BiljeskaView();
                        bv.id = biljeska.id;
                        bv.datum = biljeska.datum;
                        bv.biljeska = biljeska.biljeska;
                        biljeske.Add(bv);
                    }
                }
                biljeske = biljeske.OrderBy(o => o.datum).ToList();
                rvm.biljeske = biljeske;
                lista.Add(rvm);

            }
            return lista;

        }
    }
    public class KategorijaView
    {
        public virtual int id { get; set; }
        public virtual string naziv { get; set; }

        public virtual List<OcjenaViewModel> ocjene { get; set; }
    }
    public class BiljeskaView
    {
        public virtual int id { get; set; }
        public virtual DateTime datum { get; set; }
        public virtual string biljeska { get; set; }
    }
}