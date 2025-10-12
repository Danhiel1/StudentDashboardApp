using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace StudentDashboardApp.Forms
{
    public partial class ActivityLogForm : XtraForm
    {
        private string logFile = Path.Combine(Application.StartupPath, "activity_logs.csv");

        public ActivityLogForm()
        {
            InitializeComponent();
            LoadLogs();
        }

        // ===== LOAD LOGS =====
        private void LoadLogs()
        {
            if (!File.Exists(logFile))
            {
                CreateEmptyLogFile();
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("Time");
            dt.Columns.Add("User");
            dt.Columns.Add("Action");
            dt.Columns.Add("Details");

            var lines = File.ReadAllLines(logFile);
            for (int i = 1; i < lines.Length; i++) // bỏ dòng tiêu đề
            {
                var parts = lines[i].Split(',');
                if (parts.Length >= 4)
                    dt.Rows.Add(parts[0], parts[1], parts[2], parts[3]);
            }

            gridControl1.DataSource = dt;
        }

        private void CreateEmptyLogFile()
        {
            File.WriteAllText(logFile, "Time,User,Action,Details\n");
        }

        // ===== EXPORT LOGS =====
        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Excel Files|*.xlsx",
                FileName = $"ActivityLogs_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    gridView1.ExportToXlsx(sfd.FileName);
                    XtraMessageBox.Show("✅ Logs exported successfully!", "Export Logs",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // ===== CLEAR LOGS =====
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure you want to clear all logs?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CreateEmptyLogFile();
                LoadLogs();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ======= STATIC: ghi log từ nơi khác =======
        public static void WriteLog(string user, string action, string details)
        {
            string logFile = Path.Combine(Application.StartupPath, "activity_logs.csv");
            if (!File.Exists(logFile))
                File.WriteAllText(logFile, "Time,User,Action,Details\n");

            string line = $"{DateTime.Now:G},{user},{action},{details}";
            File.AppendAllText(logFile, line + Environment.NewLine);
        }
    }
}
