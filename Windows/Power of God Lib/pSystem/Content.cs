using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static ObservableCollection<string> ObservedList = new ObservableCollection<string>();
        public static void SetListItems(List<string> items)
        {
            if (!ButtonPressed) return;
            foreach (var item in items)
            {
                ObservedList.Add(item);
            }
        }
    }
}
