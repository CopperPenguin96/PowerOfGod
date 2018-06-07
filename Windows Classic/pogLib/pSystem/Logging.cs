using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pogLib.pSystem
{
    public enum LogLevel { General, Warning, Error, Crash, System }
    public class Logging
    {
        private static List<string> _logs = new List<string>();

        public static void Log(string text)
        {
            Console.Write(text);
            int lastLog = _logs.Count - 1;
            _logs[lastLog] = _logs[lastLog] + text;
        }

        public static void LogLine(string text)
        {
            LogLine(text, LogLevel.General);
        }

        public static void LogLine(string text, LogLevel level)
        {
            string startText = TimeStamp();
            switch (level)
            {
                case LogLevel.Warning:
                    startText += "[WARNING] ";
                    break;
                case LogLevel.Error:
                    startText += "[ERROR] ";
                    break;
                case LogLevel.Crash:
                    startText += "[ !!! CRASH !!! ] ";
                    break;
                case LogLevel.System:
                    startText += "[SYSTEM] ";
                    break;
            }
            string newText = startText + text;
            
            Console.WriteLine(newText);
            _logs.Add(newText);
        }
        private static string TimeStamp()
        {
            string dateTime = "<" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "> ";
            return dateTime;
        }
    }
}
