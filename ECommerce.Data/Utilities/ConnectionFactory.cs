using System.Data.SqlClient;

namespace ECommerce.Data
{
    public static class ConnectionFactory
    {
        //private static string _sqlConnection =
           // "server=191.234.179.75;database=DeveloperDB22;user=developers;password=dev123DEV123";
        public static SqlConnection GetConnection(string _sqlConnection)
        {
            var conn = new SqlConnection(_sqlConnection);
            conn.Open();

            return conn;
        }
    }
}
