namespace StudentDashboardApp.Model
{
    partial class FormConnectSQL
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
            label1 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            label4 = new Label();
            label3 = new Label();
            rdoSqlAuth = new RadioButton();
            rdoWindowsAuth = new RadioButton();
            btnTest = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            cboServer = new DevExpress.XtraEditors.ComboBoxEdit();
            cboDatabase = new DevExpress.XtraEditors.ComboBoxEdit();
            btnLoad = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cboServer.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboDatabase.Properties).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 25);
            label1.Name = "label1";
            label1.Size = new Size(67, 13);
            label1.TabIndex = 1;
            label1.Text = "Sever name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 65);
            label2.Name = "label2";
            label2.Size = new Size(88, 13);
            label2.TabIndex = 2;
            label2.Text = "Database name: ";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(txtUsername);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(rdoSqlAuth);
            groupBox1.Controls.Add(rdoWindowsAuth);
            groupBox1.FlatStyle = FlatStyle.Popup;
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(12, 104);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(342, 167);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = " Authentication";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(91, 127);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(215, 20);
            txtPassword.TabIndex = 5;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(91, 96);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(215, 20);
            txtUsername.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 130);
            label4.Name = "label4";
            label4.Size = new Size(56, 13);
            label4.TabIndex = 3;
            label4.Text = "Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 99);
            label3.Name = "label3";
            label3.Size = new Size(58, 13);
            label3.TabIndex = 2;
            label3.Text = "Username:";
            // 
            // rdoSqlAuth
            // 
            rdoSqlAuth.AutoSize = true;
            rdoSqlAuth.Location = new Point(25, 56);
            rdoSqlAuth.Name = "rdoSqlAuth";
            rdoSqlAuth.Size = new Size(148, 17);
            rdoSqlAuth.TabIndex = 1;
            rdoSqlAuth.Text = "SQL Sever Authentication";
            rdoSqlAuth.UseVisualStyleBackColor = true;
            rdoSqlAuth.CheckedChanged += rdoSqlAuth_CheckedChanged;
            // 
            // rdoWindowsAuth
            // 
            rdoWindowsAuth.AutoSize = true;
            rdoWindowsAuth.Checked = true;
            rdoWindowsAuth.Location = new Point(25, 33);
            rdoWindowsAuth.Name = "rdoWindowsAuth";
            rdoWindowsAuth.Size = new Size(143, 17);
            rdoWindowsAuth.TabIndex = 0;
            rdoWindowsAuth.TabStop = true;
            rdoWindowsAuth.Text = "Windows Authentication ";
            rdoWindowsAuth.UseVisualStyleBackColor = true;
            rdoWindowsAuth.CheckedChanged += rdoWindowsAuth_CheckedChanged;
            // 
            // btnTest
            // 
            btnTest.FlatAppearance.BorderColor = Color.White;
            btnTest.FlatStyle = FlatStyle.Flat;
            btnTest.Location = new Point(12, 292);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(95, 23);
            btnTest.TabIndex = 5;
            btnTest.Text = "Test Connection";
            btnTest.UseVisualStyleBackColor = true;
            btnTest.Click += btnTest_Click;
            // 
            // btnSave
            // 
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(116, 292);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(88, 23);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.FlatAppearance.BorderColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(287, 292);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(67, 23);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // cboServer
            // 
            cboServer.Location = new Point(116, 18);
            cboServer.Name = "cboServer";
            cboServer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cboServer.Properties.Items.AddRange(new object[] { "." });
            cboServer.Size = new Size(238, 28);
            cboServer.TabIndex = 8;
            // 
            // cboDatabase
            // 
            cboDatabase.Location = new Point(116, 58);
            cboDatabase.Name = "cboDatabase";
            cboDatabase.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cboDatabase.Size = new Size(238, 28);
            cboDatabase.TabIndex = 9;
            // 
            // btnLoad
            // 
            btnLoad.FlatStyle = FlatStyle.Flat;
            btnLoad.Location = new Point(210, 292);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(71, 23);
            btnLoad.TabIndex = 10;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // FormConnectSQL
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(366, 337);
            Controls.Add(btnLoad);
            Controls.Add(cboDatabase);
            Controls.Add(cboServer);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(btnTest);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "FormConnectSQL";
            Text = "Connect to SQL Sever";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cboServer.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboDatabase.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private RadioButton rdoSqlAuth;
        private RadioButton rdoWindowsAuth;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Button btnTest;
        private Button btnSave;
        private Button btnCancel;
        private DevExpress.XtraEditors.ComboBoxEdit cboServer;
        private DevExpress.XtraEditors.ComboBoxEdit cboDatabase;
        private Button btnLoad;
    }
}