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
            this.picIcon = new PictureBox();
            this.lblTitle = new Label();
            this.lblDescription = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();

            // 
            // picIcon
            // 
            this.picIcon.Location = new Point(10, 15);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new Size(40, 40);
            this.picIcon.SizeMode = PictureBoxSizeMode.Zoom;
            this.picIcon.TabStop = false;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new Point(60, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(90, 19);
            this.lblTitle.Text = "Button Title";

            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new Font("Segoe UI", 8F);
            this.lblDescription.ForeColor = Color.DimGray;
            this.lblDescription.Location = new Point(60, 38);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new Size(140, 13);
            this.lblDescription.Text = "Button description here...";

            // 
            // QuickActionButton
            // 
            this.AutoScaleMode = AutoScaleMode.None;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(this.picIcon);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblDescription);
            this.Cursor = Cursors.Hand;
            this.Name = "QuickActionButton";
            this.Size = new Size(280, 70);

            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
