using System;
using MySql.Data.MySqlClient;
using sales_and_inventory.Entity;

namespace sales_and_inventory.Controller
{
    class UserController
    {
        public static Boolean save(User user)
        {
            MySqlConnection connection = Util.DatabaseUtil.GetConnection();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO user(username, password, name, nic, mobile, email, photo, registered_date) VALUES(@username, @password, @name, @nic, @mobile, @email, @photo, @registration_date)";
            cmd.Parameters.AddWithValue("@username", user.username);
            cmd.Parameters.AddWithValue("@password", user.password);
            cmd.Parameters.AddWithValue("@name", user.name);
            cmd.Parameters.AddWithValue("@nic", user.nic);
            cmd.Parameters.AddWithValue("@mobile", user.mobile);
            cmd.Parameters.AddWithValue("@email", user.email);
            cmd.Parameters.AddWithValue("@photo", user.photo);
            cmd.Parameters.AddWithValue("@registration_date", user.registeredDate);
            cmd.ExecuteNonQuery();
            return true;
        }

        public static User getOne(int id)
        {
            MySqlConnection connection = Util.DatabaseUtil.GetConnection();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM user WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            User user = new User();
            user.username = reader["username"].ToString();
            user.password = reader["password"].ToString();
            user.name = reader["name"].ToString();
            user.nic = reader["nic"].ToString();
            user.mobile = reader["mobile"].ToString();
            user.email = reader["email"].ToString();
            user.registeredDate = reader["registered_date"].ToString();
            user.photo = (byte[])reader["photo"];
            return user;
        }
    }

}
