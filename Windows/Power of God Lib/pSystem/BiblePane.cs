using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetBible.Books;
using Power_of_God_Lib.BibPlan;

namespace Power_of_God_Lib.pSystem
{
    public partial class BiblePane : UserControl
    {
        public BiblePane()
        {
            InitializeComponent();
        }
        

        /// <summary>
        /// Sets the scripture. to be displayed. Needs to be within the same chapter
        /// </summary>
        /// <param name="v1">The starting verse</param>
        /// <param name="v2">The ending verse</param>
        public void SetScripture(VerseObj v1, VerseObj v2)
        {
            var fullText = "";
            var book = new Book();
            var alreadyShownBook = false;
            foreach (var b in Bible.AllBooks().Where(b => b.Name == v1.Book))
            {
                book = b;
            }
            for (var start = v1.Verse; start <= v2.Verse; start++)
            {
                if (!alreadyShownBook)
                {
                    if (v1.Chapter == 1)
                    {
                        fullText += "---" + v1.Book + "---";
                    }
                    alreadyShownBook = true;
                }
                if (start == 1)
                {
                    fullText += "\n-> Chapter " + v1.Chapter + " <-";
                }
                var v_text = book.ReadPlainVerse(v1.Chapter, start);
                fullText += "\n" + start + " " + v_text;
            }
            lblContent.Text = fullText;
            
        }
    }
}
