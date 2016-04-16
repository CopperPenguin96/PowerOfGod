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
using Power_of_God_Lib.pSystem;
using Power_of_God_Lib.pSystem.DialogBox;
using Power_of_God_Lib.Plugins;
using Power_of_God_Lib.Plugins.Controls;
using Power_of_God_Lib.Utilities;

namespace Lesson.Frames
{
    public partial class VideoScreenFrame : PluginFrame
    {
        public VideoScreenFrame()
        {
            InitializeComponent();
        }

        private readonly string _lastDate = null; //"http://godispower.us/Sundays/" + Plugin.GetList(false).Last().Replace("/", ".") + ".txt";
        private void VideoScreenFrame_Load(object sender, EventArgs e)
        {
            Plugin.Ol.CollectionChanged += SavedChange;
            Content.SetListItems(Plugin.GetList(false).Distinct().ToList());

            var daList = Updater.GetUrlSource(_lastDate);
            //var title = daList.ElementAt(0);
            //var url = daList.ElementAt(1);
            //Content.SetTitle(title);
            videoPlayer1.SetVideo("http://pogvids.x10host.com/2016/%233.1.mp4");
        }

        private void SavedChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            //throw new NotImplementedException();
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
