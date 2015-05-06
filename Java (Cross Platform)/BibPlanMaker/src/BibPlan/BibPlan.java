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

import java.util.ArrayList;

/**
 *
 * @author apotter96
 */
public final class BibPlan {
    public BibPlan(String name, String[] daysA, String author)
    {
        this.planName = name;
        this.days = daysA;
        this.planauthor = author;
    }

    public String planName;
    public String[] days;
    public String planauthor;
    public String[] GetDays()
    {
        return days;
    }
    public String[] GetDaysX()
    {
        ArrayList<String> aListString = new ArrayList<>();
        for (String s:days)
        {
            if (!s.equals("null"))
            {
                aListString.add(s);
            }
        }
        String[] xMe = new String[aListString.size() - 1];
        return aListString.toArray(xMe);
    }
    public int GetPlanDayCount()
    {
        return days.length + 1;
    }

    public String ReadVerseFromDay(int dayCount)
    {
        int newCount = dayCount - 1;
        String todayVerse = days[newCount];
        return null;
    }
}
