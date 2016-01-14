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
import java.io.File;
import java.io.IOException;
import java.util.*;
import power.of.god.*;
import power.of.god.Settings.*;

/**
 *
 * @author apotter96
 */
public class Parser {
    public static ArrayList<String> PlanDays = new ArrayList<>();
    public static String HtmlText(String bibPlanFileName, int day) throws IOException
    {
        BibPlan bibPlan = BibPlanParser.BiblicalPlan(AppFiles.ReadAllText(new File(bibPlanFileName)));
        String html = "<html><head><title>(Bible Plan) " + bibPlan.Name + "</title></head>" +
                "<body>Today's Reading <b>";
        ArrayList<ArrayList<VerseObj>> vs = bibPlan.VerseList;
        VerseObj v1 = vs.get(day).get(0);
        VerseObj v2 = vs.get(day).get(1);
        html += v1.Book + " " + v1.Chapter + ":" + v1.Verse + " to " +
                v2.Book + " " + v2.Chapter + ":" + v2.Verse + " (" + Settings.BibleVersion + ")</b><br><br>" +
                Body(v1, v2);
        return html;
    }
    
    public static int GetBookIndex(String nameStr)
    {
        int loopCount = 0;
        for (Book b: Bible.Bible.AllBooks())
        {
            if (b.getName().equals(nameStr))
            {
                return loopCount;
            }
            loopCount++;
        }
        return -1; // Failed
    }
    
    public static Book GetBook(String n)
    {
        return Bible.Bible.AllBooks()[GetBookIndex(n)]; // Functional programming not needed
    }
    
    private static String Body(VerseObj v1, VerseObj v2)
    {
        return PatchClass.GetVerse(v1, v2);
    }
}
