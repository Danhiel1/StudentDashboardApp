using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;
using BusinessLayer;
using BusinessLayer.Models;
using StudentDashboardApp.Services;

namespace StudentDashboardApp
{
    public partial class EditStudentControl: UserControl
    {
        private readonly StudentService _studentService;
        private Student _currentStudent;

        public EditStudentControl()
        {
            InitializeComponent();

            var connectionString = ConfigurationManager.ConnectionStrings["QLSVConnection"]?.ConnectionString;
            _studentService = new StudentService(connectionString);

            // Đăng ký event Load
            this.Load += EditStudentControl_Load;

            // Khởi tạo trạng thái ban đầu
            ClearEditControls();
            ToggleEditControls(false);

            // Mặc định ẩn Mã SV và Năm học cho đến khi tìm thấy
            textEditIDFindST.Visible = false;
            EditComboBoxSemester.Visible = false;
            textEditIDFindST.Enabled = false;
            EditComboBoxSemester.Enabled = false;

            // Nạp danh sách niên khóa (để hiển thị và chọn theo lớp của SV)
            LoadNienKhoaList();
        }

        private void EditStudentControl_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            
            // Đảm bảo dữ liệu được load khi control được hiển thị
            LoadNienKhoaList();
        }

        private void LoadNienKhoaList()
        {
            try
            {
                var nk = _studentService.GetNienKhoaList();
                EditComboBoxSemester.Properties.Items.Clear();
                foreach (DataRow row in nk.Rows)
                {
                    // Hiển thị "NamBatDau-NamKetThuc" (TenNienKhoa)
                    EditComboBoxSemester.Properties.Items.Add(row["TenNienKhoa"].ToString());
                }
            }
            catch { /* ignore nếu chưa có DB */ }
        }

        private void OnSearchClick(object sender, EventArgs e)
        {
            string maSV = textEditEnterStudentID.Text?.Trim();
            ClearEditControls();
            ToggleEditControls(false);
            _currentStudent = null;

            if (string.IsNullOrEmpty(maSV))
            {
                ToastNotification.Show("Vui lòng nhập Mã Sinh Viên để tìm kiếm.", "warning", 5000);
                return;
            }

            try
            {
                _currentStudent = _studentService.GetStudentById(maSV);
                if (_currentStudent == null)
                {
                    ToastNotification.Show($"Không tìm thấy sinh viên có Mã SV: {maSV}.", "error", 6000);
                    return;
                }

                LoadStudentToForm(_currentStudent);
                ToggleEditControls(true);
                ToastNotification.Show($"Tìm thấy sinh viên {_currentStudent.TenSV}. Bạn có thể chỉnh sửa.", "success", 4000);
            }
            catch (Exception ex)
            {
                ToastNotification.Show("Lỗi khi tìm kiếm: " + ex.Message, "error", 6000);
            }
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            if (_currentStudent == null)
            {
                ToastNotification.Show("Vui lòng tìm kiếm sinh viên trước.", "warning", 5000);
                return;
            }

            try
            {
                // Lấy dữ liệu từ form + validate theo DB
                _currentStudent.TenSV = textEditFullNameFindSTD.Text?.Trim();

                var viVN = new CultureInfo("vi-VN");
                if (DateTime.TryParseExact(textEditlDateFSTD.Text?.Trim(),
                                           new[] { "dd/MM/yyyy", "d/M/yyyy", "yyyy-MM-dd" },
                                           viVN, DateTimeStyles.None, out DateTime ns))
                {
                    _currentStudent.NgaySinh = ns;
                }
                else
                {
                    ToastNotification.Show("Ngày sinh không hợp lệ. Định dạng đúng: dd/MM/yyyy.", "error", 6000);
                    return;
                }

                var gioiTinhInput = textEditGenderFSTD.Text?.Trim();
                string gioiTinhNormalized = null;
                if (!string.IsNullOrEmpty(gioiTinhInput))
                {
                    if (string.Equals(gioiTinhInput, "Nam", StringComparison.OrdinalIgnoreCase)) gioiTinhNormalized = "Nam";
                    else if (string.Equals(gioiTinhInput, "Nữ", StringComparison.OrdinalIgnoreCase) || string.Equals(gioiTinhInput, "Nu", StringComparison.OrdinalIgnoreCase)) gioiTinhNormalized = "Nữ";
                }
                if (gioiTinhNormalized == null)
                {
                    ToastNotification.Show("Giới tính chỉ nhận 'Nam' hoặc 'Nữ'.", "error", 6000);
                    return;
                }
                _currentStudent.GioiTinh = gioiTinhNormalized;

                _currentStudent.DiaChi = textEditPlaceFSTD.Text?.Trim();
                _currentStudent.SDT = textEditPhoneFSTD.Text?.Trim();
                _currentStudent.Email = textEditEmailTFTD.Text?.Trim();
                if (!string.IsNullOrEmpty(_currentStudent.Email) && !_currentStudent.Email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
                {
                    ToastNotification.Show("Email phải để trống hoặc kết thúc bằng @gmail.com.", "error", 6000);
                    return;
                }

                // Validate SĐT: cho phép trống, hoặc 10 số bắt đầu bằng 0
                if (!string.IsNullOrEmpty(_currentStudent.SDT) && !Regex.IsMatch(_currentStudent.SDT, @"^0\d{9}$"))
                {
                    ToastNotification.Show("Số điện thoại không hợp lệ (định dạng: 0xxxxxxxxx).", "error", 6000);
                    return;
                }

                _currentStudent.MaLop = textEditCLassIDFSTD.Text?.Trim();
                if (string.IsNullOrEmpty(_currentStudent.MaLop) || !_studentService.ClassExists(_currentStudent.MaLop))
                {
                    ToastNotification.Show("Mã lớp không tồn tại.", "error", 6000);
                    return;
                }

                if (string.IsNullOrEmpty(_currentStudent.TenSV))
                {
                    ToastNotification.Show("Tên Sinh Viên không được để trống.", "error", 6000);
                    return;
                }

                _studentService.UpdateStudent(_currentStudent);
                ToastNotification.Show("Đã cập nhật thông tin sinh viên thành công!", "success", 4000);
                ToggleEditControls(false);
            }
            catch (Exception ex)
            {
                ToastNotification.Show("Lỗi khi cập nhật: " + ex.Message, "error", 6000);
            }
        }

        private void LoadStudentToForm(Student s)
        {
            textEditIDFindST.Text = s.MaSV;
            textEditFullNameFindSTD.Text = s.TenSV;
            textEditlDateFSTD.Text = s.NgaySinh.ToString("dd/MM/yyyy");
            textEditGenderFSTD.Text = s.GioiTinh;
            textEditPlaceFSTD.Text = s.DiaChi;
            textEditPhoneFSTD.Text = s.SDT;
            textEditEmailTFTD.Text = s.Email;
            textEditCLassIDFSTD.Text = s.MaLop;

            // Chọn Năm học theo MaLop → MaNienKhoa
            try
            {
                var maNk = _studentService.GetNienKhoaByClassId(s.MaLop);
                if (!string.IsNullOrEmpty(maNk))
                {
                    // Tìm text hiển thị tương ứng trong danh sách đã nạp
                    var nkList = _studentService.GetNienKhoaList();
                    foreach (DataRow row in nkList.Rows)
                    {
                        if (string.Equals(row["MaNienKhoa"].ToString(), maNk, StringComparison.OrdinalIgnoreCase))
                        {
                            var ten = row["TenNienKhoa"].ToString();
                            EditComboBoxSemester.EditValue = ten; // chọn trực tiếp 1 giá trị
                            break;
                        }
                    }
                }
            }
            catch { /* ignore nếu chưa có DB */ }
        }

        private void OnDeleteClick(object sender, EventArgs e)
        {
            if (_currentStudent == null)
            {
                ToastNotification.Show("Vui lòng tìm kiếm sinh viên trước.", "warning", 5000);
                return;
            }

            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa sinh viên: {_currentStudent.MaSV}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                _studentService.DeleteStudent(_currentStudent.MaSV);
                ToastNotification.Show("Đã xóa sinh viên thành công!", "success", 4000);
                _currentStudent = null;
                ClearEditControls();
                ToggleEditControls(false);
            }
            catch (Exception ex)
            {
                ToastNotification.Show("Lỗi khi xóa: " + ex.Message, "error", 6000);
            }
        }

