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
        private StudentDashboardApp.Services.NavigationService _navService;

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
            var importForm = new ImportForm();
            importForm.ShowDialog();

        }

        private void xtraOpenFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        
        private void DashboardStudent_Load(object sender, EventArgs e)
        {
            // Map RibbonPage → NavigationPage
            Dictionary<RibbonPage, NavigationPage> ribbonMap = new Dictionary<RibbonPage, NavigationPage>
    {
        { ribbonPage1, navigationSystemPage1 },
        { ribbonPage2, navigationPageStudent },

    };

            _navService = new StudentDashboardApp.Services.NavigationService(ribbonMap);


    //        //Mặc định khi load, chọn page 1
    //        navigationFrameSTD.SelectedPage = navigationSystemPage1;




    //        var map = new Dictionary<DevExpress.XtraBars.BarButtonItem, (DevExpress.XtraBars.Navigation.NavigationPage, UserControl)>
    //{
    //    { barButtonItemAddST, (navigationPageStudent, new AddStudentControl()) },
    //    { barButtonItemFindStudent, (navigationPageStudent, new UserControl1()) }

    //};
    //        navHelper = new NavigationHelper(navigationFrameSTD, map);

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
            
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }
       
        private void barButtonItemFindStudent_ItemClick(object sender, ItemClickEventArgs e)
        {


        }

        private void labelHeaderFindStudent_Click(object sender, EventArgs e)
        {

        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButtonEnterStudentID_Click(object sender, EventArgs e)
        {
           
        }
    }
}

