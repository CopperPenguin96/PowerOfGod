using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Updater
{
    public static class ControlUtil
    {
        public static void Disable(this Control control)
        {
            control.Enabled = false;
        }

        public static void Enable(this Control control)
        {
            control.Enabled = true;
        }
    }

    public static class DirectoryUtil
    {
        public static void ClearDirectory(this DirectoryInfo di)
        {
            ClearFolder(di.FullName);
        }

        private static void ClearFolder(string FolderName)
        {
            DirectoryInfo dir = new DirectoryInfo(FolderName);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }
            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                ClearFolder(di.FullName);
                di.Delete();
            }
        }
    }
}
