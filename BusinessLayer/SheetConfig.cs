using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public static class SheetConfig
    {
        public static readonly Dictionary<string, (string TableName, Dictionary<string, string> Mapping, string[] KeyColumns)> SheetMappings =
            new(StringComparer.OrdinalIgnoreCase)
            {
                { "Khoa", ("Khoa", ExcelMapper.KhoaMapping, new[] { "MaKhoa" }) },
                { "Nganh", ("Nganh", ExcelMapper.NganhMapping, new[] { "MaNganh" }) },
                { "Nien_Khoa", ("Nien_Khoa", ExcelMapper.NienKhoaMapping, new[] { "MaNienKhoa" }) },
                { "Chuong_Trinh_Dao_Tao", ("Chuong_Trinh_Dao_Tao", ExcelMapper.CTDTMapping, new[] { "MaCTDT" }) },
                { "Giao_Vien", ("Giao_Vien", ExcelMapper.GiaoVienMapping, new[] { "MaGV" }) },
                { "Lop", ("Lop", ExcelMapper.LopMapping, new[] { "MaLop" }) },
                { "Sinh_Vien", ("Sinh_Vien", ExcelMapper.SinhVienMapping, new[] { "MaSV" }) },
                { "Mon_Hoc", ("Mon_Hoc", ExcelMapper.MonHocMapping, new[] { "MaMon" }) },
                { "Diem", ("Diem", ExcelMapper.DiemMapping, new[] { "MaSV", "MaMon", "MaNienKhoa" }) }
            };
    }
}
