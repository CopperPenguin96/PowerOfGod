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

import com.google.gson.Gson;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;


/**
 *
 * @author apotter96
 */
public class Writer {
    public static String filePath;
    public static void SetPath(String s)
    {
        filePath = s;
    }
    public static void WriteBibPlan(BibPlan bPlan) throws IOException
    {
        BibPlan bP = bPlan;
        ArrayList<String> daysForChecks = new ArrayList<>();
        for (String s:bPlan.GetDays())
        {
            try
            {
                if (!s.equals("null"))
                {
                    daysForChecks.add(s);
                }
            }
            catch (NullPointerException ex)
            {
                //Don't add -> It was nullpointer
                System.out.println("Removed verse from being saved -> It was null");
            }
        }
        String[] theNewArray = new String[daysForChecks.size()];
        theNewArray = daysForChecks.toArray(theNewArray);
        bP.days = theNewArray;
        Gson gson = new Gson(); 
        String json = gson.toJson(bP);  
        File theFileDir = new File(filePath);
        if (!theFileDir.exists())
        {
            theFileDir.mkdirs();
        }
        File theFile = new File(filePath + bP.planName + ".bibplan");
        if (theFile.exists())
        {
            theFile.delete();
            WriteBibPlan(bP);
        }
        theFile.createNewFile();
        FileWriter fWriter = new FileWriter(theFile);
        fWriter.write(json); 
        fWriter.flush();
        fWriter.close();
    }
}


