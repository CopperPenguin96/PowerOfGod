using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Lesson.Frames;
using Power_of_God.pSystem;
using Power_of_God_Lib.pSystem;
using Power_of_God_Lib.Plugins;
using Power_of_God_Lib.Plugins.Controls;

namespace Lesson
{
    public class Plugin : Power_of_God_Lib.Plugins.Plugin
    {
        public Plugin(string name, string dev, Category cat, bool act) : base(name, dev, cat, act)
        {

        }

        public Plugin()
        {
            Console.WriteLine("Default Constructor Init");
            
            
        }

        public override void AppLoad()
        {
            PerformStartAction();
        }

        public static List<string> GetList()
        {
            var theList = new List<string>();
            GetallFilesFromHttp.ListDiractory("http://godispower.us/Sundays/");
            var intIndex = 0;
            foreach (var x in GetallFilesFromHttp.Files)
            {
                if (intIndex > 1)
                {
                    if (intIndex < GetallFilesFromHttp.Files.Count - 2)
                        try
                        {
                            var i = x.Substring(1, x.Length - 7).Replace(".", "/");
                            if (!(Convert.ToDateTime(i) > DateTime.Now))
                            {
                                theList.Add(i);
                            }
                        }
                        catch (Exception)
                        {
                            // Ignored - Occurs when "Lessons" button clicked twice

                        }
                }
                intIndex++;
            }
            var dtList = SortAscending(theList.Select(DateTime.Parse).ToList());
            return dtList.Select(date => date.ToString("MM/dd/yyyy")).ToList().Distinct().ToList();
        }

        private static IEnumerable<DateTime> SortAscending(List<DateTime> list)
        {
            list.Sort((a, b) => a.CompareTo(b));
            return list;
        }

        public override void PerformStartAction()
        {
           // UpdateWeb.Navigate("http://godispower.us/Application/Lessons/sunday.html");
            //dContent.SetListItems(GetList());
        }

        private readonly List<PluginFrame> _frames = new List<PluginFrame>
        {
            new VideoScreenFrame(),
            null
        };

        public override List<PluginFrame> FrameIdList()
        {
            return _frames;
        }

        public override PluginFrame GetFrame(string idStr)
        {
            foreach (var frame in FrameIdList().Where(frame => frame.FrameID == idStr))
            {
                return frame;
            }
            return new PluginFrame();
        }

        public static ObservableCollection<string> Ol = new ObservableCollection<string>();
        public static string DateString;
        public override void LboSelection(int i)
        {
            Ol.Clear();
            DateString = "http://godispower.us/Sundays/" + GetList().ElementAt(i).Replace("/", ".") + ".html";
            var lines = Updater.GetUrlSource(DateString);
            foreach (var line in lines)
            {
                Ol.Add(line);
            }
        }


    }
}
