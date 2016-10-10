using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Power_of_God_Lib.GUI;
using Power_of_God_Lib.Plugins;

namespace LessonPlugin
{
    public class Plugin : Power_of_God_Lib.Plugins.Plugin
    {
        
        public Plugin()
        {
            Name = "Lessons";
            TabPages = new PowerTabPage[]
            {
                new LessonPage(),
            };
            PreparePlugin();
            AppLoad = PogLoaded;
            PluginLoad = LessonsLoaded;
           
        }


        private void LessonsLoaded()
        {
        }

        private void PogLoaded()
        {
        }
    }
}
