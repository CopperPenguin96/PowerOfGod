using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Power_of_God_Lib.Utilities;

namespace Power_of_God
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (AppVersion.PreRelease)
            {
                // Open Pre-Release mode
                AllocConsole();
            }
            LogTimer.Interval = 300000; // 5 minutes for each log
            LogTimer.Tick += LogTick;
            Logging.Log("~`> Power of God Logs <`~");
            Logging.Log(":.:.:.:.:.:.:.:.:.:.:.:.:.:.:.:.:.:.");
            Logging.Log("Log started on " + DateTime.Now.ToShortDateString() + " at " +
                        DateTime.Now.ToLongTimeString(), LogType.SystemEvent);
            Logging.Log(":.:.:.:.:.:.:.:.:.:.:.:.:.:.:.:.:.:.");

            #region Preparing PreRelease mode
            if (AppVersion.PreRelease)
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
            Logging.Log("You are running Power of God " + AppVersion.GetVersionCode());
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

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private static readonly Timer LogTimer = new Timer();

    }
}
