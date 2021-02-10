using BaggageTransfer.Util;
using System.Collections.Generic;
using System.Xml;
using System;

namespace BaggageTransfer.SettingsHelpers
{
    public static class MvcThemeScriptsHelper
    {
        const string scriptXPath = "scripts/script";

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

            foreach (XmlNode pathNode in xmlDoc.SelectNodes(scriptXPath))
            {
                paths.Add(pathNode.Attributes["path"].Value);
            }

            return paths.ToArray();
        }

    }
}
