using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using Lesson.Frames;
using Power_of_God_Lib.GUI.Controls;
using Power_of_God_Lib.Plugins;
using Power_of_God_Lib.Utilities;

namespace Lesson
{
    public class Plugin : Power_of_God_Lib.Plugins.Plugin
    {
        public new int Priority = 2;
      

        public Plugin(string name, string dev, Category cat, bool act) : base(name, dev, cat, act)
        {

        }
        public Plugin()
        {

        }

        public override void AppLoad()
        {
            PerformStartAction();
        }

        private static bool _isWritten;
        public static List<string> GetList(bool isWritten)
        {
            _isWritten = isWritten;
            if (isWritten)
            {
                var theList = new List<string>();
                GetallFilesFromHttp.ListDiractory("http://godispower.us/Sundays/");
                var intIndex = 0;
                foreach (var x in GetallFilesFromHttp.Files)
                {
                    if (intIndex > 1)
                    {
                        if (intIndex < GetallFilesFromHttp.Files.Count - 2)
                        {
                            try
                            {
                                var i = x.Substring(1, x.Length - 7).Replace(".", "/");
                                if (!(Convert.ToDateTime(i) > DateTime.Now))
                                {
                                    theList.Add(i);
                                }
                            }
                            catch (Exception)
                            {
                                // Ignored - Occurs when "Lessons" button clicked twice

                            }
                        }
                    }
                    intIndex++;
                }
                var dtList = SortAscending(theList.Select(DateTime.Parse).ToList());
                return dtList.Select(date => date.ToString("MM/dd/yyyy")).ToList().Distinct().ToList();
            }
            else
            {

                GetallFilesFromHttp.Files.Clear();
                var theNewList = new List<string>();
                const string dir2016 = "http://pogvids.x10host.com/2016/";
                                      //0123456789012345678901234567890123456789
                GetallFilesFromHttp.ListDiractory(dir2016);
                GetallFilesFromHttp.Files = GetallFilesFromHttp.Files.Distinct().ToList(); // 35
                foreach (var x in GetallFilesFromHttp.Files)
                {
                    try
                    {
                        var subStr = x.Substring(1);
                        var i = subStr.Substring(0, x.LastIndexOf(".") - 1).Replace(".", "/");
                    
                        if (!(Convert.ToDateTime(i) > DateTime.Now))
                        {
                            theNewList.Add(i);
                        }
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
                return theNewList;
            }
        }
        /*
        using (MD5 md5Hash = MD5.Create())
                    {
                        string hash = Md5Hasher.GetMd5Hash(md5Hash, source);

                    }
    */
        private static IEnumerable<DateTime> SortAscending(List<DateTime> list)
        {
            list.Sort((a, b) => a.CompareTo(b));
            return list;
        }

        public override void PerformStartAction()
        {
            // UpdateWeb.Navigate("http://godispower.us/Application/Lessons/sunday.html");
            //dContent.SetListItems(GetList());
        }

        private readonly List<PluginFrame> _frames = new List<PluginFrame>
        {
            new VideoScreenFrame(),
            null
        };

        public override List<PluginFrame> FrameIdList()
        {
            return _frames;
        }

        public override PluginFrame GetFrame(string idStr)
        {
            foreach (var frame in FrameIdList().Where(frame => frame.FrameID == idStr))
            {
                return frame;
            }
            return new PluginFrame();
        }

        public static ObservableCollection<string> Ol = new ObservableCollection<string>();
        public static ObservableCollection<string> VidOl = new ObservableCollection<string>(); 
        public static string DateString;
        
        public override void LboSelection(int i)
        {
            var actionStartedId = PluginReader.AssignNewAction(this, new LessonFrame());
            if (_isWritten)
            {
                Ol.Clear();
                DateString = "http://godispower.us/Sundays/" + GetList(true).ElementAt(i).Replace("/", ".") + ".html";
                var lines = Network.GetUrlSource(DateString);
                foreach (var line in lines)
                {
                    Ol.Add(line);
                }
            }
            else
            {
                if (PluginReader.CheckIfStarted(actionStartedId)) return;
                VidOl.Clear();
                var daList =
                    Network.GetUrlSource("http://pogvids.x10host.com/2016/" +
                                         GetVidTxt(GetList(false).ElementAt(i)).Replace("/", ".") + ".txt");
                var title = daList.ElementAt(0);
                var url = daList.ElementAt(1);
                VidOl.Add(title);
                VidOl.Add(url);
                PluginReader.AssignActionFinished(actionStartedId);
            }
        }

        private static string GetVidTxt(string dtStr)
        {
            return dtStr.Replace("mp4", "txt");
        }
    }
}
