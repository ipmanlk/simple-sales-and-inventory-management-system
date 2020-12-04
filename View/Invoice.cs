using System;
using System.Data;
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
            // load products to combo box
            var dt = ProductController.GetAll();
            cmbProducts.DataSource = dt;
            cmbProducts.DisplayMember = "Name";
        }

        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get product id of the selected item
            DataRowView item = (DataRowView) cmbProducts.SelectedItem;
            int selectedProductId = Int32.Parse(item["ID"].ToString());
            // get product and show available qty
            Entity.Product product = ProductController.getOne(selectedProductId);
            txtAvailableQty.Text = product.qty.ToString();
            txtSalePrice.Text = product.salePrice.ToString();
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            DataRowView item = (DataRowView)cmbProducts.SelectedItem;
            var listItem = new ListViewItem(new[] { item["Name"].ToString(), txtSalePrice.Text, txtQty.Text, txtLineTotal.Text });
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
                Decimal lineTotal = Decimal.Parse(item.SubItems[3].Text);
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
    }
}
