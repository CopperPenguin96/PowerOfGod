/*
 * The MIT License
 *
 * Copyright 2015 apotter96.
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

import BibPlan.Exceptions.*;
import Books.*;
import java.util.*;

/**
 *
 * @author apotter96
 */
public class BibPlan {
    public String Name;
    public int Length() throws PlanParseException
    {
        if (Books.size() != Chapters.size() || Books.size() != Verses.size() || Chapters.size() != Verses.size())
        {
            //We need to check the sizes. This is to protect against code errors
            throw new PlanParseException("Malformated Bible Plan: Days Mismatch");
        }
        return Books.size();
    }
    public ArrayList<Book> Books;
    public ArrayList<Integer> Chapters;
    public ArrayList<Integer> Verses;
    
    public static BibPlan CreateObj(String _name, ArrayList<Book> _books, ArrayList<Integer> _chapters, ArrayList<Integer> _verses)
    {
        BibPlan bPlan = new BibPlan();
        bPlan.Name = _name;
        bPlan.Books = _books;
        bPlan.Chapters = _chapters;
        bPlan.Verses = _verses;
        return bPlan;
    }
}
