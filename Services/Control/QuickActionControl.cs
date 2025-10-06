using System;
using System.Drawing;
using System.Windows.Forms;

namespace StudentDashboardApp.Controls
{
    public partial class QuickActionButton : UserControl
    {
        private Color _defaultBackColor = Color.FromArgb(45, 45, 45);
        private Color _hoverBackColor = Color.LightBlue;

        public QuickActionButton()
        {
            InitializeComponent();
            this.BackColor = _defaultBackColor;

            // Đăng ký sự kiện hover
            this.MouseEnter += (s, e) => this.BackColor = _hoverBackColor;
            this.MouseLeave += (s, e) => this.BackColor = _defaultBackColor;

            // Đăng ký click cho toàn bộ child control
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Click += (s, e) => this.OnClick(e);
                ctrl.MouseEnter += (s, e) => this.BackColor = _hoverBackColor;
                ctrl.MouseLeave += (s, e) => this.BackColor = _defaultBackColor;
            }
        }

        // Thuộc tính để set/get text và icon
        public string Title
        {
            get => lblTitle.Text;
            set => lblTitle.Text = value;
        }

        public string Description
        {
            get => lblDescription.Text;
            set => lblDescription.Text = value;
        }

        public Image Icon
        {
            get => picIcon.Image;
            set => picIcon.Image = value;
        }
    }
}
