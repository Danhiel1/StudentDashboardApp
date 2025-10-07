namespace StudentDashboardApp
{
    partial class ListStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListStudent));
            panelHeaderListStudent = new Panel();
            panel1 = new Panel();
            comboBoxEditClass = new DevExpress.XtraEditors.ComboBoxEdit();
            labelControlClass = new DevExpress.XtraEditors.LabelControl();
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            comboBoxEdit2 = new DevExpress.XtraEditors.ComboBoxEdit();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            comboBoxEditcbHoc = new DevExpress.XtraEditors.ComboBoxEdit();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            pictureBoxListStudetHeader = new PictureBox();
            labelHeaderitStudentScore = new Label();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridColumnIdStudnent = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumnFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumnClass = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumnMajor = new DevExpress.XtraGrid.Columns.GridColumn();
            panelHeaderListStudent.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)comboBoxEditClass.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEdit2.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEditcbHoc.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxListStudetHeader).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            SuspendLayout();
            // 
            // panelHeaderListStudent
            // 
            panelHeaderListStudent.BackColor = Color.FromArgb(62, 64, 149);
            panelHeaderListStudent.Controls.Add(panel1);
            panelHeaderListStudent.Controls.Add(pictureBoxListStudetHeader);
            panelHeaderListStudent.Controls.Add(labelHeaderitStudentScore);
            panelHeaderListStudent.Dock = DockStyle.Top;
            panelHeaderListStudent.Location = new Point(0, 0);
            panelHeaderListStudent.Margin = new Padding(5, 3, 5, 3);
            panelHeaderListStudent.Name = "panelHeaderListStudent";
            panelHeaderListStudent.Size = new Size(545, 129);
            panelHeaderListStudent.TabIndex = 52;
            panelHeaderListStudent.Paint += panelHeaderListStudent_Paint;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(62, 64, 149);
            panel1.Controls.Add(comboBoxEditClass);
            panel1.Controls.Add(labelControlClass);
            panel1.Controls.Add(simpleButton1);
            panel1.Controls.Add(comboBoxEdit2);
            panel1.Controls.Add(labelControl3);
            panel1.Controls.Add(comboBoxEdit1);
            panel1.Controls.Add(labelControl2);
            panel1.Controls.Add(comboBoxEditcbHoc);
            panel1.Controls.Add(labelControl1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 37);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(545, 92);
            panel1.TabIndex = 57;
            // 
            // comboBoxEditClass
            // 
            comboBoxEditClass.Location = new Point(292, 52);
            comboBoxEditClass.Margin = new Padding(4, 3, 4, 3);
            comboBoxEditClass.Name = "comboBoxEditClass";
            comboBoxEditClass.Properties.Appearance.BackColor = Color.FromArgb(62, 64, 149);
            comboBoxEditClass.Properties.Appearance.Options.UseBackColor = true;
            comboBoxEditClass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            comboBoxEditClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            comboBoxEditClass.Properties.Items.AddRange(new object[] { "for (int year = 2020; year <= DateTime.Now.Year; year++)", "{", "    cbKhoa.Properties.Items.Add(year.ToString());", "}" });
            comboBoxEditClass.Size = new Size(117, 28);
            comboBoxEditClass.TabIndex = 12;
            // 
            // labelControlClass
            // 
            labelControlClass.Location = new Point(251, 60);
            labelControlClass.Margin = new Padding(4, 3, 4, 3);
            labelControlClass.Name = "labelControlClass";
            labelControlClass.Size = new Size(28, 13);
            labelControlClass.TabIndex = 11;
            labelControlClass.Text = "Class:";
            // 
            // simpleButton1
            // 
            simpleButton1.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("simpleButton1.ImageOptions.SvgImage");
            simpleButton1.ImageOptions.SvgImageSize = new Size(16, 16);
            simpleButton1.Location = new Point(439, 16);
            simpleButton1.Margin = new Padding(4, 3, 4, 3);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.Size = new Size(75, 23);
            simpleButton1.TabIndex = 10;
            simpleButton1.Text = "Filter";
            // 
            // comboBoxEdit2
            // 
            comboBoxEdit2.Location = new Point(105, 52);
            comboBoxEdit2.Margin = new Padding(4, 3, 4, 3);
            comboBoxEdit2.Name = "comboBoxEdit2";
            comboBoxEdit2.Properties.Appearance.BackColor = Color.FromArgb(62, 64, 149);
            comboBoxEdit2.Properties.Appearance.Options.UseBackColor = true;
            comboBoxEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            comboBoxEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            comboBoxEdit2.Properties.Items.AddRange(new object[] { "for (int year = 2020; year <= DateTime.Now.Year; year++)", "{", "    cbKhoa.Properties.Items.Add(year.ToString());", "}" });
            comboBoxEdit2.Size = new Size(128, 28);
            comboBoxEdit2.TabIndex = 9;
            // 
            // labelControl3
            // 
            labelControl3.Location = new Point(5, 60);
            labelControl3.Margin = new Padding(4, 3, 4, 3);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new Size(36, 13);
            labelControl3.TabIndex = 8;
            labelControl3.Text = "Course:";
            // 
            // comboBoxEdit1
            // 
            comboBoxEdit1.Location = new Point(292, 7);
            comboBoxEdit1.Margin = new Padding(4, 3, 4, 3);
            comboBoxEdit1.Name = "comboBoxEdit1";
            comboBoxEdit1.Properties.Appearance.BackColor = Color.FromArgb(62, 64, 149);
            comboBoxEdit1.Properties.Appearance.Options.UseBackColor = true;
            comboBoxEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            comboBoxEdit1.Size = new Size(117, 28);
            comboBoxEdit1.TabIndex = 7;
            // 
            // labelControl2
            // 
            labelControl2.Location = new Point(251, 14);
            labelControl2.Margin = new Padding(4, 3, 4, 3);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(29, 13);
            labelControl2.TabIndex = 6;
            labelControl2.Text = "Major:";
            // 
            // comboBoxEditcbHoc
            // 
            comboBoxEditcbHoc.Location = new Point(105, 7);
            comboBoxEditcbHoc.Margin = new Padding(4, 3, 4, 3);
            comboBoxEditcbHoc.Name = "comboBoxEditcbHoc";
            comboBoxEditcbHoc.Properties.Appearance.BackColor = Color.FromArgb(62, 64, 149);
            comboBoxEditcbHoc.Properties.Appearance.Options.UseBackColor = true;
            comboBoxEditcbHoc.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            comboBoxEditcbHoc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            comboBoxEditcbHoc.Properties.Items.AddRange(new object[] { "Trung Cấp", "Cao Đẳng ", "Đại Học" });
            comboBoxEditcbHoc.Size = new Size(128, 28);
            comboBoxEditcbHoc.TabIndex = 5;
            // 
            // labelControl1
            // 
            labelControl1.Location = new Point(5, 14);
            labelControl1.Margin = new Padding(4, 3, 4, 3);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(80, 13);
            labelControl1.TabIndex = 4;
            labelControl1.Text = "Education Level:";
            // 
            // pictureBoxListStudetHeader
            // 
            pictureBoxListStudetHeader.BackgroundImage = (Image)resources.GetObject("pictureBoxListStudetHeader.BackgroundImage");
            pictureBoxListStudetHeader.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxListStudetHeader.Location = new Point(9, 6);
            pictureBoxListStudetHeader.Margin = new Padding(5, 3, 5, 3);
            pictureBoxListStudetHeader.Name = "pictureBoxListStudetHeader";
            pictureBoxListStudetHeader.Size = new Size(27, 27);
            pictureBoxListStudetHeader.TabIndex = 1;
            pictureBoxListStudetHeader.TabStop = false;
            // 
            // labelHeaderitStudentScore
            // 
            labelHeaderitStudentScore.AutoSize = true;
            labelHeaderitStudentScore.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelHeaderitStudentScore.ForeColor = Color.White;
            labelHeaderitStudentScore.Location = new Point(46, 9);
            labelHeaderitStudentScore.Margin = new Padding(5, 0, 5, 0);
            labelHeaderitStudentScore.Name = "labelHeaderitStudentScore";
            labelHeaderitStudentScore.Size = new Size(107, 20);
            labelHeaderitStudentScore.TabIndex = 0;
            labelHeaderitStudentScore.Text = "List Student";
            // 
            // gridControl1
            // 
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.EmbeddedNavigator.Margin = new Padding(4, 3, 4, 3);
            gridControl1.Location = new Point(0, 129);
            gridControl1.MainView = gridView1;
            gridControl1.Margin = new Padding(4, 3, 4, 3);
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(545, 520);
            gridControl1.TabIndex = 53;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { gridColumnIdStudnent, gridColumnFullName, gridColumnClass, gridColumnMajor });
            gridView1.DetailHeight = 404;
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsEditForm.PopupEditFormWidth = 933;
            gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnIdStudnent
            // 
            gridColumnIdStudnent.Caption = "ID";
            gridColumnIdStudnent.FieldName = "gridColumnIdStudnent";
            gridColumnIdStudnent.MinWidth = 23;
            gridColumnIdStudnent.Name = "gridColumnIdStudnent";
            gridColumnIdStudnent.UnboundDataType = typeof(int);
            gridColumnIdStudnent.Visible = true;
            gridColumnIdStudnent.VisibleIndex = 0;
            gridColumnIdStudnent.Width = 87;
            // 
            // gridColumnFullName
            // 
            gridColumnFullName.Caption = "Full Name";
            gridColumnFullName.FieldName = "gridColumnFullName";
            gridColumnFullName.MinWidth = 23;
            gridColumnFullName.Name = "gridColumnFullName";
            gridColumnFullName.UnboundDataType = typeof(string);
            gridColumnFullName.Visible = true;
            gridColumnFullName.VisibleIndex = 1;
            gridColumnFullName.Width = 87;
            // 
            // gridColumnClass
            // 
            gridColumnClass.Caption = "Class";
            gridColumnClass.FieldName = "gridColumnClass";
            gridColumnClass.MinWidth = 23;
            gridColumnClass.Name = "gridColumnClass";
            gridColumnClass.UnboundDataType = typeof(string);
            gridColumnClass.Visible = true;
            gridColumnClass.VisibleIndex = 2;
            gridColumnClass.Width = 87;
            // 
            // gridColumnMajor
            // 
            gridColumnMajor.Caption = "Major";
            gridColumnMajor.FieldName = "gridColumnMajor";
            gridColumnMajor.MinWidth = 23;
            gridColumnMajor.Name = "gridColumnMajor";
            gridColumnMajor.UnboundDataType = typeof(string);
            gridColumnMajor.Visible = true;
            gridColumnMajor.VisibleIndex = 3;
            gridColumnMajor.Width = 87;
            // 
            // ListStudent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 32, 32);
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(gridControl1);
            Controls.Add(panelHeaderListStudent);
            ForeColor = Color.White;
            Margin = new Padding(4, 3, 4, 3);
            Name = "ListStudent";
            Size = new Size(545, 649);
            panelHeaderListStudent.ResumeLayout(false);
            panelHeaderListStudent.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)comboBoxEditClass.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEdit2.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEditcbHoc.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxListStudetHeader).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeaderListStudent;
        private PictureBox pictureBoxListStudetHeader;
        private Label labelHeaderitStudentScore;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnIdStudnent;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnFullName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnClass;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMajor;
        private Panel panel1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditClass;
        private DevExpress.XtraEditors.LabelControl labelControlClass;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditcbHoc;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
