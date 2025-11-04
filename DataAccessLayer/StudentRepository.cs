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
        public DataTable GetNienKhoaList()
        {
            string sql = "SELECT MaNienKhoa, CONCAT(NamBatDau, '-', NamKetThuc) AS TenNienKhoa FROM Nien_Khoa ORDER BY NamBatDau";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                var dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                return dt;
            }
        }

        public string GetNienKhoaByClassId(string maLop)
        {
            const string sql = "SELECT MaNienKhoa FROM Lop WHERE MaLop = @MaLop";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaLop", maLop);
                conn.Open();
                var result = cmd.ExecuteScalar();
                return result == null || result == DBNull.Value ? null : result.ToString();
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

        private DataTable ExecuteDataTable(string sql, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                conn.Open();
                var dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                return dt;
            }
        }
        public DataTable GetStudentsByCriteria(string maSV, string tenSV, string ngaySinh, string gioiTinh, string diaChi, string sdt, string email, string maLop, string maNienKhoa)
        {
            string sql = @"SELECT MaSV, TenSV, NgaySinh, GioiTinh, DiaChi, Email, MaLop, SDT 
                   FROM Sinh_Vien 
                   WHERE 1 = 1";

            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(maSV)) { sql += " AND MaSV LIKE @MaSV"; parameters.Add(new SqlParameter("@MaSV", $"%{maSV}%")); }
            if (!string.IsNullOrEmpty(tenSV)) { sql += " AND TenSV LIKE @TenSV"; parameters.Add(new SqlParameter("@TenSV", $"%{tenSV}%")); }
            if (!string.IsNullOrEmpty(ngaySinh)) { sql += " AND CONVERT(VARCHAR, NgaySinh, 23) = @NgaySinh"; parameters.Add(new SqlParameter("@NgaySinh", ngaySinh)); }
            if (!string.IsNullOrEmpty(gioiTinh)) { sql += " AND GioiTinh = @GioiTinh"; parameters.Add(new SqlParameter("@GioiTinh", gioiTinh)); }
            if (!string.IsNullOrEmpty(diaChi)) { sql += " AND DiaChi LIKE @DiaChi"; parameters.Add(new SqlParameter("@DiaChi", $"%{diaChi}%")); }
            if (!string.IsNullOrEmpty(sdt)) { sql += " AND SDT LIKE @SDT"; parameters.Add(new SqlParameter("@SDT", $"%{sdt}%")); }
            if (!string.IsNullOrEmpty(email)) { sql += " AND Email LIKE @Email"; parameters.Add(new SqlParameter("@Email", $"%{email}%")); }
            if (!string.IsNullOrEmpty(maLop)) { sql += " AND MaLop = @MaLop"; parameters.Add(new SqlParameter("@MaLop", maLop)); }
            if (!string.IsNullOrEmpty(maNienKhoa)) { sql += " AND MaLop IN (SELECT MaLop FROM Lop WHERE MaNienKhoa = @MaNienKhoa)"; parameters.Add(new SqlParameter("@MaNienKhoa", maNienKhoa)); }

            return ExecuteDataTable(sql, parameters.ToArray());
        }
        public void AddStudent(string maSV, string tenSV, DateTime ngaySinh, string gioiTinh, string diaChi, string dienThoai, string email, string maLop)
        {
          
            string sql = @"INSERT INTO Sinh_Vien (MaSV, TenSV, NgaySinh, GioiTinh, DiaChi, SDT, Email, MaLop)
                   VALUES (@MaSV, @TenSV, @NgaySinh, @GioiTinh, @DiaChi, @SDT, @Email, @MaLop)";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                cmd.Parameters.AddWithValue("@TenSV", tenSV);
                cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                // Xử lý giá trị null (DBNull.Value) cho các trường tùy chọn/có thể null
                cmd.Parameters.AddWithValue("@DiaChi", (object)diaChi ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SDT", (object)dienThoai ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MaLop", (object)maLop ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public bool StudentExists(string maSV)
        {
            string sql = "SELECT COUNT(1) FROM Sinh_Vien WHERE MaSV = @MaSV";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public DataTable GetStudentById(string maSv)
        {
            string sql = @"SELECT MaSV, TenSV, NgaySinh, GioiTinh, DiaChi, Email, MaLop, SDT
                            FROM Sinh_Vien WHERE MaSV = @MaSV";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaSV", maSv);
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
                sv.TenSV, 
                sv.NgaySinh, 
                sv.GioiTinh, 
                l.TenLop, 
                k.TenKhoa 
            FROM Sinh_Vien sv
            LEFT JOIN Lop l ON sv.MaLop = l.MaLop
            LEFT JOIN Nganh n ON l.MaNganh = n.MaNganh
            LEFT JOIN Khoa k ON n.MaKhoa = k.MaKhoa
            ORDER BY sv.MaSV DESC";

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

        public void UpdateStudent(string maSV, string tenSV, DateTime ngaySinh, string gioiTinh, string diaChi, string sdt, string email, string maLop)
        {
            string sql = @"UPDATE Sinh_Vien
                           SET TenSV = @TenSV,
                               NgaySinh = @NgaySinh,
                               GioiTinh = @GioiTinh,
                               DiaChi = @DiaChi,
                               SDT = @SDT,
                               Email = @Email,
                               MaLop = @MaLop
                           WHERE MaSV = @MaSV";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                cmd.Parameters.AddWithValue("@TenSV", tenSV);
                cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                cmd.Parameters.AddWithValue("@DiaChi", (object)diaChi ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SDT", (object)sdt ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MaLop", (object)maLop ?? DBNull.Value);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStudent(string maSv)
        {
            const string sql = "DELETE FROM Sinh_Vien WHERE MaSV = @MaSV";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaSV", maSv);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public bool ClassExists(string maLop)
        {
            string sql = "SELECT COUNT(1) FROM Lop WHERE MaLop = @MaLop";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaLop", maLop);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }
    }
}