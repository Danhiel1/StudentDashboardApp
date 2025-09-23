using DevExpress.XtraEditors;

namespace StudentDashboardApp.Controls
{
    partial class InfoCard
    {
        private PanelControl panel;
        private LabelControl lblTitle;
        private LabelControl lblValue;

        private void InitializeComponent()
        {
            panel = new PanelControl();
            lblTitle = new LabelControl();
            lblValue = new LabelControl();
            picIcon = new PictureEdit();
            ((System.ComponentModel.ISupportInitialize)panel).BeginInit();
            panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIcon.Properties).BeginInit();
            SuspendLayout();
            // 
            // panel
            // 
            panel.Appearance.BackColor = Color.FromArgb(32, 32, 32);
            panel.Appearance.Options.UseBackColor = true;
            panel.AutoSize = true;
            panel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblValue);
            panel.Controls.Add(picIcon);
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Size = new Size(220, 90);
            panel.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.Appearance.Font = new Font("Segoe UI", 10F);
            lblTitle.Appearance.Options.UseFont = true;
            lblTitle.Location = new Point(89, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(24, 17);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Title";
            // 
            // lblValue
            // 
            lblValue.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblValue.Appearance.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblValue.Appearance.Options.UseFont = true;
            lblValue.Location = new Point(89, 38);
            lblValue.Name = "lblValue";
            lblValue.Size = new Size(12, 30);
            lblValue.TabIndex = 1;
            lblValue.Text = "0";
            // 
            // picIcon
            // 
            picIcon.ImeMode = ImeMode.Off;
            picIcon.Location = new Point(10, 20);
            picIcon.Name = "picIcon";
            picIcon.Properties.AllowFocused = false;
            picIcon.Properties.Appearance.BackColor = Color.FromArgb(32, 32, 32);
            picIcon.Properties.Appearance.ForeColor = Color.Transparent;
            picIcon.Properties.Appearance.Options.UseBackColor = true;
            picIcon.Properties.Appearance.Options.UseForeColor = true;
            picIcon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            picIcon.Properties.ReadOnly = true;
            picIcon.Properties.ShowMenu = false;
            picIcon.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            picIcon.Size = new Size(48, 48);
            picIcon.TabIndex = 2;
            // 
            // InfoCard
            // 
            Controls.Add(panel);
            Name = "InfoCard";
            Size = new Size(220, 90);
            ((System.ComponentModel.ISupportInitialize)panel).EndInit();
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picIcon.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private PictureEdit picIcon;
    }
}
