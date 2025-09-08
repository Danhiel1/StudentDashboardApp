using DataAccessLayer;
using System.Data;

namespace BusinessLayer
{
    public class StudentService
    {
        private readonly StudentRepository _repo;

        public StudentService(string connectionString)
        {
            _repo = new StudentRepository(connectionString);
        }

        public void ImportGeneric(DataTable dt, string tableName)
        {
            _repo.BulkInsert(dt, tableName);
        }
        public void UpsertGeneric(string tableName, string keyColumn, DataTable data)
        {
            _repo.Upsert(tableName, keyColumn, data);
        }
        // ✅ Lấy tổng số sinh viên trong DB
        public int GetStudentCount()
        {
            return _repo.CountStudents();
        }
    }
    public static class SheetConfig
    {
        public static readonly Dictionary<string, (string TableName, Dictionary<string, string> Mapping, string KeyColumn)> SheetMappings =
            new(StringComparer.OrdinalIgnoreCase)
            {
            { "Khoa", ("Khoa", ExcelMapper.KhoaMapping, "MaKhoa") },
            { "Nganh", ("Nganh", ExcelMapper.NganhMapping, "MaNganh") },
            { "Nien_Khoa", ("Nien_Khoa", ExcelMapper.NienKhoaMapping, "MaNienKhoa") },
            { "Chuong_Trinh_Dao_Tao", ("Chuong_Trinh_Dao_Tao", ExcelMapper.CTDTMapping, "MaCTDT") },
            { "Giao_Vien", ("Giao_Vien", ExcelMapper.GiaoVienMapping, "MaGV") },
            { "Lop", ("Lop", ExcelMapper.LopMapping, "MaLop") },
            { "Sinh_Vien", ("Sinh_Vien", ExcelMapper.SinhVienMapping, "MaSV") },
            { "Mon_Hoc", ("Mon_Hoc", ExcelMapper.MonHocMapping, "MaMon") },
            // Điểm có khóa ghép (MaSV + MaMon + MaNienKhoa), tạm thời không dùng Upsert
            { "Diem", ("Diem", ExcelMapper.DiemMapping, null) }
            };
    }



}
