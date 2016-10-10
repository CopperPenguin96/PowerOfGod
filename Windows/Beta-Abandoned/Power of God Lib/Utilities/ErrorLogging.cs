using System;
using System.Collections.Generic;
using System.IO;

namespace Power_of_God_Lib.Utilities
{
    public class ErrorLogging
    {
        private static DateTime _now = DateTime.Now;
        private static readonly string Nl = Environment.NewLine;
        /// <summary>
        /// Generates Error Logs
        /// </summary>
        /// <param name="ex"></param>
        public static void Write(Exception ex)
        {
            if (!Directory.Exists("Logs/")) Directory.CreateDirectory("power.of.god/Logs/");
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
            fileLines.AddRange(Detection.FullSystemInfo());
            var writingPath = "power.of.god/Logs/" + _now.ToLongDateString() + "." + _now.Hour + "." + _now.Minute + "." + _now.Second + ".txt";
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
