using System;
using System.Collections.Generic;
using System.IO;

namespace BaggageTransfer.AppCode.OFrame
{
    public class EMailBuilder
    {
        static readonly string TAG_START = "[--";
        static readonly string TAG_STOP = "--]";

        public static string Build(string EmailMarkup, params KeyValuePair<string, string>[] Substitutions)
        {
            return Build(EmailMarkup, GetSubstitutions(Substitutions));
        }

        public static string Build(string EmailMarkup, Dictionary<string, string> Substitutions)
        {
            var emailMarkup = EmailMarkup;
            if (Substitutions.Count > 0)
            {
                foreach (var token in Substitutions)
                {
                    var tokenTag = TAG_START + token.Key + TAG_STOP;
                    emailMarkup = emailMarkup.Replace(tokenTag, token.Value);
                }
            }
            return emailMarkup;
        }

        public static string BuildFromFile(string path, params KeyValuePair<string, string>[] Substitutions)
        {
            try
            {
                return Build(File.Exists(path) ? File.ReadAllText(path) : "", Substitutions);
            }
            catch { throw; }
        }

        public static Dictionary<string, string> GetSubstitutions(params KeyValuePair<string, string>[] Substitutions)
        {
            var _tagList = new Dictionary<string, string>();
            for (var i = 0; i < Substitutions.Length; i++)
            {
                _tagList.Add(Substitutions[i].Key, Substitutions[i].Value);
            }
            return _tagList;
        }

    }

    public class Substitution
    {
        public static KeyValuePair<string, string> Get(string key, string value)
        {
            return new KeyValuePair<string, string>(key, value);
        }

    }

}
