using DevExpress.CodeParser;
using DevExpress.XtraBars;
using DevExpress.XtraCharts;
using System;
using System.Linq;
using System.Data.SqlClient;
using System.Data;


using DevExpress.XtraCharts.Native;
using BusinessLayer;

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
            navRibbonSinhVien.Visible = false;
            panel4.Visible = false;

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
                navRibbonSinhVien.Visible = false;
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

            // Lấy MSSV từ barEditItem1
            string mssv = barEditItemNhapMssv.EditValue?.ToString();

            // Gọi service
            var service = new StudentService();
            var result = service.checkTextBox(mssv);
            if (result == null)
            {
                MessageBox.Show("Mã Số Sinh Viên Không Được Để Trống");
            }
            else
            {
                MessageBox.Show($"Bạn Chưa Làm Phần Show Thông Tin Tra Cứu.\nMã số bạn nhập là: {result}");
                #region ẩn hiện các nav và panel
                navRibbonSinhVien.Visible = true;
                panel4.Visible = true;
                themsinhvienpage.PageVisible = false;
                suasinhvienpage.PageVisible = false;
                tracuu.PageVisible = true;
                navRibbonSinhVien.SelectedPage = tracuu;
                #endregion
            }


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
            #region ẩn hiện page và panel
            navRibbonSinhVien.Visible = true;
            panel4.Visible = true;
            themsinhvienpage.PageVisible = false;
            tracuu.PageVisible = false;
            suasinhvienpage.PageVisible = true;
            navRibbonSinhVien.SelectedPage = suasinhvienpage;
            #endregion
        }
        private void barButtonItem5_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            #region ẩn hiện page và panel
            panel4.Visible = true;
            navRibbonSinhVien.Visible = true;
            tracuu.PageVisible = false;
            themsinhvienpage.PageVisible = true;
            suasinhvienpage.PageVisible = false;
            navRibbonSinhVien.SelectedPage = themsinhvienpage;
            #endregion
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
            textBoxmssv1.Focus();
        }
        private void label39_Click(object sender, EventArgs e)
        {
            textBoxngaysinh1.Focus();
        }
        private void label41_Click(object sender, EventArgs e)
        {
            textBoxmalop1.Focus();
        }
        private void label40_Click(object sender, EventArgs e)
        {
            textBoxnoisinh.Focus();
        }
        private void textBox38_TextChanged(object sender, EventArgs e)
        {

        }
        private void label38_Click(object sender, EventArgs e)
        {
            textBoxten1.Focus();
        }
        private void label42_Click(object sender, EventArgs e)
        {
            textBoxNhapMssv.Focus();
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
            textBoxMssv2.Focus();
        }
        private void label48_Click(object sender, EventArgs e)
        {
            textBoxTen2.Focus();
        }
        private void label49_Click(object sender, EventArgs e)
        {
            textBoxNgaySinh2.Focus();
        }
        private void label52_Click(object sender, EventArgs e)
        {
            textBoxNoiSinh2.Focus();
        }
        private void label53_Click(object sender, EventArgs e)
        {
            textBoxMaLop2.Focus();
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
            TextBox[] tbs = { textBoxMssv2, textBoxTen2, textBoxNgaySinh2, textBoxNoiSinh2, textBoxMaLop2, textBoxGioiTinh2 };
            foreach (var tb in tbs)
            {
                string tbss = tb.Text;
                if (string.IsNullOrEmpty(tbss))
                {
                    MessageBox.Show("Vui Lòng Điền Đủ Thông Tin.");
                    return;
                }
            }
            MessageBox.Show("Thêm Thành Công");
            TextBox[] tbs1 = { textBoxMssv2, textBoxTen2, textBoxNgaySinh2, textBoxNoiSinh2, textBoxMaLop2, textBoxGioiTinh2 };
            foreach (var tb1 in tbs1)
            {
                tb1.Clear();
            }

        }

        private void label43_Click_1(object sender, EventArgs e)
        {
            textBoxGioiTinh.Focus();
        }

        private void label44_Click_1(object sender, EventArgs e)
        {
            textBoxGioiTinh2.Focus();
        }

        private void label63_Click(object sender, EventArgs e)
        {

        }

        private void textBox58_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox61_TextChanged(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sửa Thành Công");
        }

        private void textBox49_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
