namespace StudentDashboardApp.Forms
{
    partial class DashBoardStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashBoardStudent));
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            mnBackup = new DevExpress.XtraBars.BarButtonItem();
            mnRestore = new DevExpress.XtraBars.BarButtonItem();
            btnThoat = new DevExpress.XtraBars.BarButtonItem();
            skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            ribbonPageHTT = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageHt = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonCTDT = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ribbonPage4 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonSinhVien = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageStudent = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            AddStudentBtn = new DevExpress.XtraBars.BarButtonItem();
            ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            DelStudentBtn = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.EmptyAreaImageOptions.ImagePadding = new Padding(35);
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbon.ExpandCollapseItem, mnBackup, mnRestore, btnThoat, skinRibbonGalleryBarItem1, AddStudentBtn, DelStudentBtn });
            ribbon.Location = new Point(0, 0);
            ribbon.Margin = new Padding(4, 3, 4, 3);
            ribbon.MaxItemId = 9;
            ribbon.Name = "ribbon";
            ribbon.OptionsMenuMinWidth = 385;
            ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPageHTT, ribbonCTDT, ribbonSinhVien });
            ribbon.Size = new Size(1010, 201);
            ribbon.StatusBar = ribbonStatusBar;
            ribbon.Click += ribbon_Click;
            // 
            // mnBackup
            // 
            mnBackup.Caption = "Backup";
            mnBackup.Id = 1;
            mnBackup.ImageOptions.Image = (Image)resources.GetObject("mnBackup.ImageOptions.Image");
            mnBackup.ImageOptions.LargeImage = (Image)resources.GetObject("mnBackup.ImageOptions.LargeImage");
            mnBackup.Name = "mnBackup";
            mnBackup.ItemClick += mnBackup_ItemClick;
            // 
            // mnRestore
            // 
            mnRestore.Caption = "Restore";
            mnRestore.Id = 2;
            mnRestore.ImageOptions.Image = (Image)resources.GetObject("mnRestore.ImageOptions.Image");
            mnRestore.ImageOptions.LargeImage = (Image)resources.GetObject("mnRestore.ImageOptions.LargeImage");
            mnRestore.Name = "mnRestore";
            mnRestore.ItemClick += mnRestore_ItemClick;
            // 
            // btnThoat
            // 
            btnThoat.Caption = "Thoát";
            btnThoat.Id = 3;
            btnThoat.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnThoat.ImageOptions.SvgImage");
            btnThoat.Name = "btnThoat";
            // 
            // skinRibbonGalleryBarItem1
            // 
            skinRibbonGalleryBarItem1.Caption = "skinRibbonGalleryBarItem1";
            skinRibbonGalleryBarItem1.Id = 5;
            skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // ribbonPageHTT
            // 
            ribbonPageHTT.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageHt, ribbonPageGroup1 });
            ribbonPageHTT.Name = "ribbonPageHTT";
            ribbonPageHTT.Text = "Hệ thống";
            // 
            // ribbonPageHt
            // 
            ribbonPageHt.ItemLinks.Add(mnBackup, true);
            ribbonPageHt.ItemLinks.Add(mnRestore, true);
            ribbonPageHt.ItemLinks.Add(btnThoat, true);
            ribbonPageHt.Name = "ribbonPageHt";
            ribbonPageHt.Text = "Hệ Thống";
            // 
            // ribbonCTDT
            // 
            ribbonCTDT.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup2 });
            ribbonCTDT.Name = "ribbonCTDT";
            ribbonCTDT.Text = "Chương Trình Đào Tạo";
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // ribbonStatusBar
            // 
            ribbonStatusBar.Location = new Point(0, 869);
            ribbonStatusBar.Margin = new Padding(4, 3, 4, 3);
            ribbonStatusBar.Name = "ribbonStatusBar";
            ribbonStatusBar.Ribbon = ribbon;
            ribbonStatusBar.Size = new Size(1010, 37);
            // 
            // ribbonPage4
            // 
            ribbonPage4.Name = "ribbonPage4";
            ribbonPage4.Text = "ribbonPage4";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonSinhVien
            // 
            ribbonSinhVien.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageStudent });
            ribbonSinhVien.Name = "ribbonSinhVien";
            ribbonSinhVien.Text = "Sinh Viên";
            // 
            // ribbonPageStudent
            // 
            ribbonPageStudent.ItemLinks.Add(AddStudentBtn);
            ribbonPageStudent.ItemLinks.Add(DelStudentBtn);
            ribbonPageStudent.Name = "ribbonPageStudent";
            ribbonPageStudent.Text = "Sinh Viên";
            // 
            // AddStudentBtn
            // 
            AddStudentBtn.Caption = "Thêm Sinh Viên";
            AddStudentBtn.Id = 6;
            AddStudentBtn.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("AddStudent.ImageOptions.SvgImage");
            AddStudentBtn.Name = "AddStudentBtn";
            // 
            // ribbonPageGroup4
            // 
            ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // DelStudentBtn
            // 
            DelStudentBtn.Caption = "Xóa Sinh Viên";
            DelStudentBtn.Id = 7;
            DelStudentBtn.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("DelStudentBtn.ImageOptions.SvgImage");
            DelStudentBtn.Name = "DelStudentBtn";
            // 
            // DashBoardStudent
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1010, 906);
            Controls.Add(ribbonStatusBar);
            Controls.Add(ribbon);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(4, 3, 4, 3);
            Name = "DashBoardStudent";
            Ribbon = ribbon;
            StatusBar = ribbonStatusBar;
            Text = "DashBoardStudent";
            Load += DashBoardStudent_Load;
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageHTT;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageHt;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonCTDT;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
       
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage4;
        private DevExpress.XtraBars.BarButtonItem mnBackup;
        private DevExpress.XtraBars.BarButtonItem mnRestore;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonSinhVien;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageStudent;
        private DevExpress.XtraBars.BarButtonItem AddStudentBtn;
        private DevExpress.XtraBars.BarButtonItem DelStudentBtn;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
    }
}