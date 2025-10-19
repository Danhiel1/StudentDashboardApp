using System.Globalization;
using System.Resources;

public static class LanguageHelper
{
    private static ResourceManager _resourceManager =
        new ResourceManager("StudentDashboardApp.Resources.Languages.Strings",
            typeof(LanguageHelper).Assembly);

    public static void ApplyLanguage(string language)
    {
        string langCode = language.ToLower();

        if (langCode.Contains("vi"))
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN");
        else
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
    }

    public static string GetString(string key)
    {
        return _resourceManager.GetString(key) ?? key;
    }
}
