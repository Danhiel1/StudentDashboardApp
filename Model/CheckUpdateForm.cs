using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using StudentDashboardApp.Services;

namespace StudentDashboardApp.Model
{
    public partial class CheckUpdateForm : XtraForm
    {
        private readonly UpdateService _updateService;

        public CheckUpdateForm()
        {
            InitializeComponent();
            _updateService = new UpdateService(
                "https://raw.githubusercontent.com/Danhiel1/StudentDashboardAppUpdate/refs/heads/main/version.json"
            );
        }

        private async void btnCheck_Click(object sender, EventArgs e)
        {
            btnCheck.Enabled = false;
            lblStatus.Text = "🔍 Đang kiểm tra phiên bản...";
            progressBar.EditValue = 20;

            try
            {
                var info = await _updateService.GetRemoteUpdateInfoAsync();
                string current = Properties.Settings.Default.AppVersion;

                progressBar.EditValue = 60;
                lblStatus.Text = $"📦 Phiên bản hiện tại: {current} | Online: {info.version}";

                bool isNew = _updateService.IsNewVersion(current, info.version);

                progressBar.EditValue = 100;

                if (isNew)
                {
                    lblStatus.Text = $"✨ Có bản cập nhật mới ({info.version})!";
                    string msg = $"Đã có phiên bản mới ({info.version}).\n\n📝 Ghi chú:\n{info.changelog}\n\nBạn có muốn mở trang tải không?";
                    if (XtraMessageBox.Show(msg, "Cập nhật mới", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = info.download_url,
                            UseShellExecute = true
                        });
                    }
                }
                else
                {
                    lblStatus.Text = "✅ Bạn đang dùng phiên bản mới nhất.";
                    XtraMessageBox.Show("Bạn đang dùng phiên bản mới nhất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "❌ Lỗi khi kiểm tra cập nhật.";
                XtraMessageBox.Show($"Kiểm tra thất bại:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnCheck.Enabled = true;
                progressBar.EditValue = 0;
            }
        }
    }
}
