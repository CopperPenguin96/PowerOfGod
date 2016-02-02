using System;
using System.IO;
using System.Linq;
using System.Net;
using NetBible.Books;
using Newtonsoft.Json.Linq;
using Power_of_God.pSystem;
using Power_of_God.User;
using Power_of_God_Lib.BibPlan;

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
            // ReSharper disable once UnusedVariable
            foreach (var item in Directory.GetFiles(_dayPath).Where(item => item == DateString()))
            {
                alreadySaw = true;
            }

            // ReSharper disable once RedundantAssignment
            if (!alreadySaw)
            { 
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

        public static string Verses;
        public static string GetDailyScripture()
        {
            try
            {
                var webClient = new WebClient();
                var day = GetDay();
                var url = "http://godispower.us/DailyVerses/dv" + day + ".txt";
                webClient.DownloadFile(url, "tempv.txt");
                var fileLines = File.ReadAllLines("tempv.txt").ToList();
                var finalString = fileLines.Where(files => files.StartsWith("Verse")).Aggregate("Today's Verse: ", (current, files) => current + ("<html><head>" + "<title>" + Verses + "</title></head>" + "<body><b>" + ParseJson(files.Substring(8)) + "</b><br>" + "</body></html>"));
                return finalString + fileLines.ElementAt(0);
            }
            catch (Exception e)
            {
                throw new DailyScriptureException("DailyScripture", e);
            }
        }

        public static string GetDailyScripture(int day)
        {
            var webClient = new WebClient();
            var url = "http://godispower.us/DailyVerses/dv" + day + ".txt";
            webClient.DownloadFile(url, "tempv.txt");
            var fileLines = File.ReadAllLines("tempv.txt").ToList();
            var finalString = fileLines.Where(files => files.StartsWith("Verse")).Aggregate("Today's Verse: ", (current, files) => current + ("<html><head>" + "<title>" + Verses + "</title></head>" + "<body><b>" + ParseJson(files.Substring(8)) + "</b><br>" + "</body></html>"));
            return finalString + fileLines.ElementAt(0);
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
