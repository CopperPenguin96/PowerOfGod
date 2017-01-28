using System;
using System.Drawing;
using System.Windows.Forms;
using LessonPlugin;
using MetroFramework.Forms;
using Power_of_God_Lib.GUI;
using Power_of_God_Lib.GUI.BaseTabs;
using Power_of_God_Lib.pSystem;
using Power_of_God_Lib.Plugins;
using Power_of_God_Lib.Utilities;

namespace Power_of_God
{
    public partial class MainForm : MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
            Application.ApplicationExit += OnExitEvent;
        }

        private void OnExitEvent(object sender, EventArgs e)
        {
            Logging.Log("Saving logs before exit!", LogType.SystemEvent);
            Logging.SaveLogs();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            metroLabel1.Text = metroLabel1.Text.Replace("{year}", "2015-" + (DateTime.Now.Year + "").Substring(2));
            Text += " " + AppVersion.GetCurrentVersion();
            MainSystem.SelectTab(0);
            purposeTab.Controls.Add(new PurposeTab());
            if (Settings.UserSettings.EnablePlugins)
            {
                MainSystem.TabPages.Add("Plugin Manager");
                MainSystem.TabPages[1].Controls.Add(new PluginManagerTab());
            }
            MainSystem.TabPages.Add("Lessons");
            MainSystem.TabPages[2].Controls.Add(new LessonPage());
            //PluginReader.PerformMethod(new Plugin {Name = "LessonPlugin"}, "Plugin", "ExecutePluginMethod", new object[] {PluginMethods.PluginLoad});
            PluginInit();
            foreach (var pl in PluginReader.PluginList)
            {
                try
                {
                    pl.AppLoad();
                }
                catch (Exception)
                {
                    // Ignored - Plugin doesn't utilize the App Load function
                }
            }
        }

        private void PluginInit()
        {
            Logging.Log(">>> Registering plugins Phase 2/2 <<<", LogType.PluginEvent);
            foreach (var p in PluginReader.PluginList)
            {
                var loopCount = 3;
                if (!p.HasTab) continue;
                Logging.Log(p.Name + " (Plugin) was given a MainForm tab", LogType.PluginEvent);
                MainSystem.TabPages.Add(p.Name);
                MainSystem.TabPages[loopCount].Controls.Add(p.TabPages[p.MainFrame]);
                loopCount++;
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }
    }
}
