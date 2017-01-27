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
        /// Gets the title of a webpage
        /// </summary>
        /// <param name="url">the webpage</param>
        /// <returns>title of webpage</returns>
        public static string GetPageTitle(string url)
        {
            var title = "";
            try
            {
                var request = (WebRequest.Create(url) as HttpWebRequest);
                if (request == null) return title;
                var response = (request.GetResponse() as HttpWebResponse);

                if (response == null) return title;
                using (var stream = response.GetResponseStream())
                {
                    // compiled regex to check for <title></title> block
                    var titleCheck = new Regex(@"<title>\s*(.+?)\s*</title>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                    const int bytesToRead = 8092;
                    var buffer = new byte[bytesToRead];
                    var contents = "";
                    int length;
                    while (stream != null && (length = stream.Read(buffer, 0, bytesToRead)) > 0)
                    {
                        // convert the byte-array to a string and add it to the rest of the
                        // contents that have been downloaded so far
                        contents += Encoding.UTF8.GetString(buffer, 0, length);

                        var m = titleCheck.Match(contents);
                        if (m.Success)
                        {
                            // we found a <title></title> match =]
                            title = m.Groups[1].Value;
                            break;
                        }
                        else if (contents.Contains("</head>"))
                        {
                            // reached end of head-block; no title found =[
                            break;
                        }
                    }
                }
                return title;
            }
            catch (Exception e)
            {
                Logging.LogError(e);
                return "Error";
            }
        }
        /// <summary>
        /// Obtain source of webpage
        /// </summary>
        /// <param name="urlF">The url needed</param>
        /// <returns>source of page</returns>
        public static List<string> GetUrlSourceAsList(string urlF)
        {
            if (urlF.Contains("0201"))
            {
                urlF = urlF.Replace("0201", "2016");
            }
            var temp = "power.of.god/check_file.txt";
            var c = File.CreateText(temp);

            c.Close();
            using (var client = new WebClient())
            {
                try
                {
                    client.DownloadFile(urlF, temp);
                }
                catch (Exception e)
                {
                    Logging.LogError(e);
                }

            }
            return File.ReadAllLines(temp).ToList();
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
