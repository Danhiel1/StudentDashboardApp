﻿using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;

namespace StudentDashboardApp.Services
{
    public class NavigationHelper
    {
        private readonly NavigationFrame _frame;
        private readonly Dictionary<BarButtonItem, (NavigationPage page, UserControl control)> _map;

        public NavigationHelper(
            NavigationFrame frame,
            Dictionary<BarButtonItem, (NavigationPage, UserControl)> map)
        {
            _frame = frame;
            _map = map;

            foreach (var btn in _map.Keys)
                btn.ItemClick += OnButtonClick;
        }

        private void OnButtonClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item is BarButtonItem btn && _pageMap.TryGetValue(btn, out var page))
            {
                // Tắt transition trước khi đổi page
                _frame.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.False;
                _frame.SelectedPage = page;
                _frame.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.True;
            }
        }


        public void ShowNavigationPage(NavigationPage page)
        {
            if (page == null) return;
            _frame.Visible = true;
            _frame.SelectedPage = page;
        }

        /// <summary>
        /// Đưa UserControl vào 1 page
        /// </summary>
        public void FillUserControlIntoPage(NavigationPage page, UserControl usc)
        {
            if (page == null || usc == null) return;

            page.Controls.Clear();       // Xóa control cũ trong page
            usc.Dock = DockStyle.Fill;   // Cho control full khung
            page.Controls.Add(usc);      // Thêm control mới vào
        }

        /// <summary>
        /// Hiển thị 1 page rỗng (option)
        /// </summary>
        public void ShowEmptyPage(NavigationPage emptyPage)
        {
            if (emptyPage == null) return;
            _frame.Visible = true;
            _frame.SelectedPage = emptyPage;
        }
    }
}

