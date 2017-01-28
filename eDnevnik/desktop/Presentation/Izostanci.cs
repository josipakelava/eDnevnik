using Desktop.Controllers;
using Domena;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System;

namespace Desktop
{
    public partial class Izostanci : Form
    {
        private IzostanciController _controller = new IzostanciController();

        private ICollection<Izostanak> izostanci = null;
        
        public Izostanci(ICollection<Izostanak> izostanci, bool uredivanje)
        {
            this.izostanci = izostanci;

            InitializeComponent();

            UcitajIzostanke();

            // razrednik ne moze upisati izostanak naknadno
            //dgvIzostanci.AllowUserToAddRows = uredivanje;
            dgvIzostanci.ReadOnly = !uredivanje;
        }

        private void UcitajIzostanke()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Učenik");
            table.Columns.Add("Datum");
            table.Columns.Add("Predmet");
            table.Columns.Add("Razlog");
            table.Columns.Add("Opravdanost");

            int index = 0;

            foreach (Izostanak i in izostanci)
            {
                table.Rows.Add();
                table.Rows[index][0] = Helpers.Datum(i.datum);
                table.Rows[index][1] = i.ucenik.ime + " " + i.ucenik.prezime;
                table.Rows[index][2] = i.predmet.naziv;
                table.Rows[index][3] = i.razlog ?? "";
                table.Rows[index][4] = i.opravdanost ? "Opravdano" : "Neopravdano";
                index++;
            }

            dgvIzostanci.DataSource = table;

        }

        private void btnNaslovnica_Click(object sender, System.EventArgs e)
        {
            Globals.Naslovna();
        }

        private void HandleChange(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var index = 0;
                Izostanak izostanak = null;

                bool opravdanost = ((string)dgvIzostanci[4, e.RowIndex].Value).ToLower() == "opravdano" ? true : false;

                foreach (var i in izostanci)
                {
                    if (index == e.RowIndex)
                    {
                        izostanak = i;
                        break;
                    }

                    index++;
                }

                _controller.Izostanak(izostanak.id, opravdanost, (string)dgvIzostanci[3, e.RowIndex].Value);
            } catch (Exception) { }
        }
    }
}
