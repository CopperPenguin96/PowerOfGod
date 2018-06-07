using Newtonsoft.Json;
using System.IO;

namespace pogLib.pSystem
{
    public enum SettingsCategory { General, Bible, ScriptureStudies }

    public struct SettingsDefinition
    {
        public string Text;
        public object DefaultValue;
        public object Value;
        public SettingsCategory Category;
    }

    public class Settings
    {
        public static Settings Current = new Settings();

        public static bool Save()
        {
            string settingsFile = "settings.json";
            try
            {
                var writer = File.CreateText(settingsFile);
                writer.WriteLine(JsonConvert.SerializeObject(Current, Formatting.Indented));
                writer.Flush();
                writer.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Load(out Settings loaded)
        {
            string settingsFile = "settings.json";
            try
            {

                loaded = !File.Exists(settingsFile) 
                    ? new Settings() 
                    : JsonConvert.DeserializeObject<Settings>(File.ReadAllText(settingsFile));
                loaded.SetDefaults();
                return true;
            }
            catch
            {
                loaded = null;
                return false;
            }
        }

        private void SetDefaults()
        {
            // General
            if (DisplayNotifications.Value == null) DisplayNotifications.Value = DisplayNotifications.DefaultValue;
            if (CheckForUpdates.Value == null) CheckForUpdates.Value = CheckForUpdates.DefaultValue;
            if (EnablePlugins.Value == null) EnablePlugins.Value = EnablePlugins.DefaultValue;
            if (DisplaySermonText.Value == null) DisplaySermonText.Value = DisplaySermonText.DefaultValue;

            // Bible
            if (ShowVersesInText.Value == null) ShowVersesInText.Value = ShowVersesInText.DefaultValue;
            if (BibleVersion.Value == null) BibleVersion.Value = BibleVersion.DefaultValue;

            // Scripture Study
            if (DisplayScriptureNotifications.Value == null) DisplayScriptureNotifications.Value = DisplayScriptureNotifications.DefaultValue;
        }
        #region General Settings
        public SettingsDefinition DisplayNotifications = new SettingsDefinition
        {
            Text = "Display Notifications",
            DefaultValue = true,
            Category = SettingsCategory.General
        };

        public SettingsDefinition CheckForUpdates = new SettingsDefinition
        {
            Text = "Check for Updates",
            DefaultValue = true,
            Category = SettingsCategory.General
        };

        public SettingsDefinition EnablePlugins = new SettingsDefinition
        {
            Text = "Enable Plugins",
            DefaultValue = false,
            Category = SettingsCategory.General
        };

        public SettingsDefinition DisplaySermonText = new SettingsDefinition
        {
            Text = "Show sermon in text form",
            DefaultValue = true,
            Category = SettingsCategory.General
        };
        #endregion

        #region Bible Settings
        public SettingsDefinition ShowVersesInText = new SettingsDefinition
        {
            Text = "Show Verses in Sermon Text",
            DefaultValue = true,
            Category = SettingsCategory.Bible
        };

        public SettingsDefinition BibleVersion = new SettingsDefinition
        {
            Text = "Bible Version",
            DefaultValue = "KJV",
            Category = SettingsCategory.Bible
        };
        #endregion

        #region Scripture Study Notifications
        public SettingsDefinition DisplayScriptureNotifications = new SettingsDefinition
        {
            Text = "Display Scripture Study Notifications",
            DefaultValue = true,
            Category = SettingsCategory.ScriptureStudies
        };
        #endregion

    }
}
