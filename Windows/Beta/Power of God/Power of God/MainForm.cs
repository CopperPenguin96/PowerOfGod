using System;
using System.Drawing;
using System.Windows.Forms;
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
            Text += " " + AppVersion.GetVersionCode();
            metroTabControl1.SelectTab(0);
            tabPage1.Controls.Add(new PurposeTab());
            metroTabPage1.Controls.Add(new PluginManagerTab());
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
            Logging.Log("Registering plugins...");
            PluginReader.PluginInit();
            foreach (var p in PluginReader.PluginList)
            {
                var loopCount = 2;
                if (!p.HasTab) continue;
                Logging.Log(p.Name + " (Plugin) was given a MainForm tab", LogType.PluginEvent);
                metroTabControl1.TabPages.Add(p.Name);
                metroTabControl1.TabPages[loopCount].Controls.Add(p.TabPages[p.MainFrame]);
                loopCount++;
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }
    }
}
