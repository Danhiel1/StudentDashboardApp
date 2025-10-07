using StudentDashboardApp;
using StudentDashboardApp.Model;

namespace MyApp
{


    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new DashboardStudent());
        }
    }
}
