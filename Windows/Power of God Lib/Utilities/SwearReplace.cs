using System.Net;
using System.Text;

namespace Power_of_God_Lib.Utilities
{
    public class SwearReplace
    {
        public static string Check(string str)
        {
            var url = "http://godispower.us/Application/Users/words/words.php?word=fish&string=" + str;
            var client = new WebClient();
            var html = client.DownloadData(url);
            var utf = new UTF8Encoding();
            return utf.GetString(html);
        }
    }
}
