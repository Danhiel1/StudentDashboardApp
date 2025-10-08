using BusinessLayer;
using BusinessLayer.Models;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraCharts;
using StudentDashboardApp.Controls;
using StudentDashboardApp.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StudentDashboardApp.Model
{
    public partial class DashboardStudent : RibbonForm
    {
        private string _connectionString;
        private StudentService _service;
        private NavigationService navService;
        private NavigationHelper navHelper;
        private bool _isDbConnected = false;

        // Constructor có tham số
        public DashboardStudent(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _service = new StudentService(_connectionString);
        }

        // Constructor mặc định
        public DashboardStudent() : this(ConfigurationManager.ConnectionStrings["QLSVConnection"].ConnectionString) { }

        private void DashboardStudent_Load(object sender, EventArgs e)
        {
            // ⚡ 1️⃣ Thử kiểm tra kết nối trước
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    _isDbConnected = true;
                }
            }
            catch
            {
                _isDbConnected = false;
                MessageBox.Show(
                    "⚠️ Không thể kết nối CSDL.\nỨng dụng vẫn hoạt động nhưng không có dữ liệu.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }

            // ⚡ 2️⃣ Luôn khởi tạo giao diện (kể cả khi DB lỗi)
            InitializeDashboardUI();

            // ⚡ 3️⃣ Nếu kết nối được thì load dữ liệu thật
            if (_isDbConnected)
            {
                LoadDashboardData();
            }
            else
            {
                // 🔹 Nếu không kết nối được thì để số liệu = 0
                infoCardStudent.SetData("Số Sinh Viên", "0", Properties.Resources.student);
                infoCardTeacher.SetData("Số Giáo Viên", "0", Properties.Resources.student);
                infoCardMajor.SetData("Số Ngành", "0", Properties.Resources.student);

                chartControlCountPerNienKhoa.Series.Clear();
                chartControCountPerFaculty.Series.Clear();
            }
        }

        // 👉 Hàm này chỉ dùng để khởi tạo UI, Navigation, Buttons
        private void InitializeDashboardUI()
        {
            AddQuickActionButtons();

            // Map RibbonPage → NavigationPage
            var ribbonMap = new Dictionary<RibbonPage, NavigationPage>
            {
                { ribbonPage1, navigationSystemPage1 },
                { ribbonPage2, navigationPageEmpty },
                { ribbonPage3, navigationPageStudent }
            };

            // Map BarButtonItem → NavigationPage + UserControl
            var buttonMap = new Dictionary<BarButtonItem, (NavigationPage, UserControl)>
            {
                { barButtonItemFindStudent, (navigationPageStudent,new FindStudentControl()) },
                { barButtonItemAddST, (navigationPageStudent, new AddStudentControl()) },
                { barButtonItemEditST,(navigationPageStudent, new EditStudentControl()) },
                { barButtonItemViewTranscript, (navigationPageStudent, new ViewTranscriptStudentControl()) },
                {barButtonItemOverview,(navigationPageEmpty, new Overviewcontrol() ) }
            };

            // Navigation
            navHelper = new NavigationHelper(navigationFrameSTD, buttonMap);
            navigationFrameSTD.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.False;
            navigationFrameSTD.SelectedPage = navigationSystemPage1;
            navigationFrameSTD.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.True;
            navService = new NavigationService(ribbonMap);
        }

        // 👉 Hàm này chỉ load dữ liệu từ SQL
        private void LoadDashboardData()
        {
            try
            {
                infoCardStudent.SetData("Số Sinh Viên", _service.GetStudentCount().ToString(), Properties.Resources.student);
                infoCardTeacher.SetData("Số Giáo Viên", _service.GetTeacherCount().ToString(), Properties.Resources.student);
                infoCardMajor.SetData("Số Ngành", _service.GetMajorCount().ToString(), Properties.Resources.student);

                ChartService.LoadChart(
                    chartControlCountPerNienKhoa,
                    _service.GetStudentCountPerNienKhoa(),
                    "MaNienKhoa",
                    "StudentCount",
                    ViewType.Pie,
                    "Số SV theo Niên khóa"
                );

                ChartService.LoadChart(
                    chartControCountPerFaculty,
                    _service.GetStudentCountPerFaculty(),
                    "FacultyName",
                    "StudentCount",
                    ViewType.Bar,
                    "Số SV theo Khoa"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("⚠️ Lỗi khi tải dữ liệu Dashboard:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Nút đổi server
        private void btnDatabase_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var form = new FormConnectSQL())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _connectionString = form.ConnectionString;
                    _service = new StudentService(_connectionString);

                    // Reload lại dashboard
                    DashboardStudent_Load(null, null);
                }
            }
        }

        // Khi đổi RibbonPage
        private void ribbon_SelectedPageChanged(object sender, EventArgs e)
        {
            try
            {
                if (navService == null || ribbon.SelectedPage == null)
                    return;

                var navPage = navService.GetNavigationPage(ribbon.SelectedPage);
                if (navPage != null)
                {
                    navigationFrameSTD.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.False;
                    navigationFrameSTD.SelectedPage = navPage;
                    navigationFrameSTD.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.True;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("⚠️ Lỗi khi đổi trang: " + ex.Message,
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Các Quick Buttons
        private void AddQuickActionButtons()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.SuspendLayout();

            flowLayoutPanel1.Controls.Add(CreateQuickButton("Thêm sinh viên mới", "Đăng ký học sinh mới vào hệ thống"));
            flowLayoutPanel1.Controls.Add(CreateQuickButton("Cập nhật dữ liệu", "Làm mới thông tin từ cơ sở dữ liệu"));
            flowLayoutPanel1.Controls.Add(CreateQuickButton("Xuất danh sách", "Xuất danh sách sinh viên ra Excel"));

            flowLayoutPanel1.ResumeLayout();
        }

        private QuickActionButton CreateQuickButton(string title, string desc)
        {
            var btn = new QuickActionButton
            {
                Title = title,
                Description = desc,
                Icon = Properties.Resources.close
            };
            btn.Click += (s, e) => MessageBox.Show($"Bạn vừa click: {title}");
            return btn;
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            var importForm = new ImportForm();
            importForm.ShowDialog();
        }
    }
}
