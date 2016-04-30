/*
 * The MIT License
 *
 * Copyright 2015-16 apotter96.
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
package BibPlan;

import NetBible.Bible.Books.Bible;
import NetBible.Bible.Books.Book;
import java.util.ArrayList;
import javax.swing.JOptionPane;

/**
 *
 * @author apotter96
 */
public class PatchClass
{
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
        int maxVerses1 = _selectedBookStart.verseCount(chapter1);

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
                    strContent += _selectedBookStart.readPlainVerse(chapter1, x) + " ";
                }
            }
            else if (chapter1 < chapter2)
            {
                int y = chapter2 - chapter1;
                for (int z = 0; z <= y; z++)
                {
                    if (z == 0)
                    {
                        for (int x = verse1; x <= maxVerses1; x++)
                        {
                            strContent += _selectedBookStart.readPlainVerse(chapter1, x) + " ";
                        }
                    }
                    else if (z == chapter2)
                    {
                        for (int x = 1; x <= verse2; x++)
                        {
                            strContent += _selectedBookStart.readPlainVerse(chapter2, x) + " ";
                        }
                    }
                    else
                    {
                        if ((chapter2 - chapter1) > 1)
                        {
                            for (int x = 1; x <= _selectedBookStart.verseCount(y + z); x++)
                            {
                                strContent += _selectedBookStart.readPlainVerse(chapter2, x) + " ";
                            }
                        }
                        else
                        {
                            for (int x = 1; x <= verse2; x++)
                            {
                                strContent += _selectedBookStart.readPlainVerse(chapter2, x) + " ";
                            }
                        }
                    }
                }
            }
        }
        else if (book2Int > book1Int)
        {
            ArrayList<Book> bookList = new ArrayList<>();
            for (int a = book1Int; a <= book2Int; a++)
            {
                bookList.add(Bible.AllBooks()[a]);
            }
            if ((book2Int - book1Int) == 1)
            {
                for (int a = chapter1; a <= bookList.get(0).getChapterCount(); a++)
                {
                    if (a == chapter1)
                    {
                        for (int x = verse1; x <= bookList.get(0).verseCount(a); x++)
                        {
                            strContent += bookList.get(0).readPlainVerse(a, x) + " ";
                        }
                    }
                    else
                    {
                        for (int x = 1; x <= bookList.get(0).verseCount(a); x++)
                        {
                            strContent += bookList.get(0).readPlainVerse(a, x) + " ";
                        }
                    }
                }
                for (int a = 1; a <= chapter2; a++)
                {
                    if (a == chapter2)
                    {
                        for (int x = 1; x <= verse2; x++)
                        {
                            strContent += bookList.get(1).readPlainVerse(a, x) + " ";
                        }
                    }
                    else
                    {
                        for (int x = 1; x <= bookList.get(1).verseCount(a); x++)
                        {
                            strContent += bookList.get(1).readPlainVerse(a, x) + " ";
                        }
                    }
                }
            }
        }
        return strContent;
    }

}
