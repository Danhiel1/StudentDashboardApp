using System;
using System.Drawing;
using DevExpress.XtraEditors;

namespace StudentDashboardApp.Controls
{
    public partial class InfoCard : XtraUserControl
    {
        public InfoCard()
        {
            InitializeComponent();
        }

        public void SetData(string title, string value, System.Drawing.Image icon, Color? backColor = null)
        {
            lblTitle.Text = title;
            lblValue.Text = value;
            picIcon.Image = icon;

            if (backColor.HasValue)
                panel.BackColor = backColor.Value;
        }
    }
}
