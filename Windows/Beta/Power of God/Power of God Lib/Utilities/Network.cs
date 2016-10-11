using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Power_of_God_Lib.Utilities
{
    public class Network
    {
        private static string GetDirectoryListingRegexForUrl(string url)
        {
            return "\\\"([^\"]*)\\\"";
        }

        public static List<string> GetWebDirectory(string url)
        {
            var Files = new List<string>();
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
                        Files.AddRange(matches.Cast<Match>().Where(match => match.Success).Select(match => match.ToString()));
                    }
                }
            }
            return Files;
        }

        /// <summary>
        /// Obtain source of webpage
        /// </summary>
        /// <param name="url">The url needed</param>
        /// <returns>source of page</returns>
        public static string GetUrlSource(string url)
        {
            using (var client = new WebClient())
            {
                var f = client.DownloadString(url);
                return f;
            }
        }
    }
}
