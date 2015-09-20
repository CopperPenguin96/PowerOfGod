using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography.Core;
using Windows.UI.ViewManagement;

namespace Power_of_God.Network
{
    public class Updater
    {
        private const string VersionPrefix = "Alpha";

        private static readonly string[] CurrentVersion =
        {
            "1", "2", null
        };

        private static string TogetherNumbers()
        {
            var versionPrefixCount = VersionPrefix.Length;
            return LatestStable().Substring(versionPrefixCount + 1);
        }

        public static string LatestStable()
        {
            var returnValue = VersionPrefix + " " + CurrentVersion[0] + "." +
                              CurrentVersion[1];
            if (CurrentVersion[2] == null) return returnValue;
            returnValue += "." + CurrentVersion[2];
            if (CurrentVersion[3] != null)
            {
                returnValue += "." + CurrentVersion[3];
            }

            return returnValue;
        }

        public static string ServerResponse = "Nothing Yet";
        
        public static string UpdateNotice()
        {
            switch (UpdateWord())
            {
                case "Updated":
                    return "You are currently using the most recent version.";
                case "Outdated":
                    return "You do not have the most recent version." +
                           "You should consider updated to " + LatestOnline();
                default:
                    return "You are using an unsupported version of Power of God." +
                           "You should consider using the current released version, " + LatestOnline() +
                           ", because yours could possibly be unstable.";
            }
        }

        private const string UrlGlobal = "http://godispower.us/Application/Updates.txt";
        public static string funUrl;
        public static string UpdateWord()
        {
            int onlinePrefix;
            var stringObj = GetUrlSource(UrlGlobal).ElementAt(0);
            funUrl = GetUrlSource(UrlGlobal).ElementAt(0).Substring(0, stringObj.Length - 1);
            switch (stringObj)
            {
                case "Alpha":
                    onlinePrefix = 0;
                    break;
                case "Beta":
                    onlinePrefix = 1;
                    break;
                default:
                    onlinePrefix = 2;
                    break;
            }
            var item1 = int.Parse(GetUrlSource(UrlGlobal).ElementAt(1));
            var item2 = int.Parse(GetUrlSource(UrlGlobal).ElementAt(2));
            var item3 = -1;
            var item4 = -1;
            try
            {
                item3 = int.Parse(GetUrlSource(UrlGlobal).ElementAt(3));
                try
                {
                    item4 = int.Parse(GetUrlSource(UrlGlobal).ElementAt(4));
                }
                catch (Exception)
                {
                    item4 = -1;
                }
            }
            catch (Exception)
            {
                item3 = -1;
                //No Console to log stuff
            }
            if (onlinePrefix > CurrentPrefixInt()) return "Outdated";
            if (onlinePrefix < CurrentPrefixInt()) return "Unsupported";
            if (item1 > CurrentVersionInt().ElementAt(0)) return "Outdated";
            if (item1 < CurrentVersionInt().ElementAt(0)) return "Unsupported";
            if (item2 > CurrentVersionInt().ElementAt(1)) return "Outdated";
            if (item2 < CurrentVersionInt().ElementAt(1)) return "Unsupported";
            if (item3 > -1)
            {
                var local3 = CurrentVersionInt().ElementAt(2);
                if (item3 > local3) return "Outdated";
                if (item3 < local3) return "Unsupported";
                if (item4 > -1)
                {
                    var local4 = CurrentVersionInt().ElementAt(3);
                    if (item4 > local4) return "Outdated";
                    if (item4 < local4) return "Unsupported";
                }
                else
                {
                    var localHere = CurrentVersion[3];
                    if (localHere != null) return "Unsupported";
                }
            }
            else
            {
                var localHere = CurrentVersion[2];
                if (localHere != null) return "Unsupported";
            }
            return "Updated";
        }

        public static int CurrentPrefixInt()
        {
            switch (VersionPrefix)
            {
                case "Alpha":
                    return 0;
                case "Beta":
                    return 1;
                default:
                    return 2;
            }
        }

        public static List<int> CurrentVersionInt()
        {
            List<int> xList = new List<int>();
            foreach (var x in CurrentVersion)
            {
                try
                {
                    xList.Add(int.Parse(x));
                }
                catch (Exception)
                {
                    xList.Add(-1);
                }
            }
            return xList;
        } 
        
        public static string LatestOnline()
        {
            var x = GetUrlSource(UrlGlobal).ElementAt(0) + " ";
            var versionStoppedAt = 0;
            for (var x2 = 1; x2 <= 4; x2++)
            {
                if (x2 >= 5) continue;
                if (GetUrlSource(UrlGlobal).ElementAt(x2) != "NR")
                {
                    if (x2 < 4) x += "" + GetUrlSource(UrlGlobal).ElementAt(x2) + ".";

                    else if (x2 == 4) x += "" + GetUrlSource(UrlGlobal).ElementAt(x2);
                }
                else
                {
                    versionStoppedAt = x2;
                }
            }
            if (versionStoppedAt == 3 || versionStoppedAt == 4)
            {
                return x.Substring(0, x.Length - 1);
            }
            return x;
        }
        public static List<string> GetUrlSource(string url)
        {
            var webRequest = WebRequest.Create(url);
            var newList = new List<string>();
            using (var response = webRequest.GetResponseAsync().Result)
            using (var content = response.GetResponseStream())
            using (var reader = new StreamReader(content))
            {
                for (var x = 1; x <= 5; x++) // 5 definite lines in the file
                {
                    newList.Add(reader.ReadLine());
                }
            }
            return newList;
        }
    }
}
