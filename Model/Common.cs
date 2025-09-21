using System;
using System.Windows.Forms;
using BusinessLayer;

namespace StudentDashboardApp.Common
{
    public class BaseForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected readonly StudentService _service;

        public BaseForm()
        {
            string connString = "Server=.;Database=QLSV;Trusted_Connection=True;Encrypt=False;";
            _service = new StudentService(connString);
        }
    }
}
