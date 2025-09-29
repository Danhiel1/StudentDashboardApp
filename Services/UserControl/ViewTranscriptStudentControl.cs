using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentDashboardApp
{
    public partial class ViewTranscriptStudentControl : UserControl
    {
        public ViewTranscriptStudentControl()
        {
            InitializeComponent();
        }

        private void ViewTranscriptStudentControl_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaMon");
            dt.Columns.Add("TenMon");
            dt.Columns.Add("TinChi", typeof(int));
            dt.Columns.Add("DiemGiuaKy", typeof(double));
            dt.Columns.Add("DiemCuoiKy", typeof(double));
            dt.Columns.Add("DiemTong", typeof(double));
            dt.Columns.Add("HeSo", typeof(int));
            dt.Columns.Add("KetQua");

            dt.Rows.Add("MTH101", "Toán cao cấp", 3, 7.5, 8.0, 7.75, 1, "Qua");
            dt.Rows.Add("ENG201", "Tiếng Anh", 2, 6.0, 7.0, 6.5, 1, "Qua");

            gridControl2.DataSource = dt;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
