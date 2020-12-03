using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
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
            DataTable dt = ProductController.GetAll();
            dgProducts.DataSource = dt;

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

            if (ProductController.Save(product))
            {
                DataTable dt = ProductController.GetAll();
                dgProducts.DataSource = dt;
                dgProducts.Refresh();
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
    }
}
