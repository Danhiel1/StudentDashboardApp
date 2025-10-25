using System;

namespace StudentDashboardApp.Services
{
    public static class AppSettingsHelper
    {
        public static string FormatDate(DateTime date)
        {
            return date.ToString(Properties.Settings.Default.DateFormat);
        }

        public static string FormatTime(DateTime time)
        {
            return time.ToString(Properties.Settings.Default.TimeFormat);
        }

        public static string FormatDateTime(DateTime dt)
        {
            return dt.ToString($"{Properties.Settings.Default.DateFormat} {Properties.Settings.Default.TimeFormat}");
        }
    }
}
