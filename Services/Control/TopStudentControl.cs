using DevExpress.XtraCharts;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace StudentDashboardApp
{
    public partial class TopStudentControl : UserControl
    {
        private string _connectionString;

        public TopStudentControl()
            : this(ConfigurationManager.ConnectionStrings["QLSVConnection"]?.ConnectionString)
        {
        }

        public TopStudentControl(string connectionString)
        {
            InitializeComponent();
            this._connectionString = connectionString;
        }

        public void UpdateConnectionString(string connectionString)
        {
            _connectionString = connectionString;

            if (string.IsNullOrEmpty(_connectionString))
            {
                gridControl1.DataSource = null;
                chartControl1.Series.Clear();
                chartControl2.Series.Clear();
                // ✅ Đổi tên
                cboNienKhoa.Properties.Items.Clear();
                cboNganh.Properties.Items.Clear();
                cboKhoa.Properties.Items.Clear();

                simpleButton1.Enabled = false;
                // ✅ Đổi tên
                cboNienKhoa.Enabled = false;
                cboNganh.Enabled = false;
                cboKhoa.Enabled = false;
            }
            else
            {
                simpleButton1.Enabled = true;
                // ✅ Đổi tên
                cboNienKhoa.Enabled = true;
                cboNganh.Enabled = true;
                cboKhoa.Enabled = true;

                // ✅ Tải Khoa trước, các hàm khác sẽ được gọi theo chuỗi
                LoadKhoaList();
            }
        }


        private void TopStudentControl_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            SetupGridView();

            if (!string.IsNullOrEmpty(_connectionString))
            {
                // ✅ Tải Khoa trước, các hàm khác sẽ được gọi theo chuỗi
                LoadKhoaList();
            }
            else
            {
                MessageBox.Show("⚠️ Lỗi: Chuỗi kết nối chưa được thiết lập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                simpleButton1.Enabled = false;
                // ✅ Đổi tên
                cboNienKhoa.Enabled = false;
                cboNganh.Enabled = false;
                cboKhoa.Enabled = false;
            }
        }

        private void SetupGridView()
        {
            gridColumnRank.FieldName = "Rank";
            gridColumnIDStudent.FieldName = "MaSV";
            gridColumnFullName.FieldName = "TenSV";
            gridColumnGpa.FieldName = "GPA";
            gridColumnCredits.FieldName = "TongTinChi";
            gridColumnresult.FieldName = "KetQua";

            gridColumnRank.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumnGpa.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumnCredits.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            gridColumnGpa.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumnGpa.DisplayFormat.FormatString = "n1";

            gridView1.BestFitColumns();
        }

        // ✅ HÀM MỚI: Tải danh sách Khoa 
        private void LoadKhoaList()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                cboKhoa.Enabled = false;
                return;
            }

            try
            {
                cboKhoa.Properties.Items.Clear();
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    // ✅ Lấy TenKhoa
                    string query = "SELECT TenKhoa FROM Khoa ORDER BY TenKhoa";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                        cboKhoa.Properties.Items.Add(reader.GetString(0));

                    if (cboKhoa.Properties.Items.Count > 0)
                        cboKhoa.SelectedIndex = 0; // Tự động chọn mục đầu tiên
                }
                cboKhoa.Enabled = true;

                // ✅ Gọi hàm tiếp theo trong chuỗi
                LoadMajorList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("⚠️ Lỗi khi tải danh sách Khoa: " + ex.Message);
                cboKhoa.Enabled = false;
            }
        }


        // ✅ HÀM SỬA LẠI: Tải danh sách Ngành DỰA TRÊN Khoa
        private void LoadMajorList()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                cboNganh.Enabled = false;
                return;
            }

            // Nếu không có Khoa nào được chọn, xóa danh sách Ngành và gọi hàm tiếp
            if (cboKhoa.SelectedItem == null)
            {
                cboNganh.Properties.Items.Clear();
                cboNganh.Enabled = false;
                LoadNienKhoaList(); // ✅ Gọi hàm tiếp theo
                return;
            }

            // ✅ Lấy TenKhoa đã chọn
            string selectedKhoa = cboKhoa.SelectedItem.ToString();

            try
            {
                cboNganh.Properties.Items.Clear();
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    // ✅ Lọc Ngành theo TenKhoa
                    string query = @"
                        SELECT ng.TenNganh 
                        FROM Nganh ng
                        JOIN Khoa k ON ng.MaKhoa = k.MaKhoa
                        WHERE k.TenKhoa = @tenKhoa 
                        ORDER BY ng.TenNganh";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tenKhoa", selectedKhoa); // ✅ Dùng TenKhoa để lọc
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                        cboNganh.Properties.Items.Add(reader.GetString(0));

                    if (cboNganh.Properties.Items.Count > 0)
                        cboNganh.SelectedIndex = 0;
                }
                cboNganh.Enabled = true;

                // ✅ Gọi hàm tiếp theo trong chuỗi
                LoadNienKhoaList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("⚠️ Lỗi khi tải danh sách ngành: " + ex.Message);
                cboNganh.Enabled = false;
            }
        }

        // ✅ HÀM SỬA LẠI: Tải danh sách Niên Khóa
        private void LoadNienKhoaList()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                cboNienKhoa.Enabled = false;
                return;
            }

            try
            {
                cboNienKhoa.Properties.Items.Clear();
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    // ✅ Lấy TenNienKhoa
                    string query = "SELECT TenNienKhoa FROM Nien_Khoa ORDER BY NamBatDau DESC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                        cboNienKhoa.Properties.Items.Add(reader.GetString(0));

                    if (cboNienKhoa.Properties.Items.Count > 0)
                        cboNienKhoa.SelectedIndex = 0;
                }

                simpleButton1.Enabled = true;
                cboNienKhoa.Enabled = true;

                // ✅ Gọi hàm cuối cùng trong chuỗi
                LoadTopStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("⚠️ Lỗi khi tải danh sách niên khóa: " + ex.Message);
                simpleButton1.Enabled = false;
                cboNienKhoa.Enabled = false;
            }
        }

        private void LoadTopStudents()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                MessageBox.Show("⚠️ Lỗi: Không thể tải top sinh viên, chuỗi kết nối rỗng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ Lấy giá trị từ cả 3 combobox
            if (cboNienKhoa.SelectedItem == null || cboNganh.SelectedItem == null || cboKhoa.SelectedItem == null)
            {
                // Nếu 1 trong 3 chưa có giá trị, xóa grid
                gridControl1.DataSource = null;
                chartControl1.Series.Clear();
                chartControl2.Series.Clear();
                return;
            }

            string selectedYear = cboNienKhoa.SelectedItem.ToString();
            string selectedMajor = cboNganh.SelectedItem.ToString();
            string selectedKhoa = cboKhoa.SelectedItem.ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    // ✅ SỬA LỖI SQL: 
                    // Lọc theo TenNienKhoa, TenNganh, và TenKhoa
                    string query = @"
                        WITH StudentGPA AS (
                            SELECT 
                                sv.MaSV,
                                sv.TenSV,
                                nk.TenNienKhoa,
                                ng.TenNganh,
                                k.TenKhoa,
                                AVG(d.DiemTongKet) AS GPA,
                                SUM(mh.SoTinChi) AS TongTinChi
                            FROM Sinh_Vien sv
                            JOIN Diem d ON sv.MaSV = d.MaSV
                            JOIN Mon_Hoc mh ON d.MaMon = mh.MaMon
                            JOIN Nien_Khoa nk ON d.MaNienKhoa = nk.MaNienKhoa
                            JOIN Lop l ON sv.MaLop = l.MaLop
                            JOIN Nganh ng ON l.MaNganh = ng.MaNganh
                            JOIN Khoa k ON ng.MaKhoa = k.MaKhoa
                            WHERE 
                                nk.TenNienKhoa = @nienkhoa 
                                AND ng.TenNganh = @tenNganh 
                                AND k.TenKhoa = @tenKhoa
                            GROUP BY sv.MaSV, sv.TenSV, nk.TenNienKhoa, ng.TenNganh, k.TenKhoa
                        )
                        SELECT TOP 5
                            ROW_NUMBER() OVER (ORDER BY GPA DESC) AS Rank,
                            MaSV,
                            TenSV,
                            TenNienKhoa,
                            GPA,
                            TongTinChi,
                            CASE 
                                WHEN GPA >= 5.0 THEN N'Đạt'
                                ELSE N'Không Đạt'
                            END AS KetQua
                        FROM StudentGPA
                        ORDER BY GPA DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@nienkhoa", selectedYear);
                    da.SelectCommand.Parameters.AddWithValue("@tenNganh", selectedMajor);
                    da.SelectCommand.Parameters.AddWithValue("@tenKhoa", selectedKhoa);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    gridControl1.DataSource = dt;

                    // ✅ Biểu đồ cột
                    chartControl1.Series.Clear();
                    Series series = new Series("Top 5 Students", ViewType.Bar);
                    foreach (DataRow row in dt.Rows)
                    {
                        series.Points.Add(new SeriesPoint(row["TenSV"].ToString(), Convert.ToDouble(row["GPA"])));
                    }
                    chartControl1.Series.Add(series);
                    series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

                    // ✅ Biểu đồ tròn
                    chartControl2.Series.Clear();
                    Series seriesPie = new Series("GPA Distribution", ViewType.Pie);
                    foreach (DataRow row in dt.Rows)
                    {
                        seriesPie.Points.Add(new SeriesPoint(row["TenSV"].ToString(), Convert.ToDouble(row["GPA"])));
                    }
                    chartControl2.Series.Add(seriesPie);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("⚠️ Lỗi khi tải dữ liệu Top sinh viên: " + ex.Message);
            }
        }

        // ✅ HÀM MỚI: Sự kiện khi đổi Khoa
        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_connectionString))
                LoadMajorList(); // Tải lại Ngành (sẽ tự động tải lại Niên Khóa và Grid)
        }

        // ✅ HÀM MỚI: Sự kiện khi đổi Ngành
        private void cboNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_connectionString))
                LoadNienKhoaList(); // Tải lại Niên Khóa (sẽ tự động tải lại Grid)
        }

        // ✅ Đổi tên
        private void cboNienKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_connectionString))
                LoadTopStudents(); // Chỉ tải lại Grid
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // Nút "Enter" sẽ load lại tất cả
            if (!string.IsNullOrEmpty(_connectionString))
                LoadKhoaList();
        }
    }
}
