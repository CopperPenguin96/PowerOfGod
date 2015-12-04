using System;
using System.Collections.Generic;
using System.IO;

namespace Power_of_God.pSystem
{
    public class ErrorLogging
    {
        private static DateTime _now = DateTime.Now;
        private static readonly string Nl = Environment.NewLine;
        public static void Write(Exception ex)
        {
            if (!Directory.Exists("Logs/")) Directory.CreateDirectory("Logs/");
            var fileLines = new List<string> { "-----Power of God Error Log-----" + Nl };
            try
            {
                fileLines.Add("Exception Message: " + ex.Message);
            }
            catch (Exception)
            {
                fileLines.Add(Nl);
            }
            fileLines.Add(ex.ToString());
            fileLines.Add(Nl + Nl);
            fileLines.Add(ex.StackTrace);
            fileLines.Add("Log wrote at " + _now.ToLongDateString());
            var writingPath = "Logs/" + _now.ToLongDateString() + "." + _now.Hour + "." + _now.Minute + "." + _now.Second + ".txt";
            var fWriter = File.CreateText(writingPath);
            foreach (var f in fileLines)
            {
                fWriter.Write(f + Nl);
            }
            fWriter.Flush();
            fWriter.Close();
        }
    }
}
