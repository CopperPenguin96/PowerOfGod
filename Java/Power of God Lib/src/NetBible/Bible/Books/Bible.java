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
package NetBible.Bible.Books;


import NetBible.Bible.Books.OldTestament.*;
import NetBible.Bible.Books.NewTestament.*;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collection;
import java.util.HashSet;

public class Bible
{       
        public static Book[] OldTestament = new Book[]{
            new Genesis(), new Exodus(), new Leviticus(), new Numbers(),
            new Dueteronomy(), new Joshua(), new Judges(), new Ruth(),
            new Samuel1(), new Samuel2(), new Kings1(), new Kings2(),
            new Chronicles1(), new Chronicles2(), new Ezra(), new Nehemiah(),
            new Esther(), new Job(), new Psalms(), new Proverbs(),
            new Ecclesiastes(), new SongOfSolomon(), new Isaiah(), new Jeremiah(),
            new Lamentations(), new Ezekiel(), new Daniel(), new Hosea(),
            new Joel(), new Amos(), new Obadiah(), new Jonah(),
            new Micah(), new Nahum(), new Habakkuk(), new Zephaniah(),
            new Haggai(), new Zechariah(), new Malachi()
        };
        public static Book[] NewTestament = new Book[]{
            new Matthew(), new Mark(), new Luke(), new John(),
            new Acts(), new Romans(), new Corinthians1(), new Corinthians2(),
            new Galatians(), new Ephesians(), new Philippians(), new Colossians(),
            new Thessalonians1(), new Thessalonians2(), new Timothy1(), new Timothy2(),
            new Titus(), new Philemon(), new Hebrews(), new James(),
            new Peter1(), new Peter2(), new John1(), new John2(),
            new John3(), new Jude(), new Revelation()
        };
        private static Collection<Book> ToCollection(Book[] Books)
        {
            return new HashSet<>(Arrays.asList(Books));
        }
    
        public static Book[] AllBooks()
        {
            Book[] theBible = new Book[66];
            ArrayList<Book> theBibleList = new ArrayList<>();
            theBibleList.addAll(ToCollection(OldTestament));
            theBibleList.addAll(ToCollection(NewTestament));
            return theBibleList.toArray(theBible);
        }
        
        public static String bookName(boolean IsKjv)
        {
            if (IsKjv) return "book";
            else return "b";
        }
        public static String chapterName(boolean IsKjv)
        {
            if (IsKjv) return "chapter";
            else return "c";
        }
        public static String verseName(boolean IsKjv)
        {
            if (IsKjv) return "verse";
            else return "v";
        }
        public static String nameName(boolean IsKjv)
        {
            if (IsKjv) return "name";
            else return "n";
        }
}

