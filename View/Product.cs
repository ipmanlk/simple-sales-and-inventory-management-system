using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using sales_and_inventory.Controller;

namespace sales_and_inventory.View
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            RefreshProductsList();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var dt = (DataTable)dgProducts.DataSource;
            dt.DefaultView.RowFilter = string.Format("Name like '%{0}%'", txtSearch.Text);
            dgProducts.Refresh();
        }

        private void dgProducts_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // grab id of selected product
            int selectedId = Int32.Parse(dgProducts.SelectedRows[0].Cells[0].Value.ToString());
            // get product and display details
            var product = ProductController.getOne(selectedId);
            txtName.Text = product.name;
            txtPrice.Text = product.price.ToString();
            txtSalePrice.Text = product.salePrice.ToString();
            txtQty.Text = product.qty.ToString();
            txtDescription.Text = product.description;
            imgProduct.Image = Image.FromStream(new MemoryStream(product.photo));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string errors = validateInputs();

            if (errors != "")
            {
                MessageBox.Show(errors, "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var product = getInputs();

            if (ProductController.Save(product))
            {
                RefreshProductsList();
                ResetProductForm();
                MessageBox.Show("Product has been saved!.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to save the product!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSetPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog opn = new OpenFileDialog();
            opn.Filter = "Choose Image(*.jpg; *.png; *.jpeg)|*.jpg; *.png; *.jpeg";
            if (opn.ShowDialog() == DialogResult.OK)
            {
                imgProduct.Image = Image.FromFile(opn.FileName);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // check if a row is selected
            if (dgProducts.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select a product first!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // get confirmation
            var confirmResult = MessageBox.Show("Are you sure you want to delete this product?",
                                     "Confirmation",
                                     MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                int selectedId = Int32.Parse(dgProducts.SelectedRows[0].Cells[0].Value.ToString());

                if (ProductController.Delete(selectedId))
                {
                    RefreshProductsList();
                    ResetProductForm();
                    MessageBox.Show("Product has been deleted!.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to delete the product!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string errors = validateInputs();

            if (errors != "")
            {
                MessageBox.Show(errors, "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int selectedId = Int32.Parse(dgProducts.SelectedRows[0].Cells[0].Value.ToString());

            var product = getInputs();
            product.id = selectedId;

            if (ProductController.Update(product))
            {
                RefreshProductsList();
                ResetProductForm();
                MessageBox.Show("Product has been updated!.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to update the product!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Entity.Product getInputs()
        {
            var product = new Entity.Product();

            // convert input photo to a byte array
            MemoryStream ms = new MemoryStream();
            imgProduct.Image.Save(ms, imgProduct.Image.RawFormat);
            byte[] photo = ms.ToArray();

            product.name = txtName.Text.Trim();
            product.photo = photo;
            product.price = Decimal.Parse(txtPrice.Text.Trim());
            product.salePrice = Decimal.Parse(txtSalePrice.Text.Trim());
            product.qty = Int32.Parse(txtQty.Text.Trim());
            product.addedDate = DateTime.Now.ToString("yyyy-MM-dd");
            product.addedUserId = 6;

            return product;
        }

        private string validateInputs()
        {
            string errors = "";

            if (!Regex.IsMatch(txtName.Text, @"^[\w\s]{5,200}$"))
            {
                errors += "Please enter a valid product name.\n";
            }

            if (!Regex.IsMatch(txtPrice.Text, @"^[\d]{1,5}\.[\d]{2}$"))
            {
                errors += "Please enter a valid price!.\n";
            }

            if (!Regex.IsMatch(txtSalePrice.Text, @"^[\d]{1,5}\.[\d]{2}$"))
            {
                errors += "Please enter a valid sale price!.\n";
            }

            if (!Regex.IsMatch(txtQty.Text, @"^[\d]+$"))
            {
                errors += "Please enter a valid qty!.\n";
            }

            if (!Regex.IsMatch(txtDescription.Text, @"^[\w\s\d\,\\\.\n\/]{10,100}$") && txtDescription.Text.Trim() != "")
            {
                errors += "Please enter a valid description!.\n";
            }

            if (imgProduct.Image == null)
            {
                errors += "Please select a valid product picture!.";
            }

            return errors;
        }

        private void RefreshProductsList()
        {
            DataTable dt = ProductController.GetAll();
            dgProducts.DataSource = dt;
            dgProducts.Refresh();
            dgProducts.ClearSelection();
        }

        private void ResetProductForm()
        {
            txtName.Text = "";
            txtPrice.Text = "";
            txtSalePrice.Text = "";
            txtQty.Text = "";
            txtDescription.Text = "";
            imgProduct.Image = null;
        }
    }
}
