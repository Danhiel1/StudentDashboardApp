using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using BusinessLayer.Models;
using DataAccessLayer;

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

        public int GetStudentCount() => _repo.CountStudents();
        public int GetTeacherCount() => _repo.CountTeacher();
        public int GetMajorCount() => _repo.CountMajors();

        // 1️⃣ SV theo niên khóa
        public List<StudentPerNienKhoa> GetStudentCountPerNienKhoa()
        {
            var dt = _repo.GetStudentCountPerNienKhoa();
            return dt.AsEnumerable().Select(r => new StudentPerNienKhoa
            {
                MaNienKhoa = r.Field<string>("MaNienKhoa"),
                StudentCount = r.Field<int>("StudentCount")
            }).ToList();
        }

        // 2️⃣ SV theo khoa
        public List<StudentPerFaculty> GetStudentCountPerFaculty()
        {
            var dt = _repo.GetStudentCountPerFaculty();
            return dt.AsEnumerable().Select(r => new StudentPerFaculty
            {
                FacultyName = r.Field<string>("FacultyName"),
                StudentCount = r.Field<int>("StudentCount")
            }).ToList();
        }

        // 3️⃣ SV theo ngành
        public List<StudentPerMajor> GetStudentCountPerMajor()
        {
            var dt = _repo.GetStudentCountPerMajor();
            return dt.AsEnumerable().Select(r => new StudentPerMajor
            {
                MajorName = r.Field<string>("MajorName"),
                StudentCount = r.Field<int>("StudentCount")
            }).ToList();
        }

        // 4️⃣ GPA trung bình theo khoa
        public List<AverageGPAByFaculty> GetAverageGPAByFaculty()
        {
            var dt = _repo.GetAverageGPAByFaculty();
            return dt.AsEnumerable().Select(r => new AverageGPAByFaculty
            {
                FacultyName = r.Field<string>("FacultyName"),
                AverageGPA = r.Field<decimal>("AverageGPA")
            }).ToList();
        }

        // 5️⃣ Tỷ lệ đậu/rớt
        public List<PassFailRatio> GetPassFailRatio()
        {
            var dt = _repo.GetPassFailRatio();
            return dt.AsEnumerable().Select(r => new PassFailRatio
            {
                Status = r.Field<string>("Status"),
                Count = r.Field<int>("Count")
            }).ToList();
        }

        // 6️⃣ Giảng viên theo khoa
        public List<TeacherPerFaculty> GetTeacherCountPerFaculty()
        {
            var dt = _repo.GetTeacherCountPerFaculty();
            return dt.AsEnumerable().Select(r => new TeacherPerFaculty
            {
                FacultyName = r.Field<string>("FacultyName"),
                TeacherCount = r.Field<int>("TeacherCount")
            }).ToList();
        }

        // 7️⃣ Top 5 sinh viên GPA cao nhất
        public List<TopStudent> GetTop5Students()
        {
            var dt = _repo.GetTop5Students();
            return dt.AsEnumerable().Select(r => new TopStudent
            {
                StudentName = r.Field<string>("StudentName"),
                GPA = r.Field<decimal>("GPA")
            }).ToList();
        }

        // 🔎 Tìm 1 sinh viên theo mã
        public Student GetStudentById(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV)) return null;
            var dt = _repo.GetStudentById(maSV);
            if (dt.Rows.Count == 0) return null;
            var r = dt.Rows[0];
            return new Student
            {
                MaSV = r.Field<string>("MaSV"),
                TenSV = r.Field<string>("TenSV"),
                NgaySinh = r.Field<DateTime>("NgaySinh"),
                GioiTinh = r.Field<string>("GioiTinh"),
                DiaChi = r.IsNull("DiaChi") ? null : r.Field<string>("DiaChi"),
                Email = r.IsNull("Email") ? null : r.Field<string>("Email"),
                MaLop = r.Field<string>("MaLop"),
                SDT = r.IsNull("SDT") ? null : r.Field<string>("SDT")
            };
        }

        // ✏️ Cập nhật thông tin sinh viên
        public void UpdateStudent(Student s)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            _repo.UpdateStudent(s.MaSV, s.TenSV, s.NgaySinh, s.GioiTinh, s.DiaChi, s.SDT, s.Email, s.MaLop);
        }

        public void DeleteStudent(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV)) throw new ArgumentException("Mã SV không hợp lệ", nameof(maSV));
            _repo.DeleteStudent(maSV);
        }

        // ✅ Kiểm tra mã lớp có tồn tại không
        public bool ClassExists(string maLop)
        {
            if (string.IsNullOrWhiteSpace(maLop)) return false;
            return _repo.ClassExists(maLop);
        }

        // 📄 Danh sách niên khóa (MaNienKhoa, TenNienKhoa)
        public DataTable GetNienKhoaList()
        {
            return _repo.GetNienKhoaList();
        }

        // 🔗 Lấy mã niên khóa theo mã lớp
        public string GetNienKhoaByClassId(string maLop)
        {
            if (string.IsNullOrWhiteSpace(maLop)) return null;
            return _repo.GetNienKhoaByClassId(maLop);
        }

        // ➕ Thêm sinh viên
        public void AddStudent(string maSV, string tenSV, DateTime ngaySinh, string gioiTinh, string diaChi, string sdt, string email, string maLop)
        {
            _repo.AddStudent(maSV, tenSV, ngaySinh, gioiTinh, diaChi, sdt, email, maLop);
        }
    }
}
