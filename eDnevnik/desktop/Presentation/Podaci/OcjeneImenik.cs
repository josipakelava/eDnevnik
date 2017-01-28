using Domena;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Presentation
{
    public class OcjeneImenik
    {
        private IList<string> kategorije { get; set; }
        private IList<string> mjeseci { get; set; }

        public OcjeneImenik()
        {
            kategorije = new List<string>();

            mjeseci = new List<string>();
            mjeseci.Add("Kategorija");
            mjeseci.Add("IX");
            mjeseci.Add("X");
            mjeseci.Add("XI");
            mjeseci.Add("XII");
            mjeseci.Add("I");
            mjeseci.Add("II");
            mjeseci.Add("III");
            mjeseci.Add("IV");
            mjeseci.Add("V");
            mjeseci.Add("VI");
        }

        #region Getters & Setters

        public void AddKategorija(string k)
        {
            kategorije.Add(k);
        }

        public IList<string> GetKategorije()
        {
            return kategorije;
        }

        public void AddMjesec(string m)
        {
            mjeseci.Add(m);
        }

        public IList<string> GetMjeseci()
        {
            return mjeseci;
        }

        public void AddKategorije(ICollection<Kategorija> kategorije)
        {
            foreach (Kategorija k in kategorije)
                this.kategorije.Add(k.naziv);
        }

        #endregion

        public DataTable GenerirajTablicu()
        {
            DataTable table = new DataTable();

            foreach (string m in mjeseci)
            {
                table.Columns.Add(m);
            }

            foreach (string k in kategorije)
                table.Rows.Add(k);

            return table;
        }

        public void DodajOcjenu(DataTable table, Ocjena o)
        {
            string mjesec = Helpers.MjesecURimski(o.datum.Month);
            string kategorija = o.kategorija.naziv;

            int mjIndex = table.Columns.IndexOf(mjesec);
            int katIndex = 0;
            
            for (int i = 0; i < o.predmet.kategorije.Count; ++i)
                if (o.predmet.kategorije.ElementAt(i).naziv == o.kategorija.naziv)
                {
                    katIndex = i;
                    break;
                }

            table.Rows[katIndex][mjIndex] = o.ocjena;
          
        }

       
    }
}
