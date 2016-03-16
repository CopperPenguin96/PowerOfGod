using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Power_of_God.pSystem;
using Power_of_God_Lib.pSystem;
using Power_of_God_Lib.Plugins;

namespace Lesson.Frames
{
    public partial class LessonFrame : PluginFrame
    {
        public LessonFrame()
        {
            InitializeComponent();
            LessonPlugin.Plugin.oL.CollectionChanged += Update;
            // webBrowser1.Navigate("http://godispower.us/Application/Lessons/sunday.html");
            
        }

        private void Update(object sender, NotifyCollectionChangedEventArgs e)
        {
        }

        private void ChangedTitle(object sender, WebBrowserNavigatedEventArgs e)
        {

        }

        private void LessonFrame_Load(object sender, EventArgs e)
        {
            var lastDate = "http://godispower.us/Sundays/" + new LessonPlugin.Plugin().GetList().Last().Replace("/", ".") + ".html";
            var daList = Updater.GetUrlSource(lastDate);
            lessonBox.Text = "";
            var fullText = "";
            for (var x = 0; x <= daList.Count; x++)
            {
                try
                {
                    var text = "\n" + Updater.GetUrlSource(lastDate).ElementAt(x);
                    fullText += text;
                }
                catch (Exception)
                {
                    // Ignored
                }
            }
            lessonBox.SetHtmlText(fullText);
            Content.SetTitle(TitleExtractor.pageTitle(lastDate));
        }
    }
}
