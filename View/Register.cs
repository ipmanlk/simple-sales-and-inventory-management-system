using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sales_and_inventory.Entity;
using sales_and_inventory.Controller;

namespace sales_and_inventory.View
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void btnSetUserPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog opn = new OpenFileDialog();
            opn.Filter = "Choose Image(*.jpg; *.png; *.jpeg)|*.jpg; *.png; *.jpeg";
            if (opn.ShowDialog() == DialogResult.OK)
            {
               imgUser.Image = Image.FromFile(opn.FileName);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.username = "kasun";
            user.password = "kasun";
            user.name = "Kasun";
            user.nic = "23232232";
            user.mobile = "071445874";
            user.email = "kasun@kasun.com";

            MemoryStream ms = new MemoryStream();
            imgUser.Image.Save(ms, imgUser.Image.RawFormat);
            byte[] img = ms.ToArray();

            user.photo = img;
            user.registeredDate = "2015-01-01";

            UserController.save(user);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = UserController.getOne(1);
            imgUser.Image = Image.FromStream(new MemoryStream(user.photo));
        }
    }
}
