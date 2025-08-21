using StudentDashboardApp.Forms;
using System.Data.SqlClient;

namespace MyApp
{
    

    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
