using BaggageTransfer.Util;
using System.Collections.Generic;
using System.Xml;

namespace BaggageTransfer.SettingsHelpers
{
    public static class ThemeScriptsHelper
    {
        const string xPath = "scripts/script";

        public static string[] GetPathsFromSettings(string themeName)
        {
            return GetPathsFromXML($"~/Content/Themes/{themeName}/Scripts.xml".MapPath());
        }

        public static string[] GetPathsFromXMLPackage(string package)
        {
            return GetPathsFromXML($"~/Content/Bundles/ScriptBundles/{package}.xml".MapPath());
        }

        public static string[] GetPathsFromXML(string fileName)
        {

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
