using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class StudentPerNienKhoa
    {
        public string MaNienKhoa { get; set; }
        public int StudentCount { get; set; }

    }

        // SV theo khoa
        public class StudentPerFaculty
        {
            public string FacultyName { get; set; }
            public int StudentCount { get; set; }
        }

        // SV theo ngành
        public class StudentPerMajor
        {
            public string MajorName { get; set; }
            public int StudentCount { get; set; }
        }

        // Điểm trung bình theo khoa
        public class AverageGPAByFaculty
        {
            public string FacultyName { get; set; }
            public decimal AverageGPA { get; set; }
        }

        // Tỉ lệ Đậu/Rớt
        public class PassFailRatio
        {
            public string Status { get; set; }   // "Pass" hoặc "Fail"
            public int Count { get; set; }
        }

        // Số lượng giảng viên theo khoa
        public class TeacherPerFaculty
        {
            public string FacultyName { get; set; }
            public int TeacherCount { get; set; }
        }

        // Top sinh viên GPA cao
        public class TopStudent
        {
            public string StudentName { get; set; }
            public decimal GPA { get; set; }
        }
    }


