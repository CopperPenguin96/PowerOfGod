using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_of_God_Lib.Utilities
{
    public class AppVersion
    {
        public static string[] VersionCode = {"Beta", "1", "0", null, null};
        public static bool PreRelease = true;
        public static int PreReleaseNumber = 9;
        public static string GetVersionCode()
        {
            if (!PreRelease)
            {
                var finalStr = "";
                if (VersionCode[0] == "Beta")
                {
                    finalStr += "Beta ";
                }
                finalStr += VersionCode[1] + "." + VersionCode[2];
                if (VersionCode[3] != null)
                {
                    finalStr += "." + VersionCode[3];
                }
                if (VersionCode[4] != null)
                {
                    finalStr += "." + VersionCode[4];
                }
                return finalStr;
            }
            else
            {
                var firstStep = "Pre-Release " + VersionCode[0].ToCharArray()[0].ToString().ToLower();
                var code = VersionCode[1];
                if (VersionCode[2] != "0")
                {
                    code += "." + VersionCode[2];
                    if (VersionCode[3] != null)
                    {
                        code += "." + VersionCode[3];
                    }
                    if (VersionCode[4] != null)
                    {
                        code += "." + VersionCode[4];
                    }
                }
                var finalBit = "";
                if (PreReleaseNumber < 10)
                {
                    finalBit = "a00" + PreReleaseNumber;
                }
                else if (PreReleaseNumber < 100)
                {
                    finalBit = "a0" + PreReleaseNumber;
                }
                else
                {
                    finalBit = "a" + PreReleaseNumber;
                }
                return firstStep + code + finalBit;
            }
        }
    }
}
