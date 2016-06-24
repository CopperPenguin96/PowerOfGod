using System;
using System.Linq;
using System.Xml.Linq;

namespace Power_of_God_Lib.NetBible
{
    //Default book class
    //Never use unless extending
    public class Book
    {
        /// <summary>
        /// The Name of the Book
        /// </summary>
        public virtual string Name { get; set; } = "Do Not Use";
        /// <summary>
        /// The Index of the Book
        /// </summary>
        public virtual int BookNum { get; set; } = 0;
        /// <summary>
        /// The amount of chapters in the book
        /// </summary>
        public virtual int ChapterCount { get; set; } = 0;
        /// <summary>
        /// The amount of verses per chapter entered
        /// </summary>
        /// <param name="chapter">The chapter</param>
        /// <returns>Gets the amount of verses per the chapter</returns>
        public int VerseCount(int chapter)
        {
            var listofBooks = from item in LoadBibleXml(Bible.FileLocation).Descendants("book")
                              select item;
            // ReSharper disable once LoopCanBePartlyConvertedToQuery
            foreach (var xItem in listofBooks)
            {
                // ReSharper disable once InvertIf
                if (xItem.Attributes().First().Value.Equals(Name))
                {
                    var chapterElements = xItem.Elements();
                    foreach (var item in chapterElements)
                    {
                        try
                        {
                            if (int.Parse(item.FirstAttribute.Value) == chapter)
                            {
                                return item.Elements().Count();
                            }
                        }
                        catch (Exception)
                        {
                            // Ignored
                        }
                    }
                }
            }
            return -1;
        }
        /// <summary>
        /// Gets formatted string of verse
        /// </summary>
        /// <param name="chapter">Chapter</param>
        /// <param name="verse">Verse</param>
        /// <returns>Returns verse</returns>
        public virtual string ReadFormattedVerse(int chapter, int verse)
        {
            return Name + " " + chapter + ":" + verse + " (KJV) - \"" + ReadPlainVerse(chapter, verse) + "\"";
        }
        /// <summary>
        /// Gets plain string of verse
        /// </summary>
        /// <param name="chapter">Chapter</param>
        /// <param name="verse">Verse</param>
        /// <returns>Returns verse</returns>
        public string ReadPlainVerse(int chapter, int verse)
        {
            string foundVerse = null;
            try
            {
                var listofBooks = from country in LoadBibleXml(Bible.FileLocation).Descendants("book")
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
        public XDocument LoadBibleXml(string filelocation)
        {
            var xDoc = XDocument.Load(filelocation);
            return xDoc;
        }
        
    }
}
    

