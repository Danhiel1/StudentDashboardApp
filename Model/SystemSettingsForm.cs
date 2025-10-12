using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Windows.Forms;
using static DevExpress.Utils.Frames.FrameHelper;

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
            SaveSettings(cbDateFormat.Text, cbTimeFormat.Text, cbLanguage.Text);
            XtraMessageBox.Show("✅ Settings saved successfully!",
                "System Parameters", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
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
