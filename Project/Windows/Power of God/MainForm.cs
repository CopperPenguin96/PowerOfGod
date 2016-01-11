using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NetBible.Books;
using Power_of_God.BibPlan;
using Power_of_God.pSystem;
using Power_of_God.User;
using PurposeVerses = Power_of_God.pSystem.PurposeVerses;

namespace Power_of_God
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            if (!Directory.Exists("power.of.god"))
            {
                Directory.CreateDirectory("power.of.god");
            }
            InitializeComponent();
            Text = "Power of God " + Updater.LatestStable();
            //const string settingsFile = "power.of.god/settings.json";
            Settings.LoadDefault();
            Settings.LoadFromJson();
            webBrowser1.Navigated += ChangedTitle;
            SetDefaultContent();
            if (Updater.UpdateWord().ToLower() != "updated")
            {
                MessageBox.Show(Updater.UpdateNotice(), "Update Notice for Power of God");
            }
            Bible.SetLocation("power.of.god/" + Settings.UserSettings.scriptver + ".xml");
            Parser.PlanDays.CollectionChanged += CheckChanged;
            headerpanel.MouseDown += panel1_MouseDown;
            headerpanel.MouseUp += panel1_MouseUp;
            headerpanel.MouseMove += panel1_MouseMove;
            picMain.MouseDown += panel1_MouseDown;
            picMain.MouseUp += panel1_MouseUp;
            picMain.MouseMove += panel1_MouseMove;
        }
        //Global variables;
        private bool _dragging = false;
        //private Point _offset;
        private Point _startPoint = new Point(0, 0);


        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;  // _dragging is your variable flag
            _startPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_dragging) return;
            var p = PointToScreen(e.Location);
            Location = new Point(p.X - this._startPoint.X, p.Y - this._startPoint.Y);
        }
        private void CheckChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            lboListOfItems.Items.Clear();
            foreach (var x in Parser.PlanDays)
            {
                lboListOfItems.Items.Add(x);
            }
        }

        private void ChangedTitle(object sender, WebBrowserNavigatedEventArgs e)
        {
            lblName.Text = webBrowser1.DocumentTitle;
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Updater.LatestStable() != "Alpha 1.5")
            {
                picMain.Load("http://godispower.us/images/main.png");
            }
        }

        private void SetRichText(RichTextMode rt)
        {
            switch (rt)
            {
                case RichTextMode.Purpose:
                    SetDefaultContent();
                    break;
            }
        }

        private void SetDefaultContent()
        {

            webBrowser1.DocumentText =
                "<html><head><title>Purpose</title></head><body>Welcome to Power of God! Thank you for " +
                "taking the time to view this app! It could actually change your life!<br><br>If you are using " +
                "this app expecting favor for a specific denomination, you are in for a surprise! " +
                "This app is intended to be non-denominational! <br><br>You also may be wondering why such an " +
                "app exists. Well, I believe that the Holy Bible is true. " +
                PurposeVerses.GetVerse(0) + " With that in mind, I also believe that the " +
                "holy power God has is beyond compare. " + PurposeVerses.GetVerse(1) + " I " +
                "live to serve Jesus Christ, who is God, and will come back to earth take all who " +
                "believe he died and rose again, to heaven. I use this app as a way to witness, to share " +
                "this amazing truth. God bless and I hope you learn some stuff about God.</body></html>";
        }

        /*private void SetCurrentContent(string x)
        {
            webBrowser1.DocumentText = "<html><body>" + x + "</body></html>";
        }
        */
        private void btnPurpose_Click(object sender, EventArgs e)
        {
            SetRichText(RichTextMode.Purpose);
            KillPlans();
        }

        private void btnLessons_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://godispower.us/Application/Lessons/sunday.html");
            ListItems(RichTextMode.Lessons);
        }


        private void btnDailyVerses_Click(object sender, EventArgs e)
        {
            for (var x = 1; x <= 2; x++)
            {
                try
                {
                    webBrowser1.DocumentText = DailyScripture.GetDailyScripture();
                }
                catch (Exception)
                {
                    MessageBox.Show("Sorry, there is no verse(s) for today. Check back tomorrow!");
                }
            }
            ListItems(RichTextMode.DailyVerses);
        }


        private void picExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        private BibPlanDialog _bPlanDialog = new BibPlanDialog();
        private void KillPlans()
        {
            _bPlanDialog.Hide();
        }
        private RichTextMode _rtmSize;
        private void ListItems(RichTextMode rtm)
        {
            _rtmSize = rtm;
            if (rtm != RichTextMode.BiblePlans) KillPlans();
            switch (rtm)
            {
                case RichTextMode.Lessons:
                    GetallFilesFromHttp.ListDiractory("http://godispower.us/Sundays/");
                    var intIndex = 0;
                    foreach (var x in GetallFilesFromHttp.Files)
                    {
                        if (intIndex > 1)
                        {
                            if (intIndex < GetallFilesFromHttp.Files.Count - 2)
                                try
                                {
                                    var i = x.Substring(1, x.Length - 7).Replace(".", "/");
                                    if (!(Convert.ToDateTime(i) > DateTime.Now))
                                    {
                                        lboListOfItems.Items.Add(i);
                                    }
                                }
                                catch (Exception)
                                {
                                    // Ignored - Occurs when "Lessons" button clicked twice
                                }
                        }
                        intIndex++;
                    }
                    
                    break;
                case RichTextMode.DailyVerses:
                    var currentScripture = Directory.GetFiles("Verses/").Length;
                    for (var x = 1; x <= currentScripture; x++)
                    {
                        lboListOfItems.Items.Add("Day #" + x);
                    }
                    break;
            }
        }
        
        private void btnBibPlans_Click(object sender, EventArgs e)
        {
            _bPlanDialog.Show();
            _rtmSize = RichTextMode.BiblePlans;
        }

        private void lboListOfItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (_rtmSize)
            {
                case RichTextMode.Lessons:
                    var webFile = "http://godispower.us/Sundays/" +
                                  lboListOfItems.SelectedItem.ToString().Replace("/", ".") + ".html";
                    webBrowser1.Navigate(webFile);
                    break;
                case RichTextMode.DailyVerses:
                    // D a y   # 1
                    // 0 1 2 3 4 5
                    webBrowser1.DocumentText =
                        DailyScripture.GetDailyScripture(int.Parse(lboListOfItems.SelectedItem.ToString().Substring(5)));
                    break;
                case RichTextMode.BiblePlans:
                    webBrowser1.DocumentText = Parser.HtmlText(BibPlanDialog.PlanFileName, lboListOfItems.SelectedIndex);
                    break;

            }
        }

        private void headerpanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    public enum RichTextMode
    {
        Purpose,
        Lessons,
        DailyVerses,
        BiblePlans
    }

    public static class GetallFilesFromHttp
    {
        public static string GetDirectoryListingRegexForUrl(string url)
        {
            return "\\\"([^\"]*)\\\"";
        }

        public static List<string> Files = new List<string>();

        public static void Write()
        {
            var fw = File.CreateText("tempradio.txt");
            fw.Write(Files.Aggregate("", (current, f) => current + ("\n" + f)));
            fw.Flush();
            fw.Close();

        }
        public static void ListDiractory(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var html = reader.ReadToEnd();

                    var regex = new Regex(GetDirectoryListingRegexForUrl(url));
                    var matches = regex.Matches(html);
                    if (matches.Count > 0)
                    {
                        foreach (var match in matches.Cast<Match>().Where(match => match.Success))
                        {
                            Files.Add(match.ToString());
                        }
                    }
                }
                Write();
            }
        }
    }
}

