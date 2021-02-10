using BaggageTransfer.Util;
using System.Collections.Generic;
using System.Xml;

namespace BaggageTransfer.SettingsHelpers
{
    public static class ThemeStylesheetsHelper
    {
        const string xPath = "stylesheets/stylesheet";

        public static string[] GetPathsFromSettings(string themeName)
        {
            var fileName = string.Format("~/Themes/{0}/CSS.xml", themeName).MapPath();

            var paths = new List<string>();

            var xmlDoc = new XmlDocument();

            xmlDoc.Load(fileName);

            foreach (XmlNode pathNode in xmlDoc.SelectNodes(xPath))
            {
                paths.Add(pathNode.Attributes["path"].Value);
            }

            return paths.ToArray();
        }
    }
}
