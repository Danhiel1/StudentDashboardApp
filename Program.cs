using StudentDashboardApp.Model;
using StudentDashboardApp.Resources;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace StudentDashboardApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Lấy connection string trong config
            string connStr = ConfigurationManager.ConnectionStrings["QLSVConnection"]?.ConnectionString;

            if (string.IsNullOrEmpty(connStr) || !TestConnection(connStr))
            {
                // Nếu chưa có hoặc sai → bắt buộc mở FormConnectSQL
                using (var form = new FormConnectSQL())
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        connStr = form.ConnectionString;
                        // Mở Dashboard khi kết nối thành công
                        Application.Run(new DashboardStudent(connStr));
                        LanguageHelper.ApplyLanguage(Properties.Settings.Default.Language);
                    }
                }
            }
            else
            {
                // Nếu có sẵn kết nối hợp lệ → mở Dashboard luôn
                Application.Run(new DashboardStudent(connStr));
                LanguageHelper.ApplyLanguage(Properties.Settings.Default.Language);
            }
        }

        private static bool TestConnection(string connStr)
        {
            try
            {
                using (var conn = new System.Data.SqlClient.SqlConnection(connStr))
                {
                    conn.Open();
                    return true;
                }
            }
            catch { return false; }
        }
    }
}
