using System;
using System.Collections.Generic;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Updater.LatestStable().Contains("Pre-Release"))
            {
                AllocConsole();
                Console.WriteLine("Power of God Debug Console");
                Console.WriteLine("Thank you for choosing to test on of our Pre-Releases.");
                Console.WriteLine("The program will load in just a second. You will be using Power of God " + Updater.LatestStable());
                for (var x = 1; x <= 20001; x++)
                {
                   
                    if (x == 3000 || x == 6000 || x == 9000)
                    {
                        Console.Write(" . ");
                    }
                }
            }
            Application.Run(new MainForm());
        }
    }
}
