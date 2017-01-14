using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Power_of_God_Lib.GUI;
using Power_of_God_Lib.Plugins;
using Power_of_God_Lib.Utilities;

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
            PluginUninstall = UninstallMe;
        }

        private void UninstallMe()
        {
            Logging.Log("User has selected to uninstall the Lesson plugin...", LogType.Error);
            MessageBox.Show("Power of God will shutdown so that this can take affect");
            Application.ApplicationExit += DoKill;
            
            Application.Exit();
        }

        private void DoKill(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + ("/power.of.god/Plugins/Files/" + Name + "/uninstall.bat").Replace("/", "\\"));
        }

        private void LessonsLoaded()
        {
        }

        private void PogLoaded()
        {
            var batLocation = "power.of.god/Plugins/Files/" + Name + "Plugin/uninstall.bat";
            if (File.Exists(batLocation)) File.Delete(batLocation);
            var writer = File.CreateText(batLocation);
            writer.Write("cd \"" + Application.StartupPath + "/power.of.god/Plugins/dll/\"".Replace("/", "\\"));
            writer.Write(writer.NewLine + "del \"LessonPlugin.dll\"");
            writer.Write(writer.NewLine + "PAUSE");
            writer.Flush();
            writer.Close();
        }
    }
}
