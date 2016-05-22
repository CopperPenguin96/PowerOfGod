using System.Collections.Generic;
using System.IO;
using System.Linq;
using Power_of_God_Lib.GUI.DialogBox;
using Power_of_God_Lib.NetBible.Books;
using Power_of_God_Lib.NetBible.Books.New_Testament;
using Power_of_God_Lib.NetBible.Books.Old_Testament;
using Power_of_God_Lib.pSystem;

namespace Power_of_God_Lib.NetBible
{
    public class Bible
    {
        public static string FileLocation;
        /// <summary>
        /// Must be called before calling any verses
        /// </summary>
        /// <param name="location">The path and file name</param>
        public static void SetLocation(string location)
        {
            FileLocation = location;
        }
        public static List<Book> OldTestament = new List<Book>()
        {
            new Genesis(), new Exodus(), new Leviticus(), new Numbers(), new Deuteronomy(),
            new Joshua(), new Judges(), new Ruth(), new Samuel1(), new Samuel1(),
            new Kings1(), new Kings2(), new Chronicles1(), new Chronicles2(), new Ezra(),
            new Nehemiah(), new Esther(), new Job(), new Psalms(), new Proverbs(),
            new Ecclesiastes(), new SongOfSolomon(), new Isaiah(), new Jeremiah(), new Lamentations(),
            new Ezekiel(), new Daniel(), new Hosea(), new Joel(), new Amos(),
            new Obadiah(), new Jonah(), new Micah(), new Nahum(), new Habakkuk(),
            new Zephaniah(), new Haggai(), new Zechariah(), new Malachi()
        };

        public static List<Book> NewTestament = new List<Book>()
        {
            new Matthew(), new Mark(), new Luke(), new John(), new Acts(), new Romans(),
            new Corinthians1(), new Corinthians2(), new Galatians(), new Ephesians(), new Philippians(),
            new Colossians(), new Thessalonians1(), new Thessalonians2(), new Timothy1(),
            new Timothy2(), new Titus(), new Philemon(), new Hebrews(), new James(), new Peter1(), new Peter2(),
            new John1(), new John2(), new John3(), new Jude(), new Revelation()
        };

        public static List<Book> AllBooks()
        {   
            return OldTestament.Concat(NewTestament).ToList();
        }

        public static bool CheckIfDownloaded(string ver)
        {
            return File.Exists("power.of.god/Bibles/" + ver + ".xml");
        }

        public static DownloadDialogBox DownloadBox()
        {
            
            var requiredfile = "power.of.god/Bibles/" + Settings.UserSettings.scriptver + ".xml";
            
            if (!File.Exists(requiredfile))
            {
                
            }
            return null;
        }
    }
}
