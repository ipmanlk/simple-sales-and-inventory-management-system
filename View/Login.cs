using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sales_and_inventory.Controller;

namespace sales_and_inventory.View
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void lblRegister_MouseEnter(object sender, EventArgs e)
        {
            lblRegister.ForeColor = Color.Red;
        }

        private void lblRegister_MouseLeave(object sender, EventArgs e)
        {
            lblRegister.ForeColor = Color.Blue;
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            new View.Register().ShowDialog();
            this.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (AuthController.LogIn(txtUsername.Text.Trim(), txtPassword.Text))
            {
                new View.Register().Show();
            }
        }
    }
}
