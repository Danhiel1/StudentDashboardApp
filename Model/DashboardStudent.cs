using System;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Navigation;
using BusinessLayer;
using BusinessLayer.Models;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts;
using StudentDashboardApp.Common;
using StudentDashboardApp.Services;



namespace StudentDashboardApp.Model
{
    public partial class DashboardStudent : BaseForm
    {

        private NavigationHelper navHelper;
        private BusinessLayer.StudentService _service;
        public DashboardStudent()
        {
            InitializeComponent();
            string connectionString = "Server=.;Database=QLSV;Trusted_Connection=True;Encrypt=False;";
            _service = new StudentService(connectionString);
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barDockingMenuItem1_ListItemClick_1(object sender, ListItemClickEventArgs e)
        {

        }

        private void barListItem1_ListItemClick(object sender, ListItemClickEventArgs e)
        {


        }

        private void barListItem2_ListItemClick(object sender, ListItemClickEventArgs e)
        {

        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            ImportForm importForm = new ImportForm();
            importForm.ShowDialog();
        }


        private void xtraOpenFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private StudentDashboardApp.Services.NavigationService navService;
        private void DashboardStudent_Load(object sender, EventArgs e)
        {
            infoCardStudent.SetData("Số Sinh Viên", _service.GetStudentCount().ToString(), Properties.Resources.student);
            infoCardTeacher.SetData("Số Giáo Viên", _service.GetTeacherCount().ToString(), Properties.Resources.student);


            ChartService.LoadChart(
                chartControlCountPerNienKhoa,
                _service.GetStudentCountPerNienKhoa(),
                argumentMember: "MaNienKhoa",
                valueMember: "StudentCount",
                viewType: ViewType.Pie,
                chartTitle: "Số SV theo Niên khóa"
            );

            // Bar Chart: Số SV theo Khoa
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

            var buttonMap = new Dictionary<BarButtonItem, (NavigationPage, UserControl)>
            {
            { barButtonItemFindStudent, (navigationPageStudent,  null) },
            { barButtonItemAddST, (navigationPageStudent, new AddStudentControl()) }
            };




            // NavigationHelper (cho button)
            navHelper = new NavigationHelper(navigationFrameSTD, buttonMap);
            navigationFrameSTD.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.False;
            navigationFrameSTD.SelectedPage = navigationSystemPage1; // page mặc định
            navigationFrameSTD.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.True;

            // NavigationService (cho ribbon)
            navService = new StudentDashboardApp.Services.NavigationService(ribbonMap);
        }





        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void barButtonItem4_ItemClick_1(object sender, ItemClickEventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void studentRepositoryBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void layoutControl2_Click(object sender, EventArgs e)
        {

        }

        private void btnDatabase_ItemClick(object sender, ItemClickEventArgs e)
        {

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
            // navHelper.ShowEmptyPage(navigationPageEmpty);// mỗi khi chuyển page sẽ tự động trả về page rỗng
        }


        private void ribbon_Click(object sender, EventArgs e)
        {


        }

        private void chartControl1_Click(object sender, EventArgs e)
        {

        }

        private void infoCard1_Load(object sender, EventArgs e)
        {

        }

        private void chartControlCountPerNienKhoa_Click(object sender, EventArgs e)
        {

        }

        private void simpleButtonEnterStudentID_Click(object sender, EventArgs e)
        {
           
        }
    }
}

