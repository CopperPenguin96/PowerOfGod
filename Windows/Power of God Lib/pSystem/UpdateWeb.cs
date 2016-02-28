using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Power_of_God_Lib.pSystem
{
    public class UpdateWeb
    {
        public static WebBrowser XBrowser = new WebBrowser();
        public static void UpdateWebContent(string html)
        {
            XBrowser.DocumentText = html;
        }

        public static void Navigate(string url)
        {
            XBrowser.Navigate(url);
        }
    }
}
