using System.IO;

namespace Power_of_God_Lib.Utilities
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
            Directories[2] + "main.json",
            Directories[2] + "setting.json",
            Directories[1] + "installed.json"
        };

        /// <summary>
        /// Creates missing directories
        /// </summary>
        /// <param name="skip">Directories to skip. Put null if none</param>
        public static void CreateMissingDir(int[] skip)
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
                }
            }
        }
    }
}
