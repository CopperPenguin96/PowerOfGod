using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            UpdateWeb.Navigate("http://godispower.us/Application/Lessons/sunday.html");
        }
    }
}
