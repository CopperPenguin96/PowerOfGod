using System.Windows.Forms;
using MetroFramework.Forms;
using Newtonsoft.Json;
using Power_of_God_Lib.pSystem;
using Power_of_God_Lib.Utilities;

namespace Power_of_God_Lib.GUI
{
    public partial class SettingsForm : MetroForm
    {
        public SettingsForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
        }

        private void chkEnablePlugins_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkEnablePlugins.Checked)
            {
                // TODO
            }
        }

        private void chkEnableLogs_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkEnableLogs.Checked)
            {
                chkSendLogs.Enabled = true;
                chkEnableCrashReports.Enabled = true;
                chkSendCrashReports.Enabled = true;
            }
            else
            {
                chkSendLogs.Checked = false;
                chkSendLogs.Enabled = false;
                chkEnableCrashReports.Checked = false;
                chkEnableCrashReports.Enabled = false;
                chkSendCrashReports.Checked = false;
                chkSendCrashReports.Enabled = false;
            }
        }

        private void chkSendLogs_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkSendLogs.Checked)
            {
                chkEnableCrashReports.Enabled = true;
                chkSendCrashReports.Enabled = true;
            }
            else
            {
                chkEnableCrashReports.Checked = false;
                chkEnableCrashReports.Enabled = false;
                chkSendCrashReports.Checked = false;
                chkSendCrashReports.Enabled = false;
            }
        }

        private void chkEnableCrashReports_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkEnableCrashReports.Checked)
            {
                chkSendCrashReports.Enabled = true;
            }
            else
            {
                chkSendCrashReports.Checked = false;
                chkSendCrashReports.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            var x = new Settings
            {
                EnablePlugins = chkEnablePlugins.Checked,
                EnableLogs = chkEnableLogs.Checked,
                SendLogs = chkSendLogs.Checked,
                EnableCrashReports = chkEnableCrashReports.Checked,
                SendCrashReports = chkSendCrashReports.Checked
            };
            Settings.UserSettings = x;
            Settings.Save();
            MessageBox.Show("App must be restarted for changes to take affect");
            Application.Restart();
        }

        private void SettingsForm_Load(object sender, System.EventArgs e)
        {
            var us = Settings.UserSettings;
            chkEnablePlugins.Checked = us.EnablePlugins;
            chkEnableLogs.Checked = us.EnableLogs;
            chkSendLogs.Checked = us.SendLogs;
            chkEnableCrashReports.Checked = us.EnableCrashReports;
            chkSendCrashReports.Checked = us.SendCrashReports;
            SetDynamicValues();
        }

        private void SetDynamicValues()
        {
            
        }
    }
}
