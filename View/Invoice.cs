using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using sales_and_inventory.Controller;

namespace sales_and_inventory.View
{
    public partial class Invoice : Form
    {
        public Invoice()
        {
            InitializeComponent();
        }

        private void Invoice_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            // load products to combo box
            RefreshProducts();
        }

        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get product id of the selected item
            DataRowView item = (DataRowView) cmbProducts.SelectedItem;
            int selectedProductId = Int32.Parse(item["ID"].ToString());
            // get product and show available qty
            Entity.Product product = ProductController.GetOne(selectedProductId);
            txtAvailableQty.Text = product.qty.ToString();
            txtSalePrice.Text = product.salePrice.ToString();
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            DataRowView item = (DataRowView)cmbProducts.SelectedItem;
            string selectedProductId = item["ID"].ToString();

            // check item is already in product list
            Boolean isDuplicate = false;
            
            foreach (ListViewItem i in listProducts.Items)
            {
                if (i.SubItems[0].Text == selectedProductId)
                {
                    isDuplicate = true;
                }
            }

            if (isDuplicate)
            {
                MessageBox.Show("This product is already in the list!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtQty.Text.Trim() == "")
            {
                MessageBox.Show("Please enter a valid qty!.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // check with avaiable qty
            if (Int32.Parse(txtQty.Text) > Int32.Parse(txtAvailableQty.Text))
            {
                MessageBox.Show("Qty can't exceed the available qty!.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var listItem = new ListViewItem(new[] { selectedProductId, item["Name"].ToString(), txtSalePrice.Text, txtQty.Text, txtLineTotal.Text });
            listProducts.Items.Add(listItem);
            updateTotalValues();
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            if (txtQty.Text.Trim() != "")
            {
                DataRowView item = (DataRowView)cmbProducts.SelectedItem;
                Decimal salePrice = Decimal.Parse(item["Sale Price"].ToString());
                Int32 qty = Int32.Parse(txtQty.Text);
                txtLineTotal.Text = (salePrice * qty).ToString();
            } else
            {
                txtLineTotal.Text = "";
            }
        }

        private void updateTotalValues()
        {
            // calculate grand total
            Decimal grandTotal = 0;
            foreach(ListViewItem item in listProducts.Items)
            {
                Decimal lineTotal = Decimal.Parse(item.SubItems[4].Text);
                grandTotal += lineTotal;
            }

            txtGrandTotal.Text = grandTotal.ToString();

            // update net total
            Decimal discountRatio = txtDiscountRatio.Text.Trim() == "" ? 0 : Decimal.Parse(txtDiscountRatio.Text);
            Decimal netTotal = grandTotal - (grandTotal * (discountRatio / 100));

            txtNetTotal.Text = netTotal.ToString();
        }

        private void txtDiscountRatio_TextChanged(object sender, EventArgs e)
        {
            if (txtGrandTotal.Text.Trim() != "" && txtDiscountRatio.Text.Trim() != "")
            {
                Decimal grandTotal = Decimal.Parse(txtGrandTotal.Text);
                Decimal discountRatio = Decimal.Parse(txtDiscountRatio.Text);
                Decimal netTotal = grandTotal - (grandTotal * (discountRatio / 100));
                txtNetTotal.Text = netTotal.ToString();
            } else
            {
                txtNetTotal.Text = "";
            }
        }

        private void btnRemoveFromList_Click(object sender, EventArgs e)
        {
            if (listProducts.SelectedItems.Count != 0)
            {
                listProducts.SelectedItems[0].Remove();
                updateTotalValues();
            } else
            {
                MessageBox.Show("Please select a product first!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string errors = ValidateInputs();

            if (errors != "")
            {
                MessageBox.Show(errors, "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (InvoiceController.Save(GetInputs()))
            {
                ResetForm();
                MessageBox.Show("Invoice has been created!.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to create the invoice!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private string ValidateInputs()
        {
            string errors = "";

            if (!Regex.IsMatch(txtQty.Text, @"^[\d]+$"))
            {
                errors += "Please enter a valid qty!.\n";
            }

            if (!Regex.IsMatch(txtDiscountRatio.Text, @"^[\d]+$"))
            {
                errors += "Please enter a valid discount ratio!.\n";
            }

            if (listProducts.Items.Count == 0)
            {
                errors += "Please add at least one product to the list!.\n";
            }

            return errors;
        }

        private Entity.Invoice GetInputs()
        {
            Entity.Invoice invoice = new Entity.Invoice();
            invoice.grandTotal = Decimal.Parse(txtGrandTotal.Text);
            invoice.discountRatio = Int32.Parse(txtDiscountRatio.Text);
            invoice.netTotal = Decimal.Parse(txtNetTotal.Text);
            invoice.addedDate = DateTime.Now.ToString("yyyy-MM-dd");
            invoice.addedUserId = 6;
            invoice.products = new List<Entity.Product>();

            // add products
            foreach (ListViewItem item in listProducts.Items)
            {
                Entity.Product product = new Entity.Product();
                product.id = Int32.Parse(item.SubItems[0].Text);
                product.qty = Int32.Parse(item.SubItems[3].Text);
                invoice.products.Add(product);
            }

            return invoice;
        }

        private void ResetForm()
        {
            txtQty.Text = "";
            txtLineTotal.Text = "";
            listProducts.Items.Clear();
            txtGrandTotal.Text = "";
            txtDiscountRatio.Text = "";
            txtNetTotal.Text = "";
            cmbProducts_SelectedIndexChanged(cmbProducts, EventArgs.Empty);
        }

        private void RefreshProducts()
        {
            cmbProducts.Items.Clear();
            var dt = ProductController.GetAll();
            cmbProducts.DataSource = dt;
            cmbProducts.DisplayMember = "Name";
        }
    }
}
