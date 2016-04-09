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
using Power_of_God_Lib.Plugins.Controls;

namespace Lesson.Frames
{
    public partial class LessonFrame : PluginFrame
    {
        public LessonFrame()
        {
            InitializeComponent();
            Plugin.Ol.CollectionChanged += Update;
            // webBrowser1.Navigate("http://godispower.us/Application/Lessons/sunday.html");
            
        }

        private void Update(object sender, NotifyCollectionChangedEventArgs e)
        {
        }

        private void ChangedTitle(object sender, WebBrowserNavigatedEventArgs e)
        {

        }
        private readonly string _lastDate = "http://godispower.us/Sundays/" + Plugin.GetList().Last().Replace("/", ".") + ".html";
        private void LessonFrame_Load(object sender, EventArgs e)
        {
            Plugin.Ol.CollectionChanged += SavedChange;
            Content.SetListItems(Plugin.GetList().Distinct().ToList());
            
            var daList = Updater.GetUrlSource(_lastDate);
            lessonBox.Text = "";
            var fullText = "";
            for (var x = 0; x <= daList.Count; x++)
            {
                try
                {
                    var text = "\n" + Updater.GetUrlSource(_lastDate).ElementAt(x);
                    fullText += text;
                }
                catch (Exception)
                {
                    // Ignored
                }
            }
            lessonBox.SetHtmlText(fullText);
            Content.SetTitle(TitleExtractor.pageTitle(_lastDate));
        }

        private void SavedChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            var textLines = Plugin.Ol.Aggregate("", (current, t) => current + t);
            lessonBox.SetHtmlText(textLines);
            Content.SetTitle(Plugin.DateString);
        }
    }
}
