using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using BusinessLayer;
using BusinessLayer.Models;
using StudentDashboardApp.Services;

namespace StudentDashboardApp
{
    public partial class FindStudentControl: UserControl
    {
        private readonly StudentService _studentService;

        public FindStudentControl()
        {
            InitializeComponent();

            var connectionString = ConfigurationManager.ConnectionStrings["QLSVConnection"]?.ConnectionString;
            _studentService = new StudentService(connectionString);

            // Gắn handler cho nút Tìm và Xóa (gỡ handler cũ trước để tránh lặp)
            simpleButtonEnterStudentID.Click -= OnSearchClick;
            simpleButtonEnterStudentID.Click += OnSearchClick;

            simpleButtonDeleteStudentID.Click -= OnClearClick;
            simpleButtonDeleteStudentID.Click += OnClearClick;

            // Đăng ký event Load
            this.Load += FindStudentControl_Load;

            // Ẩn các ô thông tin ban đầu
            ClearStudentInfo();
        }

        private void FindStudentControl_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            
            // Đảm bảo dữ liệu được khởi tạo khi control được load
            ClearStudentInfo();
        }

        private void OnSearchClick(object sender, EventArgs e)
        {
            var maSV = textFindEnterStudentID.Text?.Trim();

            if (string.IsNullOrEmpty(maSV))
            {
                ToastNotification.Show("Vui lòng nhập trước.", "warning", 5000);
                return;
            }

            try
            {
                var student = _studentService.GetStudentById(maSV);
                if (student == null)
                {
                    ToastNotification.Show($"Không tìm thấy sinh viên có Mã SV: {maSV}.", "error", 6000);
                    ClearStudentInfo();
                    return;
                }

                LoadStudentInfo(student);
                ToastNotification.Show($"Tìm thấy sinh viên {student.TenSV}.", "success", 4000);
            }
            catch (Exception ex)
            {
                ToastNotification.Show("Lỗi khi tìm kiếm: " + ex.Message, "error", 6000);
                ClearStudentInfo();
            }
        }

        private void OnClearClick(object sender, EventArgs e)
        {
            var maSV = textFindEnterStudentID.Text?.Trim();

            if (string.IsNullOrEmpty(maSV))
            {
                ToastNotification.Show("Vui lòng nhập trước.", "warning", 5000);
                return;
            }

            textFindEnterStudentID.Text = string.Empty;
            ClearStudentInfo();
        }

        private void LoadStudentInfo(Student s)
        {
            textFindID.Text = s.MaSV;
            textFindFullName.Text = s.TenSV;
            textFindDate.Text = s.NgaySinh.ToString("dd/MM/yyyy");
            textFindGender.Text = s.GioiTinh;
            textFindPlace.Text = s.DiaChi ?? string.Empty;
            textFindPhone.Text = s.SDT ?? string.Empty;
            textFindEmail1.Text = s.Email ?? string.Empty;
            textFindClassID.Text = s.MaLop ?? string.Empty;

            // Load năm học nếu có
            try
            {
                if (!string.IsNullOrEmpty(s.MaLop))
                {
                    var maNk = _studentService.GetNienKhoaByClassId(s.MaLop);
                    if (!string.IsNullOrEmpty(maNk))
                    {
                        var nkList = _studentService.GetNienKhoaList();
                        foreach (DataRow row in nkList.Rows)
                        {
                            if (string.Equals(row["MaNienKhoa"].ToString(), maNk, StringComparison.OrdinalIgnoreCase))
                            {
                                textFindSemester1.Text = row["TenNienKhoa"].ToString();
                                break;
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void ClearStudentInfo()
        {
            textFindID.Text = string.Empty;
            textFindFullName.Text = string.Empty;
            textFindDate.Text = string.Empty;
            textFindGender.Text = string.Empty;
            textFindPlace.Text = string.Empty;
            textFindPhone.Text = string.Empty;
            textFindEmail1.Text = string.Empty;
            textFindClassID.Text = string.Empty;
            textFindSemester1.Text = string.Empty;
        }

        // =============== LOAD DATA KHI CONTROL ĐƯỢC HIỂN THỊ ===================
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            
            // Đảm bảo control được reset khi được hiển thị
            if (Visible && !DesignMode)
            {
                ClearStudentInfo();
            }
        }
    }
}
