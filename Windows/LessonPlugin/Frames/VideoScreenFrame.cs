using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Power_of_God_Lib.GUI.Controls;
using Power_of_God_Lib.pSystem;
using Power_of_God_Lib.Plugins;
using Power_of_God_Lib.Utilities;

namespace Lesson.Frames
{
    public partial class VideoScreenFrame : PluginFrame
    {
        public VideoScreenFrame()
        {
            InitializeComponent();
            Plugin.VidOl.CollectionChanged += SavedChange;
        }

        private readonly string _lastDate = "http://pogvids.x10host.com/2016/" + Plugin.GetList(false).Last().Replace("/", ".") + ".mp4";
        private void VideoScreenFrame_Load(object sender, EventArgs e)
        {
            Content.SetListItems(Plugin.GetList(false).Distinct().ToList());

            var daList = Updater.GetUrlSource(GetVidTxt(_lastDate));
            var title = daList.ElementAt(0);
            var url = daList.ElementAt(1);
            videoPlayer1.SetVideo(url);
            Content.SetTitle(title);
        }

        private string GetVidTxt(string dtStr)
        {
            return dtStr.Replace("mp4", "txt");
        }
        private void SavedChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                Content.SetTitle(Plugin.VidOl.ElementAt(0));
                videoPlayer1.SetVideo(Plugin.VidOl.ElementAt(1));
            }
            catch (Exception)
            {
                // Ignored -> From the .Clear() method
            }
        }
    }

    public class FirstDayOfWeekUtility
    {
        /// <summary>
        /// Returns the first day of the week that the specified
        /// date is in using the current culture. 
        /// </summary>
        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek)
        {
            var defaultCultureInfo = CultureInfo.CurrentCulture;
            return GetFirstDayOfWeek(dayInWeek, defaultCultureInfo);
        }

        /// <summary>
        /// Returns the first day of the week that the specified date 
        /// is in. 
        /// </summary>
        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek, CultureInfo cultureInfo)
        {
            var firstDay = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            var firstDayInWeek = dayInWeek.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
                firstDayInWeek = firstDayInWeek.AddDays(-1);

            return firstDayInWeek;
        }
    }
}
