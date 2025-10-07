using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace StudentDashboardApp
{
    public partial class StatCard : UserControl
    {
        private Size originalSize;
        private Point originalLocation;
        private Color originalColor = Color.FromArgb(45, 45, 45);   // 🎨 sáng hơn
        private Color hoverColor = Color.FromArgb(60, 60, 60);       // màu khi hover

        private System.Windows.Forms.Timer animationTimer;
        private float scale = 1.0f;
        private float targetScale = 1.0f;
        private bool isHovered = false;

        private Color originalTextColor = Color.White;
        private Color hoverTextColor = Color.FromArgb(0, 122, 204);
        private Color borderColor = Color.FromArgb(70, 70, 70);      // 🎨 viền nhẹ
        private int cornerRadius = 12;                               // 🎯 bo góc

        public StatCard()
        {
            InitializeComponent();

            // Lưu kích thước ban đầu
            this.originalSize = this.Size;
            this.originalLocation = this.Location;

            // Màu mặc định
            this.BackColor = originalColor;
            lblTitle.ForeColor = originalTextColor;
            lblValue.ForeColor = originalTextColor;

            // Sự kiện hover cho toàn bộ card + label
            this.MouseEnter += OnAnyHoverEnter;
            this.MouseLeave += OnAnyHoverLeave;
            lblTitle.MouseEnter += OnAnyHoverEnter;
            lblTitle.MouseLeave += OnAnyHoverLeave;
            lblValue.MouseEnter += OnAnyHoverEnter;
            lblValue.MouseLeave += OnAnyHoverLeave;

            // Timer animation
            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 15;
            animationTimer.Tick += AnimationTimer_Tick;

            // Bật DoubleBuffered để tránh giật khi redraw
            this.DoubleBuffered = true;
            this.Load += StatCard_Load;
        }

        private void OnAnyHoverEnter(object sender, EventArgs e)
        {
            isHovered = true;
            targetScale = 1.05f;
            animationTimer.Start();
        }

        private void OnAnyHoverLeave(object sender, EventArgs e)
        {
            if (!this.ClientRectangle.Contains(this.PointToClient(Cursor.Position)))
            {
                isHovered = false;
                targetScale = 1.0f;
                animationTimer.Start();
            }
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            float speed = 0.2f;
            scale += (targetScale - scale) * speed;

            if (Math.Abs(targetScale - scale) < 0.01f)
            {
                scale = targetScale;
                animationTimer.Stop();
            }

            int newWidth = (int)(originalSize.Width * scale);
            int newHeight = (int)(originalSize.Height * scale);
            this.Size = new Size(newWidth, newHeight);

            int offsetX = (int)((originalSize.Width - newWidth) / 2);
            int offsetY = (int)((originalSize.Height - newHeight) / 2);
            this.Location = new Point(originalLocation.X - offsetX, originalLocation.Y - offsetY);

            float blend = (scale - 1f) / 0.05f;
            blend = Math.Min(1f, Math.Max(0f, blend));
            this.BackColor = BlendColor(originalColor, hoverColor, blend);

            lblTitle.ForeColor = BlendColor(originalTextColor, hoverTextColor, blend);
            lblValue.ForeColor = BlendColor(originalTextColor, hoverTextColor, blend);

            this.Invalidate(); // 🔁 redraw lại khung bo góc và viền
        }

        private Color BlendColor(Color from, Color to, float amount)
        {
            int r = (int)(from.R + (to.R - from.R) * amount);
            int g = (int)(from.G + (to.G - from.G) * amount);
            int b = (int)(from.B + (to.B - from.B) * amount);
            return Color.FromArgb(r, g, b);
        }

        // ✨ Vẽ viền + bo góc
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = RoundedRect(new Rectangle(0, 0, this.Width - 1, this.Height - 1), cornerRadius))
            {
                // ✨ Bo góc thật (cắt vùng hiển thị)
                this.Region = new Region(path);

                // Viền
                using (Pen borderPen = new Pen(borderColor, 1))
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

        private void StatCard_Load(object sender, EventArgs e)
        {
            this.originalLocation = this.Location;
        }
    }
}
