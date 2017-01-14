using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using Power_of_God_Lib.GUI;
using Power_of_God_Lib.Utilities;
using WMPLib;

namespace LessonPlugin
{
    
    public partial class LessonPage : PowerTabPage
    {
        private readonly string aboutText = "";
        readonly List<LessonObj> MessageList = new List<LessonObj>();
        public LessonPage()
        {
            InitializeComponent();
            webBrowser1.Navigated += webBrowser1_Navigated;
            aboutText = metroLabel1.Text;

            foreach (var message in RetrieveMessages())
            {
                var url = "http://powerofgodonline.net/Sundays/2016/" +
                          message[0] + "." + message[1] + "." + message[2] + ".plesson";
                var lessonObj = JsonConvert.DeserializeObject<LessonObj>(Network.GetUrlSource(url));
                MessageList.Add(lessonObj);
            }
            var x = MessageList.ElementAt(MessageList.Count - 1);
            webBrowser1.Navigate(x.Link);
            foreach (var v in MessageList)
            {
                metroListView1.Items.Add(v.AirDate);
            }
        }

        private void SetLabelData(string name, string date)
        {
            metroLabel1.Text = aboutText.Replace("{Name}", name);
            metroLabel1.Text = metroLabel1.Text.Replace("{Date}", date);
        }
        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            var documentTitle = webBrowser1.DocumentTitle.Substring(0, webBrowser1.DocumentTitle.LastIndexOf("-") - 2);
            SetLabelData(documentTitle.Substring(documentTitle.IndexOf("\"") + 1), 
                documentTitle.Substring(documentTitle.IndexOf("-") + 1, 
                documentTitle.LastIndexOf("-") - 14));
        }

        private void metroButton1_Click(object sender, System.EventArgs e)
        {
            var result = MessageBox.Show("This is going to open your webbrowser. Is that ok?", "Are you sure?",
                MessageBoxButtons.YesNo);
            switch (result)
            {
                case DialogResult.Yes:
                    System.Diagnostics.Process.Start("http://www.dailymotion.com/video/x51u279_power-of-god-live-stream_lifestyle");
                    break;
            }
        }

        private List<string[]> RetrieveMessages()
        {
            var receivedMessages = new List<string[]>();
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var m in Network.GetWebDirectory("http://powerofgodonline.net/Sundays/2016/"))
            {
                if (!m.Contains("plesson")) continue;
                var dtStr = m.Replace("\"", "");
                dtStr = dtStr.Replace(".plesson", "");
                var dt = DateTime.Parse(dtStr.Replace(".", "/"));
                var strArr = new List<string>();
                if (dt.Month < 10) strArr.Add("0" + dt.Month);
                else strArr.Add("" + dt.Month);

                if (dt.Day < 10) strArr.Add("0" + dt.Day);
                else strArr.Add("" + dt.Day);

                strArr.Add("" + dt.Year);
                receivedMessages.Add(strArr.ToArray());
            }
            return receivedMessages;
        }

        private void metroListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // m m / d d / y y y y
            // 0 1 2 3 4 5 6 7 8 9
            var selected = metroListView1.SelectedItems[0].Text;
            var dt = DateTime.Parse(selected);
            OpenMessage("" + dt.Month, "" + dt.Day, "" + dt.Year);

        }

        public void OpenMessage(string month, string day, string year)
        {
            var m = month + "." + day + "." + year + ".plesson";
            string dtStr = m.Replace(".plesson", "");
            var dt = DateTime.Parse(dtStr.Replace(".", "/"));
            var strArr = new List<string>();
            if (dt.Month < 10) strArr.Add("0" + dt.Month);
            else strArr.Add("" + dt.Month);

            if (dt.Day < 10) strArr.Add("0" + dt.Day);
            else strArr.Add("" + dt.Day);

            strArr.Add("" + dt.Year);
            var json = "http://powerofgodonline.net/Sundays/2016/" +
                strArr[0] + "." + strArr[1] + "." + strArr[2] + ".plesson";
            webBrowser1.Navigate(JsonConvert.DeserializeObject<LessonObj>(Network.GetUrlSource(json)).Link);
        }
    }
    public class LessonObj
    {
        public string Name;
        public string AirDate;
        public string Link;
    }
}
