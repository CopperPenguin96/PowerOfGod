using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBible.Bible
{
    // 0 - 38 = Old Testament
    // 39 - 65 = New Testament
    public enum Testament { New, Old }

    public struct Chapter
    {
        public List<string> Verses;
    }
    public enum BookList
    {
        Genesis, Exodus, Leviticus, Numbers, Deuteronomy,
        Joshua, Judges, Ruth, Samuel1, Samuel2, Kings1, Kings2,
        Chronicles1, Chronicles2, Ezra, Nehemiah, Esther, Job,
        Psalms, Proverbs, Ecclesiastes, SongofSolomon,
        Isaiah, Jeremiah, Lamentations, Ezekiel, Daniel,
        Hosea, Joel, Amos, Obadiah, Jonah, Micah, Nahum,
        Habakkuk, Zephaniah, Haggai, Zechariah, Malachi,
        
        Matthew, Mark, Luke, John, Acts, Romans, Corinthians1,
        Corinthians2, Galatians, Ephesians, Philippians,
        Colossians, Thessalonians1, Thessalonians2, Timothy1,
        Timothy2, Titus, Philemon, Hebrews, James, Peter1,
        Peter2, John1, John2, John3, Jude, Revelation
    }

    public class Book
    {
        public Book(int _id)
        {
            Id = _id;
        }
        public int Id { get; set; }
        private string nameVal = string.Empty;
        public string Name
        {
            get
            {
                return nameVal == string.Empty ? ((BookList)Id).ToString() : nameVal;
            }
            set
            {
                nameVal = value;
            }
        }

        public Testament Testament
        {
            get
            {
                if (Id > 0 && Id < 39) return Testament.Old;
                if (Id > 38 && Id < 66) return Testament.New;
                return (Testament) 2;
            }
        }

        internal List<Chapter> Chapters = new List<Chapter>();

        public string ReadChapter(int chapter, bool includeVerseNumbers)
        {
            List<string> verses = new List<string>();
            for (int x = 1; x <= Chapters.Count; x++)
            {
                if (x == chapter)
                {
                    Chapter chap = Chapters[x - 1];
                    int loopCount = 0;
                    foreach (string verse in chap.Verses)
                    {
                        if (loopCount > 0)
                        {
                            verses.Add((includeVerseNumbers ? loopCount + " " : "") + verse + " ");
                        }

                        loopCount++;
                    }
                }
            }
            return verses.Aggregate("", (current, v) => current + v);
        }

        public string ReadVerse(int chapter, int verse)
        {
            Chapter chap = Chapters[chapter - 1];
            return verse == chap.Verses.Count ? 
                Chapters[chapter - 1].Verses[verse - 1] : 
                Chapters[chapter - 1].Verses[verse];
        }

        public string ReadFormattedVerse(int chapter, int verse)
        {
            return $"{Name} {chapter}:{verse} ({(BibleReader.Version == string.Empty ? "" : BibleReader.Version)}) - \"{ReadVerse(chapter, verse)}\"";
        }

        public string ReadMultipleVerses(int chapter1, int verse1, int chapter2, int verse2, bool includeVerseNumbers)
        {
            if (chapter1 > chapter2) throw new ArgumentException("chapter1 > chapter2");
            if (chapter1 == chapter2)
            {
                if (verse1 > verse2) throw new ArgumentException("chapter 1 == chapter 2; verse 1 > verse2");
            }

            List<Chapter> chapterList = new List<Chapter>();
            for (int x = chapter1; x <= chapter2; x++)
            {
                chapterList.Add(Chapters[x]);
            }
            string fullSet = "";
            int loopChap = chapter1 - 1;
            foreach (Chapter chap in chapterList)
            {
                loopChap++;
                List<string> verses = new List<string>();
                int loopCount = 0;
                if (loopChap == chapter1)
                {
                    loopCount = verse1;
                }
                foreach (string verse in chap.Verses)
                {
                    if (loopCount > 0)
                    {
                        if (loopChap == chapter2)
                        {
                            if (loopCount > verse2) continue;
                        }
                        if (loopCount > Chapters[loopCount].Verses.Count - 1) continue;
                        string partial = ReadVerse(loopChap, loopCount);
                        string chapz = "";
                        if (loopCount == 1)
                        {
                            chapz = "Chapter " + loopChap + " ";
                        }
                        else
                        {
                            if (includeVerseNumbers) chapz = loopCount + " ";
                        }
                        verses.Add((includeVerseNumbers ? chapz : "") + partial + " ");
                    }
                    loopCount++;
                }
                fullSet += verses.Aggregate("", (current, v) => current + v);

            }
            return fullSet;
        }
    }
}
