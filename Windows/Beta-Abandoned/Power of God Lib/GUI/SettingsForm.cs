using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Power_of_God_Lib.Plugins;
using Power_of_God_Lib.Utilities;
using Xilium.CefGlue;

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
            var settingsObj = new Settings
            {
                scriptver = cboBibleVersion.Text,
                UpdatesEnabled = chkUpdateChecking.Checked
            };
            //if (settingObj.CheckEquals()) return;
            Settings.UserSettings = settingsObj;
            Settings.SaveToJson();
            if (MessageBox.Show("In order to accomplish the changes made, an application restart is required.", "Saved",
                MessageBoxButtons.OK) == DialogResult.OK)
            {
                Application.Restart();
            }
        }

        public static List<string> BibleVersions()
        {
            var returnList = new List<string>();
            var list = Network.GetWebDirectory("http://powerofgodonline.net/Application/Bibles/");
            foreach (var i in list)
            {
                try
                {
                    if (!i.Contains(".xml")) continue;
                    var version = i.Substring(1, i.IndexOf(".") - 1);
                    returnList.Add(version);
                }
                catch (Exception)
                {
                    // Ignored - no "." in string
                }
            }
            return returnList;
        }

        private List<Plugin> _plList = PluginReader.PluginList;

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            cboBibleVersion.Items.Clear();
            foreach (var p in _plList)
            {
                listBox1.Items.Add(p.Name);
            }
            foreach (var b in BibleVersions())
            {
                cboBibleVersion.Items.Add(b);
            }
            Settings.LoadFromJson();

            var loopCount = 0;
            foreach (var v in cboBibleVersion.Items)
            {
                if (v.ToString().Equals(Settings.UserSettings.scriptver))
                {
                    cboBibleVersion.SelectedIndex = loopCount;
                }
                loopCount++;
            }

            chkUpdateChecking.Checked = Settings.UserSettings.UpdatesEnabled;

        }

        private void cboBibleVersion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var p in _plList)
            {
                if (p.GetName() == listBox1.SelectedItem.ToString())
                {
                    label2.Text = "Name: " + p.GetName() + "\n" +
                                  "Version:" + p.GetPluginVersion() + "\n" +
                                  "Developer: " + p.Developer + "\n" +
                                  "Category:" + p.CCategory;
                }
            }
        }

        private void btnDeletePlugin_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                var msgBoxChoice =
                    MessageBox.Show(
                        "Are you sure you want to delete " + listBox1.SelectedItem +
                        " from your plugins? This action cannot be reversed!",
                        "Are you sure?", MessageBoxButtons.YesNo);
                if (msgBoxChoice != DialogResult.Yes) return;
                FormClosed += DeletePlugins;
                _files.Add("power.of.god/Plugins/" + listBox1.SelectedItem + ".pogplugin");
                _files.Add("The plugin was deleted. The app will now restart.");
            }
        }

        private List<string> _files = new List<string>();
        private void DeletePlugins(object sender, FormClosedEventArgs e)
        {
            foreach (var v in _files)
            {
                File.Delete(v);
            }
        }
    }
}