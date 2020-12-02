using System;
using System.Drawing;
using System.IO;
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

            UserController.Save(user);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            imgUser.Image.Save(ms, imgUser.Image.RawFormat);
            byte[] img = ms.ToArray();

            byte[] encryptedImg = Util.CryptographyUtil.EncryptByteArray("b14ca5898a4e4133bbce2ea2315a1916", img);
            byte[] decryptedImg = Util.CryptographyUtil.DecryptByteArray("b14ca5898a4e4133bbce2ea2315a1916", encryptedImg);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
