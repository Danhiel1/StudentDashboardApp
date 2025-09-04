using DevExpress.CodeParser;
using DevExpress.XtraBars;
using DevExpress.XtraCharts;
using System;
using System.Linq;
using System.Data.SqlClient;
using System.Data;


using DevExpress.XtraCharts.Native;

namespace StudentDashboardApp.Model
{
    public partial class DashboardStudent : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public DashboardStudent()
        {
            InitializeComponent();
        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        private void barDockingMenuItem1_ListItemClick_1(object sender, ListItemClickEventArgs e)
        {

        }
        private void barListItem1_ListItemClick(object sender, ListItemClickEventArgs e)
        {


        }
        private void barListItem2_ListItemClick(object sender, ListItemClickEventArgs e)
        {

        }
        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {

            ImportForm frm = new ImportForm();
            frm.ShowDialog();
        }
        private void xtraOpenFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
        private void DashboardStudent_Load(object sender, EventArgs e)
        {
            nav.Visible = false;
            LoadSinhVien();
            panel4.Visible = false;
            // Opacity = 150 (0-255), Màu = xám đậm (32,32,32)
            //BlurHelper.EnableBlur(this);
        }
        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
        }
        private void ribbon_PageGroupCaptionButtonClick(object sender, DevExpress.XtraBars.Ribbon.RibbonPageGroupEventArgs e)
        {


        }
        private void ribbon_SelectedPageChanged(object sender, EventArgs e)
        {
            if (ribbon.SelectedPage.Text != "Sinh Viên")
            {
                nav.Visible = false;
                panel4.Visible = false;
            }
        }
        private void ribbon_Click(object sender, EventArgs e)
        {

        }
        private void barEditItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            #region ẩn hiện các nav và panel
            nav.Visible = true;
            panel4.Visible = false;
            themsinhvienpage.PageVisible = false;
            suasinhvienpage.PageVisible = false;
            tracuu.PageVisible = true;
            nav.SelectedPage = tracuu;
            #endregion

            string mssv = barEditItem1.EditValue?.ToString();//lấy dữ liệu từ baredit vào biến mssv


        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void ribbonStatusBar_Click(object sender, EventArgs e)
        {

        }
        private void navigationPage1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            nav.Visible = true;
            panel4.Visible = true;
            themsinhvienpage.PageVisible = false;
            tracuu.PageVisible = false;
            suasinhvienpage.PageVisible = true;
            nav.SelectedPage = suasinhvienpage;
        }
        private void barButtonItem5_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            panel4.Visible = true;
            nav.Visible = true;
            tracuu.PageVisible = false;
            themsinhvienpage.PageVisible = true;
            suasinhvienpage.PageVisible = false;
            nav.SelectedPage = themsinhvienpage;
        }
        private void label1_Click_1(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
        private void themsinhvienpage_Paint(object sender, PaintEventArgs e)
        {

        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {
            textBox2.Focus();
        }
        private void label3_Click(object sender, EventArgs e)
        {
            textBox3.Focus();
        }
        private void label5_Click(object sender, EventArgs e)
        {
            textBox5.Focus();
        }
        private void label4_Click(object sender, EventArgs e)
        {
            textBox4.Focus();
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void button5_Click(object sender, EventArgs e)
        {

        }
        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }
        private void label21_Click(object sender, EventArgs e)
        {
            textBox21.Focus();
        }
        private void label39_Click(object sender, EventArgs e)
        {
            textBox39.Focus();
        }
        private void label41_Click(object sender, EventArgs e)
        {
            textBox41.Focus();
        }
        private void label40_Click(object sender, EventArgs e)
        {
            textBox40.Focus();
        }
        private void textBox38_TextChanged(object sender, EventArgs e)
        {

        }
        private void label38_Click(object sender, EventArgs e)
        {
            textBox38.Focus();
        }
        private void label42_Click(object sender, EventArgs e)
        {
            textBox42.Focus();
        }
        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        private void label44_Click(object sender, EventArgs e)
        {

        }
        private void label45_Click(object sender, EventArgs e)
        {

        }
        private void label43_Click(object sender, EventArgs e)
        {

        }
        private void suasinhvienpage_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label47_Click(object sender, EventArgs e)
        {
            textBox43.Focus();
        }
        private void label48_Click(object sender, EventArgs e)
        {
            textBox44.Focus();
        }
        private void label49_Click(object sender, EventArgs e)
        {
            textBox45.Focus();
        }
        private void label52_Click(object sender, EventArgs e)
        {
            textBox48.Focus();
        }
        private void label53_Click(object sender, EventArgs e)
        {
            textBox49.Focus();
        }
        private void button10_Click(object sender, EventArgs e)
        {

        }
        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }
        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label55_Click(object sender, EventArgs e)
        {
            TextBox[] tbs = { textBox43, textBox44, textBox45, textBox48, textBox49 };
            foreach (var tb in tbs)
            {
                tb.Clear();
            }
        }
        //textdulieu
        private void LoadSinhVien()
        {
            string connString = @"Data Source=TUANCHAN;Initial Catalog=QLSV;Persist Security Info=True;User ID=sa;Password=123;Encrypt=False";

            string query = "SELECT MaSV, TenSV, NgaySinh, NoiSinh, MaLop FROM Sinh_Vien";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open(); // ✅ thử mở kết nối
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu trong bảng Sinh_Vien.");
                    }

                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối hoặc query: " + ex.Message);
                }
            }
        }
    }
}
