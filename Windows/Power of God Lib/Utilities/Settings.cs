using System;
using System.IO;
using Newtonsoft.Json;

namespace Power_of_God_Lib.Utilities
{
    public enum BibleVersion { KJV, ESV, NIV, NLT }
    public class Settings
    {
        public static Settings UserSettings;
        public static string DefaultJsonSettings()
        {
            return "{\"bibplansenabled\":false,\"scriptver\":\"KJV\"}";
        }
        // ReSharper disable once InconsistentNaming
        public bool bibplansenabled = false;
        // ReSharper disable once InconsistentNaming
        public string scriptver = "KJV";
        public static void LoadFromJson()
        {
            const string file = "power.of.god/settings.json";
            if (!File.Exists(file)) return;
            try
            {
                var text = File.ReadAllText(file);
                var settings = JsonConvert.DeserializeObject<Settings>(text);
                UserSettings = settings;
            }
            catch (Exception e)
            {
                ErrorLogging.Write(e);
            }
        }

        public static void LoadDefault()
        {
            UserSettings = JsonConvert.DeserializeObject<Settings>(DefaultJsonSettings());
        }
        public static void SaveToJson()
        {
            var text = JsonConvert.SerializeObject(UserSettings);
            if (File.Exists("power.of.god/settings.json"))
            {
                File.Delete("power.of.god/settings.json");
            }
            var sWriter = File.CreateText("power.of.god/settings.json");
            sWriter.Write(text);
            sWriter.Flush();
            sWriter.Close();
        }
        /// <summary>
        /// Use when saving for checking if any changes are made
        /// </summary>
        /// <returns>Whether it needs saved or not based on true or false</returns>
        public bool CheckEquals()
        {
            return scriptver == UserSettings.scriptver;
        }
    }

}
