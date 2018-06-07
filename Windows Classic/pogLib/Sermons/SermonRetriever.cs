using Newtonsoft.Json;
using pogLib.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pogLib.Sermons
{
    public class SermonRetriever
    {
        public static List<Sermon> AllSermons = new List<Sermon>();

        private static string WebDir(int year)
        {
            return $"http://godispower.us/Sermons/Dir/{year}/";
        }

        public static string FullUrl(string file)
        {
            string fish = file.Substring(6, 4);
            return $"http://godispower.us/Sermons/Dir/{fish}/{file}";
        }
        private static List<string> TrimList(List<string> list)
        {
            List<string> newList = new List<string>();
            for (int x = 2; x <= list.Count - 1; x++)
            {
                string y = list[x].Trim().Replace("\"", "");
                if (Path.GetExtension(y) == ".plesson")
                {
                    newList.Add(y);
                }
            }
            return newList;
        }

        /// <summary>
        /// Gets sermons for an entire year
        /// </summary>
        /// <param name="year">The year to retrieve</param>
        /// <returns>A list of object Sermon from specified year</returns>
        public static List<Sermon> GetSermons(int year)
        {
            string dir = WebDir(year);
            List<string> files = TrimList(Network.GetWebDirectory(dir));
            List<Sermon> sermons = new List<Sermon>();
            foreach (string file in files)
            {
                string jsonData = Network.GetUrlSource(FullUrl(file));
                sermons.Add(JsonConvert.DeserializeObject<Sermon>(jsonData));
            }
            return sermons;
        }
        
    }
}
