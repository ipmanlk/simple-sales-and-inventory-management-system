using System;
using MySql.Data.MySqlClient;
using sales_and_inventory.Entity;
using sales_and_inventory.Util;

namespace sales_and_inventory.Dao
{
    class InvoiceDao
    {
        public static void Save(Invoice invoice)
        {
            MySqlConnection connection = DatabaseUtil.GetConnection();
            MySqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = "INSERT INTO invoice(grand_total, discount_ratio, net_total, added_date, added_user_id) VALUES(@grand_total, @discount_ratio, @net_total, @added_date, @added_user_id); SELECT last_insert_id();";
            cmd.Parameters.AddWithValue("@grand_total", invoice.grandTotal);
            cmd.Parameters.AddWithValue("@discount_ratio", invoice.discountRatio);
            cmd.Parameters.AddWithValue("@net_total", invoice.netTotal);
            cmd.Parameters.AddWithValue("@added_date", invoice.addedDate);
            cmd.Parameters.AddWithValue("@added_user_id", invoice.addedUserId);

            // get the new id for associate table insertions
            int newInvoiceId = Convert.ToInt32(cmd.ExecuteScalar());

            foreach (Product product in invoice.products)
            {
                connection = DatabaseUtil.GetConnection();
                cmd = connection.CreateCommand();

                cmd.CommandText = "INSERT INTO invoice_product(product_id, invoice_id, qty) VALUES(@product_id, @invoice_id, @qty)";
                cmd.Parameters.AddWithValue("@product_id", product.id);
                cmd.Parameters.AddWithValue("@invoice_id", newInvoiceId);
                cmd.Parameters.AddWithValue("@qty", product.qty);
                cmd.ExecuteNonQuery();

                // update product qty
                Product inventoryProduct = ProductDao.GetOne(product.id);
                inventoryProduct.qty -= product.qty;
                ProductDao.Update(inventoryProduct);
            }
        }
    }
}
