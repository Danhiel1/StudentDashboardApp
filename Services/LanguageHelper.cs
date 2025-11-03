using System.Collections.Generic;

namespace StudentDashboardApp
{
    public static class LanguageHelper
    {
        private static readonly Dictionary<string, string> _vi = new Dictionary<string, string>
        {
            { "Students", "Số Sinh Viên" },
            { "Teachers", "Số Giáo Viên" },
            { "Majors", "Số Ngành" },
            { "Chart_StudentsPerYear", "Sinh viên theo Niên khóa" },
            { "Chart_StudentsPerFaculty", "Sinh viên theo Khoa" },
            { "Chart_Top5Students", "Top 5 sinh viên GPA cao nhất" },
            { "Msg_AppResetSuccess", "Đã đặt lại giao diện thành công" },
            { "Msg_AppResetError", "Lỗi khi đặt lại ứng dụng" }
        };

        public static string GetString(string key)
        {
            if (string.IsNullOrEmpty(key)) return string.Empty;
            return _vi.TryGetValue(key, out var value) ? value : key;
        }
    }
}


