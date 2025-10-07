using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentDashboardApp.Services.Popups;
using System.Data.SqlClient;
namespace StudentDashboardApp
{
    public partial class EditStudentScoreControl : UserControl
    {
        public EditStudentScoreControl()
        {
            InitializeComponent();
        }

        private void EditStudentScoreControl_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    // 🔒 Kết nối đến SQL Server
            //    string connectionString =
            //        "Data Source=TUANCHAN;Initial Catalog=QLSV;Persist Security Info=True;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True";

            //    // 🔍 Câu truy vấn lấy dữ liệu
            //    string query = @"
            //        SELECT 
            //            sv.MaSV AS ID,
            //            sv.TenSV AS Name,
            //            mh.MaMon AS SubjectID,
            //            mh.TenMon AS Subject,
            //            d.DiemTongKet AS Score
            //        FROM Diem d
            //        JOIN Sinh_Vien sv ON d.MaSV = sv.MaSV
            //        JOIN Mon_Hoc mh ON d.MaMon = mh.MaMon;";

            //    // 🧠 Mở kết nối và lấy dữ liệu vào DataTable
            //    using (SqlConnection conn = new SqlConnection(connectionString))
            //    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
            //    {
            //        DataTable dt = new DataTable();
            //        da.Fill(dt); // "Múc" dữ liệu từ SQL đổ vào DataTable

            //        // Gán DataTable cho gridControl
            //        gridControl1.DataSource = dt;
            //    }

            //    // 🏷 Gán FieldName (cột trong DataTable) cho từng cột của GridControl
            //    gridColumnIdSJ.FieldName = "ID";
            //    gridColumnNameStudent.FieldName = "Name";
            //    gridColumnSubjectID.FieldName = "SubjectID";
            //    gridColumnSubject.FieldName = "Subject";
            //    gridColumnScore.FieldName = "Score";

            //    // 🖱 Gán sự kiện cho nút Action (Edit)
            //    repositoryItemButtonEdit2.ButtonClick -= RepositoryItemButtonEdit2_ButtonClick;
            //    repositoryItemButtonEdit2.ButtonClick += RepositoryItemButtonEdit2_ButtonClick;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("❌ Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        

        private void RepositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            
            string maSV = gridView1.GetFocusedRowCellValue("ID")?.ToString();
            string tenSV = gridView1.GetFocusedRowCellValue("Name")?.ToString();
            string maMon = gridView1.GetFocusedRowCellValue("SubjectID")?.ToString();
            string tenMon = gridView1.GetFocusedRowCellValue("Subject")?.ToString();

            // 2️⃣ Mở form phụ, truyền 2 mã vào constructor
            EditStudentScoreForm frm = new EditStudentScoreForm(maSV, maMon, tenSV, tenMon);
            frm.ShowDialog();
        }

        private void listStudent1_Load(object sender, EventArgs e)
        {
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
