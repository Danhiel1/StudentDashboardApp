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
        public int CountTeacher()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Giao_Vien", conn))
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


        public DataTable GetStudentCountPerNienKhoa()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(@"
        SELECT L.MaNienKhoa, COUNT(*) AS StudentCount
        FROM Sinh_Vien SV
        JOIN Lop L ON SV.MaLop = L.MaLop
        GROUP BY L.MaNienKhoa", conn))

            {
                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
                return dt;
            }
        }
        // ✅ Students per Faculty (Pie / Bar Chart)
        public DataTable GetStudentCountPerFaculty()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(@"
        SELECT K.TenKhoa AS FacultyName, COUNT(SV.MaSV) AS StudentCount
        FROM Sinh_Vien SV
        JOIN Lop L ON SV.MaLop = L.MaLop
        JOIN Nganh N ON L.MaNganh = N.MaNganh
        JOIN Khoa K ON N.MaKhoa = K.MaKhoa
        GROUP BY K.TenKhoa", conn))
            {
                conn.Open();
                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                return dt;
            }
        }


        // ✅ Students per Major (Pie / Bar Chart)
        public DataTable GetStudentCountPerMajor()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(@"
        SELECT N.TenNganh AS MajorName, COUNT(SV.MaSV) AS StudentCount
        FROM Sinh_Vien SV
        JOIN Lop L ON SV.MaLop = L.MaLop
        JOIN Nganh N ON L.MaNganh = N.MaNganh
        GROUP BY N.TenNganh", conn))
            {
                conn.Open();
                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                return dt;
            }
        }

        // ✅ Average GPA per Faculty (Bar Chart)
        public DataTable GetAverageGPAByFaculty()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(@"
        SELECT K.TenKhoa AS FacultyName, AVG(D.DiemTongKet) AS AvgGPA
        FROM Diem D
        JOIN Sinh_Vien SV ON D.MaSV = SV.MaSV
        JOIN Lop L ON SV.MaLop = L.MaLop
        JOIN Khoa K ON L.MaKhoa = K.MaKhoa
        GROUP BY K.TenKhoa", conn))
            {
                conn.Open();
                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                return dt;
            }
        }

        // ✅ Pass vs Fail Ratio (Pie Chart)
        public DataTable GetPassFailRatio()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(@"
        SELECT CASE WHEN D.DiemTongKet >= 5 THEN 'Pass' ELSE 'Fail' END AS Result,
               COUNT(*) AS CountResult
        FROM Diem D
        GROUP BY CASE WHEN D.DiemTongKet >= 5 THEN 'Pass' ELSE 'Fail' END", conn))
            {
                conn.Open();
                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                return dt;
            }
        }

        // ✅ Teachers per Faculty (Pie Chart)
        public DataTable GetTeacherCountPerFaculty()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(@"
        SELECT K.TenKhoa AS FacultyName, COUNT(GV.MaGV) AS TeacherCount
        FROM Giao_Vien GV
        JOIN Khoa K ON GV.MaKhoa = K.MaKhoa
        GROUP BY K.TenKhoa", conn))
            {
                conn.Open();
                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                return dt;
            }
        }

        // ✅ Top 5 Students by GPA (Bar Chart Horizontal)
        public DataTable GetTop5Students()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(@"
        SELECT TOP 5 SV.TenSV AS StudentName, AVG(D.DiemTongKet) AS AvgGPA
        FROM Diem D
        JOIN Sinh_Vien SV ON D.MaSV = SV.MaSV
        GROUP BY SV.TenSV
        ORDER BY AvgGPA DESC", conn))
            {
                conn.Open();
                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                return dt;
            }
        }


    }
}
