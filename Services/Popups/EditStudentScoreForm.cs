using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentDashboardApp.Services.Popups {
    public partial class EditStudentScoreForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {



        public EditStudentScoreForm(string maSV, string maMon, string tenSV, string tenMon)
        {
            InitializeComponent();

            this._maSV = maSV;
            this._maMon = maMon;

            // Gán thông tin cơ bản lên textbox
            textEditID.Text = maSV;
            textEditFullName.Text = tenSV;
            textEditSubjectID.Text = maMon;
            textEditSubject.Text = tenMon;

            // Tải điểm từ database
            //LoadStudentScores();
        }
        private string _maSV;
        private string _maMon;

        //private void LoadStudentScores()
        //{
        //    string connString = "Data Source=TUANCHAN;Initial Catalog=QLSV;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True";

        //    string query = @"
        //        SELECT 
        //            DiemThuongXuyen, 
        //            DiemDinhKy, 
        //            DiemThi, 
        //            DiemTrungBinh, 
        //            DiemTongKet
        //        FROM Diem
        //        WHERE MaSV = @MaSV AND MaMon = @MaMon";

        //    using (SqlConnection conn = new SqlConnection(connString))
        //    using (SqlCommand cmd = new SqlCommand(query, conn))
        //    {
        //        cmd.Parameters.AddWithValue("@MaSV", _maSV);
        //        cmd.Parameters.AddWithValue("@MaMon", _maMon);

        //        conn.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            textEditRegularScore.Text = reader["DiemThuongXuyen"]?.ToString();
        //            textEditPeriodicScore.Text = reader["DiemDinhKy"]?.ToString();
        //            textEditExamScore.Text = reader["DiemThi"]?.ToString();
        //            textEditAverageScore.Text = reader["DiemTrungBinh"]?.ToString();
        //            textEditFinalGrade.Text = reader["DiemTongKet"]?.ToString();
        //        }
        //        else
        //        {
        //            // Nếu sinh viên chưa có điểm
        //            textEditRegularScore.Text = "";
        //            textEditPeriodicScore.Text = "";
        //            textEditExamScore.Text = "";
        //            textEditAverageScore.Text = "";
        //            textEditFinalGrade.Text = "";
        //        }
        //    }
        //}

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButtonSave_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    // 1️⃣ Lấy dữ liệu từ các ô nhập
            //    string maSV = textEditID.Text.Trim();
            //    string maMon = textEditSubjectID.Text.Trim();

            //    if (string.IsNullOrEmpty(maSV) || string.IsNullOrEmpty(maMon))
            //    {
            //        MessageBox.Show("⚠️ Thiếu mã sinh viên hoặc mã môn học!", "Lỗi nhập liệu");
            //        return;
            //    }

            //    // Kiểm tra rỗng trước khi chuyển kiểu
            //    if (string.IsNullOrWhiteSpace(textEditRegularScore.Text) ||
            //        string.IsNullOrWhiteSpace(textEditPeriodicScore.Text) ||
            //        string.IsNullOrWhiteSpace(textEditExamScore.Text))
            //    {
            //        MessageBox.Show("⚠️ Vui lòng nhập đủ 3 cột điểm!", "Thiếu dữ liệu");
            //        return;
            //    }

            //    decimal diemTX = Convert.ToDecimal(textEditRegularScore.Text);
            //    decimal diemDK = Convert.ToDecimal(textEditPeriodicScore.Text);
            //    decimal diemThi = Convert.ToDecimal(textEditExamScore.Text);

            //    // 2️⃣ Tính tự động điểm trung bình & tổng kết
            //    decimal diemTB = Math.Round((diemTX * 0.2m) + (diemDK * 0.3m) + (diemThi * 0.5m), 2);
            //    decimal diemTongKet = Math.Min(10, Math.Round(diemTB, 1));

            //    textEditAverageScore.Text = diemTB.ToString();
            //    textEditFinalGrade.Text = diemTongKet.ToString();

            //    // 3️⃣ Chuỗi kết nối
            //    string connectionString =
            //        "Data Source=TUANCHAN;Initial Catalog=QLSV;Persist Security Info=True;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True";

            //    // 4️⃣ Câu lệnh UPDATE trước
            //    string updateQuery = @"
            //UPDATE Diem
            //SET 
            //    DiemThuongXuyen = @DiemThuongXuyen,
            //    DiemDinhKy = @DiemDinhKy,
            //    DiemThi = @DiemThi,
            //    DiemTrungBinh = @DiemTrungBinh,
            //    DiemTongKet = @DiemTongKet
            //WHERE MaSV = @MaSV AND MaMon = @MaMon";

            //    using (SqlConnection conn = new SqlConnection(connectionString))
            //    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
            //    {
            //        cmd.Parameters.AddWithValue("@MaSV", maSV);
            //        cmd.Parameters.AddWithValue("@MaMon", maMon);
            //        cmd.Parameters.AddWithValue("@DiemThuongXuyen", diemTX);
            //        cmd.Parameters.AddWithValue("@DiemDinhKy", diemDK);
            //        cmd.Parameters.AddWithValue("@DiemThi", diemThi);
            //        cmd.Parameters.AddWithValue("@DiemTrungBinh", diemTB);
            //        cmd.Parameters.AddWithValue("@DiemTongKet", diemTongKet);

            //        conn.Open();
            //        int rowsAffected = cmd.ExecuteNonQuery();

            //        if (rowsAffected == 0)
            //        {
            //            // 5️⃣ Nếu chưa có điểm → thêm mới
            //            string insertQuery = @"
            //        INSERT INTO Diem (MaSV, MaMon, DiemThuongXuyen, DiemDinhKy, DiemThi, DiemTrungBinh, DiemTongKet)
            //        VALUES (@MaSV, @MaMon, @DiemThuongXuyen, @DiemDinhKy, @DiemThi, @DiemTrungBinh, @DiemTongKet)";
            //            using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
            //            {
            //                insertCmd.Parameters.AddWithValue("@MaSV", maSV);
            //                insertCmd.Parameters.AddWithValue("@MaMon", maMon);
            //                insertCmd.Parameters.AddWithValue("@DiemThuongXuyen", diemTX);
            //                insertCmd.Parameters.AddWithValue("@DiemDinhKy", diemDK);
            //                insertCmd.Parameters.AddWithValue("@DiemThi", diemThi);
            //                insertCmd.Parameters.AddWithValue("@DiemTrungBinh", diemTB);
            //                insertCmd.Parameters.AddWithValue("@DiemTongKet", diemTongKet);
            //                insertCmd.ExecuteNonQuery();
            //            }

            //            MessageBox.Show("✅ Đã thêm mới và lưu điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //        else
            //        {
            //            MessageBox.Show("✅ Cập nhật điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }

            //    // 6️⃣ Đóng form sau khi xử lý xong (chỉ một lần duy nhất)
            //    this.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("❌ Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }


        private decimal TinhDiemTrungBinh(decimal diemTX, decimal diemDK, decimal diemThi)
        {
            // ví dụ: TX: 20%, ĐK: 30%, Thi: 50%
            return Math.Round((diemTX * 0.2m) + (diemDK * 0.3m) + (diemThi * 0.5m), 2);
        }

        private decimal TinhDiemTongKet(decimal diemTB)
        {
            // làm tròn 1 chữ số, tối đa 10
            return Math.Min(10, Math.Round(diemTB, 1));
        }
        private void ValidateScoreInput(object sender, EventArgs e)
        {
            var txt = sender as DevExpress.XtraEditors.TextEdit;
            if (txt == null) return;

            if (decimal.TryParse(txt.Text, out decimal value))
            {
                if (value < 0 || value > 10)
                {
                    MessageBox.Show("⚠️ Điểm phải nằm trong khoảng 0 - 10!",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txt.Text = "0"; // Reset về 0 để tránh lỗi
                }
            }
            else if (!string.IsNullOrWhiteSpace(txt.Text))
            {
                MessageBox.Show("⚠️ Vui lòng nhập số hợp lệ!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt.Text = "0";
            }
        }

        private void EditStudentScoreForm_Load(object sender, EventArgs e)
        {
            // Gán sự kiện kiểm tra nhập điểm cho tất cả ô điểm
            textEditRegularScore.EditValueChanged += ValidateScoreInput;
            textEditPeriodicScore.EditValueChanged += ValidateScoreInput;
            textEditExamScore.EditValueChanged += ValidateScoreInput;
            textEditAverageScore.EditValueChanged += ValidateScoreInput;
            textEditFinalGrade.EditValueChanged += ValidateScoreInput;

        }
    }
}
