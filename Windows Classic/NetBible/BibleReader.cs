using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using NetBible.Bible;

namespace NetBible
{
    public class BibleReader
    {
        public static string Version;
        internal static bool Ready = false;
        /// <summary>
        /// Must be loaded before anything can be done
        /// </summary>
        /// <param name="path">Path to Bible XML</param>
        /// <param name="errorLog">Variable to assign error log if exception arrives. </param>
        /// <returns>True if loading was successful, False if failed</returns>
        public static bool LoadXml(string path, out string errorLog)
        {
            try
            {
                Console.WriteLine("----------Attempting to Load NETBIBLE----------");
                string xmlFile = File.ReadAllText(path);
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(xmlFile);
                Version = xmldoc.DocumentElement != null ? xmldoc.DocumentElement?.Attributes[0].Value : string.Empty;
                if (Version != string.Empty) Console.WriteLine("Bible Version: " + Version);
                XmlNodeList nodeList = xmldoc.GetElementsByTagName("book");

                int loopCount = 0;
                foreach (XmlNode node in nodeList) // Each book
                {
                    string bookName = node.Attributes[0].Value.ToLower();
                    LoadOldTestament(bookName, loopCount, node);
                    LoadNewTestament(bookName, loopCount, node);
                    loopCount++;
                }
                errorLog = "No errors";
                Ready = true;
                Console.WriteLine("NetBible loaded successfully...");
                return true;
            }
            
            catch (Exception ex)
            {
                errorLog = ex.StackTrace;
                Ready = false;
                Console.WriteLine("ERROR: NetBible failed to load... (" + ex + ")");
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        private static void LoadOldTestament(string bookName, int loopCount, XmlNode node)
        {
            switch (bookName)
            {
                case "genesis":
                    OldTestament.Genesis = LoadBook(bookName, loopCount, node);
                    break;
                case "exodus":
                    OldTestament.Exodus = LoadBook(bookName, loopCount, node);
                    break;
                case "leviticus":
                    OldTestament.Leviticus = LoadBook(bookName, loopCount, node);
                    break;
                case "numbers":
                    OldTestament.Numbers = LoadBook(bookName, loopCount, node);
                    break;
                case "deuteronomy":
                    OldTestament.Deuteronomy = LoadBook(bookName, loopCount, node);
                    break;
                case "joshua":
                    OldTestament.Joshua = LoadBook(bookName, loopCount, node);
                    break;
                case "judges":
                    OldTestament.Judges = LoadBook(bookName, loopCount, node);
                    break;
                case "ruth":
                    OldTestament.Ruth = LoadBook(bookName, loopCount, node);
                    break;
                case "1 samuel":
                    OldTestament.Samuel1 = LoadBook(bookName, loopCount, node);
                    break;
                case "2 samuel":
                    OldTestament.Samuel2 = LoadBook(bookName, loopCount, node);
                    break;
                case "1 kings":
                    OldTestament.Kings1 = LoadBook(bookName, loopCount, node);
                    break;
                case "2 kings":
                    OldTestament.Kings2 = LoadBook(bookName, loopCount, node);
                    break;
                case "1 chronicles":
                    OldTestament.Chronicles1 = LoadBook(bookName, loopCount, node);
                    break;
                case "2 chronicles":
                    OldTestament.Chronicles2 = LoadBook(bookName, loopCount, node);
                    break;
                case "ezra":
                    OldTestament.Ezra = LoadBook(bookName, loopCount, node);
                    break;
                case "nehemiah":
                    OldTestament.Nehemiah = LoadBook(bookName, loopCount, node);
                    break;
                case "esther":
                    OldTestament.Esther = LoadBook(bookName, loopCount, node);
                    break;
                case "job":
                    OldTestament.Job = LoadBook(bookName, loopCount, node);
                    break;
                case "psalms":
                    OldTestament.Psalms = LoadBook(bookName, loopCount, node);
                    break;
                case "proverbs":
                    OldTestament.Proverbs = LoadBook(bookName, loopCount, node);
                    break;
                case "ecclesiastes":
                    OldTestament.Ecclesiastes = LoadBook(bookName, loopCount, node);
                    break;
                case "song of solomon":
                    OldTestament.SongofSolomon = LoadBook(bookName, loopCount, node);
                    break;
                case "isaiah":
                    OldTestament.Isaiah = LoadBook(bookName, loopCount, node);
                    break;
                case "jeremiah":
                    OldTestament.Jeremiah = LoadBook(bookName, loopCount, node);
                    break;
                case "lamentations":
                    OldTestament.Lamentations = LoadBook(bookName, loopCount, node);
                    break;
                case "ezekiel":
                    OldTestament.Ezekiel = LoadBook(bookName, loopCount, node);
                    break;
                case "daniel":
                    OldTestament.Daniel = LoadBook(bookName, loopCount, node);
                    break;
                case "hosea":
                    OldTestament.Hosea = LoadBook(bookName, loopCount, node);
                    break;
                case "joel":
                    OldTestament.Joel = LoadBook(bookName, loopCount, node);
                    break;
                case "amos":
                    OldTestament.Amos = LoadBook(bookName, loopCount, node);
                    break;
                case "obadiah":
                    OldTestament.Obadiah = LoadBook(bookName, loopCount, node);
                    break;
                case "jonah":
                    OldTestament.Jonah = LoadBook(bookName, loopCount, node);
                    break;
                case "micah":
                    OldTestament.Micah = LoadBook(bookName, loopCount, node);
                    break;
                case "nahum":
                    OldTestament.Nahum = LoadBook(bookName, loopCount, node);
                    break;
                case "habakkuk":
                    OldTestament.Habakkuk = LoadBook(bookName, loopCount, node);
                    break;
                case "zephaniah":
                    OldTestament.Zephaniah = LoadBook(bookName, loopCount, node);
                    break;
                case "haggai":
                    OldTestament.Haggai = LoadBook(bookName, loopCount, node);
                    break;
                case "zechariah":
                    OldTestament.Zechariah = LoadBook(bookName, loopCount, node);
                    break;
                case "malachi":
                    OldTestament.Malachi = LoadBook(bookName, loopCount, node);
                    break;
            }
        }

        public static void LoadNewTestament(string bookName, int loopCount, XmlNode node)
        {
            switch (bookName)
            {
                case "matthew":
                    NewTestament.Matthew = LoadBook(bookName, loopCount, node);
                    break;
                case "mark":
                    NewTestament.Mark = LoadBook(bookName, loopCount, node);
                    break;
                case "luke":
                    NewTestament.Luke = LoadBook(bookName, loopCount, node);
                    break;
                case "john":
                    NewTestament.John = LoadBook(bookName, loopCount, node);
                    break;
                case "acts":
                    NewTestament.Acts = LoadBook(bookName, loopCount, node);
                    break;
                case "romans":
                    NewTestament.Romans = LoadBook(bookName, loopCount, node);
                    break;
                case "1 corinthians":
                    NewTestament.Corinthians1 = LoadBook(bookName, loopCount, node);
                    break;
                case "2 corinthians":
                    NewTestament.Corinthians2 = LoadBook(bookName, loopCount, node);
                    break;
                case "galatians":
                    NewTestament.Galatians = LoadBook(bookName, loopCount, node);
                    break;
                case "ephesians":
                    NewTestament.Ephesians = LoadBook(bookName, loopCount, node);
                    break;
                case "philippians":
                    NewTestament.Philippians = LoadBook(bookName, loopCount, node);
                    break;
                case "colossians":
                    NewTestament.Colossians = LoadBook(bookName, loopCount, node);
                    break;
                case "1 thessalonians":
                    NewTestament.Thessalonians1 = LoadBook(bookName, loopCount, node);
                    break;
                case "2 thessalonians":
                    NewTestament.Thessalonians2 = LoadBook(bookName, loopCount, node);
                    break;
                case "1 timothy":
                    NewTestament.Timothy1 = LoadBook(bookName, loopCount, node);
                    break;
                case "2 timothy":
                    NewTestament.Timothy2 = LoadBook(bookName, loopCount, node);
                    break;
                case "titus":
                    NewTestament.Titus = LoadBook(bookName, loopCount, node);
                    break;
                case "philemon":
                    NewTestament.Philemon = LoadBook(bookName, loopCount, node);
                    break;
                case "hebrews":
                    NewTestament.Hebrews = LoadBook(bookName, loopCount, node);
                    break;
                case "james":
                    NewTestament.James = LoadBook(bookName, loopCount, node);
                    break;
                case "1 peter":
                    NewTestament.Peter1 = LoadBook(bookName, loopCount, node);
                    break;
                case "2 peter":
                    NewTestament.Peter2 = LoadBook(bookName, loopCount, node);
                    break;
                case "1 john":
                    NewTestament.John1 = LoadBook(bookName, loopCount, node);
                    break;
                case "2 john":
                    NewTestament.John2 = LoadBook(bookName, loopCount, node);
                    break;
                case "3 john":
                    NewTestament.John3 = LoadBook(bookName, loopCount, node);
                    break;
                case "jude":
                    NewTestament.Jude = LoadBook(bookName, loopCount, node);
                    break;
                case "revelation":
                    NewTestament.Revelation = LoadBook(bookName, loopCount, node);
                    break;
            }
        }

        /// <summary>
        /// Loads the book by the name. Needs loopCount and node to identify verses/chapters
        /// </summary>
        /// <param name="name"></param>
        /// <param name="loopCount"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        private static Book LoadBook(string name, int loopCount, XmlNode node)
        {
            if (name == null) throw new ArgumentException("name");
            Book lam = new Book(loopCount) {Name = name};
            foreach (XmlNode chapters in node.ChildNodes) // Each chapter
            {
                if (chapters.Name.ToLower() != "chapter") continue;
                Chapter chapter = new Chapter
                {
                    Verses = new List<string>
                    {
                        "" // First value is blank so that numbering can remain 1 based not 0 based
                    }
                };
                foreach (XmlNode verses in chapters.ChildNodes) // Each verse
                {
                    if (verses.Name.ToLower() != "verse") continue;
                    string content = verses.InnerText;
                    chapter.Verses.Add(content);
                }
                lam.Chapters.Add(chapter);
            }
            OldTestament.Lamentations = lam;
            string bookName = name;
            char[] chars = bookName.ToCharArray();
            if (bookName == "song of solomon")
            {
                bookName = "Song of Solomon";
            }
            else if (!char.IsNumber(chars[0]))
            {
                chars[0] = char.ToUpper(chars[0]);
                bookName = new string(chars);
            }
            else
            {
                if (bookName == "2 timothy")
                {
                    var x = chars[2];
                    var y = char.ToUpper(chars[2]);
                    bookName = new string(chars);
                    Console.WriteLine(bookName);
                }
                chars[2] = char.ToUpper(chars[2]);
                bookName = new string(chars);
            }
            
            Console.WriteLine($"{bookName} loaded...");
            lam.Name = bookName;
            return lam;
        }
    }
}
