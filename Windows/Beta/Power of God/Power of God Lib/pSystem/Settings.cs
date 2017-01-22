using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Power_of_God_Lib.Plugins;
using Power_of_God_Lib.Utilities;

namespace Power_of_God_Lib.pSystem
{
    public class Settings
    {
        public static Settings UserSettings = new Settings();
        /// <summary>
        /// If true, plugins are enabled
        /// </summary>
        public bool EnablePlugins;
        /// <summary>
        /// On crash, will save to crash log if enabled
        /// </summary>
        public bool EnableCrashReports;
        /// <summary>
        /// On crash, the CrashReport will be sent, if EnableCrashReports is set to true
        /// </summary>
        public bool SendCrashReports;
        /// <summary>
        /// At the close of the program logs are sent if enabled
        /// </summary>
        public bool EnableLogs;
        /// <summary>
        /// On the close of the program, sends the logs if EnableLogs is set to true
        /// </summary>
        public bool SendLogs;

        private static string[] PluginFileNames()
        {
            return PluginReader.PluginList.Select(p => p.FileName).ToArray();
        }
        
        public static Settings DefaultSettings = new Settings
        {
            EnablePlugins = true,
            EnableCrashReports = false,
            SendCrashReports = false,
            EnableLogs = false,
            SendLogs = false
        };
        public static void Save()
        {
            if (FileSystem.FileExists(1)) File.Delete(FileSystem.Files[1]);
            var fWriter = File.CreateText(FileSystem.Files[1]);
            fWriter.Write(JsonConvert.SerializeObject(UserSettings, Formatting.Indented));
            fWriter.Flush();
            fWriter.Close();
        }

        public static Settings Load()
        {
            if (!FileSystem.FileExists(1))
            {
                FileSystem.CreateMissingFile(1);
                return DefaultSettings;
            }
            else
            {
                var ftext = File.ReadAllText(FileSystem.Files[1]);
                var jsonObj = JsonConvert.DeserializeObject(ftext);
                return JsonConvert.DeserializeObject<Settings>(ftext);
            }
        }

    }
}
