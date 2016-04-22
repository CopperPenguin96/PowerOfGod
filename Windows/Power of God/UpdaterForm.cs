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

        private void Download()
        {
            var temp_updates = "power.of.god/temp_updates/";
            var download_name = "power.of.god/temp_updates/update.zip";
            if (!Directory.Exists(temp_updates))
            {
                Directory.CreateDirectory(temp_updates);
            }
            var client = new WebClient();
            client.DownloadProgressChanged += client_DownloadProgressChanged;
            client.DownloadFileCompleted += client_DownloadFileCompleted;
            var uri =
                new Uri(
                    Network.Mediafire(
                        Network.GetUrlSource("http://godispower.us/Application/launcher_subside.txt")
                        .ElementAt(comboBox1.SelectedIndex)));
            client.DownloadFileAsync(uri, download_name);
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Maximum = (int)e.TotalBytesToReceive / 100;
            progressBar1.Value = (int)e.BytesReceived / 100;
        }

        private string BaseDir()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace("\\", "/");
        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            var result = MessageBox.Show(
                "The Update has finished downloading. Would you like for us to complete the update for you?",
                "Download finished", MessageBoxButtons.YesNo
                );
            if (result == DialogResult.Yes)
            {
                var newFolder = "power.of.god/temp_updates/UpdateFolder/";
                if (Directory.Exists(newFolder)) FileSystem.DeleteDirectory(newFolder);
                Directory.CreateDirectory(newFolder);
                ZipFile.ExtractToDirectory("power.of.god/temp_updates/update.zip", newFolder);
                Closed += OperateExe;
                Close();
            }
            else
            {
                MessageBox.Show("To complete the installation, you will need to unzip the .zip file (" +
                                 BaseDir() +
                                "/power.of.god/temp_updates/update.zip) and then " +
                                "copy and paste into the main folder.");
            }
        }

        private void OperateExe(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(BaseDir() + "/Updater.exe");
        }
    }
}
