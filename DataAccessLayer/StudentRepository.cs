using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public class StudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // ✅ BulkInsert: Nạp dữ liệu nhanh vào SQL
        public void BulkInsert(DataTable dt, string tableName)
        {
            if (dt == null || dt.Rows.Count == 0) return;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlBulkCopy bulk = new SqlBulkCopy(conn))
                {
                    bulk.DestinationTableName = tableName;
                    bulk.BatchSize = 1000; // xử lý theo lô
                    bulk.BulkCopyTimeout = 60;

                    foreach (DataColumn col in dt.Columns)
                    {
                        bulk.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                    }

                    bulk.WriteToServer(dt);
                }
            }
        }

        // ✅ Đếm số lượng sinh viên
        public int CountStudents()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Sinh_Vien", conn))
            {
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        // ✅ Upsert (Insert nếu chưa có, Update nếu tồn tại)
        public void Upsert(string tableName, string keyColumn, DataTable data)
        {
            if (data == null || data.Rows.Count == 0) return;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                // lấy danh sách khóa hiện có trong DB
                HashSet<string> existing = new HashSet<string>();
                using (SqlCommand cmd = new SqlCommand($"SELECT {keyColumn} FROM {tableName}", conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        existing.Add(reader[keyColumn].ToString());
                    }
                }

                foreach (DataRow row in data.Rows)
                {
                    string keyValue = row[keyColumn].ToString();

                    if (existing.Contains(keyValue)) // update
                    {
                        string setClause = string.Join(", ",
                            data.Columns.Cast<DataColumn>()
                            .Where(c => c.ColumnName != keyColumn)
                            .Select(c => $"{c.ColumnName}=@{c.ColumnName}"));

                        string updateSql = $"UPDATE {tableName} SET {setClause} WHERE {keyColumn}=@{keyColumn}";

                        using (SqlCommand updateCmd = new SqlCommand(updateSql, conn))
                        {
                            foreach (DataColumn col in data.Columns)
                            {
                                updateCmd.Parameters.AddWithValue("@" + col.ColumnName, row[col] ?? DBNull.Value);
                            }
                            updateCmd.ExecuteNonQuery();
                        }
                    }
                    else // insert
                    {
                        string cols = string.Join(", ", data.Columns.Cast<DataColumn>().Select(c => c.ColumnName));
                        string vals = string.Join(", ", data.Columns.Cast<DataColumn>().Select(c => "@" + c.ColumnName));

                        string insertSql = $"INSERT INTO {tableName} ({cols}) VALUES ({vals})";

                        using (SqlCommand insertCmd = new SqlCommand(insertSql, conn))
                        {
                            foreach (DataColumn col in data.Columns)
                            {
                                insertCmd.Parameters.AddWithValue("@" + col.ColumnName, row[col] ?? DBNull.Value);
                            }
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}
