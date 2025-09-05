using System;
using System.Data;
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

        public void BulkInsert(DataTable dt, string tableName)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlBulkCopy bulk = new SqlBulkCopy(conn))
                {
                    bulk.DestinationTableName = tableName;

                    foreach (DataColumn col in dt.Columns)
                    {
                        bulk.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                    }

                    bulk.WriteToServer(dt);
                }
            }
        }


        // ✅ Đếm số lượng sinh viên trong DB
        public int CountStudents()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Sinh_Vien", conn))
                {
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

    }
    public static class ExcelMapper
    {
        // KHOA
        public static readonly Dictionary<string, string> KhoaMapping = new()
    {
        { "Mã khoa", "MaKhoa" },
        { "Tên khoa", "TenKhoa" }
    };

        // NGÀNH
        public static readonly Dictionary<string, string> NganhMapping = new()
    {
        { "Mã ngành", "MaNganh" },
        { "Tên ngành", "TenNganh" },
        { "Mã khoa", "MaKhoa" }
    };

        // NIÊN KHÓA
        public static readonly Dictionary<string, string> NienKhoaMapping = new()
    {
        { "Mã niên khóa", "MaNienKhoa" },
        { "Tên niên khóa", "TenNienKhoa" },
        { "Năm bắt đầu", "NamBatDau" },
        { "Năm kết thúc", "NamKetThuc" }
    };

        // CHƯƠNG TRÌNH ĐÀO TẠO
        public static readonly Dictionary<string, string> CTDTMapping = new()
    {
        { "Mã CTDT", "MaCTDT" },
        { "Tên CTDT", "TenCTDT" },
        { "Mã ngành", "MaNganh" }
    };

        // GIÁO VIÊN
        public static readonly Dictionary<string, string> GiaoVienMapping = new()
    {
        { "Mã GV", "MaGV" },
        { "Tên GV", "TenGV" },
        { "Ngày sinh", "NgaySinh" },
        { "Giới tính", "GioiTinh" },
        { "Email", "Email" },
        { "Mã khoa", "MaKhoa" },
        { "Học vị", "HocVi" },
        { "Chuyên môn", "ChuyenMon" }
    };

        // LỚP
        public static readonly Dictionary<string, string> LopMapping = new()
    {
        { "Mã lớp", "MaLop" },
        { "Tên lớp", "TenLop" },
        { "Mã ngành", "MaNganh" },
        { "Mã CTDT", "MaCTDT" },
        { "Mã niên khóa", "MaNienKhoa" },
        { "Mã GVCN", "MaGVCN" }
    };

        // SINH VIÊN
        public static readonly Dictionary<string, string> SinhVienMapping = new()
    {
        { "Mã SV", "MaSV" },
        { "Tên SV", "TenSV" },
        { "Ngày sinh", "NgaySinh" },
        { "Nơi sinh", "NoiSinh" },
        { "Mã lớp", "MaLop" },
        { "Giới tính", "GioiTinh" },
        { "Email", "Email" },
        { "Năm học", "NamHoc" }
    };

        // MÔN HỌC
        public static readonly Dictionary<string, string> MonHocMapping = new()
    {
        { "Mã CTDT", "MaCTDT" },
        { "Mã môn", "MaMon" },
        { "Tên môn", "TenMon" },
        { "Mã GV", "MaGV" },
        { "Thời gian lý thuyết", "ThoiGianLyThuyet" },
        { "Thời gian thực hành", "ThoiGianThucHanh" },
        { "Số tín chỉ", "SoTinChi" }
    };

        // ĐIỂM
        public static readonly Dictionary<string, string> DiemMapping = new()
    {
        { "Mã SV", "MaSV" },
        { "Mã môn", "MaMon" },
        { "Học kỳ", "HocKy" },
        { "Mã niên khóa", "MaNienKhoa" },
        { "Điểm thường xuyên", "DiemThuongXuyen" },
        { "Điểm định kỳ", "DiemDinhKy" },
        { "Điểm trung bình", "DiemTrungBinh" },
        { "Điểm thi", "DiemThi" },
        { "Điểm tổng kết", "DiemTongKet" }
    };

        // Hàm MapColumns
        public static DataTable MapColumns(DataTable dt, Dictionary<string, string> mapping)
        {
            foreach (var map in mapping)
            {
                if (dt.Columns.Contains(map.Key))
                    dt.Columns[map.Key].ColumnName = map.Value;
            }
            return dt;
        }
    }
}

