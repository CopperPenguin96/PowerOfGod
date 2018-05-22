using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.IO.Compression;

namespace Updater
{

    public partial class UpdaterForm : Form
    {
        private Type type;
        private List<Version> versionList = new List<Version>();
        public UpdaterForm()
        {
            InitializeComponent();
            UpdaterConsole.WriteLine("-------POG Upater Console-------");
            if (!LibraryLoad.LoadLibrary())
            {
                Close();
            }
            type = LibraryLoad.pogLib.CreateInstance("pogLib.Utils.Network").GetType();
            object[] pars = new object[] { "http://godispower.us/Application/Update/past.json", null };
            bool result = ExecuteStaticMethod("ExecuteUrl", pars, out object resultObj);
            if (result)
            {
                if (resultObj.ToString().ToLower() == "true")
                {
                    List<Version> past = JsonConvert.DeserializeObject<List<Version>>(pars[1].ToString());
                    foreach (Version version in past)
                    {
                        versionList.Add(version);
                    }
                }
            }

            pars = new object[] { "http://godispower.us/Application/Update/current.json", null };
            result = ExecuteStaticMethod("ExecuteUrl", pars, out resultObj);
            if (result)
            {
                if (resultObj.ToString().ToLower() == "true")
                {
                    Version current = JsonConvert.DeserializeObject<Version>(pars[1].ToString());
                    versionList.Add(current);
                }
            }
            versionList.Reverse();
            PopulateList();
        }

        private void PopulateList()
        {
            cboVersionSelector.Items.Clear();
            foreach (Version v in versionList)
            {
                if (chkAlpha.Checked && v.Name == "Alpha")
                {
                    cboVersionSelector.Items.Add(v);
                }
                else if (chkBeta.Checked && v.Name == "Beta")
                {
                    cboVersionSelector.Items.Add(v);
                }
                else if (v.Name != "Alpha" && v.Name != "Beta")
                {
                    cboVersionSelector.Items.Add(v);
                }
            }
        }

        private bool ExecuteStaticMethod(string name, object[] args, out object result)
        {
            bool foundOne = false;
            foreach (var method in type.GetMethods())
            {
                if (method.Name == name && !foundOne)
                {
                    foundOne = true;
                    result = method.Invoke(null, args);
                    return true;
                }
            }
            result = null;
            return foundOne;

        }

        private void cboVersionSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVersionSelector.SelectedIndex > -1)
            {
                btnInstall.Enabled = true;
            }
        }

        private void ShowUnstable(int vs)
        {
            var msg = MessageBox.Show("WARNING! \n\nInstalling Alpha/Beta Versions is not recommended. " +
                "These versions are considered to be unstable and/or outdated. Use at your own risk.",
                "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (msg == DialogResult.Cancel)
            {
                if (vs == 0) chkAlpha.Checked = false;
                if (vs == 1) chkBeta.Checked = false;
            }
        }
        private void chkAlpha_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAlpha.Checked)
            {
                ShowUnstable(0);
                PopulateList();
            }
        }

        private void chkBeta_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBeta.Checked)
            {
                ShowUnstable(1);
                PopulateList();
            }
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            string downloadLink = 
                $"http://godispower.us/Application/Update/Download/" +
                $"{versionList[cboVersionSelector.SelectedIndex].ToString().Replace(" ", "%20")}.zip";
            var msg = MessageBox.Show("You are about to download Power of God " + cboVersionSelector.SelectedText + ". Are you sure you want to continue?",
                "Continue?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (msg != DialogResult.Yes) return;

            Download(downloadLink);
        }

        private void Download(string link)
        {
            if (File.Exists("update.zip"))
            {
                File.Delete("update.zip");
            }
            lblResults.Text = "";
            lblResults.ForeColor = Color.Black;
            lblResults.Show();
            Thread thread = new Thread(() => {
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri(link), "update.zip");
            });
            thread.Start();
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                lblResults.Text = "Downloaded " + e.BytesReceived + " of " + e.TotalBytesToReceive + " (" + Math.Round(percentage, 0) + "%)";
                progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
            });
        }
        private System.Timers.Timer t = new System.Timers.Timer()
        {
            Interval = 500
        };
        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate {
                lblResults.ForeColor = Color.Olive;
                
                t.Elapsed += Elapse;
                t.Enabled = true;
                t.Start();
                Install();
            });
        }

        short currentNum = 1;
        private void Elapse(object sender, ElapsedEventArgs e)
        {
            if (currentNum == 4) currentNum = 1;
            string dots = "";
            for (int x = 1; x <= currentNum; x++)
            {
                dots += ".";
                

            }
            currentNum++;
            BeginInvoke((MethodInvoker)delegate
            {
                lblResults.Text = "Download Complete. Installing" + dots;
            });
            
        }


        private void Install()
        {
            if (Directory.Exists("Update"))
            {
                DirectoryInfo di = new DirectoryInfo("Update");
                di.ClearDirectory();
                Directory.Delete("Update");
            }
            ZipFile.ExtractToDirectory("update.zip", "Update");
            File.Delete("Update/Updater.exe"); 

            foreach (string file in Directory.GetFiles("Update/"))
            {
                try
                {
                    string rootName = file.Substring(file.LastIndexOf("/") + 1);
                    if (File.Exists(rootName)) File.Delete(rootName);
                    File.Move(file, rootName);
                }
                catch (UnauthorizedAccessException)
                {
                    // Ignored -> Libraries in use by Updater. Will be updated with updater
                }
            }
            new DirectoryInfo("Update/").ClearDirectory();
            Directory.Delete("Update/");
            File.Delete("update.zip");
            lblResults.ForeColor = Color.Green;
            lblResults.Text = "Update Successful!";
            t.Stop();
            t.Enabled = false;
            
        }
        
    }

    public class Version
    {
        public string Name;
        public int Major;
        public int Minor;
        public int Build;
        public int Revision;

        /// <summary>
        /// Default Constructor for JSON use
        /// </summary>
        public Version()
        {

        }

        public Version(string name, int major, int minor)
        {
            Name = name;
            Major = major;
            Minor = minor;
            Build = -1;
            Revision = -1;
        }

        public Version(string name, int major, int minor, int build)
        {
            Name = name;
            Major = major;
            Minor = minor;
            Build = build;
            Revision = -1;
        }

        public Version(string name, int major, int minor, int build, int revision)
        {
            Name = name;
            Major = major;
            Minor = minor;
            Build = build;
            Revision = revision;
        }

        public override string ToString()
        {
            string finalVersion = Name + " " + Major + "." + Minor;
            if (Build > -1)
            {
                finalVersion += "." + Build;
                if (Revision > -1)
                {
                    finalVersion += "." + Revision;
                }
            }
            return finalVersion;
        }
    }
}
