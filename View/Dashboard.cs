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
            // set user avatar and info
            User loggedUser = AuthController.currentUser;
            imgUser.Image = Image.FromStream(new MemoryStream(loggedUser.photo));
            label1.Text = loggedUser.email;
            label2.Text = loggedUser.username;
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

        private void btnCreateInvoice_Click(object sender, EventArgs e)
        {
            Form invoiceForm = new Invoice();
            invoiceForm.Show();
        }
    }
}
