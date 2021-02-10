using BaggageTransfer.Util;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using BaggageTransfer.SettingsHelpers;

namespace BaggageTransfer.Helpers
{
    public static class ThemeHelper
    {
        public static string GetTheme(string theme)
        {
            var layoutPath = "~/Views/Layouts/FallBack.cshtml";

            if (File.Exists(layoutPath.MapPath()))
            {
                layoutPath = $"~/Content/Themes/{theme}/Layout.cshtml";
            }

            return layoutPath;
        }

        public static IEnumerable<string> GetThemeDirectories()
        {
            return Directory.EnumerateDirectories("~/Content/Themes/".MapPath(), "*", SearchOption.TopDirectoryOnly).Select(c => new DirectoryInfo(c).Name);
        }
        
        public static IEnumerable<string> GetBundlePackages()
        {
            return Directory.EnumerateFiles("~/Content/Bundles/ScriptBundles".MapPath(), "*.xml").Select(c => Path.GetFileNameWithoutExtension(c));
        }

        internal static void SetBundleVersion(String version)
        {
            KeywordsHelper.SetKeywordValue("BundleVersion", version);
            KeywordsHelper.SetKeywordValue("BundleVersion", version, PerformanceMode.ApplicationState);
        }

        public static string GetCurrentBundleVersion()
        {
            String value = KeywordsHelper.GetKeywordValue("BundleVersion", PerformanceMode.ApplicationState);

            if (value == null || value.Length <= 0) {

                value = "1.0.0";
                KeywordsHelper.SetKeywordValue("BundleVersion", value);
            }

            return value;
        }
    }
}
