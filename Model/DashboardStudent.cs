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
            var importForm = new ImportForm();
            importForm.ShowDialog();

        }

        private void xtraOpenFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        
        private void DashboardStudent_Load(object sender, EventArgs e)
        {
            var pageMap = new Dictionary<BarButtonItem, NavigationPage>()
    {
                // thêm nút khác và page cần hiển thị tại đây
        { barButtonItemFindStudent, navigationPageFindStudent },
        { barButtonItemAddST, navigationPageAddST },
      
        
    };

            navHelper = new NavigationHelper(navigationFrameSTD, pageMap); // đưa cho hàm ăn tham số của frame và Dictionary lần lượt là navigationFrameSTD và pageMap
            navigationFrameSTD.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.False; // tắt transition của frame    
            navHelper.ShowEmptyPage(navigationPageEmpty);// mặc định khi mở form sễ tự chọn form rỗng thay vì trả frame về false sẽ dễ gay ra lỗi linh tinh gì gì đó

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
            navHelper.ShowEmptyPage(navigationPageEmpty);// mỗi khi chuyển page sẽ tự động trả về page rỗng
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }
       
        private void barButtonItemFindStudent_ItemClick(object sender, ItemClickEventArgs e)
        {

           
        }

        private void barButtonItemAddST_ItemClick(object sender, ItemClickEventArgs e)
        {

           
        }
    }
}

