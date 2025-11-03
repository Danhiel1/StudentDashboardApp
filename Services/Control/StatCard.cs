using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace StudentDashboardApp.Controls
{
    public partial class StatCard : UserControl
    {
        private readonly Color originalColor = Color.FromArgb(32, 32, 32);
        private readonly Color hoverColor = Color.FromArgb(50, 50, 50);
        private readonly Color originalTextColor = Color.White;
        private readonly Color hoverTextColor = Color.FromArgb(0, 122, 204);
        private readonly Color borderColor = Color.FromArgb(100, 100, 100);
        private const int cornerRadius = 12;
        private const int baseBorderWidth = 2;

        private float blend = 0f;
        private float targetBlend = 0f;
        private Timer animationTimer;

        public StatCard()
        {
            InitializeComponent();

            // Kích thước cố định
            this.Size = new Size(162, 110);
            this.MinimumSize = new Size(162, 110);
            this.MaximumSize = new Size(162, 110);

            // Hover toàn bộ
            this.MouseEnter += OnAnyHoverEnter;
            this.MouseLeave += OnAnyHoverLeave;
            lblTitle.MouseEnter += OnAnyHoverEnter;
            lblTitle.MouseLeave += OnAnyHoverLeave;
            lblValue.MouseEnter += OnAnyHoverEnter;
            lblValue.MouseLeave += OnAnyHoverLeave;

            // Khởi tạo Timer
            animationTimer = new Timer();
            animationTimer.Interval = 10;
            animationTimer.Tick += AnimationTimer_Tick;
        }

        // Public method cho Dashboard
        public void SetData(string title, int value, Image icon = null)
        {
            lblTitle.Text = title;
            lblValue.Text = value.ToString();

            if (icon != null && pictureBox1 != null)
            {
                pictureBox1.Image = icon;
            }
        }



        private void OnAnyHoverEnter(object sender, EventArgs e)
        {
            targetBlend = 1f;
            animationTimer.Start();
        }

        private void OnAnyHoverLeave(object sender, EventArgs e)
        {
            if (!this.ClientRectangle.Contains(this.PointToClient(Cursor.Position)))
            {
                targetBlend = 0f;
                animationTimer.Start();
            }
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            const float speed = 0.25f;
            blend += (targetBlend - blend) * speed;

            if (Math.Abs(targetBlend - blend) < 0.01f)
            {
                blend = targetBlend;
                animationTimer.Stop();
            }

            this.BackColor = BlendColor(originalColor, hoverColor, blend);
            lblTitle.ForeColor = BlendColor(originalTextColor, hoverTextColor, blend);
            lblValue.ForeColor = BlendColor(originalTextColor, hoverTextColor, blend);

            this.Invalidate();
        }

        private Color BlendColor(Color from, Color to, float amount)
        {
            int r = (int)(from.R + (to.R - from.R) * amount);
            int g = (int)(from.G + (to.G - from.G) * amount);
            int b = (int)(from.B + (to.B - from.B) * amount);
            return Color.FromArgb(r, g, b);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = RoundedRect(new Rectangle(0, 0, this.Width - 1, this.Height - 1), cornerRadius))
            {
                this.Region = new Region(path);
                int borderWidth = baseBorderWidth + (int)(blend * 1.5f);
                using (Pen borderPen = new Pen(borderColor, borderWidth))
                {
                    e.Graphics.DrawPath(borderPen, path);
                }
            }
        }

        private GraphicsPath RoundedRect(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(rect.Location, size);

            path.AddArc(arc, 180, 90);
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
