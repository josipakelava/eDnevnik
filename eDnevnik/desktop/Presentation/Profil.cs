using Domena;
using Desktop.Controllers;
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
    public partial class Profil: Form
    {
        public Profil(Osoba o)
        {
            InitializeComponent();

            txtIme.Text = o.ime;
            txtPrezime.Text = o.prezime;
            txtDatRod.Text = o.datumRodjenja.ToShortDateString();
            txtOIB.Text = o.OIB;
            txtAdresa.Text = o.adresa;
            txtMjesto.Text = o.mjesto.ime;
            txtEmail.Text = o.email;
        }

        private void btnNaslovnica_Click(object sender, EventArgs e)
        {
            Globals.Naslovna();
        }
    }
}
