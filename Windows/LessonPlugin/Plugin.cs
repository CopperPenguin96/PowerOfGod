using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lesson.Frames;
using Power_of_God_Lib.pSystem;
using Power_of_God_Lib.pSystem.DialogBox;
using Power_of_God_Lib.Plugins;

namespace LessonPlugin
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
        public override void PerformStartAction()
        {
            var theList = new List<string>();
            UpdateWeb.Navigate("http://godispower.us/Application/Lessons/sunday.html");
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
            Content.SetListItems(theList);
        }

        private readonly List<PluginFrame> _frames = new List<PluginFrame>
        {
            new LessonFrame(),
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
    }
}
