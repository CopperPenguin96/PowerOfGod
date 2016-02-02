using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Power_of_God_Lib.pSystem
{
    public static class GetallFilesFromHttp
    {
        public static string GetDirectoryListingRegexForUrl(string url)
        {
            return "\\\"([^\"]*)\\\"";
        }

        public static List<string> Files = new List<string>();

        public static void Write()
        {
            var fw = File.CreateText("tempradio.txt");
            fw.Write(Files.Aggregate("", (current, f) => current + ("\n" + f)));
            fw.Flush();
            fw.Close();

        }
        public static void ListDiractory(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var html = reader.ReadToEnd();

                    var regex = new Regex(GetDirectoryListingRegexForUrl(url));
                    var matches = regex.Matches(html);
                    if (matches.Count > 0)
                    {
                        foreach (var match in matches.Cast<Match>().Where(match => match.Success))
                        {
                            Files.Add(match.ToString());
                        }
                    }
                }
                Write();
            }
        }
    }
}
