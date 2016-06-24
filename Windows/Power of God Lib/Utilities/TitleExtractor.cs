using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Power_of_God_Lib.Utilities
{
    public class TitleExtractor
    {
        /// <summary>
        /// Gets the title of a webpage
        /// </summary>
        /// <param name="url">the webpage</param>
        /// <returns>title of webpage</returns>
        public static string PageTitle(string url)
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
                Console.WriteLine("ERROR " + e);
                return "Error";
            }
        }
    }
}
