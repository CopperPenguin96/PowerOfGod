using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using BibPlans;
using Power_of_God_Lib.NetBible;
using Power_of_God_Lib.NetBible.Books;
using Power_of_God_Lib.pSystem;

namespace Power_of_God_Lib.BibPlan
{
    public class Parser
    {
        public static ObservableCollection<string> PlanDays = new ObservableCollection<string>();
        /// <summary>
        /// Returns the html of the Bible Plan 
        /// </summary>
        /// <param name="bibplanFileName">The file path and name</param>
        /// <param name="day">The day selected. Note that variable day is 0 based.</param>
        /// <returns></returns>
        public static string HtmlText(string bibplanFileName, int day)
        {
            var bibPlan = BibPlanParser.BiblicalPlan(File.ReadAllText(bibplanFileName));
            var html = "<html><head><title>(BiblePlan) " + bibPlan.Name + "</title></head>" +
                            "<body>Today's Reading: <b>";
            var vs = bibPlan.VerseList;
            var v1 = vs.ElementAt(day).ElementAt(0);
            var v2 = vs.ElementAt(day).ElementAt(1);
            html += v1.Book + " " + v1.Chapter + ":" + v1.Verse + " to " +
                v2.Book + " " + v2.Chapter + ":" + v2.Verse + "(" + Settings.UserSettings.scriptver + ")</b><br><br>" +
                Body(ToVerseObj(v1), ToVerseObj(v2));
             
            return html;
        }

        private static VerseObj ToVerseObj(VerseObj v)
        {
            return new VerseObj
            {
                Book = v.Book,
                Chapter = v.Chapter,
                Verse = v.Verse
            };
        }
        private static int GetBookIndex(string nameStr)
        {
            var loopCount = 0;
            foreach (var b in Bible.AllBooks())
            {
                if (b.Name == nameStr)
                {
                    return loopCount;
                }
                loopCount += 1;
            }
            return -1;
        }

        private static Book GetBook(string n)
        {
            return Bible.AllBooks().FirstOrDefault(b => b.Name == n);
        }

        private static string Body(VerseObj v1, VerseObj v2)
        {
            
            return new PatchClass().GetVerse(
                new VerseObj
                {
                    Book = v1.Book,
                    Chapter = v1.Chapter,
                    Verse = v1.Verse
                },
                new VerseObj
                {
                    Book = v2.Book,
                    Chapter = v2.Chapter,
                    Verse = v2.Verse
                }
            );
        }
    }
}
