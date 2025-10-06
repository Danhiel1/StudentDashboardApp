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

namespace StudentDashboardApp.Model
{
    public partial class DashboardStudent : RibbonForm
    {
        private string _connectionString;
        private StudentService _service;
        private NavigationService navService;
        private NavigationHelper navHelper;

        // Constructor có tham số
        public DashboardStudent(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _service = new StudentService(_connectionString);
        }

        // Constructor mặc định → lấy connection string từ App.config
        public DashboardStudent() : this(ConfigurationManager.ConnectionStrings["QLSVConnection"].ConnectionString) { }

        private void DashboardStudent_Load(object sender, EventArgs e)
        {
            // Load InfoCard
            infoCardStudent.SetData("Số Sinh Viên", _service.GetStudentCount().ToString(), Properties.Resources.student);
            infoCardTeacher.SetData("Số Giáo Viên", _service.GetTeacherCount().ToString(), Properties.Resources.student);
            infoCardMajor.SetData("Số Ngành", _service.GetMajorCount().ToString(), Properties.Resources.student);

            // Quick Action
            AddQuickActionButtons();

            // Pie Chart: SV theo niên khóa
            ChartService.LoadChart(
                chartControlCountPerNienKhoa,
                _service.GetStudentCountPerNienKhoa(),
                argumentMember: "MaNienKhoa",
                valueMember: "StudentCount",
                viewType: ViewType.Pie,
                chartTitle: "Số SV theo Niên khóa"
            );

            // Bar Chart: SV theo Khoa
            ChartService.LoadChart(
                chartControCountPerFaculty,
                _service.GetStudentCountPerFaculty(),
                argumentMember: "FacultyName",
                valueMember: "StudentCount",
                viewType: ViewType.Bar,
                chartTitle: "Số SV theo Khoa"
            );

            // Map RibbonPage → NavigationPage
            Dictionary<RibbonPage, NavigationPage> ribbonMap = new Dictionary<RibbonPage, NavigationPage>
            {
                { ribbonPage1, navigationSystemPage1 },
                { ribbonPage2, navigationPageEmpty},
                { ribbonPage3, navigationPageStudent }
            };

            // Map Button → Navigation
            var buttonMap = new Dictionary<BarButtonItem, (NavigationPage, UserControl)>
            {
                { barButtonItemFindStudent, (navigationPageStudent,new FindStudentControl()) },
                { barButtonItemAddST, (navigationPageStudent, new AddStudentControl()) },
                { barButtonItemEditST,(navigationPageStudent, new EditStudentControl()) },
                { barButtonItemViewTranscript, (navigationPageStudent, new ViewTranscriptStudentControl()) }
            };

            // Navigation Helper
            navHelper = new NavigationHelper(navigationFrameSTD, buttonMap);
            navigationFrameSTD.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.False;
            navigationFrameSTD.SelectedPage = navigationSystemPage1; // page mặc định
            navigationFrameSTD.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.True;

            // Navigation Service
            navService = new NavigationService(ribbonMap);
        }

        // Nút đổi server
        private void btnDatabase_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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


        private void ribbon_SelectedPageChanged(object sender, EventArgs e)
        {
            NavigationPage navPage = navService.GetNavigationPage(ribbon.SelectedPage);
            if (navPage != null)
            {
                navigationFrameSTD.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.False;
                navigationFrameSTD.SelectedPage = navPage;
                navigationFrameSTD.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.True;
            }
        }

        private void AddQuickActionButtons()
        {
            // Xóa các nút cũ để không bị nhân đôi
            flowLayoutPanel1.Controls.Clear();

            // Dừng layout để thêm nút nhanh hơn, tránh nhấp nháy
            flowLayoutPanel1.SuspendLayout();

            // Thêm các nút mong muốn
            flowLayoutPanel1.Controls.Add(CreateQuickButton(
                "Thêm sinh viên mới",
                "Đăng ký học sinh mới vào hệ thống"
            ));

            flowLayoutPanel1.Controls.Add(CreateQuickButton(
                "Cập nhật dữ liệu",
                "Làm mới thông tin từ cơ sở dữ liệu"
            ));

            flowLayoutPanel1.Controls.Add(CreateQuickButton(
                "Xuất danh sách",
                "Xuất danh sách sinh viên ra Excel"
            ));

            // Kích hoạt lại layout
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
