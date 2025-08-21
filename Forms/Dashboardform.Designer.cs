namespace StudentDashboardApp.Forms

{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            GradeButton = new Button();
            StudentButton = new Button();
            CourseButton = new Button();
            HomeButton = new Button();
            panel2 = new Panel();
            panel3 = new Panel();
            DTHS = new DataGridView();
            MASV = new DataGridViewTextBoxColumn();
            TENSV = new DataGridViewTextBoxColumn();
            NGAYSINH = new DataGridViewTextBoxColumn();
            NOISINH = new DataGridViewTextBoxColumn();
            MALOP = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DTHS).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = Color.FromArgb(34, 43, 64);
            panel1.Controls.Add(GradeButton);
            panel1.Controls.Add(StudentButton);
            panel1.Controls.Add(CourseButton);
            panel1.Controls.Add(HomeButton);
            panel1.Location = new Point(0, 70);
            panel1.Name = "panel1";
            panel1.Size = new Size(203, 626);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // GradeButton
            // 
            GradeButton.FlatAppearance.BorderSize = 0;
            GradeButton.FlatStyle = FlatStyle.Flat;
            GradeButton.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            GradeButton.ForeColor = Color.White;
            GradeButton.Image = (Image)resources.GetObject("GradeButton.Image");
            GradeButton.Location = new Point(0, 350);
            GradeButton.Name = "GradeButton";
            GradeButton.Size = new Size(200, 83);
            GradeButton.TabIndex = 2;
            GradeButton.Text = "Grade";
            GradeButton.TextAlign = ContentAlignment.BottomCenter;
            GradeButton.TextImageRelation = TextImageRelation.ImageAboveText;
            GradeButton.UseVisualStyleBackColor = true;
            // 
            // StudentButton
            // 
            StudentButton.FlatAppearance.BorderSize = 0;
            StudentButton.FlatStyle = FlatStyle.Flat;
            StudentButton.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StudentButton.ForeColor = Color.White;
            StudentButton.Image = (Image)resources.GetObject("StudentButton.Image");
            StudentButton.Location = new Point(0, 191);
            StudentButton.Name = "StudentButton";
            StudentButton.Size = new Size(200, 83);
            StudentButton.TabIndex = 2;
            StudentButton.Text = "Student";
            StudentButton.TextAlign = ContentAlignment.BottomCenter;
            StudentButton.TextImageRelation = TextImageRelation.ImageAboveText;
            StudentButton.UseVisualStyleBackColor = true;
            StudentButton.Click += StudentButton_Click;
            // 
            // CourseButton
            // 
            CourseButton.FlatAppearance.BorderSize = 0;
            CourseButton.FlatStyle = FlatStyle.Flat;
            CourseButton.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CourseButton.ForeColor = Color.White;
            CourseButton.Image = (Image)resources.GetObject("CourseButton.Image");
            CourseButton.Location = new Point(0, 271);
            CourseButton.Name = "CourseButton";
            CourseButton.Size = new Size(200, 83);
            CourseButton.TabIndex = 2;
            CourseButton.Text = "Course";
            CourseButton.TextAlign = ContentAlignment.BottomCenter;
            CourseButton.TextImageRelation = TextImageRelation.ImageAboveText;
            CourseButton.UseVisualStyleBackColor = true;
            // 
            // HomeButton
            // 
            HomeButton.FlatAppearance.BorderSize = 0;
            HomeButton.FlatStyle = FlatStyle.Flat;
            HomeButton.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HomeButton.ForeColor = Color.White;
            HomeButton.Image = (Image)resources.GetObject("HomeButton.Image");
            HomeButton.Location = new Point(0, 111);
            HomeButton.Name = "HomeButton";
            HomeButton.Size = new Size(200, 83);
            HomeButton.TabIndex = 2;
            HomeButton.Text = "Home";
            HomeButton.TextAlign = ContentAlignment.BottomCenter;
            HomeButton.TextImageRelation = TextImageRelation.ImageAboveText;
            HomeButton.UseVisualStyleBackColor = true;
            HomeButton.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.AutoSize = true;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 66);
            panel2.Name = "panel2";
            panel2.Size = new Size(1064, 2);
            panel2.TabIndex = 0;
            panel2.Paint += panel2_Paint;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(24, 28, 38);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1064, 66);
            panel3.TabIndex = 0;
            panel3.Paint += panel3_Paint;
            // 
            // DTHS
            // 
            DTHS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DTHS.Columns.AddRange(new DataGridViewColumn[] { MASV, TENSV, NGAYSINH, NOISINH, MALOP });
            DTHS.Location = new Point(209, 70);
            DTHS.Name = "DTHS";
            DTHS.RowHeadersWidth = 62;
            DTHS.Size = new Size(830, 381);
            DTHS.TabIndex = 1;
            DTHS.CellContentClick += dataGridView1_CellContentClick_2;
            // 
            // MASV
            // 
            MASV.DataPropertyName = "MASV";
            MASV.HeaderText = "Mã SV";
            MASV.MinimumWidth = 8;
            MASV.Name = "MASV";
            MASV.Width = 150;
            // 
            // TENSV
            // 
            TENSV.DataPropertyName = "TENSV";
            TENSV.HeaderText = "  TÊN SV";
            TENSV.MinimumWidth = 8;
            TENSV.Name = "TENSV";
            TENSV.Width = 150;
            // 
            // NGAYSINH
            // 
            NGAYSINH.DataPropertyName = "NGAYSINH";
            NGAYSINH.HeaderText = "Ngày Sinh";
            NGAYSINH.MinimumWidth = 8;
            NGAYSINH.Name = "NGAYSINH";
            NGAYSINH.Width = 150;
            // 
            // NOISINH
            // 
            NOISINH.DataPropertyName = "NOISINH";
            NOISINH.HeaderText = "Nơi Sinh";
            NOISINH.MinimumWidth = 8;
            NOISINH.Name = "NOISINH";
            NOISINH.Width = 150;
            // 
            // MALOP
            // 
            MALOP.DataPropertyName = "MALOP";
            MALOP.HeaderText = "Mã Lớp";
            MALOP.MinimumWidth = 8;
            MALOP.Name = "MALOP";
            MALOP.Width = 150;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(41, 44, 51);
            BackgroundImageLayout = ImageLayout.None;
            CancelButton = StudentButton;
            ClientSize = new Size(1064, 696);
            Controls.Add(DTHS);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(62, 120, 138);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DTHS).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button GradeButton;
        private Button StudentButton;
        private Button CourseButton;
        private Panel panel3;
        public Button HomeButton;
        private DataGridView DTHS;
        private DataGridViewTextBoxColumn MASV;
        private DataGridViewTextBoxColumn TENSV;
        private DataGridViewTextBoxColumn NGAYSINH;
        private DataGridViewTextBoxColumn NOISINH;
        private DataGridViewTextBoxColumn MALOP;
    }
}