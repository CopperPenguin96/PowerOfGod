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
using Newtonsoft.Json;
using Power_of_God_Lib.GUI.Controls;
using Power_of_God_Lib.Plugins;
using Power_of_God_Lib.Utilities;

namespace Lesson.Frames
{
    public partial class MainFrame : PluginFrame
    {
        public MainFrame()
        {
            InitializeComponent();
            try
            {
                SetLastDate();
            }
            catch (Exception m)
            {
                ErrorLogging.Write(m);
                
            }
            
            Plugin.VidOl.CollectionChanged += SavedChange;
        }

        private string _lastDate;
        private void SetLastDate()
        {
            var dt = FirstDayOfWeekUtility.GetFirstDayOfWeek(DateTime.Now);
            var powerGodStr = "http://powerofgodonline.net/Sundays/" + dt.Year + "/" +
                              dt.ToString("MM.dd.yyyy") + ".plesson";
            var lObj = JsonConvert.DeserializeObject<LessonObj>(Network.GetUrlSource(powerGodStr).ElementAt(0));
            try
            {
                // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                if (!Network.IsPreRelease)
                {
                    Content.SetTitle(lObj.Name + " - " + lObj.AirDate);
                    _lastDate = lObj.Link;
                }
                else
                {
                    _lastDate = "http://powerofgodonline.net/prnotice.html";
                }
            }
            catch (InvalidOperationException)
            {
                // Ignored
            }
        }
        private void VideoScreenFrame_Load(object sender, EventArgs e)
        {
            try
            {
                SetLastDate();
                if (Network.IsPreRelease)
                {
                    var title = Network.GetPageTitle(_lastDate);
                    Content.SetTitle(title);
                }
                var url = _lastDate;
                videoPlayer1.SetVideo(url);
            }
            catch (Exception ef)
            {
                ErrorLogging.Write(ef);
            }
        }

        private string GetVidTxt(string dtStr)
        {
            //return dtStr.Replace("mp4", "txt");
            return dtStr;
        }
        private void SavedChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                Content.SetTitle(Plugin.VidOl.ElementAt(0));
                //videoPlayer1.SetVideo(Plugin.VidOl.ElementAt(1));
            }
            catch (Exception)
            {
                // Ignored -> From the .Clear() method
            }
        }

        private void btnRegularLessons_Click(object sender, EventArgs e)
        {
            PluginReader.SetFrame(new LessonFrame());
        }
    }
 
    
}
