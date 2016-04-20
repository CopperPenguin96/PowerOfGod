using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BiblePlanPlugin.BibPlan;
using Power_of_God_Lib.GUI.Controls;
using Power_of_God_Lib.Plugins;

namespace BiblePlanPlugin
{
    public class Plugin: Power_of_God_Lib.Plugins.Plugin
    {
        public new string Name = "Bible Plans";

        public override string GetName()
        {
            return Name;
        }
        public Plugin(string name, string dev, Category cat, bool act) : base(name, dev, cat, act)
        {

        }

        public Plugin()
        {
            Console.WriteLine("Default Constructor Init");
        }

        public override void AppLoad()
        {
            //PerformStartAction();
        }
        
        /// <summary>
        /// In order for this method to work, you must make sure the Name variable is assigned
        /// </summary>
        public override void PerformStartAction()
        {
            if (PluginReader.GetPluginLoaded(Name))
            { 
                
            }
        }

        public static bool AlreadyStarted = false;

        private readonly List<PluginFrame> _frames = new List<PluginFrame>
        {
            new PlanFrame()
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

        public static WebBrowser WBrowser = new WebBrowser();
        public override void LboSelection(int index)
        {
            WBrowser.DocumentText = Parser.HtmlText(BibPlanDialog.PlanFileName, index);
        }
    }
}
