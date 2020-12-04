using MySql.Data.MySqlClient;
using sales_and_inventory.Util;
using System;
using System.Data;
using sales_and_inventory.Entity;

namespace sales_and_inventory.Dao
{
    class ProductDao
    {
        public static DataTable GetAll()
        {
            MySqlConnection connection = DatabaseUtil.GetConnection();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT id AS ID, name as Name, price as Price, sale_price as 'Sale Price', qty as Qty FROM product";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DatabaseUtil.CloseConnection();
            return dt;
        }

        public static Product GetOne(int id)
        {
            MySqlConnection connection = DatabaseUtil.GetConnection();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM product WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            Product product = new Product();
            product.id = Int32.Parse(reader["id"].ToString());
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

        public static void Save(Product product)
        {
            MySqlConnection connection = DatabaseUtil.GetConnection();
            MySqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = "INSERT INTO product(name, photo, price, sale_price, qty, description, added_date, added_user_id) VALUES(@name, @photo, @price, @sale_price, @qty, @description, @added_date, @added_user_id)";
            cmd.Parameters.AddWithValue("@name", product.name);
            cmd.Parameters.AddWithValue("@photo", product.photo);
            cmd.Parameters.AddWithValue("@price", product.price);
            cmd.Parameters.AddWithValue("@sale_price", product.salePrice);
            cmd.Parameters.AddWithValue("@qty", product.qty);
            cmd.Parameters.AddWithValue("@description", product.description);
            cmd.Parameters.AddWithValue("@added_date", product.addedDate);
            cmd.Parameters.AddWithValue("@added_user_id", product.addedUserId);

            cmd.ExecuteNonQuery();

            DatabaseUtil.CloseConnection();
        }

        public static void Update(Product product)
        {
            MySqlConnection connection = DatabaseUtil.GetConnection();
            MySqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = "UPDATE product SET name=@name, photo=@photo, price=@price, sale_price=@sale_price, qty=@qty, description=@description WHERE id=@id";
            cmd.Parameters.AddWithValue("@id", product.id);
            cmd.Parameters.AddWithValue("@name", product.name);
            cmd.Parameters.AddWithValue("@photo", product.photo);
            cmd.Parameters.AddWithValue("@price", product.price);
            cmd.Parameters.AddWithValue("@sale_price", product.salePrice);
            cmd.Parameters.AddWithValue("@qty", product.qty);
            cmd.Parameters.AddWithValue("@description", product.description);

            cmd.ExecuteNonQuery();

            DatabaseUtil.CloseConnection();
        }

        public static void Delete(int id)
        {
            MySqlConnection connection = DatabaseUtil.GetConnection();
            MySqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = "DELETE FROM product WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            DatabaseUtil.CloseConnection();
        }
    }
}
