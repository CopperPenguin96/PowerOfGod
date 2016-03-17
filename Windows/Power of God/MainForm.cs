﻿using System;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NetBible.Books;
using Power_of_God.BibPlan;
using Power_of_God.pSystem;
using Power_of_God.User;
using Power_of_God_Lib.pSystem;
using Power_of_God_Lib.Plugins;
using Power_of_God_Lib.pSystem.DialogBox;

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
            SetEventHandlers();
            //const string settingsFile = "power.of.god/settings.json";
            Settings.LoadDefault();
            Settings.LoadFromJson();
            if (Updater.UpdateWord().ToLower() != "updated")
            {
                var dBox = new DialogBox("Update Notice for Power of God", Updater.UpdateNotice());
                dBox.Show();
            }
            Bible.SetLocation("power.of.god/" + Settings.UserSettings.scriptver + ".xml");
            UpdatePluginPanel();
            lblName.Text = Updater.LatestStable();
            MessageBox.Show(Content.GenerateMd5("xrxy3749"));
        }
        
        private void UpdatePluginPanel()
        {
            PluginReader.LoadPlugins();
            foreach (var pl in PluginReader.PluginList)
            {
                var myButton = new Power_of_God_Lib.Plugins.Button(pl);
                myButton.SetText(pl.Name);
                myButton.Width = flowLayoutPanel1.Width - 5;
                myButton.Click += myButtonClick;
                flowLayoutPanel1.Controls.Add(myButton);
            }
            lblName.Text = Updater.LatestStable();
        }

        private void myButtonClick(object sender, EventArgs e)
        {
            var btnObject = (Power_of_God_Lib.Plugins.Button) sender;
            MessageBox.Show(btnObject.Text);
        }

        private void SetEventHandlers()
        {
            //webBrowser1.Navigated += ChangedTitle;
            Parser.PlanDays.CollectionChanged += CheckChanged;
            headerpanel.MouseDown += panel1_MouseDown;
            headerpanel.MouseUp += panel1_MouseUp;
            headerpanel.MouseMove += panel1_MouseMove;
            picMain.MouseDown += panel1_MouseDown;
            picMain.MouseUp += panel1_MouseUp;
            picMain.MouseMove += panel1_MouseMove;
            Content.ObservedList.CollectionChanged += CollectionChanged;
        }

        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            lboListOfItems.Items.Clear();
            foreach (var item in Content.ObservedList)
            {
                lboListOfItems.Items.Add(item);
            }
        }



        //Global variables;
        private bool _dragging;
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
            Location = new Point(p.X - _startPoint.X, p.Y - _startPoint.Y);
        }
        private void CheckChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            lboListOfItems.Items.Clear();
            foreach (var x in Parser.PlanDays)
            {
                lboListOfItems.Items.Add(x);
            }
        }
        

        public sealed override string Text
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
            var x = PluginReader.PluginList;
            foreach (var c in x)
            {
                PluginReader.AppLoad(c);
            }
            lblName.Text = Updater.LatestStable();
        }
        

        private void btnLessons_Click(object sender, EventArgs e)
        {
            ListItems(RichTextMode.Lessons);
        }


        private void btnDailyVerses_Click(object sender, EventArgs e)
        {
            for (var x = 1; x <= 2; x++)
            {
                try
                {
                    //webBrowser1.DocumentText = DailyScripture.GetDailyScripture();
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

        private readonly BibPlanDialog _bPlanDialog = new BibPlanDialog();
        private void KillPlans()
        {
            _bPlanDialog.Hide();
        }
        // ReSharper disable once NotAccessedField.Local
        private RichTextMode _rtmSize;
        private void ListItems(RichTextMode rtm)
        {
            lboListOfItems.Items.Clear();
            _rtmSize = rtm;
            if (rtm != RichTextMode.BiblePlans) KillPlans();
            switch (rtm)
            {
                case RichTextMode.Lessons:
                    
                    
                    break;
                case RichTextMode.DailyVerses:
                    var currentScripture = Directory.GetFiles("Verses/").Length;
                    for (var x = 1; x <= currentScripture; x++)
                    {
                        lboListOfItems.Items.Add("Day #" + x);
                    }
                    break;
                case RichTextMode.Purpose:
                    break;
                case RichTextMode.BiblePlans:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(rtm), rtm, null);
            }
        }

        private void btnBibPlans_Click(object sender, EventArgs e)
        {
            _bPlanDialog.Show();
            _rtmSize = RichTextMode.BiblePlans;
        }

        private void lboListOfItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            PluginReader.ActivatePluginListMethod(lboListOfItems.SelectedIndex);
        }

        private PluginFrame _alreadyClearedFrame;
        private string _alreadyClearedTitle;

        private void PluginUpdateTimer_Tick(object sender, EventArgs e)
        {
            // Update Content
            if (PluginReader.CurrentFrame != PluginReader.OldFrame)
            {
                if (_alreadyClearedFrame == null || _alreadyClearedFrame != PluginReader.CurrentFrame)
                {
                    flowLayoutPanel2.Controls.Clear();
                    _alreadyClearedFrame = PluginReader.CurrentFrame;
                    flowLayoutPanel2.Controls.Add(PluginReader.CurrentFrame);
                }
            }
            if (PluginReader.CurrentFrame == PluginReader.OldFrame)
            {
                flowLayoutPanel2.Controls.Add(PluginReader.CurrentFrame);
            }
            // Update Text
            if (Content.CurrentTitle != Content.OldTitle)
            {
                if (_alreadyClearedTitle == null || _alreadyClearedTitle != Content.CurrentTitle)
                {
                    lblName.Text = "";
                    _alreadyClearedTitle = Content.CurrentTitle;
                    lblName.Text = _alreadyClearedTitle;
                }
            }
            if (Content.CurrentTitle == Content.OldTitle)
            {
                lblName.Text = Content.CurrentTitle;
            }
        }
        
    }

    public enum RichTextMode
    {
        Purpose,
        Lessons,
        DailyVerses,
        BiblePlans
    }
}

