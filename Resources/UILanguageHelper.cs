using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;

namespace StudentDashboardApp.Resources
{
    public static class UILanguageHelper
    {
        public static void ApplyLanguage(Control parent)
        {
            if (parent == null) return;

            // 🔹 Đầu tiên, duyệt qua các control bình thường
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl.Tag != null)
                {
                    string key = ctrl.Tag.ToString();
                    string text = LanguageHelper.GetString(key);
                    if (!string.IsNullOrEmpty(text))
                        ctrl.Text = text;
                }

                // DevExpress basic controls
                if (ctrl is SimpleButton btn && btn.Tag != null)
                    btn.Text = LanguageHelper.GetString(btn.Tag.ToString());

                if (ctrl is LabelControl lbl && lbl.Tag != null)
                    lbl.Text = LanguageHelper.GetString(lbl.Tag.ToString());

                if (ctrl is GroupControl grp && grp.Tag != null)
                    grp.Text = LanguageHelper.GetString(grp.Tag.ToString());

                if (ctrl is TabPage tab && tab.Tag != null)
                    tab.Text = LanguageHelper.GetString(tab.Tag.ToString());

                if (ctrl.HasChildren)
                    ApplyLanguage(ctrl);
            }

            // 🔹 Riêng form có RibbonControl
            if (parent is Form form)
            {
                foreach (Control c in form.Controls)
                {
                    if (c is RibbonControl ribbon)
                        ApplyRibbonLanguage(ribbon);
                }
            }
        }

        private static void ApplyRibbonLanguage(RibbonControl ribbon)
        {
            if (ribbon == null) return;

            // 🔸 Duyệt qua các Page
            foreach (RibbonPage page in ribbon.Pages)
            {
                if (page.Tag != null)
                    page.Text = LanguageHelper.GetString(page.Tag.ToString());

                // 🔸 Duyệt qua từng nhóm (RibbonPageGroup)
                foreach (RibbonPageGroup group in page.Groups)
                {
                    if (group.Tag != null)
                        group.Text = LanguageHelper.GetString(group.Tag.ToString());

                    // 🔸 Duyệt từng item (BarButtonItem, BarSubItem,…)
                    foreach (BarItemLink itemLink in group.ItemLinks)
                    {
                        if (itemLink.Item is BarButtonItem btn && btn.Tag != null)
                        {
                            string translated = LanguageHelper.GetString(btn.Tag.ToString());
                            if (!string.IsNullOrEmpty(translated))
                                btn.Caption = translated;
                        }
                    }
                }
            }
        }
    }
}
