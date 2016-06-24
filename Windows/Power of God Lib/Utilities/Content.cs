﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Power_of_God_Lib.Utilities
{
    public class Content
    {
        public static string OldTitle;
        public static string CurrentTitle;
        public static bool ButtonPressed;
        /// <summary>
        /// Sets the title
        /// </summary>
        /// <param name="text">the desired title</param>
        public static void SetTitle(string text)
        {
            if (OldTitle != null)
            {
                OldTitle = CurrentTitle;
            }
            CurrentTitle = text;

        }

        public static string CurrentListId = "";
        /// <summary>
        /// Generates an MD5 Hash
        /// </summary>
        /// <param name="original">the text used</param>
        /// <returns></returns>
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
        /// <summary>
        /// Sets the content of the ListBox to the Right of the MainScreen Form
        /// </summary>
        /// <param name="items">The Collection</param>
        public static void SetListItems(List<string> items)
        {
            ObservedList.Clear();
            var newList = items.Distinct().ToList();
           
            if (!ButtonPressed) return;
            foreach (var item in newList)
            {
                ObservedList.Add(item);
            }
            
        }
    }
}
