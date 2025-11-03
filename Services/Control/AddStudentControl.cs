using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BusinessLayer;
using DevExpress.XtraBars.ToastNotifications;
using DevExpress.XtraEditors.Controls;

namespace StudentDashboardApp
{
    public partial class AddStudentControl : UserControl
    {
        private readonly StudentService _service;
        private DataTable _nienKhoaCache;
        public AddStudentControl()
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["QLSVConnection"]?.ConnectionString;
            _service = new StudentService(connectionString);

            simpleButtonAdd.Click += OnAddClick;
            textAddClassID.Leave += OnClassIdLeave;
        }

        private void AddStudentControl_Load(object sender, EventArgs e)
        {
            // Nạp niên khóa (nếu cần hiển thị)
            try
            {
                _nienKhoaCache = _service.GetNienKhoaList();
                comboBoxAddSemester1.Properties.Items.Clear();
                foreach (DataRow row in _nienKhoaCache.Rows)
                {
                    comboBoxAddSemester1.Properties.Items.Add(row["TenNienKhoa"].ToString());
                }
            }
            catch { }

            // Cấu hình combobox giới tính
            comboBoxAddGender.Properties.Items.Clear();
            comboBoxAddGender.Properties.Items.AddRange(new[] { "Nam", "Nữ" });
            comboBoxAddGender.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            // Mask ngày sinh dd/MM/yyyy
            textAddlDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            textAddlDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            textAddlDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            // Không cho chọn ngày sau hôm nay
            textAddlDate.Properties.MaxValue = DateTime.Today;

            // Giới hạn nhập SĐT: tối đa 10 ký tự số
            textEditMajorFSTD.Properties.MaxLength = 10;
            textEditMajorFSTD.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            textEditMajorFSTD.Properties.Mask.EditMask = "\\d{0,10}";
            textEditMajorFSTD.Properties.Mask.UseMaskAsDisplayFormat = false;
        }

        private void OnAddClick(object sender, EventArgs e)
        {
            try
            {
                var maSV = textAddID.Text?.Trim();
                var tenSV = textAddFullName.Text?.Trim();
                var ngaySinhStr = textAddlDate.Text?.Trim();
                var gioiTinhInput = comboBoxAddGender.Text?.Trim();
                var email = textAddEmail.Text?.Trim();
                var maLop = textAddClassID.Text?.Trim();
                var diaChi = textAddPlace.Text?.Trim();
                var sdt = textEditMajorFSTD.Text?.Trim();

                if (string.IsNullOrEmpty(maSV) || string.IsNullOrEmpty(tenSV) || string.IsNullOrEmpty(ngaySinhStr) || string.IsNullOrEmpty(gioiTinhInput) || string.IsNullOrEmpty(maLop))
                {
                    ToastNotification.Show("Vui lòng nhập đầy đủ: Mã SV, Tên, Ngày sinh, Giới tính, Mã lớp.", "warning", 5000);
                    return;
                }

                // Parse ngày sinh dd/MM/yyyy hoặc yyyy-MM-dd
                var viVN = new CultureInfo("vi-VN");
                if (!DateTime.TryParseExact(ngaySinhStr, new[] { "dd/MM/yyyy", "d/M/yyyy", "yyyy-MM-dd" }, viVN, DateTimeStyles.None, out DateTime ngaySinh))
                {
                    ToastNotification.Show("Ngày sinh không hợp lệ. Định dạng: dd/MM/yyyy.", "error", 6000);
                    return;
                }

                // Không cho ngày sinh sau hôm nay
                if (ngaySinh.Date > DateTime.Today)
                {
                    ToastNotification.Show("Ngày sinh không hợp lệ.", "error", 6000);
                    return;
                }

                // Chuẩn hóa giới tính
                string gioiTinh = null;
                if (string.Equals(gioiTinhInput, "Nam", StringComparison.OrdinalIgnoreCase)) gioiTinh = "Nam";
                else if (string.Equals(gioiTinhInput, "Nữ", StringComparison.OrdinalIgnoreCase) || string.Equals(gioiTinhInput, "Nu", StringComparison.OrdinalIgnoreCase)) gioiTinh = "Nữ";
                if (gioiTinh == null)
                {
                    ToastNotification.Show("Giới tính chỉ nhận 'Nam' hoặc 'Nữ'.", "error", 6000);
                    return;
                }

                if (!string.IsNullOrEmpty(email) && !email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
                {
                    ToastNotification.Show("Email phải để trống hoặc kết thúc bằng @gmail.com.", "error", 6000);
                    return;
                }

                if (!_service.ClassExists(maLop))
                {
                    ToastNotification.Show("Mã lớp không tồn tại.", "error", 6000);
                    return;
                }

                // Validate SĐT: cho phép trống, hoặc 10 số bắt đầu bằng 0
                if (!string.IsNullOrEmpty(sdt) && !Regex.IsMatch(sdt, @"^0\d{9}$"))
                {
                    ToastNotification.Show("Số điện thoại không hợp lệ (định dạng: 0xxxxxxxxx).", "error", 6000);
                    return;
                }

                // Gọi thêm mới
                _service.AddStudent(maSV, tenSV, ngaySinh, gioiTinh, diaChi, sdt, email, maLop);
                ToastNotification.Show("Thêm sinh viên thành công!", "success", 4000);

                // Xóa form
                textAddID.Text = string.Empty;
                textAddFullName.Text = string.Empty;
                textAddlDate.Text = string.Empty;
                comboBoxAddGender.EditValue = null;
                textAddEmail.Text = string.Empty;
                textAddClassID.Text = string.Empty;
                textAddPlace.Text = string.Empty;
                textEditMajorFSTD.Text = string.Empty;
                comboBoxAddSemester1.EditValue = null;
            }
            catch (Exception ex)
            {
                ToastNotification.Show("Lỗi khi thêm: " + ex.Message, "error", 6000);
            }
        }

        private void OnClassIdLeave(object sender, EventArgs e)
        {
            try
            {
                var maLop = textAddClassID.Text?.Trim();
                if (string.IsNullOrEmpty(maLop)) return;
                var maNk = _service.GetNienKhoaByClassId(maLop);
                if (string.IsNullOrEmpty(maNk)) return;

                if (_nienKhoaCache == null)
                    _nienKhoaCache = _service.GetNienKhoaList();

                foreach (DataRow row in _nienKhoaCache.Rows)
                {
                    if (string.Equals(row["MaNienKhoa"].ToString(), maNk, StringComparison.OrdinalIgnoreCase))
                    {
                        comboBoxAddSemester1.EditValue = row["TenNienKhoa"].ToString();
                        break;
                    }
                }
            }
            catch { }
        }
    }
}
