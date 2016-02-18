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
package apdevelopment.powerofgod.alphaphase.BibPlans;


import com.google.gson.Gson;

import java.io.File;
import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;

import Books.Book;
import apdevelopment.powerofgod.alphaphase.Files;
import apdevelopment.powerofgod.alphaphase.User.Settings.Settings;

/**
 *
 * @author apotter96
 */
public class Parser {
    public static PowerList<String> PlanDays = new PowerList<>();

    public static String HtmlText(String bibPlanFileName, int day) throws IOException
    {
        BibPlan bibPlan = BibPlanParser.BiblicalPlan(Files.ReadAllText(new File(bibPlanFileName)));
        String html = "Today's Reading <b>";
        ArrayList<ArrayList<VerseObj>> vs = bibPlan.VerseList;
        VerseObj v1 = vs.get(day).get(0);
        VerseObj v2 = vs.get(day).get(1);
        html += v1.Book + " " + v1.Chapter + ":" + v1.Verse + " to " +
                v2.Book + " " + v2.Chapter + ":" + v2.Verse + " (" + Settings.BibleVersion + ")</b><br><br>" +
                Body(v1, v2);
        return html;
    }

    public static void UpdateList(String plan) throws IOException {
        String dirBase = "/sdcard/Android/data/apdevelopment.powerofgod/BibPlans/";
        if (plan.contains(dirBase))
        {
            dirBase = "";
        }
        File dirBaseObj = new File(dirBase);
        if (!dirBaseObj.exists())
        {
            dirBaseObj.mkdirs();
        }

        if (plan.substring(plan.lastIndexOf(".")).equals(".bibplan"))
        {
            File fileObj = new File(dirBase + plan);
            BibPlan bObj = BiblicalPlan(Files.ReadAllText(fileObj));
            String dir = dirBase + plan.replace(".bibplan", "") + "/";
            File dirObj = new File(dir);
            if (!dirObj.exists())
            {
                dirObj.mkdirs();
            }
            Date currentDate = new Date();
            int currentDay = dirObj.list().length;
            File cText = new File(dir + new SimpleDateFormat("dd.MM.yyyy").format(currentDate));
            for (int x = 0; x <= currentDay; x++)
            {
                try
                {
                    if (!dirObj.list()[x].contains(currentDate.toString()))
                    {
                        try
                        {
                            cText.createNewFile();
                        }
                        catch (Exception e)
                        {
                            e.printStackTrace();
                        }
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        ex.printStackTrace();
                        cText.createNewFile();
                    }
                    catch (Exception e4)
                    {
                        ex.printStackTrace();
                        e4.printStackTrace();
                    }
                }
            }
            Parser.PlanDays.clear();
            for (int xitem = 0; xitem <= dirObj.list().length; xitem++)
            {
                System.out.println("Day #" + xitem + 1);
                Parser.PlanDays.add("Day #" + xitem);
            }
            PlanFileName = "/sdcard/Android/data/apdevelopment.powerofgod/BibPlans/" + plan;
        }
    }
    public static String PlanFileName;
    public static BibPlan BiblicalPlan(String content)
    {
        return new Gson().fromJson(content, BibPlan.class);
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
