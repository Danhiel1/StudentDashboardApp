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
        public void UpsertGeneric(string tableName, string[] keyColumns, DataTable data)
        {
            _repo.Upsert(tableName, keyColumns, data);
        }

        // ✅ Lấy tổng số sinh viên trong DB
        public int GetStudentCount()
        {
            return _repo.CountStudents();
        }
    }
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
