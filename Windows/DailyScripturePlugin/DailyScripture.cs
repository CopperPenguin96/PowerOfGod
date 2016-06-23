using System;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;
using Power_of_God_Lib.BibPlan;
using Power_of_God_Lib.NetBible;
using Power_of_God_Lib.NetBible.Books;
using Power_of_God_Lib.Utilities;

namespace DailyScripture
{
    public class DailyScripture
    {

        
        private static string _dayPath = "power.of.god/Verses/";

        private static string DateString()
        {
            var dt = DateTime.Now;
            return dt.ToString("MM-dd-yyyy");
        }
        

        private static string ParseJson(string json)
        {
            var vrsObj = JObject.Parse(json).ToObject<VerseObj>();
            var foundBook = new Book();
            foreach (var b in Bible.AllBooks().Where(b => b.Name.ToLower() == vrsObj.Book.ToLower()))
            {
                foundBook = b;
            }

            var chap = vrsObj.Chapter;
            var verse = vrsObj.Verse;
            Verses = foundBook.Name + " " + chap + ":" + verse +
                     " (" + Settings.UserSettings.scriptver + ")";
            return foundBook.ReadFormattedVerse(chap, verse);
        }

        public static string Verses;
        
        public static string GetDailyScripture()
        {
           
            try
            {
                Verses = "";
                var webClient = new WebClient();
                var day = GetDay();
                var url = "http://godispower.us/DailyVerses/dv" + day + ".txt";
                webClient.DownloadFile(url, "tempv.txt");
                var fileLines = File.ReadAllLines("tempv.txt").ToList();
                var finalString = fileLines.Where(files => files.StartsWith("Verse")).Aggregate("<h1>Verse #" + day + "</h1><br>", (current, files) => current + Verses + ParseJson(files.Substring(8)) + "<br>");
                finalString =
                    (finalString + fileLines.ElementAt(0)).Replace("<html><head><title></title></head><body>", "")
                        .Replace("</body></html>", "");

                var i = GetDay();
                if (!Network.DailyScriptureAlreadyPulled)
                {
                    i--;
                }
                WriteDay(i);
                return "<html>" + finalString + "</html>";
            }
            catch (Exception e)
            {
                throw new DailyScriptureException("DailyScripture", e);
            }
        }

        public static string GetDailyScripture(int day)
        {
            Verses = "";
            var webClient = new WebClient();
            var url = "http://godispower.us/DailyVerses/dv" + (day) + ".txt";
            webClient.DownloadFile(url, "tempv.txt");
            var fileLines = File.ReadAllLines("tempv.txt").ToList();
            var finalString = fileLines.Where(files => files.StartsWith("Verse")).Aggregate("<h1>Verse #" + day + "</h1><br>", (current, files) => current + ParseJson(files.Substring(8)) + "<br>");
            finalString =
                (finalString + fileLines.ElementAt(0)).Replace("<html><head><title></title></head><body>", "")
                    .Replace("</body></html>", "");
            return "<html>" + finalString + "</html>";
        }

        public static int GetDay()
        {
            if (!Directory.Exists(_dayPath))
            {
                Directory.CreateDirectory(_dayPath);
                WriteDay(1);
                return 1;
            } 
            else
            {
                var count = Directory.GetFiles(_dayPath).Length + 1;
                if (!File.Exists(file)) WriteDay(count);
                return count;
            }
        }

        private static string file = "";
        public static void WriteDay(int day)
        {
            file = _dayPath + "dv" + day + DateTime.Now.ToShortDateString().Replace("/", ".") + ".txt";

            if (File.Exists(_dayPath))
            {
                Console.WriteLine("Daily Scripture already read " + file);
            }
            else
            {
                var f = File.Create(file);
                f.Close();
            }
        }
    }
    
    public class DailyScriptureException : Exception
    {
        public DailyScriptureException()
        {
            ErrorLogging.Write(this);
        }

        public DailyScriptureException(string message) : base(message)
        {
            ErrorLogging.Write(this);
        }

        public DailyScriptureException(string message, Exception e) : base(message, e)
        {
            ErrorLogging.Write(this);
        }
    }
}
