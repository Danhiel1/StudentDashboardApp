namespace StudentDashboardApp
{
    partial class Overviewcontrol
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
            statCard1 = new StatCard();
            SuspendLayout();
            // 
            // statCard1
            // 
            statCard1.BackColor = Color.FromArgb(45, 45, 45);
            statCard1.BorderStyle = BorderStyle.FixedSingle;
            statCard1.Location = new Point(322, 160);
            statCard1.Name = "statCard1";
            statCard1.Size = new Size(215, 148);
            statCard1.TabIndex = 0;
            // 
            // Overviewcontrol
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 32, 32);
            Controls.Add(statCard1);
            ForeColor = Color.White;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Overviewcontrol";
            Size = new Size(1310, 543);
            ResumeLayout(false);
        }

        #endregion

        private StatCard statCard1;
    }
}
