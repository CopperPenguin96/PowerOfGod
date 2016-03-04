using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Power_of_God_Lib.pSystem;
using Power_of_God_Lib.Plugins;

namespace Lesson.Frames
{
    public partial class LessonFrame : PluginFrame
    {
        public LessonFrame()
        {
            InitializeComponent();
            webBrowser1.Navigated += ChangedTitle;
            webBrowser1.Navigate("http://godispower.us/Application/Lessons/sunday.html");

        }

        private void ChangedTitle(object sender, WebBrowserNavigatedEventArgs e)
        {
            Content.SetTitle(webBrowser1.DocumentTitle);
        }
    }
}
