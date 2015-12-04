using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Power_of_God.Books;
using Power_of_God.pSystem;
using Power_of_God.User;

namespace Power_of_God
{
    public class DailyScripture
    {
        private static string _dayPath = "Verses/";

        private static string DateString()
        {
            var dt = DateTime.Now;
            return dt.ToString("MM-dd-yyyy");
        }

        private static void WriteDay()
        {
            try
            {
                if (!Directory.Exists("Verses/"))
                {
                    Directory.CreateDirectory("Verses/");
                }
                File.Create("Verses/" + DateString() + ".txt");
            }
            catch (Exception e)
            {
                ErrorLogging.Write(e);
            }
        }

        private static int GetDay()
        {
            var alreadySaw = false;
            var file = _dayPath;
            if (!Directory.Exists(file))
            {
                Directory.CreateDirectory(file);
                WriteDay();
                return 1;
            }
            foreach (var item in Directory.GetFiles(_dayPath).Where(item => item == DateString()))
            {
                alreadySaw = true;
            }

            var trueVar = 1;
            if (alreadySaw) trueVar = 0;
            else
            {
                trueVar = 1;
                WriteDay();
            }
            return Directory.GetFiles(_dayPath).Length;
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

        private static BibleVersion Bv()
        {
            switch (Settings.UserSettings.scriptver)
            {
                case "NIV":
                    return BibleVersion.NIV;
                case "NLT":
                    return BibleVersion.NLT;
                case "ESV":
                    return BibleVersion.ESV;
                default:
                    return BibleVersion.KJV;
            }
        }

        public static string Verses;
        public static string GetDailyScripture()
        {
            try
            {
                var webClient = new WebClient();
                var _day = GetDay();
                var url = "http://godispower.us/DailyVerses/dv" + _day + ".txt";
                webClient.DownloadFile(url, "tempv.txt");
                var fileLines = File.ReadAllLines("tempv.txt").ToList();
                var finalString = "Today's Verse: ";
                foreach (var files in fileLines)
                {
                    if (files.StartsWith("Verse"))
                    {
                        finalString += "<html><head>" +
                            "<title>" + Verses + "</title></head>" +
                            "<body><b>" + ParseJson(files.Substring(8)) + "</b><br>" +
                            "</body></html>";
                    }

                }
                return finalString + fileLines.ElementAt(0);
            }
            catch (Exception e)
            {
                throw new DailyScriptureException("DailyScripture", e);
            }
        }
    }

    public class VerseObj
    {
        public string Book;
        public int Chapter;
        public int Verse;
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
