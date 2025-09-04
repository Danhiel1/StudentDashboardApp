namespace StudentDashboardApp.Model
{
    partial class ImportForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            recentlyUsedItemsComboBox1 = new DevExpress.XtraReports.UserDesigner.RecentlyUsedItemsComboBox();
            designRepositoryItemComboBox1 = new DevExpress.XtraReports.UserDesigner.DesignRepositoryItemComboBox();
            fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            dataGridView1 = new DataGridView();
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            lblSheetName = new Label();
            xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            btnNext = new Button();
            btnPrevious = new Button();
            btnImport = new Button();
            btnPreview = new Button();
            btnBrowse = new Button();
            txtFilePath = new TextBox();
            fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            ((System.ComponentModel.ISupportInitialize)recentlyUsedItemsComboBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)designRepositoryItemComboBox1).BeginInit();
            fluentDesignFormContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fluentDesignFormControl1).BeginInit();
            SuspendLayout();
            // 
            // recentlyUsedItemsComboBox1
            // 
            recentlyUsedItemsComboBox1.AppearanceDropDown.Font = new Font("Tahoma", 11.25F);
            recentlyUsedItemsComboBox1.AppearanceDropDown.Options.UseFont = true;
            recentlyUsedItemsComboBox1.AutoHeight = false;
            recentlyUsedItemsComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            recentlyUsedItemsComboBox1.Name = "recentlyUsedItemsComboBox1";
            // 
            // designRepositoryItemComboBox1
            // 
            designRepositoryItemComboBox1.AutoHeight = false;
            designRepositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            designRepositoryItemComboBox1.Name = "designRepositoryItemComboBox1";
            // 
            // fluentDesignFormContainer1
            // 
            fluentDesignFormContainer1.Controls.Add(dataGridView1);
            fluentDesignFormContainer1.Controls.Add(groupControl1);
            fluentDesignFormContainer1.Dock = DockStyle.Fill;
            fluentDesignFormContainer1.Location = new Point(0, 33);
            fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            fluentDesignFormContainer1.Size = new Size(691, 440);
            fluentDesignFormContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Transparent;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(691, 331);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // groupControl1
            // 
            groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            groupControl1.Controls.Add(lblSheetName);
            groupControl1.Controls.Add(xtraScrollableControl1);
            groupControl1.Controls.Add(btnNext);
            groupControl1.Controls.Add(btnPrevious);
            groupControl1.Controls.Add(btnImport);
            groupControl1.Controls.Add(btnPreview);
            groupControl1.Controls.Add(btnBrowse);
            groupControl1.Controls.Add(txtFilePath);
            groupControl1.Dock = DockStyle.Bottom;
            groupControl1.Location = new Point(0, 331);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new Size(691, 109);
            groupControl1.TabIndex = 0;
            groupControl1.Text = "groupControl1";
            // 
            // lblSheetName
            // 
            lblSheetName.AccessibleDescription = "";
            lblSheetName.AutoSize = true;
            lblSheetName.Dock = DockStyle.Fill;
            lblSheetName.ForeColor = Color.Transparent;
            lblSheetName.Location = new Point(0, 0);
            lblSheetName.Name = "lblSheetName";
            lblSheetName.Size = new Size(65, 13);
            lblSheetName.TabIndex = 0;
            lblSheetName.Text = "Name Sheet";
            lblSheetName.Click += lblSheetName_Click;
            // 
            // xtraScrollableControl1
            // 
            xtraScrollableControl1.Location = new Point(0, 0);
            xtraScrollableControl1.Name = "xtraScrollableControl1";
            xtraScrollableControl1.Size = new Size(75, 23);
            xtraScrollableControl1.TabIndex = 7;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNext.Enabled = false;
            btnNext.Location = new Point(614, 6);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(65, 23);
            btnNext.TabIndex = 6;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Visible = false;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrevious.Enabled = false;
            btnPrevious.Location = new Point(543, 6);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(65, 23);
            btnPrevious.TabIndex = 5;
            btnPrevious.Text = "Previous";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Visible = false;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnImport
            // 
            btnImport.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnImport.FlatStyle = FlatStyle.System;
            btnImport.Location = new Point(614, 45);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(65, 29);
            btnImport.TabIndex = 3;
            btnImport.Text = "Import Sql";
            btnImport.UseVisualStyleBackColor = true;
            btnImport.Click += btnImport_Click;
            // 
            // btnPreview
            // 
            btnPreview.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnPreview.FlatStyle = FlatStyle.System;
            btnPreview.Location = new Point(543, 45);
            btnPreview.Name = "btnPreview";
            btnPreview.Size = new Size(65, 29);
            btnPreview.TabIndex = 2;
            btnPreview.Text = "Preview";
            btnPreview.UseVisualStyleBackColor = true;
            btnPreview.Click += btnPreview_Click;
            // 
            // btnBrowse
            // 
            btnBrowse.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnBrowse.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBrowse.BackColor = Color.Black;
            btnBrowse.BackgroundImageLayout = ImageLayout.None;
            btnBrowse.FlatAppearance.BorderColor = Color.White;
            btnBrowse.FlatAppearance.BorderSize = 0;
            btnBrowse.FlatStyle = FlatStyle.System;
            btnBrowse.ForeColor = Color.Transparent;
            btnBrowse.Location = new Point(472, 45);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(65, 29);
            btnBrowse.TabIndex = 1;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = false;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // txtFilePath
            // 
            txtFilePath.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtFilePath.BackColor = Color.White;
            txtFilePath.BorderStyle = BorderStyle.None;
            txtFilePath.ForeColor = SystemColors.Desktop;
            txtFilePath.ImeMode = ImeMode.NoControl;
            txtFilePath.Location = new Point(12, 45);
            txtFilePath.Multiline = true;
            txtFilePath.Name = "txtFilePath";
            txtFilePath.ReadOnly = true;
            txtFilePath.Size = new Size(447, 29);
            txtFilePath.TabIndex = 0;
            // 
            // fluentDesignFormControl1
            // 
            fluentDesignFormControl1.FluentDesignForm = this;
            fluentDesignFormControl1.Location = new Point(0, 0);
            fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            fluentDesignFormControl1.Size = new Size(691, 33);
            fluentDesignFormControl1.TabIndex = 2;
            fluentDesignFormControl1.TabStop = false;
            // 
            // ImportForm
            // 
            Appearance.ForeColor = Color.Black;
            Appearance.Options.UseFont = true;
            Appearance.Options.UseForeColor = true;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(691, 473);
            ControlContainer = fluentDesignFormContainer1;
            Controls.Add(fluentDesignFormContainer1);
            Controls.Add(fluentDesignFormControl1);
            FluentDesignFormControl = fluentDesignFormControl1;
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "ImportForm";
            Text = "ImportForm";
            ((System.ComponentModel.ISupportInitialize)recentlyUsedItemsComboBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)designRepositoryItemComboBox1).EndInit();
            fluentDesignFormContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fluentDesignFormControl1).EndInit();
            ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private TextBox txtFilePath;
        private Button btnBrowse;
        private DevExpress.XtraReports.UserDesigner.RecentlyUsedItemsComboBox recentlyUsedItemsComboBox1;
        private DevExpress.XtraReports.UserDesigner.DesignRepositoryItemComboBox designRepositoryItemComboBox1;
        private Button btnImport;
        private Button btnPreview;
        private DataGridView dataGridView1;
        private Button btnPrevious;
        private Button btnNext;
        private Label lblSheetName;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
    }
}