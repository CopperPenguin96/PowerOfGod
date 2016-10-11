using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_of_God_Lib.Utilities
{
    public class Logging
    {
        public static List<string> Logs = new List<string>();
    
        private static void SetColor(LogType logType)
        {
            switch (logType)
            {
                case LogType.Normal:
                    Console.ResetColor();
                    break;
                case LogType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogType.SystemEvent:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
            }
        }
   
        /// <summary>
        /// Log a normal log
        /// </summary>
        /// <param name="content">The content to log</param>
        public static void Log(string content)
        {
            Log(content, LogType.Normal);
        }

        public static void Log(string content, LogType lType)
        {
            Logs.Add(content);
            SetColor(lType);
            Console.WriteLine(content);
        }

        public static void SaveLogs()
        {
            try
            {
                var writingPath = FileSystem.Directories[6] + _now.ToLongDateString() + ".txt";
                if (File.Exists(writingPath))
                {
                    var linesExisting = File.ReadAllLines(writingPath).ToList();
                    File.Delete(writingPath);
                    var writer = File.CreateText(writingPath);
                    linesExisting.AddRange(Logs);
                    foreach (var log in linesExisting)
                    {
                        writer.WriteLine(log);
                    }
                    writer.Flush();
                    writer.Close();
                }
                else
                {
                    var writer = File.CreateText(writingPath);
                    foreach (var line in Logs)
                    {
                        writer.WriteLine(line);
                    }
                    writer.Flush();
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                Log("Couldn't save the logs. Check the Error Logs for more info", LogType.Error);
            }
        }
        private static DateTime _now = DateTime.Now;
        private static readonly string Nl = Environment.NewLine;
        /// <summary>
        /// Generates Error Logs
        /// </summary>
        /// <param name="ex"></param>
        public static void LogError(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Log("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
            Log("Exception Caught! :(\n" +
                              "Exception: " + ex + "\n" +
                              "Message: " + ex.Message);
            Log("Exception has been logged");
            Log("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
            Console.ResetColor();
            if (!Directory.Exists(FileSystem.Directories[7])) Directory.CreateDirectory(FileSystem.Directories[7]);
            var fileLines = new List<string> { "-----Power of God (" + AppVersion.GetVersionCode() + ") Error Log-----" + Nl };
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
            var writingPath = FileSystem.Directories[7] + _now.ToLongDateString() + "." + _now.Hour + "." + _now.Minute + "." + _now.Second + ".txt";
            var fWriter = File.CreateText(writingPath);

            foreach (var f in fileLines)
            {
                fWriter.Write(f + Nl);
            }
            fWriter.Flush();
            fWriter.Close();
        }
    }

    public enum LogType
    {
        Normal, Warning, Error, SystemEvent
    }
}
