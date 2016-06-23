using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Power_of_God_Lib.GUI;
using Power_of_God_Lib.Utilities;

namespace Power_of_God
{
    static class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            var mainPath = "power.of.god/";
            var bibPath = "power.of.god/Bibles/";
            if (!Directory.Exists(mainPath)) Directory.CreateDirectory(mainPath);
            if (!Directory.Exists(bibPath)) Directory.CreateDirectory(bibPath);
            bool safeToRun = false;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            try
            {
                var n = Network.LatestStable(false);
                if (n.Contains("Pre-Release"))
                {
                    AllocConsole();
                    Console.WriteLine("Power of God Debug Console");
                    Console.WriteLine("Thank you for choosing to test on of our Pre-Releases.");
                    Console.WriteLine("The program will load in just a second. You will be using Power of God " +
                                      Network.LatestStable(false));

                    Console.WriteLine(Environment.NewLine);
                    foreach (var line in Detection.FullSystemInfo())
                    {
                        Console.WriteLine(line);
                    }
                    for (var x = 1; x <= 20001; x++)
                    {

                        if (x == 3000 || x == 6000 || x == 9000)
                        {
                            Console.Write(" . ");
                        }
                    }
                    safeToRun = true;
                    
                }

                else if (Network.UpdateWord() != "Updated")
                {
                    var choice =
                        MessageBox.Show(
                            "It is recommended that you get Power of God " + Network.LatestOnline() +
                            ", because you have now " +
                            Network.LatestStable(false) +
                            ". \n\nWould you like us to update it for you? This is the recommended option.", "Updater",
                            MessageBoxButtons.YesNo);
                    switch (choice)
                    {
                        case DialogResult.Yes:
                            if (File.Exists("Updater.exe"))
                            {
                                new UpdaterForm().ShowDialog();
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
                            safeToRun = true;
                            break;
                    }
                }
                if (safeToRun) Application.Run(new MainForm());
            }
            catch (Exception)
            {
                // ignored
            }
        }

       
    }
}
