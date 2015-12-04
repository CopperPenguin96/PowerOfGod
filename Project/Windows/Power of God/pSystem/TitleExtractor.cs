using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Power_of_God.pSystem
{
    public class TitleExtractor
    {
        public static String pageTitle(String url)
        {
            string title = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest.Create(url) as HttpWebRequest);
                HttpWebResponse response = (request.GetResponse() as HttpWebResponse);

                using (Stream stream = response.GetResponseStream())
                {
                    // compiled regex to check for <title></title> block
                    Regex titleCheck = new Regex(@"<title>\s*(.+?)\s*</title>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                    int bytesToRead = 8092;
                    byte[] buffer = new byte[bytesToRead];
                    string contents = "";
                    int length = 0;
                    while ((length = stream.Read(buffer, 0, bytesToRead)) > 0)
                    {
                        // convert the byte-array to a string and add it to the rest of the
                        // contents that have been downloaded so far
                        contents += Encoding.UTF8.GetString(buffer, 0, length);

                        Match m = titleCheck.Match(contents);
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
