using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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

        public static string[] GetPreReleaseParts(string prereleaseStr)
        {
            var chrArray = prereleaseStr.ToCharArray();
            var verName = chrArray[0].ToString();
            string verNumbers;
            if (prereleaseStr.Contains("."))
            {
                // hello.Any(x => !char.IsLetter(x));
               
                var index = 1 + chrArray.Count(c => !char.IsLetter(c));
                verNumbers = prereleaseStr.Substring(2, index);
            }
            return new[] {verName};
        }
        
    }
}
