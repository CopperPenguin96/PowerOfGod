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

import java.util.ArrayList;

/**
 *
 * @author apotter96
 */
public class BibPlan {
    public String Name;
    public String Id;
    public ArrayList<ArrayList<VerseObj>> VerseList;
    public String VerseAuthor;
    
    public BibPlan(String name, String id, ArrayList<ArrayList<VerseObj>> verses, String verseauthor, Boolean isCreator) throws Exception
    {
        Name = name;
        Id = id;
        if (!isCreator)
        {
            if (!ValidateId()) throw new Exception("The Bible Plan ID could not be validated. Possible duplicate?");
        }
        VerseList = verses;
        VerseAuthor = verseauthor;
    }
    
    private Boolean ValidateId()
    {
        return true; // Method not used yet. 
    }
}
