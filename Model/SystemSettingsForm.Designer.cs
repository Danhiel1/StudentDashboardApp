namespace StudentDashboardApp.Forms
{
    partial class SystemSettingsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            groupDate = new DevExpress.XtraEditors.GroupControl();
            cbTimeFormat = new DevExpress.XtraEditors.ComboBoxEdit();
            cbDateFormat = new DevExpress.XtraEditors.ComboBoxEdit();
            lblTimeFormat = new DevExpress.XtraEditors.LabelControl();
            lblDateFormat = new DevExpress.XtraEditors.LabelControl();
            groupLanguage = new DevExpress.XtraEditors.GroupControl();
            cbLanguage = new DevExpress.XtraEditors.ComboBoxEdit();
            lblLanguage = new DevExpress.XtraEditors.LabelControl();
            btnSave = new DevExpress.XtraEditors.SimpleButton();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)groupDate).BeginInit();
            groupDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cbTimeFormat.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbDateFormat.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupLanguage).BeginInit();
            groupLanguage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cbLanguage.Properties).BeginInit();
            SuspendLayout();
            // 
            // groupDate
            // 
            groupDate.Controls.Add(cbTimeFormat);
            groupDate.Controls.Add(cbDateFormat);
            groupDate.Controls.Add(lblTimeFormat);
            groupDate.Controls.Add(lblDateFormat);
            groupDate.Location = new Point(19, 20);
            groupDate.Margin = new Padding(2);
            groupDate.Name = "groupDate";
            groupDate.Size = new Size(345, 98);
            groupDate.TabIndex = 0;
            groupDate.Text = "Date / Time Format";
            // 
            // cbTimeFormat
            // 
            cbTimeFormat.Location = new Point(112, 57);
            cbTimeFormat.Margin = new Padding(2);
            cbTimeFormat.Name = "cbTimeFormat";
            cbTimeFormat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cbTimeFormat.Properties.Items.AddRange(new object[] { "HH:mm:ss", "hh:mm tt" });
            cbTimeFormat.Size = new Size(150, 28);
            cbTimeFormat.TabIndex = 3;
            // 
            // cbDateFormat
            // 
            cbDateFormat.Location = new Point(112, 28);
            cbDateFormat.Margin = new Padding(2);
            cbDateFormat.Name = "cbDateFormat";
            cbDateFormat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cbDateFormat.Properties.Items.AddRange(new object[] { "dd/MM/yyyy", "MM/dd/yyyy", "yyyy-MM-dd" });
            cbDateFormat.Size = new Size(150, 28);
            cbDateFormat.TabIndex = 2;
            // 
            // lblTimeFormat
            // 
            lblTimeFormat.Location = new Point(30, 59);
            lblTimeFormat.Margin = new Padding(2);
            lblTimeFormat.Name = "lblTimeFormat";
            lblTimeFormat.Size = new Size(61, 13);
            lblTimeFormat.TabIndex = 1;
            lblTimeFormat.Text = "Time Format:";
            // 
            // lblDateFormat
            // 
            lblDateFormat.Location = new Point(30, 31);
            lblDateFormat.Margin = new Padding(2);
            lblDateFormat.Name = "lblDateFormat";
            lblDateFormat.Size = new Size(61, 13);
            lblDateFormat.TabIndex = 0;
            lblDateFormat.Text = "Date Format:";
            // 
            // groupLanguage
            // 
            groupLanguage.Controls.Add(cbLanguage);
            groupLanguage.Controls.Add(lblLanguage);
            groupLanguage.Location = new Point(19, 134);
            groupLanguage.Margin = new Padding(2);
            groupLanguage.Name = "groupLanguage";
            groupLanguage.Size = new Size(345, 81);
            groupLanguage.TabIndex = 1;
            groupLanguage.Text = "Language Settings";
            // 
            // cbLanguage
            // 
            cbLanguage.Location = new Point(112, 37);
            cbLanguage.Margin = new Padding(2);
            cbLanguage.Name = "cbLanguage";
            cbLanguage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cbLanguage.Properties.Items.AddRange(new object[] { "English", "Tiếng Việt", "繁體中文" });
            cbLanguage.Size = new Size(150, 28);
            cbLanguage.TabIndex = 1;
            // 
            // lblLanguage
            // 
            lblLanguage.Location = new Point(30, 39);
            lblLanguage.Margin = new Padding(2);
            lblLanguage.Name = "lblLanguage";
            lblLanguage.Size = new Size(51, 13);
            lblLanguage.TabIndex = 0;
            lblLanguage.Text = "Language:";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(195, 236);
            btnSave.Margin = new Padding(2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 28);
            btnSave.TabIndex = 2;
            btnSave.Tag = "BtnSave";
            btnSave.Text = "💾 Save";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(285, 236);
            btnCancel.Margin = new Padding(2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 28);
            btnCancel.TabIndex = 3;
            btnCancel.Tag = "BtnCancel";
            btnCancel.Text = "✖ Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // SystemSettingsForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 284);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(groupLanguage);
            Controls.Add(groupDate);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SystemSettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Tag = "TxtSystemParameter";
            Text = "System Parameters (Date/Time, Format, Language)";
            ((System.ComponentModel.ISupportInitialize)groupDate).EndInit();
            groupDate.ResumeLayout(false);
            groupDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cbTimeFormat.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbDateFormat.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupLanguage).EndInit();
            groupLanguage.ResumeLayout(false);
            groupLanguage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cbLanguage.Properties).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupDate;
        private DevExpress.XtraEditors.ComboBoxEdit cbTimeFormat;
        private DevExpress.XtraEditors.ComboBoxEdit cbDateFormat;
        private DevExpress.XtraEditors.LabelControl lblTimeFormat;
        private DevExpress.XtraEditors.LabelControl lblDateFormat;
        private DevExpress.XtraEditors.GroupControl groupLanguage;
        private DevExpress.XtraEditors.ComboBoxEdit cbLanguage;
        private DevExpress.XtraEditors.LabelControl lblLanguage;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}
