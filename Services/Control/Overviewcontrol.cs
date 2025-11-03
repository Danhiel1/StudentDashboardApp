using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using DevExpress.XtraCharts;

namespace StudentDashboardApp
{
    public partial class Overviewcontrol : UserControl
    {
        private string _connectionString;

        public Overviewcontrol()
        {
            InitializeComponent();
            _connectionString = ConfigurationManager.ConnectionStrings["QLSVConnection"]?.ConnectionString;
        }

        private void Overviewcontrol_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (!string.IsNullOrEmpty(_connectionString))
                LoadOverviewData();
            else
                ClearData();
        }

        // =============== CLEAR DATA ===================
        private void ClearData()
        {
            statCard1.SetData("Tổng Sinh Viên", 0, null);
            statCard2.SetData("Tổng Giáo Viên", 0, null);
            statCard3.SetData("Tổng Số Khoa", 0, null);
            statCard4.SetData("Tổng Số Ngành", 0, null);

            chartControl1.Series.Clear();
            chartControl2.Series.Clear();
            gridControl1.DataSource = null;
        }

        // =============== LOAD DATA ===================
        private void LoadOverviewData()
        {
            try
            {
                statCard1.SetData("Tổng Sinh Viên", GetCount("SINHVIEN"), Properties.Resources.student);
                statCard2.SetData("Tổng Giáo Viên", GetCount("GIAOVIEN"), Properties.Resources.teacher);
                statCard3.SetData("Tổng Số Khoa", GetCount("KHOA"), Properties.Resources.course);
                statCard4.SetData("Tổng Số Ngành", GetCount("NGANH"), Properties.Resources.course);

                LoadChartNienKhoa();
                LoadChartKhoa();
                LoadStudentGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        // =============== HÀM ĐẾM ===============
        private int GetCount(string tableName)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM {tableName}", conn);
                return (int)cmd.ExecuteScalar();
            }
        }

        // =============== BIỂU ĐỒ THEO NIÊN KHÓA ===============
        private void LoadChartNienKhoa()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(@"
                    SELECT MaNienKhoa, COUNT(*) AS SoLuong
                    FROM SINHVIEN
                    GROUP BY MaNienKhoa", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                chartControl2.Series.Clear();
                Series s = new Series("Sinh viên theo Niên khóa", ViewType.Pie);
                s.DataSource = dt;
                s.ArgumentDataMember = "MaNienKhoa";
                s.ValueDataMembers.AddRange("SoLuong");
                s.Label.TextPattern = "{A}: {V} ({VP:p0})";
                chartControl2.Series.Add(s);
            }
        }

        // =============== BIỂU ĐỒ THEO KHOA ===============
        private void LoadChartKhoa()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(@"
                    SELECT K.TenKhoa, COUNT(S.MaSV) AS SoLuong
                    FROM SINHVIEN S
                    JOIN LOP L ON S.MaLop = L.MaLop
                    JOIN KHOA K ON L.MaKhoa = K.MaKhoa
                    GROUP BY K.TenKhoa", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                chartControl1.Series.Clear();
                Series s = new Series("Sinh viên theo Khoa", ViewType.Bar);
                s.DataSource = dt;
                s.ArgumentDataMember = "TenKhoa";
                s.ValueDataMembers.AddRange("SoLuong");
                s.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                chartControl1.Series.Add(s);
            }
        }

        // =============== GRIDVIEW DANH SÁCH SINH VIÊN ===============
        private void LoadStudentGrid()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(@"
                    SELECT MaSV, TenSV, NgaySinh, GioiTinh, TenLop, TenKhoa
                    FROM SINHVIEN S
                    JOIN LOP L ON S.MaLop = L.MaLop
                    JOIN KHOA K ON L.MaKhoa = K.MaKhoa", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gridControl1.DataSource = dt;
                gridView1.BestFitColumns();
            }
        }
    }
}
