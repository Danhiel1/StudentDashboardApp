using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using StudentDashboardApp.Model;
using StudentDashboardApp.Resources;
using System;
using System.Windows.Forms;
using static DevExpress.Utils.Frames.FrameHelper;
using StudentDashboardApp.Services;
namespace StudentDashboardApp.Forms
{
    public partial class SystemSettingsForm : XtraForm
    {
        public SystemSettingsForm()
        {
            InitializeComponent();
            this.LookAndFeel.SkinName = "The Bezier"; // giao diện đẹp
            LoadSettings();
        }

        private void LoadSettings()
        {
            cbDateFormat.Text = Properties.Settings.Default.DateFormat;
            cbTimeFormat.Text = Properties.Settings.Default.TimeFormat;
            cbLanguage.Text = Properties.Settings.Default.Language;
            if (string.IsNullOrEmpty(Properties.Settings.Default.DateFormat))
                Properties.Settings.Default.DateFormat = "dd/MM/yyyy";
            if (string.IsNullOrEmpty(Properties.Settings.Default.TimeFormat))
                Properties.Settings.Default.TimeFormat = "HH:mm:ss";
            if (string.IsNullOrEmpty(Properties.Settings.Default.Language))
                Properties.Settings.Default.Language = "English";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ToastNotification.Success("MsgSaved");


            // 1️⃣ Lưu cài đặt
            SaveSettings(cbDateFormat.Text, cbTimeFormat.Text, cbLanguage.Text);

            // 2️⃣ Áp dụng ngôn ngữ
            LanguageHelper.ApplyLanguage(cbLanguage.Text);

            // 3️⃣ Duyệt toàn bộ form đang mở
            foreach (Form frm in Application.OpenForms)
            {
                UILanguageHelper.ApplyLanguage(frm);

                // 🔹 Nếu là Dashboard → load lại dữ liệu để cập nhật text trong chart
                if (frm is DashboardStudent dashboard)
                {
                    dashboard.LoadDashboardData(); // ✅ Gọi lại hàm cập nhật chart
                }
            }
        }







        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveSettings(string date, string time, string lang)
        {
            Properties.Settings.Default.DateFormat = date;
            Properties.Settings.Default.TimeFormat = time;
            Properties.Settings.Default.Language = lang;
            Properties.Settings.Default.Save();
        }
    }
}
