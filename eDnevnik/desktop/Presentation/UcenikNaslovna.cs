using Desktop.Controllers;
using Desktop.Presentation;
using Domena;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop
{
    public partial class UcenikNaslovna : Form
    {
        private UcenikNaslovnaController _controller = new UcenikNaslovnaController();

        private Ucenik _ucenik = null;

        public UcenikNaslovna(Ucenik u)
        {
            _ucenik = u;

            InitializeComponent();

            txtRazrednik.Text = u.razred.razrednik.ime + " " + u.razred.razrednik.prezime;
            txtUcenik.Text = u.ime + " " + u.prezime;
            txtRazred.Text = u.razred.naziv;

            IList<String> predmeti = new List<String>();

            foreach (EvidencijaNastave e in u.razred.evidencijaNastave)
                predmeti.Add(e.predmet.naziv);

            lbPredmeti.DataSource = predmeti;

            prikaziPredmet();
        }

        private void prikaziPredmet()
        {
            string predmet = (string)lbPredmeti.SelectedValue;

            Predmet odabran = null;

            foreach (var i in _ucenik.razred.evidencijaNastave)
            {
                if (i.predmet.naziv == predmet)
                {
                    odabran = i.predmet;
                    break;
                }
            }

            OcjeneImenik imenik = new OcjeneImenik();
            imenik.AddKategorije(odabran.kategorije);

            DataTable table = imenik.GenerirajTablicu();

            foreach (Ocjena o in _ucenik.ocjene)
            {
                if (o.predmet.naziv == odabran.naziv)
                {
                    imenik.DodajOcjenu(table, o);
                }
            }

            dgvOcjene.DataSource = table;

            DataTable biljeske = new DataTable();
            biljeske.Columns.Add("Datum");
            biljeske.Columns.Add("Bilješka");

            int redak = 0;

            foreach (Biljeska b in _ucenik.biljeske)
                if (b.predmet.naziv == odabran.naziv)
                {
                    biljeske.Rows.Add();
                    biljeske.Rows[redak][0] = Helpers.Datum(b.datum);
                    biljeske.Rows[redak][1] = b.biljeska;
                    redak++;
                }

            dgvBiljeske.DataSource = biljeske;
        }

        private void odjavaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.Logout();
        }

        private void profilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.Profil();
        }

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            prikaziPredmet();
        }

        private void izostanciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.Izostanci(_ucenik.izostanci);
        }
    }
}
