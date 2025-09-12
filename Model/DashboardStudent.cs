using System;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Navigation;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;



namespace StudentDashboardApp.Model
{
    public partial class DashboardStudent : DevExpress.XtraBars.Ribbon.RibbonForm
    {
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
        private StudentDashboardApp.Services.NavigationService navService;

        private void DashboardStudent_Load(object sender, EventArgs e)
        {
         
            navigationFrameSTD.Visible = false;
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
            navigationFrameSTD.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.False;
            navigationFrameSTD.SelectedPage = navigationPageEmpty;
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItemFindStudent_ItemClick(object sender, ItemClickEventArgs e)
        {
            navigationFrameSTD.Visible = true;
            navigationFrameSTD.SelectedPage = navigationPageFindStudent;
        }

        private void barButtonItemAddST_ItemClick(object sender, ItemClickEventArgs e)
        {
          
            navigationFrameSTD.Visible = true;
            navigationFrameSTD.SelectedPage = navigationPageAddST;
        }
    }
}