        private void ClearEditControls()
        {
            textEditIDFindST.Text = string.Empty;
            textEditFullNameFindSTD.Text = string.Empty;
            textEditlDateFSTD.Text = string.Empty;
            textEditGenderFSTD.Text = string.Empty;
            textEditPlaceFSTD.Text = string.Empty;
            textEditPhoneFSTD.Text = string.Empty;
            textEditEmailTFTD.Text = string.Empty;
            textEditCLassIDFSTD.Text = string.Empty;
        }

        private void ToggleEditControls(bool enabled)
        {
            // Hiển thị/ẩn và cho phép sửa Mã SV, Năm học sau khi tìm thấy
            textEditIDFindST.Visible = enabled;
            EditComboBoxSemester.Visible = enabled;
            textEditIDFindST.Enabled = enabled;
            EditComboBoxSemester.Enabled = enabled;
            textEditFullNameFindSTD.Enabled = enabled;
            textEditlDateFSTD.Enabled = enabled;
            textEditGenderFSTD.Enabled = enabled;
            textEditPlaceFSTD.Enabled = enabled;
            textEditPhoneFSTD.Enabled = enabled;
            textEditEmailTFTD.Enabled = enabled;
            textEditCLassIDFSTD.Enabled = enabled;
            simpleButtonEditStudent.Enabled = enabled;
        }

        // =============== LOAD DATA KHI CONTROL ĐƯỢC HIỂN THỊ ===================
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            
            // Load dữ liệu khi control được hiển thị
            if (Visible && !DesignMode && _studentService != null)
            {
                // Đảm bảo niên khóa được load khi control được hiển thị
                LoadNienKhoaList();
            }
        }

        // ComboBoxEdit không cần xử lý ItemCheck; chọn trực tiếp một giá trị
    }
}
