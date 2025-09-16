using System;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Navigation;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using StudentDashboardApp.Services;


namespace StudentDashboardApp.Model
{
    public partial class DashboardStudent : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private NavigationHelper navHelper;
        public DashboardStudent()
        {
            InitializeComponent();
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
            // Map RibbonPage → NavigationPage
            Dictionary<RibbonPage, NavigationPage> ribbonMap = new Dictionary<RibbonPage, NavigationPage>
            {
            { ribbonPage1, navigationSystemPage1 },
            { ribbonPage2, navigationPage1 },
            { ribbonPage3, navigationPage2 }
            };

            // Map BarButtonItem → NavigationPage
            Dictionary<BarButtonItem, NavigationPage> buttonMap = new Dictionary<BarButtonItem, NavigationPage>
            {
            { barButtonItemFindStudent, navigationPageFindStudent },
            { barButtonItemAddST, navigationPageAddST }
            };

            // Khởi tạo NavigationHelper (cho button)
            navHelper = new NavigationHelper(navigationFrameSTD, buttonMap);
            navigationFrameSTD.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.False;
            navigationFrameSTD.SelectedPage = navigationSystemPage1; // 👈 chọn page mặc định khi mở
            navigationFrameSTD.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.True;


            // Khởi tạo NavigationService (cho ribbon)
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
       
    }
}

