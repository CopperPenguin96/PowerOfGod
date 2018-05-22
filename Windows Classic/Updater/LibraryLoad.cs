using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Updater
{
    internal class LibraryLoad
    {
        internal static Assembly pogLib;
        internal static bool LoadLibrary()
        {
            try
            {
                string file = Directory.GetCurrentDirectory() + "\\pogLib.dll";
                pogLib = Assembly.LoadFile(file);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("A fatal error has occured. Unable to run the updater. (" + ex.ToString() + ")",
                    "Sorry",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
