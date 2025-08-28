namespace StudentDashboardApp.Model
{
    partial class DashboardStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardStudent));
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            barButtonGroup1 = new DevExpress.XtraBars.BarButtonGroup();
            barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            barDockingMenuItem1 = new DevExpress.XtraBars.BarDockingMenuItem();
            barDockingMenuItem2 = new DevExpress.XtraBars.BarDockingMenuItem();
            barListItem1 = new DevExpress.XtraBars.BarListItem();
            barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            barListItem2 = new DevExpress.XtraBars.BarListItem();
            barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbon.ExpandCollapseItem, barButtonItem1, barButtonGroup1, barButtonItem2, barDockingMenuItem1, barDockingMenuItem2, barButtonItem3, barListItem1, barSubItem1, barSubItem2, barButtonItem4, barListItem2, barButtonItem5 });
            ribbon.Location = new Point(0, 0);
            ribbon.MaxItemId = 25;
            ribbon.Name = "ribbon";
            ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1, ribbonPage2, ribbonPage3 });
            ribbon.Size = new Size(1090, 201);
            ribbon.StatusBar = ribbonStatusBar;
            // 
            // barButtonItem1
            // 
            barButtonItem1.Caption = "barButtonItem1";
            barButtonItem1.Id = 2;
            barButtonItem1.Name = "barButtonItem1";
            barButtonItem1.ItemClick += barButtonItem1_ItemClick;
            // 
            // barButtonGroup1
            // 
            barButtonGroup1.Caption = "barButtonGroup1";
            barButtonGroup1.Id = 10;
            barButtonGroup1.ItemLinks.Add(barButtonItem3);
            barButtonGroup1.Name = "barButtonGroup1";
            // 
            // barButtonItem3
            // 
            barButtonItem3.Id = 17;
            barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem2
            // 
            barButtonItem2.Caption = "barButtonItem2";
            barButtonItem2.Id = 11;
            barButtonItem2.Name = "barButtonItem2";
            // 
            // barDockingMenuItem1
            // 
            barDockingMenuItem1.Caption = "barDockingMenuItem1";
            barDockingMenuItem1.Id = 14;
            barDockingMenuItem1.Name = "barDockingMenuItem1";
            barDockingMenuItem1.ListItemClick += barDockingMenuItem1_ListItemClick_1;
            // 
            // barDockingMenuItem2
            // 
            barDockingMenuItem2.Caption = "barDockingMenuItem2";
            barDockingMenuItem2.Id = 15;
            barDockingMenuItem2.Name = "barDockingMenuItem2";
            // 
            // barListItem1
            // 
            barListItem1.Caption = "barListItem1";
            barListItem1.Id = 19;
            barListItem1.Name = "barListItem1";
            barListItem1.ListItemClick += barListItem1_ListItemClick;
            // 
            // barSubItem1
            // 
            barSubItem1.Caption = "barSubItem1";
            barSubItem1.Id = 20;
            barSubItem1.Name = "barSubItem1";
            // 
            // barSubItem2
            // 
            barSubItem2.Caption = "Import";
            barSubItem2.Id = 21;
            barSubItem2.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            barSubItem2.ImageOptions.Image = (Image)resources.GetObject("barSubItem2.ImageOptions.Image");
            barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barButtonItem4) });
            barSubItem2.Name = "barSubItem2";
            // 
            // barButtonItem4
            // 
            barButtonItem4.Caption = "barButtonItem4";
            barButtonItem4.Id = 22;
            barButtonItem4.Name = "barButtonItem4";
            barButtonItem4.ItemClick += barButtonItem4_ItemClick;
            // 
            // barListItem2
            // 
            barListItem2.Caption = "barListItem2";
            barListItem2.Id = 23;
            barListItem2.Name = "barListItem2";
            barListItem2.ListItemClick += barListItem2_ListItemClick;
            // 
            // barButtonItem5
            // 
            barButtonItem5.Caption = "Tra Cứu Thông Tin Sinh Viên";
            barButtonItem5.Id = 24;
            barButtonItem5.Name = "barButtonItem5";
            barButtonItem5.ItemClick += barButtonItem5_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Hệ Thống";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(barButtonGroup1);
            ribbonPageGroup1.ItemLinks.Add(barSubItem2);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonPage2
            // 
            ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup2 });
            ribbonPage2.Name = "ribbonPage2";
            ribbonPage2.Text = "Sinh Viên";
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.ItemLinks.Add(barButtonItem5);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // ribbonPage3
            // 
            ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup3, ribbonPageGroup4 });
            ribbonPage3.Name = "ribbonPage3";
            ribbonPage3.Text = "Ngành";
            // 
            // ribbonPageGroup3
            // 
            ribbonPageGroup3.Name = "ribbonPageGroup3";
            ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // ribbonPageGroup4
            // 
            ribbonPageGroup4.Name = "ribbonPageGroup4";
            ribbonPageGroup4.Text = "ribbonPageGroup4";
            // 
            // ribbonStatusBar
            // 
            ribbonStatusBar.Location = new Point(0, 509);
            ribbonStatusBar.Name = "ribbonStatusBar";
            ribbonStatusBar.Ribbon = ribbon;
            ribbonStatusBar.Size = new Size(1090, 37);
            // 
            // DashboardStudent
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1090, 546);
            Controls.Add(ribbonStatusBar);
            Controls.Add(ribbon);
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("DashboardStudent.IconOptions.SvgImage");
            Name = "DashboardStudent";
            Ribbon = ribbon;
            StatusBar = ribbonStatusBar;
            Text = "DashboardStudent";
            Load += DashboardStudent_Load;
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonGroup barButtonGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarDockingMenuItem barDockingMenuItem1;
        private DevExpress.XtraBars.BarDockingMenuItem barDockingMenuItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarListItem barListItem1;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarListItem barListItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
    }
}