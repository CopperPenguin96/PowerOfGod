using System;
using System.Linq;
using System.Windows.Forms;
using Power_of_God_Lib.pSystem;
using Power_of_God_Lib.Plugins;

namespace Power_of_God_Lib.GUI
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var settingObj = Settings.UserSettings;
            settingObj.scriptver = cboBibleVersion.Text;
            //if (settingObj.CheckEquals()) return;
            Settings.UserSettings = settingObj;
            Settings.SaveToJson();
            if (MessageBox.Show("In order to accomplish the changes made, an application restart is required.", "Saved",
                MessageBoxButtons.OK) == DialogResult.OK)
            {
                Application.Restart();
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            Settings.LoadFromJson(); //kjv esv niv nlt
            switch (Settings.UserSettings.scriptver)
            {
                case "NIV":
                    cboBibleVersion.SelectedIndex = 2;
                    break;
                case "ESV":
                    cboBibleVersion.SelectedIndex = 1;
                    break;
                case "NLT":
                    cboBibleVersion.SelectedIndex = 3;
                    break;
                default:
                    cboBibleVersion.SelectedIndex = 0;
                    break;
            }
            
        }
    }
}
