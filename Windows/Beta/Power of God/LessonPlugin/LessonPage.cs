using System;
using System.ComponentModel;
using System.Windows.Forms;
using Power_of_God_Lib.GUI;

namespace LessonPlugin
{
    public partial class LessonPage : PowerTabPage
    {
        private string aboutText = "";
        public LessonPage()
        {
            InitializeComponent();
            webBrowser1.Navigated += webBrowser1_Navigated;
            webBrowser1.Navigate("https://www.youtube.com/embed/hV__1XE4tq4");
            aboutText = metroLabel1.Text;
            

        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            var DocumentTitle = webBrowser1.DocumentTitle.Substring(0, webBrowser1.DocumentTitle.LastIndexOf("-") - 2);
            metroLabel1.Text = metroLabel1.Text.Replace("{Name}", DocumentTitle.Substring(DocumentTitle.IndexOf("\"") + 1));
            metroLabel1.Text = metroLabel1.Text.Replace("{Date}", DocumentTitle.Substring(DocumentTitle.IndexOf("-") + 1, DocumentTitle.LastIndexOf("-") - 14));
        }

        private void metroButton1_Click(object sender, System.EventArgs e)
        {
            var result = MessageBox.Show("This is going to open your webbrowser. Is that ok?", "Are you sure?",
                MessageBoxButtons.YesNo);
            switch (result)
            {
                case DialogResult.Yes:
                    System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCVayQj2y7NeL7t83wzWNSAA");
                    break;
            }
        }
    }
}
