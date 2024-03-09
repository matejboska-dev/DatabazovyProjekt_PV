using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_DatabaseProject_MatejBoska.Singleton
{
    public class DatabaseSingleton
    {
        private static SqlConnection conn = null;
        private static readonly object lockObject = new object();

        private DatabaseSingleton()
        {
        }

        public static SqlConnection GetInstance()
        {
            lock (lockObject)
            {
                if (conn == null || conn.State == System.Data.ConnectionState.Closed)
                {
                    string connectionString = GetConnectionString();
                    conn = new SqlConnection(connectionString);

                    try
                    {
                        conn.Open();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error opening database connection: {ex.Message}");
                        // Handle the exception (log, throw, etc.) based on your application's needs.
                        throw;
                    }
                }
                else if (conn.State == System.Data.ConnectionState.Broken)
                {
                    // Reopen the connection if it's broken
                    conn.Close();
                    conn.Open();
                }

                return conn;
            }
        }

        public static void CloseConnection()
        {
            lock (lockObject)
            {
                if (conn != null)
                {
                    if (conn.State != System.Data.ConnectionState.Closed)
                    {
                        conn.Close();
                    }

                    conn.Dispose();
                    conn = null;
                }
            }
        }

        private static string GetConnectionString()
        {
            SqlConnectionStringBuilder consStringBuilder = new SqlConnectionStringBuilder();
            consStringBuilder.UserID = ReadSetting("Name");
            consStringBuilder.Password = ReadSetting("Password");
            consStringBuilder.InitialCatalog = ReadSetting("Database");
            consStringBuilder.DataSource = ReadSetting("DataSource");
            consStringBuilder.ConnectTimeout = 30;

            return consStringBuilder.ConnectionString;
        }

        private static string ReadSetting(string key)
        {
            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings[key] ?? "Not Found";
            return result;
        }
    }
}
