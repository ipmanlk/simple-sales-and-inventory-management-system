using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using sales_and_inventory.Entity;
using sales_and_inventory.Util;

namespace sales_and_inventory.Dao
{
    class UserDao
    {
        public static void Save(User user)
        {
            MySqlConnection connection = DatabaseUtil.GetConnection();
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

            DatabaseUtil.CloseConnection();
        }

        public static User GetOne(string username)
        {
            MySqlConnection connection = DatabaseUtil.GetConnection();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM user WHERE username = @username";
            cmd.Parameters.AddWithValue("@username", username);
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

            reader.Close();
            DatabaseUtil.CloseConnection();

            return user;
        }
    }
}
