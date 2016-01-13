/*
 * The MIT License
 *
 * Copyright 2016 apotter96.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
package power.of.god.BibPlans;

import Books.Book;
import javax.swing.JOptionPane;

/**
 *
 * @author apotter96
 */
public class PatchClass {
    public static String GetVerse(VerseObj v1Obj, VerseObj v2Obj)
    {
        String book1Name = v1Obj.Book;
        int chapter1 = v1Obj.Chapter;
        int verse1 = v1Obj.Verse;
        String book2Name = v2Obj.Book;
        int chapter2 = v2Obj.Chapter;
        int verse2 = v2Obj.Verse;
        String verseStartString = book1Name + " " + chapter1 + ":" + verse1;
        String verseEndString = book2Name + " " + chapter2 + ":" + verse2;
        int book1Int = Parser.GetBookIndex(book1Name);
        int book2Int = Parser.GetBookIndex(book2Name);
        Book _selectedBookStart = Parser.GetBook(book1Name);
        Book _selectedBookEnd = Parser.GetBook(book2Name);
        int maxVerses1 = _numVerseStart.Maximum;

	if (book1Int > book2Int)
        {
            JOptionPane.showConfirmDialog(null, "Selected Start Verse cannot be before Selected End Verse");
            return null;
        }
		else if ((book2Int - book1Int) > 1)
		{
                    JOptionPane.showConfirmDialog(null, "Sorry, there cannot be that big of gap between books. Too many verses!");
                    return null;
		}
		else
		{
                    if (book1Int == book2Int)
                    {
			if (chapter1 > chapter2)
                        {
                            JOptionPane.showConfirmDialog(null, "Selected Start Verse cannot be before Selected End Verse");
                            return null;
			}
			else
			{
                            if (chapter1 == chapter2)
                            {
				if (verse1 > verse2)
				{
                                    JOptionPane.showConfirmDialog(null, "Selected Start Verse cannot be before Selected End Verse");
                                    return null;
				}
                            }
			}
                    }
		}
		// Should only reach this point if the verses selected for a day are OK
		String strContent = verseStartString + " - " + verseEndString + " (KJV) - ";
		if (book1Int == book2Int) // Books are the same
		{
                    if (chapter1 == chapter2)
                    {
			for (int x = verse1; x <= verse2; x++)
			{
                            strContent += _selectedBookStart.ReadPlainVerse(_numChapterStart.Value, x) + " ";
				}
			}
			else if (_numChapterStart.Value < _numChapterEnd.Value)
			{
				Object y = _numChapterEnd.Value - _numChapterStart.Value;
				for (Object z = 0; z <= y; z++)
				{
//VB TO JAVA CONVERTER NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to Java 'if-else' logic:
//					Select Case z
//ORIGINAL LINE: Case 0
					if (z == 0)
					{
						for (Object x = _numVerseStart.Value; x <= maxVerses1; x++)
						{
							strContent += _selectedBookStart.ReadPlainVerse(_numChapterStart.Value, x) + " ";
						}
					}
//ORIGINAL LINE: Case _numChapterEnd.Value
					else if (z == _numChapterEnd.Value)
					{
						for (Object x = 1; x <= _numVerseEnd.Value; x++)
						{
							strContent += _selectedBookStart.ReadPlainVerse(_numChapterEnd.Value, x) + " ";
						}
					}
//ORIGINAL LINE: Case Else
					else
					{
						if ((_numChapterEnd.Value - _numChapterStart.Value) > 1)
						{
							for (Object x = 1; x <= _selectedBookStart.VerseCount(y + z); x++)
							{
								strContent += _selectedBookStart.ReadPlainVerse(_numChapterEnd.Value, x) + " ";
							}
						}
						else
						{
							for (Object x = 1; x <= _numVerseEnd.Value; x++)
							{
								strContent += _selectedBookStart.ReadPlainVerse(_numChapterEnd.Value, x) + " ";
							}
						}
					}
				}
			}
		}
		else if (book2Int > book1Int)
		{
			java.util.ArrayList<Book> bookList = new java.util.ArrayList<Book>();
			for (Object a = book1Int; a <= book2Int; a++)
			{
				bookList.add(Bible.AllBooks().ElementAt(a));
			}
			if ((book2Int - book1Int) == 1)
			{
				for (Object a = _numChapterStart.Value; a <= bookList.ElementAt(0).ChapterCount; a++)
				{
//VB TO JAVA CONVERTER NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to Java 'if-else' logic:
//					Select Case a
//ORIGINAL LINE: Case _numChapterStart.Value
					if (a == _numChapterStart.Value)
					{
						for (Object x = _numVerseStart.Value; x <= bookList.ElementAt(0).VerseCount(a); x++)
						{
							strContent += bookList.ElementAt(0).ReadPlainVerse(a, x) + " ";
						}
					}
//ORIGINAL LINE: Case Else
					else
					{
						for (Object x = 1; x <= bookList.ElementAt(0).VerseCount(a); x++)
						{
							strContent += bookList.ElementAt(0).ReadPlainVerse(a, x) + " ";
						}
					}
				}
				for (Object a = 1; a <= _numChapterEnd.Value; a++)
				{
//VB TO JAVA CONVERTER NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to Java 'if-else' logic:
//					Select Case a
//ORIGINAL LINE: Case _numChapterEnd.Value
					if (a == _numChapterEnd.Value)
					{
						for (Object x = 1; x <= _numVerseEnd.Value; x++)
						{
							strContent += bookList.ElementAt(1).ReadPlainVerse(a, x) + " ";
						}
					}
//ORIGINAL LINE: Case Else
					else
					{
						for (Object x = 1; x <= bookList.ElementAt(1).VerseCount(a); x++)
						{
							strContent += bookList.ElementAt(1).ReadPlainVerse(a, x) + " ";
						}
					}
				}
			}
		}
    }
    
}
