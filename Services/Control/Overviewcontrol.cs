using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using BusinessLayer;
using StudentDashboardApp.Resources;
using StudentDashboardApp.Services;
using DevExpress.XtraCharts;
using DevExpress.XtraGrid.Views.Grid;

namespace StudentDashboardApp
{
    public partial class Overviewcontrol : UserControl
    {
        private StudentService _studentService;
        private bool _isLoading = false;

        public Overviewcontrol()
        {
            InitializeComponent();
            InitializeService();
            SetupGridView();
            this.Load += Overviewcontrol_Load;
        }

        private void InitializeService()
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["QLSVConnection"]?.ConnectionString;
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new Exception("Không tìm thấy connection string trong config.");
                }
                _studentService = new StudentService(connectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi khởi tạo service: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void SetupGridView()
        {
            if (gridView1 != null)
            {
                // Cấu hình grid view
                gridView1.OptionsView.ShowGroupPanel = false;
                gridView1.OptionsView.ShowAutoFilterRow = true;
                gridView1.OptionsBehavior.Editable = false;
                gridView1.OptionsSelection.MultiSelect = false;
                
                // Đặt format cho cột ngày sinh
                if (gridColumnNgaySinh != null)
                {
                    gridColumnNgaySinh.DisplayFormat.FormatString = "dd/MM/yyyy";
                    gridColumnNgaySinh.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                }
            }
        }

        private void Overviewcontrol_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            
            if (_studentService == null)
            {
                ClearData();
                return;
            }

            LoadOverviewData();
        }

        // =============== CLEAR DATA ===================
        private void ClearData()
        {
            try
            {
                string lblStudents = LanguageHelper.GetString("Students") ?? "Số Sinh Viên";
                string lblTeachers = LanguageHelper.GetString("Teachers") ?? "Số Giáo Viên";
                string lblMajors = LanguageHelper.GetString("Majors") ?? "Số Ngành";
                string lblFaculties = LanguageHelper.GetString("Lbl_FacultyCount") ?? "Tổng Số Khoa";

                statCard1?.SetData(lblStudents, 0, Properties.Resources.student);
                statCard2?.SetData(lblTeachers, 0, Properties.Resources.teacher);
                statCard3?.SetData(lblFaculties, 0, Properties.Resources.course);
                statCard4?.SetData(lblMajors, 0, Properties.Resources.course);

                chartControl1?.Series.Clear();
                chartControl2?.Series.Clear();
                gridControl1.DataSource = null;
            }
            catch (Exception ex)
            {
                // Silent fail khi clear
                System.Diagnostics.Debug.WriteLine($"ClearData error: {ex.Message}");
            }
        }

        // =============== LOAD DATA ===================
        public void LoadOverviewData()
        {
            if (_isLoading || _studentService == null) return;
            
            _isLoading = true;
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // Load Stat Cards
                LoadStatCards();

                // Load Charts
                LoadCharts();

                // Load Student Grid
                LoadStudentGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi khi tải dữ liệu Overview:\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                ClearData();
            }
            finally
            {
                _isLoading = false;
                this.Cursor = Cursors.Default;
            }
        }

        private void LoadStatCards()
        {
            try
            {
                string lblStudents = LanguageHelper.GetString("Students") ?? "Số Sinh Viên";
                string lblTeachers = LanguageHelper.GetString("Teachers") ?? "Số Giáo Viên";
                string lblMajors = LanguageHelper.GetString("Majors") ?? "Số Ngành";
                string lblFaculties = LanguageHelper.GetString("Lbl_FacultyCount") ?? "Tổng Số Khoa";

                int studentCount = _studentService.GetStudentCount();
                int teacherCount = _studentService.GetTeacherCount();
                int khoaCount = _studentService.GetKhoaCount();
                int majorCount = _studentService.GetMajorCount();

                statCard1?.SetData(lblStudents, studentCount, Properties.Resources.student);
                statCard2?.SetData(lblTeachers, teacherCount, Properties.Resources.teacher);
                statCard3?.SetData(lblFaculties, khoaCount, Properties.Resources.course);
                statCard4?.SetData(lblMajors, majorCount, Properties.Resources.course);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi khi tải thống kê: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void LoadCharts()
        {
            try
            {
                string chartPerYear = LanguageHelper.GetString("Chart_StudentsPerYear") ?? "Sinh viên theo Niên khóa";
                string chartPerFaculty = LanguageHelper.GetString("Chart_StudentsPerFaculty") ?? "Sinh viên theo Khoa";

                // Chart 1: Sinh viên theo Khoa (Bar Chart)
                var facultyData = _studentService.GetStudentCountPerFaculty();
                if (facultyData != null && facultyData.Count > 0)
                {
                    ChartService.LoadChart(
                        chartControl1,
                        facultyData,
                        "FacultyName",
                        "StudentCount",
                        ViewType.Bar,
                        chartPerFaculty
                    );
                }
                else
                {
                    chartControl1?.Series.Clear();
                }

                // Chart 2: Sinh viên theo Niên khóa (Pie Chart)
                var nienKhoaData = _studentService.GetStudentCountPerNienKhoa();
                if (nienKhoaData != null && nienKhoaData.Count > 0)
                {
                    ChartService.LoadChart(
                        chartControl2,
                        nienKhoaData,
                        "MaNienKhoa",
                        "StudentCount",
                        ViewType.Pie,
                        chartPerYear
                    );
                }
                else
                {
                    chartControl2?.Series.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi khi tải biểu đồ: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                chartControl1?.Series.Clear();
                chartControl2?.Series.Clear();
            }
        }

        // =============== GRIDVIEW DANH SÁCH SINH VIÊN ===============
        private void LoadStudentGrid()
        {
            try
            {
                var dt = _studentService.GetStudentDataForOverview();
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    gridControl1.DataSource = dt;
                    gridView1.BestFitColumns();
                    
                    // Cập nhật caption cho các cột
                    UpdateGridColumnCaptions();
                }
                else
                {
                    gridControl1.DataSource = null;
                    MessageBox.Show(
                        "Không có dữ liệu sinh viên để hiển thị.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi khi tải danh sách sinh viên:\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                gridControl1.DataSource = null;
            }
        }

        private void UpdateGridColumnCaptions()
        {
            if (gridView1 == null) return;

            try
            {
                // Cập nhật caption cho các cột nếu có
                if (gridColumnMaSV != null)
                    gridColumnMaSV.Caption = "Mã SV";
                if (gridColumnTenSV != null)
                    gridColumnTenSV.Caption = "Họ Tên";
                if (gridColumnNgaySinh != null)
                    gridColumnNgaySinh.Caption = "Ngày Sinh";
                if (gridColumnGioiTinh != null)
                    gridColumnGioiTinh.Caption = "Giới Tính";
                if (gridColumnTenLop != null)
                    gridColumnTenLop.Caption = "Lớp";
                if (gridColumnTenKhoa != null)
                    gridColumnTenKhoa.Caption = "Khoa";
            }
            catch
            {
                // Ignore errors when updating captions
            }
        }

        // =============== REFRESH BUTTON (nếu có) ===================
        public void RefreshData()
        {
            LoadOverviewData();
        }

        // =============== LOAD DATA KHI CONTROL ĐƯỢC HIỂN THỊ ===================
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            
            // Load dữ liệu khi control được hiển thị lần đầu tiên
            if (Visible && !DesignMode && _studentService != null && !_isLoading)
            {
                LoadOverviewData();
            }
        }
    }
}
