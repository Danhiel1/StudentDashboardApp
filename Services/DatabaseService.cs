using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace StudentDashboardApp.Services
{
    internal class DatabaseService
    {
        private readonly string connectionString =
            "Data Source=DESKTOP-QPFPA2B;Initial Catalog=QLSV;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

        public int ExecuteNonQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error executing query: " + ex.Message);
                    return -1; // Indicate failure
                }
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error executing query: " + ex.Message);
                }
            }
            return dataTable;
        }
    }
}
