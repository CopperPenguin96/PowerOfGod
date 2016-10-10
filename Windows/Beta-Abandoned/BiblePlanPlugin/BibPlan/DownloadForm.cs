using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Power_of_God_Lib.Utilities;

namespace BiblePlanPlugin.BibPlan
{
    public partial class DownloadForm : Form
    {
        public DownloadForm()
        {
            InitializeComponent();
        }

        private string _webdir;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var x = txtAuthorName.Text;
                _webdir = "http://godispower.us/BiblePlans/" + x + "/";
                
                var list = Network.GetWebDirectory(_webdir); ;
                foreach (var i in list.Where(i => i.Contains(".bibplan")))
                {
                    lboContent.Items.Add(i.Substring(1, i.Length - 2));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Sorry, try again.");
            }
        }

        private void lboContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            var texta = GetUrlSource("http://godispower.us/BiblePlans/" + 
                txtAuthorName.Text + 
                "/" + lboContent.SelectedItem).Aggregate("", (current, x) => current +
                x);
            var tempbib = Parser.BiblicalPlan(texta);
            var text = $"Name: {tempbib.Name}\nDays: {tempbib.VerseList.Count}";
            lblInfoContent.Text = text;
        }
        public static List<string> GetUrlSource(string urlF)
        {
            var temp = "power.of.god/tempupdate.txt";
            if (File.Exists(temp))
            {
                File.Delete(temp);
            }
            using (var client = new WebClient())
            {
                try
                {
                    client.DownloadFile(urlF, temp);
                }
                catch (Exception e)
                {
                    ErrorLogging.Write(e);
                }

            }
            var x = File.CreateText("texttexttext.txt");
            x.Write(temp);
            x.Flush();
            x.Close();
            return File.ReadAllLines(temp).ToList();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            var dirNameBase = "power.of.god/BibPlans/" + lboContent.SelectedItem;
            var dirName = dirNameBase.Substring(0, dirNameBase.LastIndexOf(".bibplan"));
            var desPath = "power.of.god/BibPlans/" + lboContent.SelectedItem;
            if (File.Exists(desPath))
            {
                if (MessageBox.Show("Plan with same file name already exists. Overwrite?", "Overwrite?",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    File.Delete(desPath);
                    if (Directory.Exists(dirName))
                    {
                        Directory.Delete(dirName);
                    }
                }
            }
            Directory.CreateDirectory(dirName);
            var texta = GetUrlSource("http://godispower.us/BiblePlans/" +
                txtAuthorName.Text +
                "/" + lboContent.SelectedItem).Aggregate("", (current, x) => current +
                x);
            var sWriter = File.CreateText(desPath);
            sWriter.Write(texta);
            sWriter.Flush();
            sWriter.Close();
            MessageBox.Show("Bible Plan downloaded successfully. Application must be restarted for plan to appear.");
        }
    }
}
