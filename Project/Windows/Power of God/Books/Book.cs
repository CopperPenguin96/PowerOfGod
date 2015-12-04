﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Power_of_God.User;

namespace Power_of_God.Books
{
    //Default book class
    //Never use unless extending
    public class Book
    {
        public virtual string Name { get; set; } = "Do Not Use";

        public virtual int BookNum { get; set; } = 0;

        public virtual int ChapterCount { get; set; } = 0;

        public virtual string ReadFormattedVerse(int chapter, int verse)
        {
            return Name + " " + chapter + ":" + verse + " (KJV) - \"" + ReadPlainVerse(chapter, verse) + "\"";
        }

        
        public string ReadPlainVerse(int chapter, int verse)
        {
            string foundVerse = null;
            try
            {
                var listofBooks = from country in LoadBibleXml().Descendants("book")
                                                        select country;
                
                foreach (var x3 in (from x in listofBooks let currentBook = x.Attributes().First().Value
                                         where currentBook.Equals(Name) select x).SelectMany(x => (from x2 in x.Elements()
                                         where x2.Name.ToString().Equals("chapter") let chapterNum = Convert.ToInt32(x2.Attributes().First().Value)
                                         where chapterNum == chapter from x3 in (from x3 in x2.Elements() where x3.Name.ToString().Equals("verse") let verseNum = Convert.ToInt32(x3.Attributes().First().Value)
                                         where verseNum == verse select x3) select x3)))
                {
                    //Congratulations - Verse is found!
                    foundVerse = x3.Value;
                }
            }
            catch (Exception)
            {
                //ShowMessage("Error", e.ToString());
            }
            return foundVerse;
        }
        internal static int ToOdd(int normz)
        {
            return normz + (normz - 1);
        }
        /*internal static string GetAttribute(Node n)
        {
            return n.Attributes.getNamedItem("name").NodeValue;
        }
        public static Node[] convertToArray(NodeList list)
        {
            int length = list.Length;
            Node[] copy = new Node[length];
            for (int n = 0; n < length; ++n)
            {
                copy[n] = list.item(n);
            }
            return copy;
        }
        */
        /// <summary>
        /// Loads the xml doc
        /// </summary>
        /// <returns></returns>
        public XDocument LoadBibleXml()
        {
            var file = "power.of.god/" + Settings.UserSettings.scriptver + ".xml";
            var xDoc = XDocument.Load(file);
            return xDoc;
        }
    }
}
    
