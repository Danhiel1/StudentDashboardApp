using DevExpress.XtraEditors;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentDashboardApp.Model
{
    public partial class FormConnectSQL : XtraForm
    {
        public string ConnectionString { get; private set; }

        public FormConnectSQL()
        {
            InitializeComponent();

            cboServer.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            cboDatabase.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;

            rdoWindowsAuth.Checked = true;
            ToggleAuth();
        }

        private void rdoWindowsAuth_CheckedChanged(object sender, EventArgs e) => ToggleAuth();

        private void rdoSqlAuth_CheckedChanged(object sender, EventArgs e) => ToggleAuth();

        private void ToggleAuth()
        {
            bool isSqlAuth = rdoSqlAuth.Checked;
            txtUsername.Enabled = isSqlAuth;
            txtPassword.Enabled = isSqlAuth;

            if (!isSqlAuth)
            {
                txtUsername.Clear();
                txtPassword.Clear();
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string connStr = BuildConnectionString();
            string message;
            MessageBoxIcon icon;

            if (TryTestConnection(connStr, out string error))
            {
                message = "✅ Kết nối thành công!";
                icon = MessageBoxIcon.Information;
            }
            else
            {
                message = $"❌ Kết nối thất bại:\n{error}";
                icon = MessageBoxIcon.Error;
            }

            XtraMessageBox.Show(message, "Kết quả kiểm tra", MessageBoxButtons.OK, icon);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string connStr = BuildConnectionString();

            if (!TryTestConnection(connStr, out string error))
            {
                XtraMessageBox.Show($"❌ Kết nối thất bại!\n{error}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connSection = config.ConnectionStrings.ConnectionStrings;

                if (connSection["QLSVConnection"] == null)
                {
                    connSection.Add(new ConnectionStringSettings("QLSVConnection", connStr));
                }
                else
                {
                    connSection["QLSVConnection"].ConnectionString = connStr;
                }

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");

                ConnectionString = connStr;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"❌ Lỗi khi lưu cấu hình:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Kiểm tra kết nối và trả về chi tiết lỗi nếu có.
        /// </summary>
        private bool TryTestConnection(string connStr, out string error)
        {
            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    error = string.Empty;
                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnLoadDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                string conn = rdoWindowsAuth.Checked
                    ? $"Server={cboServer.Text};Database=master;Trusted_Connection=True;Encrypt=False;"
                    : $"Server={cboServer.Text};Database=master;User Id={txtUsername.Text};Password={txtPassword.Text};Encrypt=False;";

                using (var sql = new SqlConnection(conn))
                {
                    sql.Open();
                    var cmd = new SqlCommand("SELECT name FROM sys.databases ORDER BY name", sql);
                    var reader = cmd.ExecuteReader();

                    cboDatabase.Properties.Items.Clear();
                    while (reader.Read())
                    {
                        cboDatabase.Properties.Items.Add(reader.GetString(0));
                    }
                }

                XtraMessageBox.Show("📂 Đã tải danh sách Database thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"❌ Không thể tải Database:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string BuildConnectionString()
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = cboServer.Text,
                InitialCatalog = cboDatabase.Text,
                IntegratedSecurity = rdoWindowsAuth.Checked,
                Encrypt = false
            };

            if (!rdoWindowsAuth.Checked)
            {
                builder.UserID = txtUsername.Text;
                builder.Password = txtPassword.Text;
            }

            return builder.ConnectionString;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = BuildConnectionString();

                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    var checkCmd = new SqlCommand("SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SINH_VIEN'", conn);
                    bool tableExists = (int)checkCmd.ExecuteScalar() > 0;

                    if (!tableExists)
                        throw new Exception("Không tìm thấy bảng SINH_VIEN trong database hiện tại!");

                    var dataCmd = new SqlCommand("SELECT TOP 10 * FROM SINH_VIEN", conn);
                    using (var reader = dataCmd.ExecuteReader())
                    {
                        string result = string.Empty;
                        while (reader.Read())
                        {
                            result += reader[0] + "\n";
                        }

                        if (string.IsNullOrWhiteSpace(result))
                            XtraMessageBox.Show("Không có dữ liệu trong bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            XtraMessageBox.Show($"✅ Đã tải dữ liệu thành công!\n\n{result}", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"❌ Lỗi khi tải dữ liệu:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormConnectSQL_Load(object sender, EventArgs e)
        {
            cboServer.Properties.Items.AddRange(new object[] { ".", @"localhost\\SQLEXPRESS", @"MAYTINH\\SQLSERVER" });
            cboDatabase.Properties.Items.AddRange(new object[] { "master", "tempdb" });

            cboServer.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            cboDatabase.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            cboServer.Properties.DropDownRows = cboDatabase.Properties.DropDownRows = 10;

            string savedConn = ConfigurationManager.ConnectionStrings["QLSVConnection"]?.ConnectionString;
            if (string.IsNullOrEmpty(savedConn)) return;

            var builder = new SqlConnectionStringBuilder(savedConn);
            cboServer.Text = builder.DataSource;
            cboDatabase.Text = builder.InitialCatalog;

            if (builder.IntegratedSecurity)
            {
                rdoWindowsAuth.Checked = true;
            }
            else
            {
                rdoSqlAuth.Checked = true;
                txtUsername.Text = builder.UserID;
                txtPassword.Text = builder.Password;
            }
        }
    }
}
