using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BiblePlanPlugin.BibPlan
{
    public partial class BibPlanDialog : Form
    {
        public BibPlanDialog()
        {
            InitializeComponent();
        }

        public static string PlanFileName;
        private void BibPlanDialog_Load(object sender, EventArgs e)
        {
            var filePath = "power.of.god/BibPlans/";
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            foreach (var file in Directory.GetFiles(filePath))
            {
                lboPlanList.Items.Add(file.Substring(22));
            }
            if (lboPlanList.Items.Count == 0)
            {
                var x = MessageBox.Show("You don't have any Bible Plans added! Would you like to download some?",
                    "No Plans",
                    MessageBoxButtons.YesNo);
                switch (x)
                {
                    case DialogResult.Yes:
                        new DownloadForm().ShowDialog();
                        break;
                }
            }
        }

        private void lboPlanList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dir = "power.of.god/BibPlans/" + lboPlanList.SelectedItem.ToString().Replace(".bibplan", "") + "/";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            var currentDate = DateTime.Now.ToString("yy-MM-dd");
            var currentDay = Directory.GetFiles(dir).Count();
            for (var x = 0; x <= currentDay; x++)
            {
                try
                {
                    if (!Directory.GetFiles(dir).ElementAt(x).Contains(currentDate))
                    {
                        try
                        {
                            File.CreateText(dir + currentDate);
                        }
                        catch (IOException)
                        {
                            // Ignored
                        }
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    // New file. No files
                    try
                    {
                        File.CreateText(dir + currentDate);
                    }
                    catch (IOException)
                    {
                        // Ignored
                    }
                }
            }
            Parser.PlanDays.Clear();
            for (var x = 1; x <= Directory.GetFiles(dir).Length; x++)
            {
                Parser.PlanDays.Add("Day #" + x);
            }
            PlanFileName = "power.of.god/BibPlans/" + lboPlanList.SelectedItem;
        }

        private void btnDownloadSome_Click(object sender, EventArgs e)
        {
            new DownloadForm().Show();
        }
    }
}
