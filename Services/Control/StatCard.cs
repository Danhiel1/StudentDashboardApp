using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace StudentDashboardApp
{
    public partial class StatCard : UserControl
    {
        private readonly Color originalColor = Color.FromArgb(32, 32, 32);   // Màu nền mặc định
        private readonly Color hoverColor = Color.FromArgb(50, 50, 50);      // Màu khi hover

        private readonly Color originalTextColor = Color.White;
        private readonly Color hoverTextColor = Color.FromArgb(0, 122, 204); // Màu chữ khi hover

        private readonly Color borderColor = Color.FromArgb(100, 100, 100);
        private const int cornerRadius = 12;  // Bo góc
        private const int baseBorderWidth = 2; // Viền mặc định

        private float blend = 0f;
        private float targetBlend = 0f;
        private System.Windows.Forms.Timer animationTimer;


        public StatCard()
        {
            InitializeComponent();

            // ✅ Kích thước cố định 162x110
            this.Size = new Size(162, 110);
            this.MinimumSize = new Size(162, 110);
            this.MaximumSize = new Size(162, 110);

            // Màu chữ mặc định
            this.BackColor = originalColor;
            lblTitle.ForeColor = originalTextColor;
            lblValue.ForeColor = originalTextColor;

            // Hover toàn bộ card + label
            this.MouseEnter += OnAnyHoverEnter;
            this.MouseLeave += OnAnyHoverLeave;
            lblTitle.MouseEnter += OnAnyHoverEnter;
            lblTitle.MouseLeave += OnAnyHoverLeave;
            lblValue.MouseEnter += OnAnyHoverEnter;
            lblValue.MouseLeave += OnAnyHoverLeave;

            // Timer cho hiệu ứng chuyển màu
            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 10; // mượt
            animationTimer.Tick += AnimationTimer_Tick;

            this.DoubleBuffered = true;
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
            const float speed = 0.25f; // tốc độ blend
            blend += (targetBlend - blend) * speed;

            if (Math.Abs(targetBlend - blend) < 0.01f)
            {
                blend = targetBlend;
                animationTimer.Stop();
            }

            // Blend màu nền và chữ
            this.BackColor = BlendColor(originalColor, hoverColor, blend);
            lblTitle.ForeColor = BlendColor(originalTextColor, hoverTextColor, blend);
            lblValue.ForeColor = BlendColor(originalTextColor, hoverTextColor, blend);

            this.Invalidate(); // Vẽ lại viền
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

                // Viền dày hơn khi hover
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

            // top left
            path.AddArc(arc, 180, 90);

            // top right
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}
