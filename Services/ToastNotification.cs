using System;
using System.Drawing;
using System.Windows.Forms;
using StudentDashboardApp.Resources; // để dùng LanguageHelper.GetString

namespace StudentDashboardApp.Services
{
    public static class ToastNotification
    {
        private static System.Windows.Forms.Timer showTimer;
        private static System.Windows.Forms.Timer hideTimer;
        private static Panel toastPanel;
        private static Label toastLabel;
        private static int startY;
        private static int targetY;
        private static bool isShowing = false;

        // ✅ Hàm tìm form Dashboard đang mở
        private static Form GetDashboardForm()
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == "DashboardStudent") // hoặc dùng frm is DashboardStudent
                    return frm;
            }
            return null;
        }

        public static void Show(string messageKey, string type = "info", int duration = 4000)
        {
            // ✅ Lấy text theo ngôn ngữ
            string message = LanguageHelper.GetString(messageKey) ?? messageKey;

            if (isShowing) return;

            // ✅ Luôn hiển thị trên Dashboard
            Form dashboard = GetDashboardForm();
            if (dashboard == null) return;

            isShowing = true;

            toastPanel = new Panel
            {
                Size = new Size(400, 50),
                BackColor = GetColorByType(type),
                BorderStyle = BorderStyle.FixedSingle
            };

            toastLabel = new Label
            {
                Text = "   " + message,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Regular)
            };

            toastPanel.Controls.Add(toastLabel);
            dashboard.Controls.Add(toastPanel);
            toastPanel.BringToFront();

            // 🔹 Vị trí hiển thị (trượt xuống)
            startY = -toastPanel.Height;
            targetY = 20;
            toastPanel.Location = new Point((dashboard.Width - toastPanel.Width) / 2, startY);

            showTimer = new System.Windows.Forms.Timer { Interval = 10 };
            showTimer.Tick += (s, e) =>
            {
                if (toastPanel.Top < targetY)
                    toastPanel.Top += 5;
                else
                    showTimer.Stop();
            };
            showTimer.Start();

            // 🔹 Ẩn sau vài giây
            hideTimer = new System.Windows.Forms.Timer { Interval = duration };
            hideTimer.Tick += (s, e) =>
            {
                hideTimer.Stop();
                FadeOut(dashboard);
            };
            hideTimer.Start();
        }

        private static void FadeOut(Form dashboard)
        {
            var fadeTimer = new System.Windows.Forms.Timer { Interval = 15 };
            int alpha = 255;

            fadeTimer.Tick += (s, e) =>
            {
                alpha -= 15;
                if (alpha <= 0)
                {
                    fadeTimer.Stop();
                    dashboard.Controls.Remove(toastPanel);
                    toastPanel.Dispose();
                    isShowing = false;
                }
                else
                {
                    toastPanel.BackColor = Color.FromArgb(alpha, toastPanel.BackColor);
                }
            };

            fadeTimer.Start();
        }

        private static Color GetColorByType(string type)
        {
            switch (type.ToLower())
            {
                case "success": return Color.FromArgb(46, 204, 113);
                case "error": return Color.FromArgb(231, 76, 60);
                case "warning": return Color.FromArgb(241, 196, 15);
                default: return Color.FromArgb(52, 152, 219);
            }
        }

        // ✅ Hàm rút gọn
        public static void Success(string messageKey, int duration = 4000)
            => Show(messageKey, "success", duration);

        public static void Error(string messageKey, int duration = 4000)
            => Show(messageKey, "error", duration);

        public static void Warning(string messageKey, int duration = 4000)
            => Show(messageKey, "warning", duration);

        public static void Info(string messageKey, int duration = 4000)
            => Show(messageKey, "info", duration);
    }
}
