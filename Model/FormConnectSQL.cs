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

            // Cho phép nhập tay trong combo
            cboServer.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            cboDatabase.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;

            rdoWindowsAuth.Checked = true;
            ToggleAuth();
        }

        private void rdoWindowsAuth_CheckedChanged(object sender, EventArgs e)
        {
            ToggleAuth();
        }

        private void rdoSqlAuth_CheckedChanged(object sender, EventArgs e)
        {
            ToggleAuth();
        }

        private void ToggleAuth()
        {
            bool sqlAuth = rdoSqlAuth.Checked;
            txtUsername.Enabled = sqlAuth;
            txtPassword.Enabled = sqlAuth;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string conn = BuildConnectionString();
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    XtraMessageBox.Show("✅ Kết nối thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("❌ Kết nối thất bại:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string connStr = BuildConnectionString();

            // Test trước khi lưu
            if (TestConnection(connStr))
            {
                // ✅ Nếu kết nối được → Lưu connection string
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                if (config.ConnectionStrings.ConnectionStrings["QLSVConnection"] == null)
                {
                    config.ConnectionStrings.ConnectionStrings.Add(
                        new ConnectionStringSettings("QLSVConnection", connStr));
                }
                else
                {
                    config.ConnectionStrings.ConnectionStrings["QLSVConnection"].ConnectionString = connStr;
                }

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");

                // Trả về cho Program.cs
                this.ConnectionString = connStr;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("❌ Kết nối thất bại! Vui lòng kiểm tra lại thông tin.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool TestConnection(string connStr)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnLoadDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                string conn = rdoWindowsAuth.Checked
                    ? $"Server={cboServer.Text};Database=master;Trusted_Connection=True;Encrypt=False;"
                    : $"Server={cboServer.Text};Database=master;User Id={txtUsername.Text};Password={txtPassword.Text};Encrypt=False;";

                using (SqlConnection sql = new SqlConnection(conn))
                {
                    sql.Open();
                    var cmd = new SqlCommand("SELECT name FROM sys.databases", sql);
                    var reader = cmd.ExecuteReader();

                    cboDatabase.Properties.Items.Clear();
                    while (reader.Read())
                    {
                        cboDatabase.Properties.Items.Add(reader["name"].ToString());
                    }
                }

                XtraMessageBox.Show("📂 Đã tải danh sách Database", "Thông báo");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("❌ Không thể tải Database:\n" + ex.Message, "Lỗi");
            }
        }

        private string BuildConnectionString()
        {
            if (rdoWindowsAuth.Checked)
            {
                return $"Server={cboServer.Text};Database={cboDatabase.Text};Trusted_Connection=True;Encrypt=False;";
            }
            else
            {
                return $"Server={cboServer.Text};Database={cboDatabase.Text};User Id={txtUsername.Text};Password={txtPassword.Text};Encrypt=False;";
            }
        }

        private void FormConnectSQL_Load(object sender, EventArgs e)
        {
            // Gợi ý server
            cboServer.Properties.Items.AddRange(new object[]
            {
                ".",
                @"localhost\SQLEXPRESS",
                @"MAYTINH\SQLSERVER"
            });

            // Gợi ý database test
            cboDatabase.Properties.Items.AddRange(new object[]
            {
                "master",
                "tempdb"
            });

            // Cho phép vừa nhập vừa chọn
            cboServer.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            cboDatabase.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;

            cboServer.Properties.DropDownRows = 10;
            cboDatabase.Properties.DropDownRows = 10;

            // Load connection string đã lưu (nếu có)
            string conn = ConfigurationManager.ConnectionStrings["QLSVConnection"]?.ConnectionString;
            if (!string.IsNullOrEmpty(conn))
            {
                var builder = new SqlConnectionStringBuilder(conn);
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
}
