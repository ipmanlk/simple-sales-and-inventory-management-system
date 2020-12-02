using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using sales_and_inventory.Entity;
using sales_and_inventory.Controller;
using System.Text.RegularExpressions;

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
            string errors = validateInputs();

            if (errors != "")
            {
                MessageBox.Show(errors, "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            User user = getInputs();

            if (AuthController.Register(user))
            {
                MessageBox.Show("Registration completed!.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            } else
            {
                MessageBox.Show("Registration failed!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private User getInputs()
        {
            User user = new User();
            user.username = txtUsername.Text.Trim();
            user.name = txtName.Text.Trim();
            user.nic = txtNIC.Text.Trim();
            user.mobile = txtMobile.Text.Trim();
            user.email = txtEmail.Text.Trim();
            user.password = txtPassword.Text;
           
            // convert input photo to a byte array
            MemoryStream ms = new MemoryStream();
            imgUser.Image.Save(ms, imgUser.Image.RawFormat);
            byte[] photo = ms.ToArray();

            user.photo = photo;
            user.registeredDate = DateTime.Now.ToString("yyyy-MM-dd");

            return user;
        }

        private string validateInputs()
        {
            string errors = "";
            
            if (!Regex.IsMatch(txtUsername.Text, @"^[\w\d]{5,15}$")) {
                errors += "Please enter a valid username!.\n";
            }

            if (!Regex.IsMatch(txtName.Text, @"^[\w\s]{5,150}$"))
            {
                errors += "Please enter a valid full name!.\n";
            }

            if (!Regex.IsMatch(txtNIC.Text, @"^([\d]{9}(V|X))$|^([\d]{12})$"))
            {
                errors += "Please enter a valid NIC!.\n";
            }

            if (!Regex.IsMatch(txtMobile.Text, @"^[\d]{10}$"))
            {
                errors += "Please enter a valid mobile number!.\n";
            }

            if (!Regex.IsMatch(txtEmail.Text, @"^\S+@\S+\.\S+$"))
            {
                errors += "Please enter a valid email!.\n";
            }

            if (!Regex.IsMatch(txtPassword.Text, @"^[\w\s\d]{5,100}$"))
            {
                errors += "Please enter a valid password!.\n";
            }

            if (txtPassword.Text != txtPasswordConfirm.Text)
            {
                errors += "Password and confirmation doesn't match!.\n";
            }

            if (imgUser.Image == null)
            {
                errors += "Please select a valid profile picture!.";
            }

            return errors;
        }

   
    }
}
