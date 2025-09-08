using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
public static class  ExcelMapper
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

        public static DataTable MapColumns(DataTable dt, Dictionary<string, string> mapping)
        {
            foreach (var map in mapping)
            {
                if (dt.Columns.Contains(map.Key))
                {
                    var column = dt.Columns[map.Key];
                    if (column != null)
                    {
                        column.ColumnName = map.Value;
                    }
                }
            }
            return dt;
        }
    }
}
