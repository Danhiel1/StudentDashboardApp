using BusinessLayer;
using BusinessLayer.Models;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraCharts;
using DevExpress.XtraPrinting;

using StudentDashboardApp.Controls;
using StudentDashboardApp.Forms;
using StudentDashboardApp.Resources;
using StudentDashboardApp.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace StudentDashboardApp.Model
{
    public partial class DashboardStudent : RibbonForm
    {
        private string _connectionString;
        private StudentService _service;
        private NavigationService navService;
        private NavigationHelper navHelper;
        private bool _isDbConnected = false;

        // ✅ Constructor có tham số
        public DashboardStudent(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _service = new StudentService(_connectionString);
        }

        // ✅ Constructor mặc định
        public DashboardStudent()
            : this(ConfigurationManager.ConnectionStrings["QLSVConnection"].ConnectionString)
        { }

        private void DashboardStudent_Load(object sender, EventArgs e)
        {
            UILanguageHelper.ApplyLanguage(this);

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
                infoCardTeachers.SetData("Số Giáo Viên", "0", Properties.Resources.teacher);
                infoCardMajors.SetData("Số Ngành", "0", Properties.Resources.course);
                chartControlCountPerNienKhoa.Series.Clear();
                chartControCountPerFaculty.Series.Clear();
            }
        }

        // 👉 Khởi tạo UI, Navigation, Buttons
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
                { barButtonItemFindStudent, (navigationPageStudent, new FindStudentControl()) },
                { barButtonItemAddST, (navigationPageStudent, new AddStudentControl()) },
                { barButtonItemEditST, (navigationPageStudent, new EditStudentControl()) },
                { barButtonItemViewTranscript, (navigationPageStudent, new ViewTranscriptStudentControl()) },
                { barButtonItemTopStudents, (navigationPageStudent, new TopStudentControl()) },
                { barButtonItemListbyClassorYear, (navigationPageStudent, new ListbyClassorYearControl()) },
                { barButtonItemEditStudentScore, (navigationPageStudent, new EditStudentScoreControl()) },
                { barButtonItemAttendance, (navigationPageStudent, new AttendanceControl()) },
                { barButtonItemOverview, (navigationPageStudent, new Overviewcontrol()) },
            };

            // Navigation
            navHelper = new NavigationHelper(navigationFrameSTD, buttonMap);
            navigationFrameSTD.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.False;
            navigationFrameSTD.SelectedPage = navigationSystemPage1;
            navigationFrameSTD.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.True;
            navService = new NavigationService(ribbonMap);
        }

        // 👉 Load dữ liệu từ SQL
        public void LoadDashboardData()
        {
            try
            {
                string studentText = LanguageHelper.GetString("Students") + ":";
                string teacherText = LanguageHelper.GetString("Teachers") + ":";
                string majorText = LanguageHelper.GetString("Majors") + ":";

                string chartPerYear = LanguageHelper.GetString("Chart_StudentsPerYear");
                string chartPerFaculty = LanguageHelper.GetString("Chart_StudentsPerFaculty");

                infoCardStudent.SetData(
                    studentText,
                    _service.GetStudentCount().ToString(),
                    Properties.Resources.student
                );

                infoCardTeachers.SetData(
                    teacherText,
                    _service.GetTeacherCount().ToString(),
                    Properties.Resources.teacher
                );

                infoCardMajors.SetData(
                    majorText,
                    _service.GetMajorCount().ToString(),
                    Properties.Resources.course
                );

                // Biểu đồ
                ChartService.LoadChart(
                    chartControlCountPerNienKhoa,
                    _service.GetStudentCountPerNienKhoa(),
                    "MaNienKhoa",
                    "StudentCount",
                    ViewType.Pie,
                    chartPerYear
                );

                ChartService.LoadChart(
                    chartControCountPerFaculty,
                    _service.GetStudentCountPerFaculty(),
                    "FacultyName",
                    "StudentCount",
                    ViewType.Bar,
                    chartPerFaculty
                );

                var topStudents = _service.GetTop5Students();
                string chartTop5 = LanguageHelper.GetString("Chart_Top5Students");

                ChartService.LoadChart(
                    chartTop5Students,
                    topStudents,
                    "StudentName",
                    "GPA",
                    ViewType.Bar,
                    chartTop5
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "⚠️ Lỗi khi tải dữ liệu Dashboard:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
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
                MessageBox.Show(
                    "⚠️ Lỗi khi đổi trang: " + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        // Các Quick Buttons
        public void AddQuickActionButtons()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.SuspendLayout();

            flowLayoutPanel1.Controls.Add(CreateQuickButton(
                "addStudent",
                LanguageHelper.GetString("Quick_AddStudent"),
                LanguageHelper.GetString("Quick_AddStudent_Desc"),
                Properties.Resources.add
            ));

            flowLayoutPanel1.Controls.Add(CreateQuickButton(
                "refreshData",
                LanguageHelper.GetString("Quick_RefreshData"),
                LanguageHelper.GetString("Quick_RefreshData_Desc"),
                Properties.Resources.reset
            ));

            flowLayoutPanel1.Controls.Add(CreateQuickButton(
                "exportList",
                LanguageHelper.GetString("Quick_ExportList"),
                LanguageHelper.GetString("Quick_ExportList_Desc"),
                Properties.Resources.export
            ));

            flowLayoutPanel1.ResumeLayout();
        }

        private QuickActionButton CreateQuickButton(string actionKey, string title, string desc, Image icon)
        {
            var btn = new QuickActionButton
            {
                Title = title,
                Description = desc,
                Icon = icon,
                Tag = actionKey
            };

            btn.Click += (s, e) =>
            {
                switch (actionKey)
                {
                    case "addStudent":
                        ShowUserControl(new AddStudentControl(), false);
                        break;

                    case "refreshData":
                        LoadDashboardData();
                        ToastNotification.Show(LanguageHelper.GetString("Msg_RefreshSuccess"), "success", 3000);
                        break;

                    case "exportList":
                        ToastNotification.Show(LanguageHelper.GetString("Msg_ExportComingSoon"), "info", 3000);
                        break;
                }
            };

            return btn;
        }

        private void ShowUserControl(UserControl control, bool useAnimation = true)
        {
            try
            {
                if (!useAnimation)
                    navigationFrameSTD.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.False;

                navigationFrameSTD.SelectedPage = navigationPageStudent;
                navigationPageStudent.Controls.Clear();

                control.Dock = DockStyle.Fill;
                navigationPageStudent.Controls.Add(control);

                navigationFrameSTD.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.True;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "⚠️ Lỗi khi hiển thị UserControl:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            var importForm = new ImportForm();

            importForm.ImportCompleted += (s, args) =>
            {
                ToastNotification.Error("MsgSaved");
                MessageBox.Show("🔄 Dữ liệu đã được cập nhật. Làm mới dashboard...");
                LoadDashboardData();
            };

            importForm.ShowDialog();
        }

        private void btnRestore_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                _isDbConnected = false;
                _connectionString = _connectionString ?? string.Empty;
                _service = new StudentService(_connectionString);

                infoCardStudent.SetData(LanguageHelper.GetString("Lbl_StudentCount"), "0", Properties.Resources.student);
                infoCardTeachers.SetData(LanguageHelper.GetString("Lbl_TeacherCount"), "0", Properties.Resources.teacher);
                infoCardMajors.SetData(LanguageHelper.GetString("Lbl_MajorCount"), "0", Properties.Resources.course);

                chartControlCountPerNienKhoa.Series.Clear();
                chartControCountPerFaculty.Series.Clear();
                chartTop5Students.Series.Clear();

                navigationFrameSTD.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.False;
                navigationFrameSTD.SelectedPage = navigationSystemPage1;
                navigationFrameSTD.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.True;

                navigationPageStudent.Controls.Clear();

                ToastNotification.Show(
                    LanguageHelper.GetString("Msg_AppResetSuccess"),
                    "success",
                    10000
                );
            }
            catch (Exception ex)
            {
                ToastNotification.Show(
                    LanguageHelper.GetString("Msg_AppResetError") + ": " + ex.Message,
                    "error",
                    8000
                );
            }
        }

        private void btnParameters_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new SystemSettingsForm();
            frm.ShowDialog();
        }

        private void btnActLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            var logForm = new ActivityLogForm();
            logForm.ShowDialog();
        }

        private void btnCkUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new CheckUpdateForm();
            frm.ShowDialog();
        }

        private void ApplyLanguage(Control parent = null)
        {
            parent ??= this;

            // 🟢 1️⃣ Duyệt toàn bộ control WinForms
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl.Tag is string tagKey && !string.IsNullOrEmpty(tagKey))
                    ctrl.Text = LanguageHelper.GetString(tagKey);

                if (ctrl is ChartControl chart)
                {
                    foreach (var t in chart.Titles.OfType<ChartTitle>())
                    {
                        if (t.Tag is string chartKey && !string.IsNullOrEmpty(chartKey))
                            t.Text = LanguageHelper.GetString(chartKey);
                    }
                }

                if (ctrl.HasChildren)
                    ApplyLanguage(ctrl);
            }

            // 🟢 2️⃣ Duyệt RibbonControl (DevExpress)
            var ribbonControls = parent.Controls.OfType<RibbonControl>();
            foreach (var ribbon in ribbonControls)
            {
                foreach (BarItem item in ribbon.Items.OfType<BarItem>())
                {
                    if (item.Tag is string tagKey && !string.IsNullOrEmpty(tagKey))
                        item.Caption = LanguageHelper.GetString(tagKey);
                }

                foreach (RibbonPage page in ribbon.Pages)
                {
                    if (page.Tag is string pageKey && !string.IsNullOrEmpty(pageKey))
                        page.Text = LanguageHelper.GetString(pageKey);

                    foreach (RibbonPageGroup group in page.Groups)
                    {
                        if (group.Tag is string groupKey && !string.IsNullOrEmpty(groupKey))
                            group.Text = LanguageHelper.GetString(groupKey);
                    }
                }
            }

            // 🟢 3️⃣ Duyệt BarManager (nếu form có)
            if (this is DevExpress.XtraEditors.XtraForm formWithBars)
            {
                var field = formWithBars.GetType()
                    .GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    .FirstOrDefault(f => f.FieldType == typeof(BarManager));

                if (field?.GetValue(formWithBars) is BarManager barManager)
                {
                    foreach (BarItem item in barManager.Items.OfType<BarItem>())
                    {
                        if (item.Tag is string tagKey && !string.IsNullOrEmpty(tagKey))
                            item.Caption = LanguageHelper.GetString(tagKey);
                    }
                }
            }
        }
    }
}
