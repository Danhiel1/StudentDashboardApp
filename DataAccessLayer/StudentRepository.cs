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
        public void Upsert(string tableName, string[] keyColumns, DataTable data)
        {
            if (data == null || data.Rows.Count == 0) return;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                // Tạo bảng tạm
                string tempTable = $"#Temp_{Guid.NewGuid():N}";
                string createTableSql = $"CREATE TABLE {tempTable} (";
                foreach (DataColumn col in data.Columns)
                {
                    string sqlType = GetSqlType(col.DataType);
                    createTableSql += $"[{col.ColumnName}] {sqlType},";
                }
                createTableSql = createTableSql.TrimEnd(',') + ")";
                using (SqlCommand createCmd = new SqlCommand(createTableSql, conn))
                {
                    createCmd.ExecuteNonQuery();
                }

                // Bulk copy
                using (SqlBulkCopy bulk = new SqlBulkCopy(conn))
                {
                    bulk.DestinationTableName = tempTable;
                    bulk.WriteToServer(data);
                }

                // Ghép nhiều key
                string onClause = string.Join(" AND ",
                    keyColumns.Select(k => $"target.[{k}] = source.[{k}]"));

                string updateSet = string.Join(", ",
                    data.Columns.Cast<DataColumn>()
                    .Where(c => !keyColumns.Contains(c.ColumnName))
                    .Select(c => $"target.[{c.ColumnName}] = source.[{c.ColumnName}]"));

                string cols = string.Join(", ", data.Columns.Cast<DataColumn>().Select(c => $"[{c.ColumnName}]"));
                string vals = string.Join(", ", data.Columns.Cast<DataColumn>().Select(c => $"source.[{c.ColumnName}]"));

                string mergeSql = $@"
            MERGE INTO {tableName} AS target
            USING {tempTable} AS source
            ON {onClause}
            WHEN MATCHED THEN
                UPDATE SET {updateSet}
            WHEN NOT MATCHED THEN
                INSERT ({cols})
                VALUES ({vals});";

                using (SqlCommand mergeCmd = new SqlCommand(mergeSql, conn))
                {
                    mergeCmd.ExecuteNonQuery();
                }

                using (SqlCommand dropCmd = new SqlCommand($"DROP TABLE {tempTable}", conn))
                {
                    dropCmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Chuyển kiểu .NET sang SQL Server
        /// </summary>
        private string GetSqlType(Type type)
        {
            if (type == typeof(int)) return "INT";
            if (type == typeof(long)) return "BIGINT";
            if (type == typeof(decimal)) return "DECIMAL(18,2)";
            if (type == typeof(double) || type == typeof(float)) return "FLOAT";
            if (type == typeof(DateTime)) return "DATETIME";
            if (type == typeof(bool)) return "BIT";
            return "NVARCHAR(MAX)"; // fallback
        }

    }
}
