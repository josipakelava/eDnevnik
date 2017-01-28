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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop
{
    public partial class ProfesorNaslovna : Form
    {
        private ProfesorNaslovnaController _controller = new ProfesorNaslovnaController();
        private Profesor _profesor = null;
        private IDictionary<Predmet, IList<Razred>> _nastava;
        private Random random = new Random();

        public ProfesorNaslovna(Profesor p)
        {
            _profesor = p;

            InitializeComponent();

            UcitajPredmeteIRazrede();

            PrikaziUcenike();

            PrikaziOcjeneIBiljeske();
        }

        public void Osvjezi(int predmetIndex, int razredIndex, int ucenikIndex = 0)
        {
            _profesor = _controller.GetProfesor(_profesor.idOsoba);

            var p = _profesor;

            UcitajPredmeteIRazrede(predmetIndex, razredIndex);

            PrikaziUcenike(ucenikIndex);

            PrikaziOcjeneIBiljeske();
        }

        private void PrikaziOcjeneIBiljeske()
        {
            Predmet odabran = VratiPredmet(cbPredmet.Text);

            OcjeneImenik imenik = new OcjeneImenik();
            imenik.AddKategorije(odabran.kategorije);

            DataTable table = imenik.GenerirajTablicu();

            Ucenik ucenik = VratiUcenika(cbPredmet.Text, cbRazred.Text, lbUcenici.Text);

            foreach (Ocjena o in ucenik.ocjene)
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

            foreach (Biljeska b in ucenik.biljeske)
                if (b.predmet.naziv == odabran.naziv)
                {
                    biljeske.Rows.Add();
                    biljeske.Rows[redak][0] = Helpers.Datum(b.datum);
                    biljeske.Rows[redak][1] = b.biljeska;
                    redak++;
                }

            dgvBiljeske.DataSource = biljeske;
        }

        private Ucenik VratiUcenika(string predmet, string razred, string ucenik)
        {
            var naziv = ucenik.Split(' ');

            Razred trenutni = null;
            foreach (var p in _nastava.Keys)
                if (p.naziv == predmet)
                {
                    foreach (var r in _nastava[p])
                        if (r.naziv == razred)
                        {
                            trenutni = r;
                            break;
                        }
                    break;
                }

            foreach (var u in trenutni.ucenici)
                if (u.ime == naziv[0] && u.prezime == naziv[1])
                    return u;

            return null;
        }

        private void UcitajPredmeteIRazrede(int predmet = 0, int razred = 0)
        {
            _nastava = new Dictionary<Predmet, IList<Razred>>();

            foreach (var e in _profesor.evidencijaNastave)
            {
                if (_nastava.ContainsKey(e.predmet))
                {
                    IList<Razred> razredi;
                    _nastava.TryGetValue(e.predmet, out razredi);
                    razredi.Add(e.razred);
                }
                else
                {
                    IList<Razred> odgovarajuciRazredi = new List<Razred>();
                    odgovarajuciRazredi.Add(e.razred);
                    _nastava[e.predmet] = odgovarajuciRazredi;
                }
            }

            IList<string> predmeti = new List<string>();

            foreach (var p in _nastava.Keys)
                predmeti.Add(p.naziv);

            cbPredmet.DataSource = predmeti;
            cbPredmet.SelectedIndex = predmet;
            cbPredmet.SelectedIndex = 0;

            PostaviRazrede(razred);
        }

        private void PostaviRazrede(int razred = 0)
        {
            IList<string> razrediZaPredmet = new List<string>();

            Predmet p = VratiPredmet(cbPredmet.Text);
            foreach (var r in _nastava[p])
                razrediZaPredmet.Add(r.naziv);

            cbRazred.DataSource = razrediZaPredmet;
            cbRazred.SelectedIndex = razred;
        }

        private void PrikaziUcenike(int index = 0)
        {
            Razred aktivan = null;
            Predmet p = VratiPredmet(cbPredmet.Text);
            foreach (var r in _nastava[p])
                if (r.naziv == cbRazred.Text)
                {
                    aktivan = r;
                    break;
                }

            IList<string> ucenici = new List<string>();

            foreach (var u in aktivan.ucenici)
                ucenici.Add(u.ime + " " + u.prezime);

            lbUcenici.DataSource = ucenici;
            lbUcenici.SelectedIndex = index;
        }

        private Predmet VratiPredmet(string naziv)
        {
            foreach (var p in _nastava.Keys)
                if (p.naziv == naziv)
                    return p;

            return null;
        }

        private void odjavaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.Logout();
        }

        private void profilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.Profil();
        }

        private void HandlePredmetChange(object sender, EventArgs e)
        {
            PostaviRazrede();

            PrikaziUcenike();

            PrikaziOcjeneIBiljeske();
        }

        private void HandleRazredChange(object sender, EventArgs e)
        {
            PrikaziUcenike();

            PrikaziOcjeneIBiljeske();
        }

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            PrikaziOcjeneIBiljeske();
        }

        private void btnOdabir_Click(object sender, EventArgs e)
        {
            int rb = random.Next(0, lbUcenici.Items.Count);

            lbUcenici.SelectedIndex = rb;

            PrikaziOcjeneIBiljeske();
        }

        private void saveChange(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int ocjena = int.Parse((string)dgvOcjene[e.ColumnIndex, e.RowIndex].Value);

                if (ocjena > 0 && ocjena < 6)
                {
                    Predmet p = VratiPredmet(cbPredmet.Text);
                    
                    int mj = (8 + e.ColumnIndex) % 13;
                    if (mj < 9) ++mj;
                    DateTime date = new DateTime(DateTime.Now.Year, mj, DateTime.Now.Day);

                    var o = VratiUcenika(cbPredmet.Text, cbRazred.Text, lbUcenici.Text).idOsoba;
                    var k = p.kategorije.ElementAt(e.RowIndex).idKategorija;

                    _controller.SpremiOcjenu(
                        ocjena,
                        VratiUcenika(cbPredmet.Text, cbRazred.Text, lbUcenici.Text).idOsoba,
                        p.idPredmet,
                        p.kategorije.ElementAt(e.RowIndex).idKategorija,
                        date
                    );

                    Osvjezi(cbPredmet.SelectedIndex, cbRazred.SelectedIndex, lbUcenici.SelectedIndex);

                    return;
                } else
                {
                    dgvOcjene[e.ColumnIndex, e.RowIndex].Value = "";
                }
            }
            catch (Exception)
            {
                dgvOcjene[e.ColumnIndex, e.RowIndex].Value = "";
                return;
            }
        }

        private void HandleBiljeska(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvBiljeske.Rows[e.RowIndex];

            try
            {
                string c1 = (string)dgvBiljeske[0, e.RowIndex].Value;
                string c2 = (string)dgvBiljeske[1, e.RowIndex].Value;

                if (!String.IsNullOrWhiteSpace(c1) && !String.IsNullOrWhiteSpace(c2))
                {
                    Predmet p = VratiPredmet(cbPredmet.Text);

                    var split = c1.Split('.');
                    DateTime date = new DateTime(int.Parse(split[2]), int.Parse(split[1]), int.Parse(split[0]));

                    int o = VratiUcenika(cbPredmet.Text, cbRazred.Text, lbUcenici.Text).idOsoba;

                    _controller.SpremiBiljesku(p.idPredmet, o, c2.Trim(), date);

                    Osvjezi(cbPredmet.SelectedIndex, cbRazred.SelectedIndex, lbUcenici.SelectedIndex);
                }
            } catch (Exception)
            {
                return;
            }
            
        }

        private void mojRazredToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_profesor.razrednistvo == null)
            {
                MessageBox.Show("Vi niste razrednik.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            _controller.MojRazred(_profesor);
        }

        private void btnNijePrisutan_Click(object sender, EventArgs e)
        {
            var upitnik = MessageBox.Show("Učenik/ca " + lbUcenici.SelectedItem + " nije prisutan/na?", "Potvrdite", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (upitnik == DialogResult.OK)
            {
                Predmet p = VratiPredmet(cbPredmet.Text);
                Osoba u = VratiUcenika(cbPredmet.Text, cbRazred.Text, lbUcenici.Text);
                DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                   
                _controller.Nedostaje(p.idPredmet, u.idOsoba, date);
            }
        }
    }
}
