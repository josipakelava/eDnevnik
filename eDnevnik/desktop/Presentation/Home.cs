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
    public partial class Home : Form
    {
        private HomeController controller = null;

        public Home(IList<string> uloge, HomeController controller, bool uspjeh = true)
        {
            this.controller = controller; 

            InitializeComponent();

            cbUloga.DataSource = uloge;
            if (uloge.Count > 0)
            {
                cbUloga.SelectedIndex = 0;
            }

            if (!uspjeh)
            {
                MessageBox.Show("Uneseni podaci nisu točni!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
            }

            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            controller.Login(txtEmail.Text, txtPassword.Text, cbUloga.Text);
        }

        private void keyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                Login();
            }
        }
    }
}
