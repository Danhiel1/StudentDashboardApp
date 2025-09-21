﻿using System.Collections.Generic;
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

        public int GetStudentCount()
        {
            return _repo.CountStudents();
        }

        // 1. Lấy số lượng SV theo niên khóa
        public List<StudentPerNienKhoa> GetStudentCountPerNienKhoa()
        {
            DataTable dt = _repo.GetStudentCountPerNienKhoa();

            return dt.AsEnumerable()
                .Select(r => new StudentPerNienKhoa
                {
                    MaNienKhoa = r.Field<string>("MaNienKhoa"),
                    StudentCount = r.Field<int>("StudentCount")
                }).ToList();
        }

        // 2. Lấy số lượng SV theo khoa
        public List<StudentPerFaculty> GetStudentCountPerFaculty()
        {
            DataTable dt = _repo.GetStudentCountPerFaculty();

            return dt.AsEnumerable()
                .Select(r => new StudentPerFaculty
                {
                    FacultyName = r.Field<string>("FacultyName"),
                    StudentCount = r.Field<int>("StudentCount")
                }).ToList();
        }

        // 3. Lấy số lượng SV theo ngành
        public List<StudentPerMajor> GetStudentCountPerMajor()
        {
            DataTable dt = _repo.GetStudentCountPerMajor();

            return dt.AsEnumerable()
                .Select(r => new StudentPerMajor
                {
                    MajorName = r.Field<string>("MajorName"),
                    StudentCount = r.Field<int>("StudentCount")
                }).ToList();
        }

        // 4. Lấy điểm trung bình GPA theo khoa
        public List<AverageGPAByFaculty> GetAverageGPAByFaculty()
        {
            DataTable dt = _repo.GetAverageGPAByFaculty();

            return dt.AsEnumerable()
                .Select(r => new AverageGPAByFaculty
                {
                    FacultyName = r.Field<string>("FacultyName"),
                    AverageGPA = r.Field<decimal>("AverageGPA")
                }).ToList();
        }

        // 5. Lấy tỷ lệ đậu/rớt
        public List<PassFailRatio> GetPassFailRatio()
        {
            DataTable dt = _repo.GetPassFailRatio();

            return dt.AsEnumerable()
                .Select(r => new PassFailRatio
                {
                    Status = r.Field<string>("Status"),
                    Count = r.Field<int>("Count")
                }).ToList();
        }

        // 6. Lấy số lượng giảng viên theo khoa
        public List<TeacherPerFaculty> GetTeacherCountPerFaculty()
        {
            DataTable dt = _repo.GetTeacherCountPerFaculty();

            return dt.AsEnumerable()
                .Select(r => new TeacherPerFaculty
                {
                    FacultyName = r.Field<string>("FacultyName"),
                    TeacherCount = r.Field<int>("TeacherCount")
                }).ToList();
        }

        // 7. Lấy Top 5 sinh viên GPA cao nhất
        public List<TopStudent> GetTop5Students()
        {
            DataTable dt = _repo.GetTop5Students();

            return dt.AsEnumerable()
                .Select(r => new TopStudent
                {
                    StudentName = r.Field<string>("StudentName"),
                    GPA = r.Field<decimal>("GPA")
                }).ToList();
        }
    }
}
