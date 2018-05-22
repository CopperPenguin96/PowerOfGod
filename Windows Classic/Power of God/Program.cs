using pogLib.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static pogLib.Global;

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
            UpdateUpdater();
        }

        private static void UpdateUpdater()
        {
            Network.ExecuteUrl("http://godispower.us/Application/Update/UpdaterVersion.txt", out string x);
            string updaterText = "updaterVersion.txt";
            if (!File.Exists(updaterText) || 
                !File.ReadAllText(updaterText).Equals(x))
                Start();
            else Application.Run(SplashScreen);
        }

        private static void Start()
        {
            Process.Start("UpdateUpdater.exe");
            Application.Exit();
        }
    }
}
