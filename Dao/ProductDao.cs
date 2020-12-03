using MySql.Data.MySqlClient;
using sales_and_inventory.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sales_and_inventory.Entity;
using System.Diagnostics;

namespace sales_and_inventory.Dao
{
    class ProductDao
    {
        public static DataTable GetAll()
        {
            try
            {
                MySqlConnection connection = DatabaseUtil.GetConnection();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT id AS ID, code AS Code, name as Name, price as Price, sale_price as 'Sale Price', qty as Qty FROM product";
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DatabaseUtil.CloseConnection();
                return dt;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return new DataTable();
            }
        }

        public static Product GetOne(int id)
        {

            try
            {
                MySqlConnection connection = DatabaseUtil.GetConnection();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM product WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                Product product = new Product();
                product.id = Int32.Parse(reader["id"].ToString());
                product.code = reader["code"].ToString();
                product.name = reader["name"].ToString();
                product.photo = (byte[])reader["photo"];
                product.price = Decimal.Parse(reader["price"].ToString());
                product.salePrice = Decimal.Parse(reader["sale_price"].ToString());
                product.qty = Int32.Parse(reader["qty"].ToString());
                product.description = reader["description"].ToString();
                product.addedDate = reader["added_date"].ToString();
                product.addedUserId = Int32.Parse(reader["added_user_id"].ToString());

                reader.Close();
                DatabaseUtil.CloseConnection();

                return product;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                DatabaseUtil.CloseConnection();
                return new Product();
            }
        }
    }
}
