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
            lblTitle.Location = new Point(0, 15);
            lblTitle.Margin = new Padding(4, 3, 4, 3);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(253, 53);
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
            lblValue.Location = new Point(0, 57);
            lblValue.Margin = new Padding(4, 3, 4, 3);
            lblValue.Name = "lblValue";
            lblValue.Size = new Size(253, 57);
            lblValue.TabIndex = 1;
            lblValue.Text = "Value";
            // 
            // StatCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblValue);
            Controls.Add(lblTitle);
            Margin = new Padding(4, 3, 4, 3);
            Name = "StatCard";
            Size = new Size(251, 171);
            Load += StatCard_Load;
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblValue;
    }
}
