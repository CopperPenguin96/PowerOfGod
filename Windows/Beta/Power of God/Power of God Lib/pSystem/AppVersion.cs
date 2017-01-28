using System;
using System.Collections.Generic;
using System.Linq;
using Power_of_God_Lib.Utilities;

namespace Power_of_God_Lib.pSystem
{
    public class AppVersion
    {
        public const bool IsPreRelease = true;
        public static string VersionPrefix = "Beta";
        
        public static string VersionLetter()
        {
            var x = VersionPrefix.ToLower().Substring(0, 1);
            return x;
        }
        public const int ReleaseNumber = 1;


        private static readonly string[] CurrentVersion = {
            "1", "0", "2", null
        };
        /// <summary>
        /// Gets current installed version
        /// </summary>
        /// <param name="catchingPreRelease">True if Pre-Release</param>
        /// <returns></returns>
        public static string GetCurrentVersion()
        {
            if (!IsPreRelease)
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
            var start = "Pre-Release " + VersionLetter() + CurrentVersion[0];
            var mid = "";
            var lastAvailable = -1;
            var lastLoop = false;
            foreach (var v in CurrentVersion)
            {
                if (lastLoop) continue;
                if (v != null) lastAvailable++;
                else lastLoop = true;
            }
            if (lastAvailable == 1)
            {
                if (CurrentVersion[1] != "0")
                {
                    mid += "." + CurrentVersion[1];
                }
            }
            else if (lastAvailable == 2)
            {
                mid += "." + CurrentVersion[1]
                    + "." + CurrentVersion[2];
            }
            else if (lastAvailable == 3)
            {
                mid += "." + CurrentVersion[1]
                    + "." + CurrentVersion[2]
                    + "." + CurrentVersion[3];
            }
            var finalString = "a";
            if (ReleaseNumber < 10) finalString += AddZeroes(2, ReleaseNumber);
            else if (ReleaseNumber < 100) finalString += AddZeroes(1, ReleaseNumber);
            else finalString += AddZeroes(0, ReleaseNumber);
            return start + mid + finalString;
        }

        private static string AddZeroes(int amount, int value)
        {
            var returnValue = "";
            for (var loopCount = 1; loopCount <= amount; loopCount++)
            {
                returnValue += "0";
            }
            return returnValue + value;
        }
        private static int CurrentPrefixInt()
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

        public static string ServerResponse = "Nothing Yet";

        public static string UpdateNotice()
        {
            switch (UpdateWord())
            {
                case "Updated":
                    return "You are currently updated to the most recent version.";
                case "Outdated":
                    return "You do not have the most recent version. Consider updating to " +
                           LatestOnline();
                default:
                    if (IsPreRelease)
                    {
                        return
                            "You are using a Pre-Release. Please note that not all features will be functional.\n\n" +
                            "(" + GetCurrentVersion() + ")";
                    }
                    else
                    {
                        return "You are using an unsupported version of Power of God. \nPlease consider " +
                            "using the current version, " + LatestOnline() +
                            ", \nbecause your version could possibly be unstable.";
                    }
            }
        }

        public static string UpdateWord()
        {
            try

            {

                int onlinePrefix;
                switch (Network.GetUrlSourceAsList(Url).ElementAt(0).Substring(1))
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
                Network.GetUrlSourceAsList(Url);
                var itemcontext = Network.GetUrlSourceAsList(Url).ElementAt(1);
                var item1 = int.Parse(itemcontext);
                var item2 = int.Parse(Network.GetUrlSourceAsList(Url).ElementAt(2));
                int item3; // If these values stay as -1 then the app will know to not read them
                var item4 = -1;
                try
                {
                    item3 = int.Parse(Network.GetUrlSourceAsList(Url).ElementAt(3));
                    try
                    {
                        item4 = int.Parse(Network.GetUrlSourceAsList(Url).ElementAt(4));
                    }
                    catch (Exception)
                    {
                        item4 = -1;
                    }
                }
                catch (Exception)
                {
                    item3 = -1;
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
                return "Updated"; // If it gets to this point - the user has passed all checks. They are updated!
            }
            catch (Exception ex)
            {
                Logging.LogError(ex);
                return "Updated"; // Exception caught. Let the user continue.
            }
        }

        private static IEnumerable<int> CurrentVersionInt()
        {
            var xList = new List<int>();
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

        private const string Url = "http://godispower.us/Application/Updates.txt";
        /// <summary>
        /// Gets latest version
        /// </summary>
        /// <returns></returns>
        public static string LatestOnline()
        {
            var x = Network.GetUrlSourceAsList(Url).ElementAt(0) + " ";
            var versionStoppedAt = 0;
            for (var x2 = 1; x2 <= 4; x2++)
            {
                if (x2 >= 5) continue;
                if (!Network.GetUrlSourceAsList(Url).ElementAt(x2).Equals("NR"))
                {
                    if (x2 < 4) x += "" + Network.GetUrlSourceAsList(Url).ElementAt(x2) + ".";
                    else if (x2 == 4) x += "" + Network.GetUrlSourceAsList(Url).ElementAt(x2);
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
    }
}
