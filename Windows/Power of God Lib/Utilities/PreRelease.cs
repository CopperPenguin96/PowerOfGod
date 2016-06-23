using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Power_of_God_Lib.Utilities
{
    public class PreRelease
    {
        private static readonly string Phase = Network.VersionLetter();

        private static string VersionCode()
        {
            var text = Network.LatestStable(true);
            text = text.Substring(text.IndexOf(" ") + 1);
            for (var i = 1; i <= 26; i++)
            {
                var verText = i + ".0";
                if (text == verText)
                {
                    return i + "";
                }
            }
            return text;
        }


        private static string CurrentRelease()
        {
            if (Network.ReleaseNumber < 10)
            {
                return "00" + Network.ReleaseNumber;
            }
            else if (Network.ReleaseNumber < 100)
            {
                return "0" + Network.ReleaseNumber;
            }
            else
            {
                return "" + Network.ReleaseNumber;
            }
        }

        public static string GetString()
        {
            var phase = Phase;
            var vc = VersionCode() + "a";
            var cr = CurrentRelease();
            var combined = phase + vc + cr;
            return combined;
        }
    }
}
