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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            button1 = new Button();
            GradeButton = new Button();
            StudentButton = new Button();
            CourseButton = new Button();
            HomeButton = new Button();
            panel3 = new Panel();
            button2 = new Button();
            panel2 = new Panel();
            notifyIcon1 = new NotifyIcon(components);
            fileSystemWatcher1 = new FileSystemWatcher();
            bindingSource1 = new BindingSource(components);
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(34, 43, 64);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(GradeButton);
            panel1.Controls.Add(StudentButton);
            panel1.Controls.Add(CourseButton);
            panel1.Controls.Add(HomeButton);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 696);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // button1
            // 
            button1.FlatAppearance.MouseDownBackColor = Color.Red;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(5, 197, 250);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(12, 625);
            button1.Name = "button1";
            button1.Size = new Size(174, 59);
            button1.TabIndex = 2;
            button1.Text = "Đăng nhập";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
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
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(24, 28, 38);
            panel3.Controls.Add(button2);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(200, 73);
            panel3.TabIndex = 0;
            panel3.Paint += panel3_Paint;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Top;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.FromArgb(5, 197, 250);
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(0, 0);
            button2.Name = "button2";
            button2.Size = new Size(200, 73);
            button2.TabIndex = 2;
            button2.Text = "Dashboard";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.TextImageRelation = TextImageRelation.ImageBeforeText;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(200, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(864, 73);
            panel2.TabIndex = 0;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(41, 44, 51);
            ClientSize = new Size(1064, 696);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(62, 120, 138);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private Button HomeButton;
        private Button GradeButton;
        private Button StudentButton;
        private Button CourseButton;
        private NotifyIcon notifyIcon1;
        private Button button2;
        private Button button1;
        private FileSystemWatcher fileSystemWatcher1;
        private BindingSource bindingSource1;
    }
}