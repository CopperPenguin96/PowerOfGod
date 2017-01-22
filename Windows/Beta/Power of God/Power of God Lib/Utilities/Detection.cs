using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic.Devices;

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
            return Environment.Is64BitOperatingSystem == false ? "32-Bit" : "64-Bit";
        }
        /// <summary>
        /// Gets the name of the OS
        /// </summary>
        /// <returns>The name of the Operating System</returns>
        public static string GetOperatingSystemName()
        {
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
                catch (Exception ex)
                {
                    Logging.LogError(ex);
                    return "Unknown";
                }

            }
            return Environment.OSVersion.ToString();
        }
        /// <summary>
        /// Full System info
        /// </summary>
        /// <returns></returns>
        public static List<string> FullSystemInfo()
        {
            var list = new List<string>
            {
                "-----User's System Information-----",
                "OS Version: " + GetOperatingSystemName(),
                "Bits: " + GetBits(),
                "RAM (Available): " + GetAvailableRAM(),
                "RAM (Total): " + GetTotalRAM()
            };
            return list;
        }

        public static ulong GetAvailableRAM()
        {
            var ci = new ComputerInfo();
            return ci.AvailablePhysicalMemory;
        }

        public static ulong GetTotalRAM()
        {
            var ci = new ComputerInfo();
            return ci.TotalPhysicalMemory;
        }
    }
}