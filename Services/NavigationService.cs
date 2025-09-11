using System.Collections.Generic;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;

namespace StudentDashboardApp.Services
{
    internal class NavigationService
    {
        private readonly Dictionary<RibbonPage, NavigationPage> ribbonToNavMap;

        // ✅ Constructor nhận Dictionary
        public NavigationService(Dictionary<RibbonPage, NavigationPage> mapping)
        {
            ribbonToNavMap = mapping;
        }

        // ✅ Method lấy NavigationPage từ RibbonPage
        public NavigationPage GetNavigationPage(RibbonPage ribbonPage)
        {
            if (ribbonPage == null) return null;

            return ribbonToNavMap.TryGetValue(ribbonPage, out var navPage)
                ? navPage
                : null;
        }

        // (tuỳ chọn) Lấy RibbonPage từ NavigationPage (nếu muốn đồng bộ 2 chiều)
        public RibbonPage GetRibbonPage(NavigationPage navPage)
        {
            foreach (var kvp in ribbonToNavMap)
            {
                if (kvp.Value == navPage)
                    return kvp.Key;
            }
            return null;
        }
    }
}
