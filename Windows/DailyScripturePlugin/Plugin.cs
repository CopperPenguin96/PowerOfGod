using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Power_of_God_Lib.GUI.Controls;
using Power_of_God_Lib.pSystem;
using Power_of_God_Lib.Plugins;

namespace DailyScripture
{
    public class Plugin : Power_of_God_Lib.Plugins.Plugin
    {
        public Plugin(string name, string dev, Category cat, bool act) : base(name, dev, cat, act)
        {
            
        }

        public override void AppLoad()
        {
            // Add any needed plugin start up content
            PerformStartAction(); /* If your start action trigers any events, it needs to be called 
            * first in the constructor and 2nd in the
            * Button click */
        }
        public Plugin()
        {
            Console.WriteLine("Default Constructor Init");
            
        }
        public override void PerformStartAction()
        {
            
        }

        // Put main frame id in spot 0. This ensures that your main frame loads first when the button is pressed to load your plugin
        private readonly List<PluginFrame> _frames = new List<PluginFrame>
        {
            new ScriptureFrame()
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

        public static WebBrowser Browser1 = new WebBrowser();
        public override void LboSelection(int index)
        {
            Browser1.DocumentText = DailyScripture.GetDailyScripture(index + 1);
        }
    }
}
