using Newtonsoft.Json;
using pogLib.GUI.Panels;
using pogLib.Properties;
using pogLib.pSystem;
using pogLib.Utils;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using static pogLib.Global;

namespace pogLib.GUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            if (!File.Exists("settings.json"))
            {
                Settings.Save();
                Settings.Load(out Settings.Current);
            }
            else
            {
                Settings.Load(out Settings.Current);
            }
            
            NetBible.BibleReader.LoadXml(Settings.Current.BibleVersion.Value + ".xml", out string log);
            button1_Click(new object(), new EventArgs());
        }


        public void button1_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (CurrentScreen == id) return;
            CurrentScreen = id;
            button1.BackgroundImage = Resources.button_clicked;
        }

        public void button2_Click(object sender, EventArgs e)
        {
            int id = 1;
            if (CurrentScreen == id) return;
            CurrentScreen = id;
            button2.BackgroundImage = Resources.button_clicked;
        }

        public void button3_Click(object sender, EventArgs e)
        {
            int id = 2;
            if (CurrentScreen == id) return;
            CurrentScreen = id;
            button3.BackgroundImage = Resources.button_clicked;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }

        private int lastSetId = -1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CurrentScreen != lastSetId)
            {
                lastSetId = CurrentScreen;
                UpdatePanel(CurrentScreen);
            }

            bool isLive = Network.IsLive();
            picWeLive.Visible = isLive;
            picWeLive2.Visible = isLive;
        }

        private void UpdatePanel(int id)
        {
            panel1.Controls.Clear();
            switch (id)
            {
                case 0:
                    PurposePanel pp = new PurposePanel();
                    foreach (var control in pp.ControlList())
                    {
                        panel1.Controls.Add((Control)control);
                    }
                    break;
                case 1:
                    ServicePanel cp = new ServicePanel();
                    foreach (var control in cp.ControlList())
                    {
                        panel1.Controls.Add((Control)control);
                    }
                    break;
                case 2:

                    break;
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
        }
    }
}
