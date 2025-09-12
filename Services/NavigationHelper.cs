using System.Collections.Generic;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using StudentDashboardApp.Model;

namespace StudentDashboardApp.Services
{
    public class NavigationHelper
    {
        //fild
        private readonly NavigationFrame _frame;
        //constructor
        public NavigationHelper(NavigationFrame frame)
        {
            _frame = frame;
        }
        //funtion
        public void ShowNavigationPage(NavigationPage Page)
        {
            _frame.Visible = true;
            _frame.SelectedPage = Page;
        }
    }
}
