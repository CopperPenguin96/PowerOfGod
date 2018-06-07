using pogLib.pSystem;
using System;
using System.Windows.Forms;

namespace pogLib.GUI
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        public new void Show()
        {
            ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void SaveSettings()
        {
            Settings.Current.CheckForUpdates.Value = chkCheckUpdates.Checked;
            Settings.Current.DisplayNotifications.Value = chkNotifyU.Checked;

            if (!Settings.Save())
            {
                MessageBox.Show("Unable to save settings", "Settings Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!Settings.Save())
            {
                MessageBox.Show("Unable to save Settings", "Settings Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Settings were saved.In order for your settings to take effect, please restart the application", "Settings Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadSettings()
        {
            chkCheckUpdates.Checked = (bool)Settings.Current.CheckForUpdates.Value;
            chkNotifyU.Checked = (bool)Settings.Current.DisplayNotifications.Value;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }
    }
}
