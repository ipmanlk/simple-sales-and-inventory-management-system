using MySql.Data.MySqlClient;

namespace sales_and_inventory.Util
{
    class DatabaseUtil
    {
        private static MySqlConnection connection = null;

        private const string DatabaseHost = "localhost";
        private const string DatabaseName = "shop";
        private const string DatabaseUser = "root";
        private const string DatabasePass = "";
        private const int DatabasePort = 3306;

        public static MySqlConnection GetConnection()
        {
            if (connection == null)
            {
                CreateConnection();
            }
            return connection;
        }


        private static void CreateConnection()
        {
            string connstring = string.Format("Server={0}; database={1}; UID={2}; password={3}; port={4}", DatabaseHost, DatabaseName, DatabaseUser, DatabasePass, DatabasePort);
            connection = new MySqlConnection(connstring);
            connection.Open();
        }

        public static void CloseConnection()
        {
            connection.Close();
            connection = null;
        }
    }
}
