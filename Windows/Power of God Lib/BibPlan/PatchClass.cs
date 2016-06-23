using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using Power_of_God_Lib.NetBible;
using Power_of_God_Lib.NetBible.Books;

namespace Power_of_God_Lib.BibPlan
{
    public class PatchClass
    {
        private static Book _selectedBookStart;
        private static Book _selectedBookEnd;

        private void cboBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            NumChapterStart.Value = 1;
            dynamic foundOne = false;
            // ReSharper disable once LoopCanBePartlyConvertedToQuery
            foreach (var b in Bible.AllBooks())
            {
                if (b.Name != CboBookStart.SelectedText || foundOne) continue;
                foundOne = true;
                _selectedBookStart = b;
            }
            NumChapterStart.Maximum = _selectedBookStart.ChapterCount;
        }

        private void _cboBookEnd_SelectedIndexChanged(object sender, EventArgs e)
        {
            NumChapterEnd.Value = 1;
            dynamic foundOne = false;
            // ReSharper disable once LoopCanBePartlyConvertedToQuery
            foreach (var b in Bible.AllBooks())
            {
                if (b.Name != CboBookEnd.SelectedText || foundOne) continue;
                foundOne = true;
                _selectedBookEnd = b;
            }
            NumChapterEnd.Maximum = _selectedBookEnd.ChapterCount;
        }

        private void numChapter_ValueChanged(object sender, EventArgs e)
        {
            _numVerseStart.Value = 1;
            try
            {
                _numVerseStart.Maximum = _selectedBookStart.VerseCount((int)NumChapterStart.Value);
            }
            catch (Exception)
            {
                // MsgBox("Unable to collect verse count. Please try again")
                // Ignored
            }
        }

