namespace StudentDashboardApp
{
    partial class StatCard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new DevExpress.XtraEditors.LabelControl();
            lblValue = new DevExpress.XtraEditors.LabelControl();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Appearance.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.Appearance.ForeColor = Color.White;
            lblTitle.Appearance.Options.UseFont = true;
            lblTitle.Appearance.Options.UseForeColor = true;
            lblTitle.Appearance.Options.UseTextOptions = true;
            lblTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblTitle.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblTitle.Location = new Point(3, -1);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(160, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Title";
            // 
            // lblValue
            // 
            lblValue.Appearance.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblValue.Appearance.ForeColor = Color.White;
            lblValue.Appearance.Options.UseFont = true;
            lblValue.Appearance.Options.UseForeColor = true;
            lblValue.Appearance.Options.UseTextOptions = true;
            lblValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblValue.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            lblValue.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblValue.Location = new Point(3, 33);
            lblValue.Name = "lblValue";
            lblValue.Size = new Size(164, 49);
            lblValue.TabIndex = 1;
            lblValue.Text = "Value";
            // 
            // StatCard
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblValue);
            Controls.Add(lblTitle);
            Name = "StatCard";
            Size = new Size(162, 110);
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblValue;
    }
}
