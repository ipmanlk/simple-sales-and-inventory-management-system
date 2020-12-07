using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sales_and_inventory.Controller;
using sales_and_inventory.Entity;

namespace sales_and_inventory.View
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;

            // set user avatar and info
            User loggedUser = AuthController.currentUser;
            statusUserInfo.Image = Image.FromStream(new MemoryStream(loggedUser.photo));
            statusUserInfo.Text = String.Format("{0} ({1})", loggedUser.username, loggedUser.email);
        }

        private void menuLogOut_Click(object sender, EventArgs e)
        {
            if (AuthController.logOut())
            {
                this.Hide();
                AuthController.loginForm.Show();
            }
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            AuthController.loginForm.Close();
        }


        private void menuSalesReport_Click(object sender, EventArgs e)
        {

        }

        private void menuCreateInvoice_Click(object sender, EventArgs e)
        {
            Form invoice = new Invoice();
            invoice.MdiParent = this;
            invoice.Show();
        }

        private void menuProducts_Click(object sender, EventArgs e)
        {
            Form product = new Product();
            product.MdiParent = this;
            product.Show();
        }
    }
}
