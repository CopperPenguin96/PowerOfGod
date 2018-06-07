using pogLib;
using pogLib.pSystem;
using pogLib.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using static pogLib.Global;
using Version = pogLib.Utils.Version;

namespace Power_of_God
{
    static class Program
    {
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (CheckForInternetConnection())
            {
                Settings s = new Settings();
                Settings.Load(out s);
                if ((bool)s.CheckForUpdates.Value == true)
                {
                    UpdateUpdater();
                }
            }
            else
            {
                MessageBox.Show("Sorry, but Power of God requires an internet connection to be able to work." +
                    "\n\nThink this is an error on our part? Contact us at https://godispower.com/",
                    "Internet Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

        }

        private static void UpdateUpdater()
        {
            Version currentRelease = Version.CurrentRelease();
            if (currentRelease.ToString() != Global.Version.ToString())
            {
                DialogResult result = MessageBox.Show("A new update for Power of God is available!\n" +
                    "It is HIGHLY recommended that you update. Update now?",
                    "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    // First update the updater
                    Network.ExecuteUrl("http://godispower.us/Application/Update/UpdaterVersion.txt", out string x);
                    string updaterText = "updaterVersion.txt";
                    if (!File.Exists(updaterText) ||
                        !File.ReadAllText(updaterText).Equals(x))
                    {
                        Start();
                    }
                    else Application.Run(SplashScreen);
                }
                else
                {
                    Application.Run(SplashScreen);
                }
            }
            else
            {
                Application.Run(SplashScreen);
            }
            
        }

        private static void Start()
        {
            Process.Start("UpdateUpdater.exe");
            Application.Exit();
        }
    }
}
