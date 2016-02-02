namespace Power_of_God_Lib.BibPlan
{
    public class VerseObj
    {
        public string Book;
        public int Chapter;
        public int Verse;

        public VerseObj()
        {
            // Empty for simple usage inefficient usage
        }

        public VerseObj(string book, int chap, int v)
        {
            Book = book;
            Chapter = chap;
            Verse = v;
        }
    }
}
