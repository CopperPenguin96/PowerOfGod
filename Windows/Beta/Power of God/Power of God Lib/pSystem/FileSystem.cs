using System;
using System.IO;
using Power_of_God_Lib.Utilities;

namespace Power_of_God_Lib.pSystem
{
    public class FileSystem
    {
        public static readonly string MainDirectory = "power.of.god/";

        public static readonly string[] Directories = {
            MainDirectory,
            MainDirectory + "Plugins/",
            MainDirectory + "Plugins/dll/",
            MainDirectory + "Plugins/Files/",
            MainDirectory + "UserInfo/",
            MainDirectory + "Logs/",
            MainDirectory + "Logs/Main/",
            MainDirectory + "Logs/Errors/"
        };

        public static readonly string[] Files =
        {
            Directories[0] + "main.json",
            Directories[0] + "setting.json",
            Directories[1] + "installed.json"
        };

        /// <summary>
        /// Creates missing directories
        /// </summary>
        /// <param name="skip">Directories to skip. Put null if none</param>
        public static bool CreateMissingDir(int[] skip)
        {
            for (var x = 0; x <= Directories.Length - 1; x++)
            {
                var skipIt = false;
                foreach (var y in skip)
                {
                    if (y == x) skipIt = true;
                }
                if (skipIt) continue;
                if (!Directory.Exists(Directories[x]))
                {
                    Directory.CreateDirectory(Directories[x]);
                    Logging.Log("Created directory: " + Directories[x]);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Checks if a file exists per its index of the Files array
        /// </summary>
        /// <param name="index">The index of the file</param>
        /// <returns></returns>
        public static bool FileExists(int index)
        {
            return File.Exists(Files[index]);
        }
        /// <summary>
        /// Creates the file if the file exists per its index of the Files array
        /// </summary>
        /// <param name="index">The index of the file</param>
        /// <returns></returns>
        public static bool CreateMissingFile(int index)
        {
            try
            {
                var v = File.Create(Files[index]);
                v.Close();
                Logging.Log("Created missing file: " + Files[index]);
                return true;
            }
            catch (Exception e)
            {
                Logging.LogError(e);
                return false;
            }
        }
    }
}
