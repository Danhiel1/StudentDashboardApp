using DevExpress.CodeParser;
using DevExpress.XtraBars;
using DevExpress.XtraCharts;
using System;
using System.Linq;
using System.Data.SqlClient;
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
            navigationFrame1.Visible = false;
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
                themsinhvienpage.PageVisible = false;
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
            showallthongke.PageVisible = false;
            themsinhvienpage.PageVisible = false;
            suasinhvienpage.PageVisible = true;
            navigationFrame1.SelectedPage = suasinhvienpage;
        }

        private void barButtonItem5_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            showallthongke.PageVisible = false;
            suasinhvienpage.PageVisible = false;
            navigationFrame1.Visible = true;
            themsinhvienpage.PageVisible = true;
            navigationFrame1.SelectedPage = themsinhvienpage;
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

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox[] tbs = { textBox1, textBox2, textBox3, textBox4, textBox5 };
            foreach (var tb in tbs)
            {
                tb.Clear();
            }
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

            suasinhvienpage.PageVisible = false;
            themsinhvienpage.PageVisible = false;
            showallthongke.PageVisible = true;
            navigationFrame1.SelectedPage = showallthongke;
        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }
    }
}
