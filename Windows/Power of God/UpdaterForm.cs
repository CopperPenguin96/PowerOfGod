using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Power_of_God_Lib.GUI.DialogBox;
using Power_of_God_Lib.Utilities;

namespace Power_of_God
{
    public partial class UpdaterForm : Form
    {
        public UpdaterForm()
        {
            InitializeComponent();
        }

        private static IEnumerable<string> Versions()
        {
            const string textFile = "http://godispower.us/Application/launcher.txt";
            return Network.GetUrlSource(textFile);
        }

        private void UpdaterForm_Load(object sender, EventArgs e)
        {
            foreach (var item in Versions())
            {
                comboBox1.Items.Add(item);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedText != Network.LatestOnline())
            {
                lblNotice.Text = "This is not a recommended version";
                lblNotice.ForeColor = Color.Maroon;
            }
            else
            {
                lblNotice.Text = "This is the recommended version";
                lblNotice.ForeColor = Color.Green;
            }
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {var safeToDownload = false;
            if (comboBox1.SelectedText != Network.LatestOnline())
            {
                if (MessageBox.Show(
                    "This is not the recommended version that you have selected. Untold issues might come up if you proceed!",
                    "Warning!", MessageBoxButtons.YesNo)
                    .Equals(DialogResult.Yes))
                {
                    safeToDownload = true;
                }
            }
            else
            {
                safeToDownload = true;
            }

            if (safeToDownload) Download();
        }

        private DownloadDialogBox _box;
        private void Download()
        {
            var temp_updates = "power.of.god/temp_updates/";
            var download_name = "power.of.god/temp_updates/update.zip";
            if (!Directory.Exists(temp_updates))
            {
                Directory.CreateDirectory(temp_updates);
            }
            var dl = Network.Mediafire(
                Network.GetUrlSource("http://godispower.us/Application/launcher_subside.txt")
                    .ElementAt(comboBox1.SelectedIndex));
            _box = new DownloadDialogBox("Downloading " + comboBox1.SelectedText,
                "The installation will be complete here shortly. Thank you for choosing Power of God!",
                dl, download_name);
            _box.Closed += OperateExe;
            _box.Show();
        }

        private void OperateExe(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(FileSystem.BaseDir() + "/Updater.exe");
            Application.Exit();
        }
    }
}
