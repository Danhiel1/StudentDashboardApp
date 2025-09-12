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
        private NavigationHelper navHelper;// khai báo fild để tạo cho đối tượng trong DashboardStudent_Load

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
            navHelper = new NavigationHelper(navigationFrameSTD); // tạo đối tượng để sử dụng hàm trong class đc tạo
            navigationFrameSTD.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.False; // bỏ hiệu ứng chuyển nav
            navigationFrameSTD.SelectedPage = navigationPageEmpty; // chọn navpage rỗng làm mặc định 
       
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
            navigationFrameSTD.SelectedPage = navigationPageEmpty; // mỗi khi chuyển ribbon sẽ tự chọn lại navpage rỗng 
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }
       
        private void barButtonItemFindStudent_ItemClick(object sender, ItemClickEventArgs e)
        {

            navHelper.ShowNavigationPage(navigationPageFindStudent); // gáng những page muốn mở vào những sự kiện của nút như đây là ví dụ điển hình, làm tương tự như những cái ở dưới
        }

        private void barButtonItemAddST_ItemClick(object sender, ItemClickEventArgs e)
        {

            navHelper.ShowNavigationPage(navigationPageAddST);
        }
    }
}

