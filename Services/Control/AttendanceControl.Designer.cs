namespace StudentDashboardApp
{
    partial class AttendanceControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttendanceControl));
            panelHeaderAttendance = new Panel();
            panel1 = new Panel();
            comboBoxEdit3 = new DevExpress.XtraEditors.ComboBoxEdit();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            comboBoxEditClass = new DevExpress.XtraEditors.ComboBoxEdit();
            labelControlClass = new DevExpress.XtraEditors.LabelControl();
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            comboBoxEdit2 = new DevExpress.XtraEditors.ComboBoxEdit();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            comboBoxEditcbHoc = new DevExpress.XtraEditors.ComboBoxEdit();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            pictureBoxHeaderFindStudent = new PictureBox();
            labelHeaderAttendance = new Label();
            comboBoxEdit4 = new DevExpress.XtraEditors.ComboBoxEdit();
            labelControl5 = new DevExpress.XtraEditors.LabelControl();
            panel2 = new Panel();
            simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridColumnStudentID = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumnFullname = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumnClass = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumnSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumnStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumnNote = new DevExpress.XtraGrid.Columns.GridColumn();
            panelHeaderAttendance.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)comboBoxEdit3.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEditClass.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEdit2.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEditcbHoc.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHeaderFindStudent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEdit4.Properties).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            SuspendLayout();
            // 
            // panelHeaderAttendance
            // 
            panelHeaderAttendance.BackColor = Color.FromArgb(62, 64, 149);
            panelHeaderAttendance.Controls.Add(panel1);
            panelHeaderAttendance.Controls.Add(pictureBoxHeaderFindStudent);
            panelHeaderAttendance.Controls.Add(labelHeaderAttendance);
            panelHeaderAttendance.Dock = DockStyle.Top;
            panelHeaderAttendance.Location = new Point(0, 0);
            panelHeaderAttendance.Margin = new Padding(5, 3, 5, 3);
            panelHeaderAttendance.Name = "panelHeaderAttendance";
            panelHeaderAttendance.Size = new Size(1310, 157);
            panelHeaderAttendance.TabIndex = 53;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(62, 64, 149);
            panel1.Controls.Add(comboBoxEdit4);
            panel1.Controls.Add(labelControl5);
            panel1.Controls.Add(comboBoxEdit3);
            panel1.Controls.Add(labelControl4);
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
            panel1.Location = new Point(0, 54);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1310, 103);
            panel1.TabIndex = 54;
            // 
            // comboBoxEdit3
            // 
            comboBoxEdit3.Location = new Point(309, 59);
            comboBoxEdit3.Margin = new Padding(4, 3, 4, 3);
            comboBoxEdit3.Name = "comboBoxEdit3";
            comboBoxEdit3.Properties.Appearance.BackColor = Color.FromArgb(62, 64, 149);
            comboBoxEdit3.Properties.Appearance.Options.UseBackColor = true;
            comboBoxEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            comboBoxEdit3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            comboBoxEdit3.Properties.Items.AddRange(new object[] { "for (int year = 2020; year <= DateTime.Now.Year; year++)", "{", "    cbKhoa.Properties.Items.Add(year.ToString());", "}" });
            comboBoxEdit3.Size = new Size(100, 28);
            comboBoxEdit3.TabIndex = 14;
            // 
            // labelControl4
            // 
            labelControl4.Location = new Point(251, 66);
            labelControl4.Margin = new Padding(4, 3, 4, 3);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new Size(39, 13);
            labelControl4.TabIndex = 13;
            labelControl4.Text = "Subject:";
            // 
            // comboBoxEditClass
            // 
            comboBoxEditClass.Location = new Point(309, 7);
            comboBoxEditClass.Margin = new Padding(4, 3, 4, 3);
            comboBoxEditClass.Name = "comboBoxEditClass";
            comboBoxEditClass.Properties.Appearance.BackColor = Color.FromArgb(62, 64, 149);
            comboBoxEditClass.Properties.Appearance.Options.UseBackColor = true;
            comboBoxEditClass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            comboBoxEditClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            comboBoxEditClass.Properties.Items.AddRange(new object[] { "for (int year = 2020; year <= DateTime.Now.Year; year++)", "{", "    cbKhoa.Properties.Items.Add(year.ToString());", "}" });
            comboBoxEditClass.Size = new Size(100, 28);
            comboBoxEditClass.TabIndex = 12;
            // 
            // labelControlClass
            // 
            labelControlClass.Location = new Point(251, 14);
            labelControlClass.Margin = new Padding(4, 3, 4, 3);
            labelControlClass.Name = "labelControlClass";
            labelControlClass.Size = new Size(37, 13);
            labelControlClass.TabIndex = 11;
            labelControlClass.Text = "Faculty:";
            // 
            // simpleButton1
            // 
            simpleButton1.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("simpleButton1.ImageOptions.SvgImage");
            simpleButton1.ImageOptions.SvgImageSize = new Size(16, 16);
            simpleButton1.Location = new Point(671, 66);
            simpleButton1.Margin = new Padding(4, 3, 4, 3);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.Size = new Size(75, 23);
            simpleButton1.TabIndex = 10;
            simpleButton1.Text = "Filter";
            // 
            // comboBoxEdit2
            // 
            comboBoxEdit2.Location = new Point(105, 59);
            comboBoxEdit2.Margin = new Padding(4, 3, 4, 3);
            comboBoxEdit2.Name = "comboBoxEdit2";
            comboBoxEdit2.Properties.Appearance.BackColor = Color.FromArgb(62, 64, 149);
            comboBoxEdit2.Properties.Appearance.Options.UseBackColor = true;
            comboBoxEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            comboBoxEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            comboBoxEdit2.Properties.Items.AddRange(new object[] { "for (int year = 2020; year <= DateTime.Now.Year; year++)", "{", "    cbKhoa.Properties.Items.Add(year.ToString());", "}" });
            comboBoxEdit2.Size = new Size(95, 28);
            comboBoxEdit2.TabIndex = 9;
            // 
            // labelControl3
            // 
            labelControl3.Location = new Point(5, 66);
            labelControl3.Margin = new Padding(4, 3, 4, 3);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new Size(33, 13);
            labelControl3.TabIndex = 8;
            labelControl3.Text = "Intake:";
            // 
            // comboBoxEdit1
            // 
            comboBoxEdit1.Location = new Point(514, 7);
            comboBoxEdit1.Margin = new Padding(4, 3, 4, 3);
            comboBoxEdit1.Name = "comboBoxEdit1";
            comboBoxEdit1.Properties.Appearance.BackColor = Color.FromArgb(62, 64, 149);
            comboBoxEdit1.Properties.Appearance.Options.UseBackColor = true;
            comboBoxEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            comboBoxEdit1.Size = new Size(100, 28);
            comboBoxEdit1.TabIndex = 7;
            // 
            // labelControl2
            // 
            labelControl2.Location = new Point(456, 14);
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
            comboBoxEditcbHoc.Size = new Size(95, 28);
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
            // pictureBoxHeaderFindStudent
            // 
            pictureBoxHeaderFindStudent.BackgroundImage = (Image)resources.GetObject("pictureBoxHeaderFindStudent.BackgroundImage");
            pictureBoxHeaderFindStudent.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxHeaderFindStudent.Location = new Point(5, 5);
            pictureBoxHeaderFindStudent.Margin = new Padding(5, 3, 5, 3);
            pictureBoxHeaderFindStudent.Name = "pictureBoxHeaderFindStudent";
            pictureBoxHeaderFindStudent.Size = new Size(43, 43);
            pictureBoxHeaderFindStudent.TabIndex = 1;
            pictureBoxHeaderFindStudent.TabStop = false;
            // 
            // labelHeaderAttendance
            // 
            labelHeaderAttendance.AutoSize = true;
            labelHeaderAttendance.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelHeaderAttendance.ForeColor = Color.White;
            labelHeaderAttendance.Location = new Point(58, 12);
            labelHeaderAttendance.Margin = new Padding(5, 0, 5, 0);
            labelHeaderAttendance.Name = "labelHeaderAttendance";
            labelHeaderAttendance.Size = new Size(131, 25);
            labelHeaderAttendance.TabIndex = 0;
            labelHeaderAttendance.Text = "Attendance";
            // 
            // comboBoxEdit4
            // 
            comboBoxEdit4.Location = new Point(514, 59);
            comboBoxEdit4.Margin = new Padding(4, 3, 4, 3);
            comboBoxEdit4.Name = "comboBoxEdit4";
            comboBoxEdit4.Properties.Appearance.BackColor = Color.FromArgb(62, 64, 149);
            comboBoxEdit4.Properties.Appearance.Options.UseBackColor = true;
            comboBoxEdit4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            comboBoxEdit4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            comboBoxEdit4.Properties.Items.AddRange(new object[] { "for (int year = 2020; year <= DateTime.Now.Year; year++)", "{", "    cbKhoa.Properties.Items.Add(year.ToString());", "}" });
            comboBoxEdit4.Size = new Size(100, 28);
            comboBoxEdit4.TabIndex = 16;
            // 
            // labelControl5
            // 
            labelControl5.Location = new Point(456, 66);
            labelControl5.Margin = new Padding(4, 3, 4, 3);
            labelControl5.Name = "labelControl5";
            labelControl5.Size = new Size(26, 13);
            labelControl5.TabIndex = 15;
            labelControl5.Text = "Date:";
            // 
            // panel2
            // 
            panel2.Controls.Add(simpleButton5);
            panel2.Controls.Add(simpleButton4);
            panel2.Controls.Add(simpleButton3);
            panel2.Controls.Add(simpleButton2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 157);
            panel2.Name = "panel2";
            panel2.Size = new Size(1310, 64);
            panel2.TabIndex = 54;
            // 
            // simpleButton2
            // 
            simpleButton2.Location = new Point(10, 19);
            simpleButton2.Name = "simpleButton2";
            simpleButton2.Size = new Size(75, 23);
            simpleButton2.TabIndex = 0;
            simpleButton2.Text = "Edit";
            // 
            // simpleButton3
            // 
            simpleButton3.Location = new Point(114, 19);
            simpleButton3.Name = "simpleButton3";
            simpleButton3.Size = new Size(75, 23);
            simpleButton3.TabIndex = 1;
            simpleButton3.Text = "Export";
            // 
            // simpleButton4
            // 
            simpleButton4.Location = new Point(213, 19);
            simpleButton4.Name = "simpleButton4";
            simpleButton4.Size = new Size(75, 23);
            simpleButton4.TabIndex = 2;
            simpleButton4.Text = "Save\r\n";
            // 
            // simpleButton5
            // 
            simpleButton5.Location = new Point(309, 19);
            simpleButton5.Name = "simpleButton5";
            simpleButton5.Size = new Size(75, 23);
            simpleButton5.TabIndex = 3;
            simpleButton5.Text = "Cancel";
            // 
            // gridControl1
            // 
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.Location = new Point(0, 221);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(1310, 464);
            gridControl1.TabIndex = 55;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { gridColumnStudentID, gridColumnFullname, gridColumnClass, gridColumnSubject, gridColumnStatus, gridColumnNote });
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnStudentID
            // 
            gridColumnStudentID.Caption = "Student ID";
            gridColumnStudentID.Name = "gridColumnStudentID";
            gridColumnStudentID.Visible = true;
            gridColumnStudentID.VisibleIndex = 0;
            // 
            // gridColumnFullname
            // 
            gridColumnFullname.Caption = "Student Name";
            gridColumnFullname.Name = "gridColumnFullname";
            gridColumnFullname.Visible = true;
            gridColumnFullname.VisibleIndex = 1;
            // 
            // gridColumnClass
            // 
            gridColumnClass.Caption = "Class";
            gridColumnClass.Name = "gridColumnClass";
            gridColumnClass.Visible = true;
            gridColumnClass.VisibleIndex = 2;
            // 
            // gridColumnSubject
            // 
            gridColumnSubject.Caption = "Subject";
            gridColumnSubject.Name = "gridColumnSubject";
            gridColumnSubject.Visible = true;
            gridColumnSubject.VisibleIndex = 3;
            // 
            // gridColumnStatus
            // 
            gridColumnStatus.Caption = "Status";
            gridColumnStatus.Name = "gridColumnStatus";
            gridColumnStatus.Visible = true;
            gridColumnStatus.VisibleIndex = 4;
            // 
            // gridColumnNote
            // 
            gridColumnNote.Caption = "Note";
            gridColumnNote.Name = "gridColumnNote";
            gridColumnNote.Visible = true;
            gridColumnNote.VisibleIndex = 5;
            // 
            // AttendanceControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 32, 32);
            Controls.Add(gridControl1);
            Controls.Add(panel2);
            Controls.Add(panelHeaderAttendance);
            ForeColor = Color.White;
            Margin = new Padding(4, 3, 4, 3);
            Name = "AttendanceControl";
            Size = new Size(1310, 685);
            panelHeaderAttendance.ResumeLayout(false);
            panelHeaderAttendance.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)comboBoxEdit3.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEditClass.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEdit2.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEditcbHoc.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHeaderFindStudent).EndInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEdit4.Properties).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeaderAttendance;
        private PictureBox pictureBoxHeaderFindStudent;
        private Label labelHeaderAttendance;
        private Panel panel1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditClass;
        private DevExpress.XtraEditors.LabelControl labelControlClass;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditcbHoc;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private Panel panel2;
        private DevExpress.XtraEditors.SimpleButton simpleButton5;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnStudentID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnFullname;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnClass;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSubject;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnNote;
    }
}
