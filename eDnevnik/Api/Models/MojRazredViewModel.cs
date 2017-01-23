using Domena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class MojRazredViewModel
    {
        public virtual int idPredmet { get; set; }
        public virtual string ucenik { get; set; }
        public virtual List<PredmetView> predmeti { get; set; }

        public static List<MojRazredViewModel> toList(Razred razred, IList<EvidencijaNastave> evidencijaNstave)
        {

            List<MojRazredViewModel> lista = new List<MojRazredViewModel>();
            foreach (Ucenik ucenik in razred.ucenici)
            {

                MojRazredViewModel rvm = new MojRazredViewModel();

                rvm.ucenik = ucenik.ime + " " + ucenik.prezime;

                List<PredmetView> listaPredmeta = new List<PredmetView>();
                foreach (EvidencijaNastave evidencija in evidencijaNstave)
                {
                    PredmetView pv = new PredmetView();
                    pv.predavac = evidencija.profesor.ime + " " + evidencija.profesor.prezime;
                    pv.naziv = evidencija.predmet.naziv;

                    IList<KategorijaView> kategorije = new List<KategorijaView>();
                    foreach (var kategorija in evidencija.predmet.kategorije)
                    {
                        KategorijaView kv = new KategorijaView();
                        kv.id = kategorija.idKategorija;
                        kv.naziv = kategorija.naziv;
                        IList<Ocjena> ocjene = ucenik.ocjene.Where(p => p.kategorija.idKategorija == kategorija.idKategorija && p.predmet.idPredmet == evidencija.predmet.idPredmet).ToList();
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
                    pv.kategorije = kategorije;

                    IList<BiljeskaView> biljeske = new List<BiljeskaView>();
                    foreach (Biljeska biljeska in ucenik.biljeske)
                    {
                        if (biljeska.predmet.idPredmet == evidencija.predmet.idPredmet)
                        {
                            BiljeskaView bv = new BiljeskaView();
                            bv.id = biljeska.id;
                            bv.datum = biljeska.datum;
                            bv.biljeska = biljeska.biljeska;
                            biljeske.Add(bv);
                        }
                    }
                    biljeske = biljeske.OrderBy(o => o.datum).ToList();
                    pv.biljeske = biljeske;
                    listaPredmeta.Add(pv);
                }
                rvm.predmeti = listaPredmeta;
                lista.Add(rvm);
            }
            return lista;

        }
    }

    public class PredmetView
    {
        public virtual string naziv { get; set; }
        public virtual string predavac { get; set; }
        public virtual IList<KategorijaView> kategorije { get; set; }
        public virtual IList<BiljeskaView> biljeske { get; set; }
    }
}