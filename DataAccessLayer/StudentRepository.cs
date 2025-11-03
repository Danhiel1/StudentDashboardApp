using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class StudentRepository
    {
        private readonly string _connectionString;
        public StudentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // ✅ BulkInsert cơ bản (không async)
        public void BulkInsert(DataTable dt, string tableName)
        {
            if (dt == null || dt.Rows.Count == 0)
                throw new ArgumentException("DataTable rỗng.");

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlBulkCopy bulk = new SqlBulkCopy(conn))
                {
                    bulk.DestinationTableName = tableName;
                    bulk.BatchSize = 1000;
                    foreach (DataColumn col in dt.Columns)
                        bulk.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                    bulk.WriteToServer(dt);
                }
            }
        }

        public int CountStudents() => ExecuteCount("SELECT COUNT(*) FROM Sinh_Vien");
        public int CountTeacher() => ExecuteCount("SELECT COUNT(*) FROM Giao_Vien");
        public int CountMajors() => ExecuteCount("SELECT COUNT(*) FROM Nganh");

        private int ExecuteCount(string sql)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    try { return Convert.ToInt32(cmd.ExecuteScalar()); }
                    catch (SqlException ex) when (ex.Number == 208) { return 0; } // Bảng không tồn tại
                }
            }
            return 0;
        }

        // ✅ Upsert (Insert nếu chưa có, Update nếu có)
        public void Upsert(string tableName, string[] keyColumns, DataTable data)
        {
            if (data == null || data.Rows.Count == 0) return;
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string tempTable = $"#Temp_{Guid.NewGuid():N}";
                string createSql = $"CREATE TABLE {tempTable} (" +
                    string.Join(",", data.Columns.Cast<DataColumn>()
                    .Select(c => $"[{c.ColumnName}] {GetSqlType(c.DataType)}")) + ")";
                new SqlCommand(createSql, conn).ExecuteNonQuery();

                using (var bulk = new SqlBulkCopy(conn))
                {
                    bulk.DestinationTableName = tempTable;
                    bulk.WriteToServer(data);
                }

                string onClause = string.Join(" AND ", keyColumns.Select(k => $"target.[{k}] = source.[{k}]"));
                string updateSet = string.Join(", ", data.Columns.Cast<DataColumn>()
                    .Where(c => !keyColumns.Contains(c.ColumnName))
                    .Select(c => $"target.[{c.ColumnName}] = source.[{c.ColumnName}]"));
                string cols = string.Join(", ", data.Columns.Cast<DataColumn>().Select(c => $"[{c.ColumnName}]"));

                string merge = $@"
                    MERGE {tableName} AS target
                    USING {tempTable} AS source
                    ON {onClause}
                    WHEN MATCHED THEN UPDATE SET {updateSet}
                    WHEN NOT MATCHED THEN INSERT ({cols}) VALUES ({string.Join(", ", data.Columns.Cast<DataColumn>().Select(c => $"source.[{c.ColumnName}]"))});";

                new SqlCommand(merge, conn).ExecuteNonQuery();
                new SqlCommand($"DROP TABLE {tempTable}", conn).ExecuteNonQuery();
            }
        }

        private string GetSqlType(Type t)
        {
            if (t == typeof(int)) return "INT";
            if (t == typeof(long)) return "BIGINT";
            if (t == typeof(decimal)) return "DECIMAL(18,2)";
            if (t == typeof(double) || t == typeof(float)) return "FLOAT";
            if (t == typeof(DateTime)) return "DATETIME";
            if (t == typeof(bool)) return "BIT";
            return "NVARCHAR(MAX)";
        }

        // ✅ Các truy vấn thống kê
        public DataTable GetStudentCountPerNienKhoa() =>
            ExecuteDataTable(@"SELECT L.MaNienKhoa, COUNT(*) AS StudentCount
                               FROM Sinh_Vien SV JOIN Lop L ON SV.MaLop = L.MaLop
                               GROUP BY L.MaNienKhoa");

        public DataTable GetStudentCountPerFaculty() =>
            ExecuteDataTable(@"SELECT K.TenKhoa AS FacultyName, COUNT(SV.MaSV) AS StudentCount
                               FROM Sinh_Vien SV
                               JOIN Lop L ON SV.MaLop = L.MaLop
                               JOIN Nganh N ON L.MaNganh = N.MaNganh
                               JOIN Khoa K ON N.MaKhoa = K.MaKhoa
                               GROUP BY K.TenKhoa");

        public DataTable GetStudentCountPerMajor() =>
            ExecuteDataTable(@"SELECT N.TenNganh AS MajorName, COUNT(SV.MaSV) AS StudentCount
                               FROM Sinh_Vien SV
                               JOIN Lop L ON SV.MaLop = L.MaLop
                               JOIN Nganh N ON L.MaNganh = N.MaNganh
                               GROUP BY N.TenNganh");

        public DataTable GetAverageGPAByFaculty() =>
            ExecuteDataTable(@"SELECT K.TenKhoa AS FacultyName, AVG(D.DiemTongKet) AS AverageGPA
                               FROM Diem D
                               JOIN Sinh_Vien SV ON D.MaSV = SV.MaSV
                               JOIN Lop L ON SV.MaLop = L.MaLop
                               JOIN Khoa K ON L.MaKhoa = K.MaKhoa
                               GROUP BY K.TenKhoa");

        public DataTable GetPassFailRatio() =>
            ExecuteDataTable(@"SELECT CASE WHEN D.DiemTongKet >= 5 THEN 'Pass' ELSE 'Fail' END AS Status,
                                      COUNT(*) AS Count
                               FROM Diem D
                               GROUP BY CASE WHEN D.DiemTongKet >= 5 THEN 'Pass' ELSE 'Fail' END");

        public DataTable GetTeacherCountPerFaculty() =>
            ExecuteDataTable(@"SELECT K.TenKhoa AS FacultyName, COUNT(GV.MaGV) AS TeacherCount
                               FROM Giao_Vien GV
                               JOIN Khoa K ON GV.MaKhoa = K.MaKhoa
                               GROUP BY K.TenKhoa");

        public DataTable GetTop5Students() =>
            ExecuteDataTable(@"SELECT TOP 5 SV.TenSV AS StudentName, AVG(D.DiemTongKet) AS GPA
                               FROM Diem D
                               JOIN Sinh_Vien SV ON D.MaSV = SV.MaSV
                               GROUP BY SV.TenSV
                               ORDER BY GPA DESC");

        private DataTable ExecuteDataTable(string sql)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                var dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                return dt;
            }
        }
    
    private int GetCountFromDB(string tableName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = $"SELECT COUNT(*) FROM {tableName}"; // 
                    SqlCommand cmd = new SqlCommand(query, conn);
                    return (int)cmd.ExecuteScalar(); // 
                }
            }
            catch
            {
                return 0; // 
            }
        }

        public int GetKhoaCount() => GetCountFromDB("Khoa"); // 

        public DataTable GetStudentDataForOverview()
        {
            try
            {
                string query = @"
            SELECT TOP 100 
                sv.MaSV, 
                sv.HoTen AS TenSV, 
                sv.NgaySinh, 
                sv.GioiTinh, 
                l.TenLop, 
                k.TenKhoa 
            FROM Sinh_Vien sv
            LEFT JOIN Lop l ON sv.MaLop = l.MaLop
            LEFT JOIN Nganh n ON l.MaNganh = n.MaNganh
            LEFT JOIN Khoa k ON n.MaKhoa = k.MaKhoa
            ORDER BY sv.MaSV DESC"; // 

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt; // 
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi truy vấn dữ liệu sinh viên: " + ex.Message); // 
            }
        }
    }
}