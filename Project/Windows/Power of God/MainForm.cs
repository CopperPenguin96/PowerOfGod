﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Power_of_God.Books;
using Power_of_God.Books.Old_Testament;
using Power_of_God.Books.New_Testament;
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
            const string settingsFile = "power.of.god/settings.json";
            Settings.LoadDefault();
            Settings.LoadFromJson();
            webBrowser1.Navigated += ChangedTitle;
            SetDefaultContent();
            if (Updater.UpdateWord().ToLower() != "updated")
            {
                MessageBox.Show(Updater.UpdateNotice(), "Update Notice for Power of God");
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
            picMain.Load("http://godispower.us/images/main.png");
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
            
            webBrowser1.DocumentText = "<html><head><title>Purpose</title></head><body>Welcome to Power of God! Thank you for " +
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

        private void SetCurrentContent(string x)
        {
            webBrowser1.DocumentText = "<html><body>" + x + "</body></html>";
        }
        private void btnPurpose_Click(object sender, EventArgs e)
        {
            SetRichText(RichTextMode.Purpose);
        }
        private void btnLessons_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://godispower.us/Application/Lessons/sunday.html");
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
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm();
            settingsForm.Show();
        }
    }

    public enum RichTextMode
    {
        Purpose, Lessons, DailyVerses
    }
}