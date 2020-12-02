using System;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using sales_and_inventory.Entity;
using sales_and_inventory.Util;

namespace sales_and_inventory.Controller
{
    class UserController
    {
        public static Boolean Save(User user)
        {
            try
            {
                MySqlConnection connection = Util.DatabaseUtil.GetConnection();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO user(username, password, name, nic, mobile, email, photo, registered_date) VALUES(@username, @password, @name, @nic, @mobile, @email, @photo, @registration_date)";

                string passwordHash = CryptographyUtil.GetHash(user.password);
                byte[] encryptedPhoto = CryptographyUtil.EncryptByteArray(passwordHash.Substring(0, 32), user.photo);

                cmd.Parameters.AddWithValue("@username", user.username);
                cmd.Parameters.AddWithValue("@password", passwordHash);
                cmd.Parameters.AddWithValue("@name", user.name);
                cmd.Parameters.AddWithValue("@nic", user.nic);
                cmd.Parameters.AddWithValue("@mobile", user.mobile);
                cmd.Parameters.AddWithValue("@email", user.email);
                cmd.Parameters.AddWithValue("@photo", encryptedPhoto);
                cmd.Parameters.AddWithValue("@registration_date", user.registeredDate);
                cmd.ExecuteNonQuery();
                return true;
            } catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        public static User GetOne(int id)
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
