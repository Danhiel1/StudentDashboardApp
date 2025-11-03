using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace StudentDashboardApp
{
    public static class ToastNotification
    {
        public static void Show(string message, string type = "info", int durationMs = 4000)
        {
            // Tạm thời dùng XtraMessageBox để bảo đảm compile và hiển thị thông báo.
            // durationMs không áp dụng cho MessageBox (modal).
            var icon = MessageBoxIcon.Information;
            switch (type?.ToLower())
            {
                case "success":
                    icon = MessageBoxIcon.Information; break;
                case "warning":
                    icon = MessageBoxIcon.Warning; break;
                case "error":
                    icon = MessageBoxIcon.Error; break;
            }
            XtraMessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, icon);
        }

        public static void Error(string message)
        {
            Show(message, "error");
        }

        public static void Warning(string message)
        {
            Show(message, "warning");
        }

        public static void Success(string message)
        {
            Show(message, "success");
        }
    }
}