        private void _numChapterEnd_ValueChanged(object sender, EventArgs e)
        {
            _numVerseEnd.Value = 1;
            try
            {
                _numVerseEnd.Maximum = _selectedBookEnd.VerseCount((int)NumChapterEnd.Value);
            }
            catch (Exception)
            {
                // MsgBox("Unable to collect verse count. Please try again")
                // Ignored
            }
        }
        private ComboBox _withEventsFieldCboBookStart = new ComboBox();
        private ComboBox CboBookStart
        {
            get { return _withEventsFieldCboBookStart; }
            // ReSharper disable once UnusedMember.Local
            set
            {
                if (_withEventsFieldCboBookStart != null)
                {
                    _withEventsFieldCboBookStart.SelectedIndexChanged -= cboBook_SelectedIndexChanged;
                }
                _withEventsFieldCboBookStart = value;
                if (_withEventsFieldCboBookStart != null)
                {
                    _withEventsFieldCboBookStart.SelectedIndexChanged += cboBook_SelectedIndexChanged;
                }
            }
        }
        private ComboBox _withEventsFieldCboBookEnd = new ComboBox();
        private ComboBox CboBookEnd
        {
            get { return _withEventsFieldCboBookEnd; }
            // ReSharper disable once UnusedMember.Local
            set
            {
                if (_withEventsFieldCboBookEnd != null)
                {
                    _withEventsFieldCboBookEnd.SelectedIndexChanged -= _cboBookEnd_SelectedIndexChanged;
                }
                _withEventsFieldCboBookEnd = value;
                if (_withEventsFieldCboBookEnd != null)
                {
                    _withEventsFieldCboBookEnd.SelectedIndexChanged += _cboBookEnd_SelectedIndexChanged;
                }
            }
        }
        private NumericUpDown _withEventsFieldNumChapterStart = new NumericUpDown();
        private NumericUpDown NumChapterStart
        {
            get { return _withEventsFieldNumChapterStart; }
            // ReSharper disable once UnusedMember.Local
            set
            {
                if (_withEventsFieldNumChapterStart != null)
                {
                    _withEventsFieldNumChapterStart.ValueChanged -= numChapter_ValueChanged;
                }
                _withEventsFieldNumChapterStart = value;
                if (_withEventsFieldNumChapterStart != null)
                {
                    _withEventsFieldNumChapterStart.ValueChanged += numChapter_ValueChanged;
                }
            }
        }
        private NumericUpDown _withEventsFieldNumChapterEnd = new NumericUpDown();
        private NumericUpDown NumChapterEnd
        {
            get { return _withEventsFieldNumChapterEnd; }
            // ReSharper disable once UnusedMember.Local
            set
            {
                if (_withEventsFieldNumChapterEnd != null)
                {
                    _withEventsFieldNumChapterEnd.ValueChanged -= _numChapterEnd_ValueChanged;
                }
                _withEventsFieldNumChapterEnd = value;
                if (_withEventsFieldNumChapterEnd != null)
                {
                    _withEventsFieldNumChapterEnd.ValueChanged += _numChapterEnd_ValueChanged;
                }
            }
        }
        private readonly NumericUpDown _numVerseStart = new NumericUpDown();
        private readonly NumericUpDown _numVerseEnd = new NumericUpDown();
        private static int GetBookIndex(string nameStr)
        {
            dynamic loopCount = 0;
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

        public void SetBooks(string b1, string b2)
        {
            foreach (var b in Bible.AllBooks().Where(b => b.Name == b1))
            {
                _selectedBookStart = b;
            }
            foreach (var b in Bible.AllBooks().Where(b => b.Name == b2))
            {
                _selectedBookEnd = b;
            }
        }

        public string GetVerse(VerseObj v1Obj, VerseObj v2Obj)
        {
            SetBooks(v1Obj.Book, v2Obj.Book);
            foreach (var bookItem in Bible.AllBooks())
            {
                CboBookStart.Items.Add(bookItem.Name);
                CboBookEnd.Items.Add(bookItem.Name);
            }
            CboBookStart.SelectedItem = v1Obj.Book;
            CboBookEnd.SelectedItem = v2Obj.Book;
            NumChapterStart.Value = v1Obj.Chapter;
            NumChapterEnd.Value = v2Obj.Chapter;
            _numVerseStart.Value = v1Obj.Verse;
            _numVerseEnd.Value = v2Obj.Verse;

            var verseStartString = CboBookStart.SelectedItem + " " + NumChapterStart.Value + ":" + _numVerseStart.Value;
            var verseEndString = CboBookEnd.SelectedItem + " " + NumChapterEnd.Value + ":" + _numVerseEnd.Value;

            // Dim v1 = v1Obj
            //Dim v2 = v2Obj
            //v1.Book = _cboBookStart.SelectedItem
            //v1.Chapter = _numChapterStart.Value
            //v1.Verse = _numVerseStart.Value
            //v2.Book = _cboBookEnd.SelectedItem
            //v2.Chapter = _numChapterEnd.Value
            //v2.Verse = _numVerseEnd.Value


            var book1Int = GetBookIndex(CboBookStart.SelectedText);
            var book2Int = GetBookIndex(CboBookEnd.SelectedText);
            var maxVerses1 = _numVerseStart.Maximum;

            if (book1Int > book2Int)
            {
                Interaction.MsgBox("Selected Start Verse cannot be before Selected End Verse");
                return null;
            }
            if ((book2Int - book1Int) > 1)
            {
                Interaction.MsgBox("Sorry, there cannot be that big of gap between books. Too many verses!");
                return null;
            }
            if (book1Int == book2Int)
            {
                if (NumChapterStart.Value > NumChapterEnd.Value)
                {
                    Interaction.MsgBox("Selected Start Verse cannot be before Selected End Verse");
                    return null;
                }
                if (NumChapterStart.Value == NumChapterEnd.Value)
                {
                    if (_numVerseStart.Value > _numVerseEnd.Value)
                    {
                        Interaction.MsgBox("Selected Start Verse cannot be before Selected End Verse");
                        return null;
                    }
                }
            }
            // Should only reach this point if the verses selected for a day are OK
            string strContent = verseStartString + " - " + verseEndString + " (KJV) - ";
            // Books are the same
            if (book1Int == book2Int)
            {
                if (NumChapterStart.Value == NumChapterEnd.Value)
                {
                    for (var x = _numVerseStart.Value; x <= _numVerseEnd.Value; x++)
                    {
                        strContent += _selectedBookStart.ReadPlainVerse((int)NumChapterStart.Value, (int)x) + " ";
                    }
                }
                else if (NumChapterStart.Value < NumChapterEnd.Value)
                {
                    dynamic y = NumChapterEnd.Value - NumChapterStart.Value;
                    for (var z = 0; z <= y; z++)
                    {
                        if (z == 0)
                        {
                            for (var x = _numVerseStart.Value; x <= maxVerses1; x++)
                            {
                                strContent += _selectedBookStart.ReadPlainVerse((int)NumChapterStart.Value, (int)x) + " ";
                            }
                        }
                        else if (z == NumChapterEnd.Value)
                        {
                            for (var x = 1; x <= _numVerseEnd.Value; x++)
                            {
                                strContent += _selectedBookStart.ReadPlainVerse((int) NumChapterEnd.Value, x) + " ";
                            }
                        }
                        else
                        {
                            if ((NumChapterEnd.Value - NumChapterStart.Value) > 1)
                            {
                                for (var x = 1; x <= _selectedBookStart.VerseCount(y + z); x++)
                                {
                                    strContent += _selectedBookStart.ReadPlainVerse((int)NumChapterEnd.Value, x) + " ";
                                }
                            }
                            else
                            {
                                for (var x = 1; x <= _numVerseEnd.Value; x++)
                                {
                                    strContent += _selectedBookStart.ReadPlainVerse((int)NumChapterEnd.Value, x) + " ";
                                }
                            }
                        }
                    }
                }
            }
            else if (book2Int > book1Int)
            {
                var bookList = new List<Book>();
                for (var a = book1Int; a <= book2Int; a++)
                {
                    bookList.Add(Bible.AllBooks().ElementAt(a));
                }
                if ((book2Int - book1Int) != 1) return strContent;
                for (var a = NumChapterStart.Value; a <= bookList.ElementAt(0).ChapterCount; a++)
                {
                    if (a == NumChapterStart.Value)
                    {
                        for (var x = _numVerseStart.Value; x <= bookList.ElementAt(0).VerseCount((int) a); x++)
                        {
                            strContent += bookList.ElementAt(0).ReadPlainVerse((int)a, (int)x) + " ";
                        }
                    }
                    else
                    {
                        for (var x = 1; x <= bookList.ElementAt(0).VerseCount((int)a); x++)
                        {
                            strContent += bookList.ElementAt(0).ReadPlainVerse((int)a, x) + " ";
                        }
                    }
                }
                for (var a = 1; a <= NumChapterEnd.Value; a++)
                {
                    if (a == NumChapterEnd.Value)
                    {
                        for (var x = 1; x <= _numVerseEnd.Value; x++)
                        {
                            strContent += bookList.ElementAt(1).ReadPlainVerse(a, x) + " ";
                        }
                    }
                    else
                    {
                        for (var x = 1; x <= bookList.ElementAt(1).VerseCount(a); x++)
                        {
                            strContent += bookList.ElementAt(1).ReadPlainVerse(a, x) + " ";
                        }
                    }
                }
            }
            return strContent;
        }
    }
}
