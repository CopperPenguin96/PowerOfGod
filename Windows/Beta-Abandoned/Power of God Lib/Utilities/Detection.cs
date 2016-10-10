using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Power_of_God_Lib.Utilities
{
    public class Detection
    {
        /// <summary>
        /// Detects if user is using the Mono Framework
        /// </summary>
        /// <returns>true if on mono</returns>
        public static bool IsRunningOnMono()
        {
            return Type.GetType("Mono.Runtime") != null;
        }
        /// <summary>
        /// Gets if 32 bit or 64
        /// </summary>
        /// <returns>Amount of bits</returns>
        public static string GetBits()
        {
            return System.Environment.Is64BitOperatingSystem == false ? "32-Bit" : "64-Bit";
        }
        /// <summary>
        /// Gets the name of the OS
        /// </summary>
        /// <returns></returns>
        public static string GetOperatingSystemName()
        {
            var p = (int)Environment.OSVersion.Platform;
            if (IsRunningOnMono())
            {
                try
                {
                    var flines = File.ReadAllLines("/etc/lsb-release").ToList();
                    var returnText = "";
                    foreach (var v in flines)
                    {
                        const string id = "DISTRIB_ID=";
                        const string release = "DISTRIB_RELEASE=";
                        if (v.Contains(id))
                        {
                            returnText += v.Substring(id.Length) + " ";
                        }
                        if (v.Contains(release))
                        {
                            returnText += v.Substring(release.Length);
                        }
                    }
                    return returnText;
                }
                catch (Exception)
                {
                    return "Unknown";
                }

            }
            else
            {
                return Environment.OSVersion.ToString();
            }
            return "";
        }
        /// <summary>
        /// Full System info
        /// </summary>
        /// <returns></returns>
        public static List<string> FullSystemInfo()
        {
            var list = new List<string>();
            list.Add("-----User's System Information-----");
            list.Add("OS Version: " + GetOperatingSystemName());
            list.Add("Bits: " + GetBits());
            return list;
        }
    }
}
