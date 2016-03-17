using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Power_of_God_Lib.Plugins;

namespace Power_of_God_Lib.pSystem
{
    public class Content
    {
        public static string OldTitle;
        public static string CurrentTitle;
        public static bool ButtonPressed;
        public static void SetTitle(string text)
        {
            if (!ButtonPressed)
            {
                CurrentTitle = "Beta 1.0";
            }
            else
            {
                if (OldTitle != null)
                {
                    OldTitle = CurrentTitle;
                }
                CurrentTitle = text;
            }
        }

        public static string CurrentListId = "";

        public static string GenerateMd5(string original)
        {
            var md5 = MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(original);
            var hash = md5.ComputeHash(inputBytes);
            var sb = new StringBuilder();
            foreach (var t in hash)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString().ToLower();
        }
        public static ObservableCollection<string> ObservedList = new ObservableCollection<string>();
        public static void SetListItems(List<string> items)
        {
            var newList = items.Distinct().ToList();
           
            if (!ButtonPressed) return;
            foreach (var item in newList)
            {
                ObservedList.Add(item);
            }
            
        }
    }
}
