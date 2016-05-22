using System;
using System.Linq;
using System.Windows.Forms;
using Power_of_God_Lib.NetBible;
using Power_of_God_Lib.NetBible.Books;
using Power_of_God_Lib.NetBible.Books.New_Testament;
using Power_of_God_Lib.pSystem;

namespace Power_of_God_Lib.GUI
{
    public partial class BibleReaderForm : Form
    {
        public BibleReaderForm()
        {
            InitializeComponent();
            foreach (var b in Bible.AllBooks())
            {
                cboBook.Items.Add(b.Name);
            }
            cboBook.SelectedItem = "2 Timothy";
            numChapter.Maximum = new Timothy2().ChapterCount;
            numChapter.Value = 2;
        }

        private void BibleReaderForm_Load(object sender, EventArgs e)
        {
            VerseObj v1 = new VerseObj
            {
                Book = "2 Timothy",
                Chapter = 2,
                Verse = 1
            };
            VerseObj v2 = new VerseObj
            {
                Book = "2 Timothy",
                Chapter = 2,
                Verse = new Timothy2().VerseCount(2)
            };
            biblePane1.SetScripture(v1, v2);
            version.Text = "(" + Settings.UserSettings.scriptver + ")";
        }

        private void biblePane1_Load(object sender, EventArgs e)
        {

        }

        private Book _book = new Book();
        private void cboBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var b in Bible.AllBooks().Where(b => b.Name == cboBook.Text))
            {
                _book = b;
            }
            numChapter.Minimum = 1;
            numChapter.Maximum = _book.ChapterCount;
        }

        private void numChapter_ValueChanged(object sender, EventArgs e)
        {
            var v1 = new VerseObj
            {
                Book = cboBook.Text,
                Chapter = (int) numChapter.Value,
                Verse = 1
            };
            var v2 = new VerseObj
            {
                Book = v1.Book,
                Chapter = v1.Chapter,
                Verse = _book.VerseCount(v1.Chapter)
            };
            biblePane1.SetScripture(v1, v2);
        }
    }
}

