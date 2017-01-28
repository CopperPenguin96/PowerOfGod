using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Power_of_God_Lib.pSystem;
using Power_of_God_Lib.Plugins;
using Power_of_God_Lib.Utilities;

namespace Power_of_God
{
    static class Program
    {
        [DllImport("user32.dll")]

        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]

        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (AppVersion.IsPreRelease)
            {
                Logging.Log("Starting...");
            }
            else
            {
                ShowWindow(FindWindow(null, Console.Title), 0);
                if (AppVersion.UpdateWord() != "Outdated")
                {
                    var choice =
                            MessageBox.Show(
                                "It is recommended that you get Power of God " + AppVersion.LatestOnline() +
                                ", because you have now " +
                                AppVersion.GetCurrentVersion() +
                                ". \n\nWould you like us to update it for you? This is the recommended option.",
                                "Updater",
                                MessageBoxButtons.YesNo);
                    switch (choice)
                    {
                        case DialogResult.Yes:
                            if (File.Exists("Updater.exe"))
                            {
                                new UpdaterForm().ShowDialog();
                                return;
                            }
                            else
                            {
                                MessageBox.Show(
                                    "We can't update without Updater.exe. You will have to download the udpate yourself.");
                            }
                            break;
                        default:
                            MessageBox.Show(
                                "You have chosen not to update. Some features might not work or you will not get access to new things.");
                            break;
                    }
                }
            }
            LogTimer.Interval = 300000; // 5 minutes for each log
            LogTimer.Tick += LogTick;
            Logging.Log("~`> Power of God Logs <`~");
            Logging.Log(":.:.:.:.:.:.:.:.:.:.:.:.:.:.:.:.:.:.");
            Logging.Log("Log started on " + DateTime.Now.ToShortDateString() + " at " +
                        DateTime.Now.ToLongTimeString(), LogType.SystemEvent);
            Logging.Log(":.:.:.:.:.:.:.:.:.:.:.:.:.:.:.:.:.:.");
            if (FileSystem.FileExists(1))
            {
                if (new FileInfo(FileSystem.Files[1]).Length == 0)
                {
                    File.Delete(FileSystem.Files[1]);
                    Logging.Log("Settings file is empty! Deleting it, so we can start over", LogType.Warning);
                }
            }
            
            var ts = Settings.Load();
            Settings.UserSettings = ts;
            if (Settings.UserSettings.EnablePlugins)
            {
                Logging.Log(">>> Registering plugins Phase 1/2 <<<", LogType.PluginEvent);
                PluginReader.PluginInit();
            }
            else
            {
                Logging.Log("!!! Plugins are not enabled !!!", LogType.Error);
            }
            if (!Settings.UserSettings.EnableLogs)
                Console.WriteLine("Logs are not enabled... Logs will not be written");
            #region Preparing PreRelease mode
            if (AppVersion.IsPreRelease)
            {
                Logging.Log("Preparing Pre-Release Mode");
                foreach (var s in Detection.FullSystemInfo())
                {
                    Logging.Log(s);
                }
                Logging.Log(
                    "WARNING: THIS IS AN UNSUPPORTED VERSION. Back up your installation before continuing.");
            }
            #endregion
            Logging.Log("You are running Power of God " + AppVersion.GetCurrentVersion());
            Logging.Log("Loading Scripture (KJV.xml)");
            NetBible.Books.Bible.SetLocation("KJV.xml");
            Logging.Log("Preparing the File System");
            FileSystem.CreateMissingDir(new int[] { });
            Logging.Log("Opening the MainForm...");
            Application.Run(new MainForm());
        }

        private static void LogTick(object sender, EventArgs e)
        {
            Logging.Log("Saving available logs", LogType.SystemEvent);
            Logging.SaveLogs();
        }

        private static readonly Timer LogTimer = new Timer();

    }
}
