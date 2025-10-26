using System.Windows.Forms;
using System.Drawing;

namespace StudentDashboardApp.Controls
{
    partial class QuickActionButton
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox picIcon;
        private Label lblTitle;
        private Label lblDescription;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            picIcon = new PictureBox();
            lblTitle = new Label();
            lblDescription = new Label();
            ((System.ComponentModel.ISupportInitialize)picIcon).BeginInit();
            SuspendLayout();
            // 
            // picIcon
            // 
            picIcon.Image = Properties.Resources.Excel;
            picIcon.Location = new Point(10, 15);
            picIcon.Name = "picIcon";
            picIcon.Size = new Size(40, 40);
            picIcon.SizeMode = PictureBoxSizeMode.Zoom;
            picIcon.TabIndex = 0;
            picIcon.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(60, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(86, 19);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Button Title";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 8F);
            lblDescription.ForeColor = Color.Transparent;
            lblDescription.Location = new Point(60, 38);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(139, 13);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Button description here...";
            // 
            // QuickActionButton
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(45, 45, 45);
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(picIcon);
            Controls.Add(lblTitle);
            Controls.Add(lblDescription);
            Cursor = Cursors.Hand;
            Name = "QuickActionButton";
            Size = new Size(255, 70);
            ((System.ComponentModel.ISupportInitialize)picIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
