using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using Power_of_God_Lib.GUI.BaseTabs;
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
            tabPage2.Controls.Add(new SettingsTab());
            //PluginReader.PerformMethod(new Plugin {Name = "LessonPlugin"}, "Plugin", "ExecutePluginMethod", new object[] {PluginMethods.PluginLoad});
            PluginInit();
           
        }

        private void PluginInit()
        {
            Logging.Log("Registering plugins...");
            PluginReader.PluginInit();
            foreach (var p in PluginReader.PluginList)
            {
                var loopCount = 2;
                if (p.HasTab)
                {
                    Logging.Log(p.Name + " (Plugin) was given a MainForm tab");
                    metroTabControl1.TabPages.Add(p.Name);
                    metroTabControl1.TabPages[loopCount].Controls.Add(p.TabPages[p.MainFrame]);
                    loopCount++;
                }
            }
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
