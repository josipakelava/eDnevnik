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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            SetRoleData();
        }

        private void SetRoleData()
        {
            IList<string> uloge = new List<string>();
            uloge.Add("Učenik");
            //uloge.Add("Razrednik");
            uloge.Add("Profesor");
            uloge.Add("Administrator");

            cbUloga.DataSource = uloge;
            cbUloga.SelectedIndex = 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
        }
    }
}
