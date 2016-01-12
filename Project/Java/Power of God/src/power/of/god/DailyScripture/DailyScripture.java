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
package power.of.god.DailyScripture;

import Bible.*;
import Books.*;
import com.google.gson.Gson;
import java.io.*;
import java.net.*;
import java.text.*;
import java.time.*;
import java.util.*;
import java.util.logging.*;
import power.of.god.Settings.*;

/**
 *
 * @author apotter96
 */
public class DailyScripture {
    private static String dayPath = "Verses/";
    private static String DateString()
    {
        LocalDateTime ldt = LocalDateTime.now();
        return new SimpleDateFormat("MM-dd-yyyy").format(Date.from(ldt.atZone(ZoneId.systemDefault()).toInstant()));
    }
    private static void WriteDay()
    {
        File f = new File("Verses/" + DateString() + ".txt");
        try {
            f.createNewFile();
        } catch (IOException ex) {
            Logger.getLogger(DailyScripture.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    private static int GetDay()
    {
        
        boolean alreadySaw = false;
        File f = new File(dayPath);
        if (!f.exists())
        {
            f.mkdirs();
            WriteDay();
            return 1;
        }
        for (File file: f.listFiles())
        {
            if (file.getName().contains(DateString()))
            {
                alreadySaw = true;
            }
        }
        int trueVar = 1;
        if (alreadySaw) trueVar = 0;
        else 
        {
            trueVar = 1;
            WriteDay();
        }
        return f.listFiles().length;
    }
    private static String parseJson(String json)
    {
        TransferObjVerses x = new Gson().fromJson(json, TransferObjVerses.class);
        Book foundBook = new Book();
        for (Book b: Bible.AllBooks())
        {
            if (b.getName().equalsIgnoreCase(x.Book))
            {
                foundBook = b;
            }
        }
        return foundBook.readFormattedVerse(x.Chapter, x.Verse);
    }
    private static BibleVersion bv()
    {
        switch (Settings.BibleVersion)
        {
            case "KJV":
                return BibleVersion.KJV;
            case "NIV":
                return BibleVersion.NIV;
            case "NLT":
                return BibleVersion.NLT;
            case "ESV":
                return BibleVersion.ESV;
            default:
                return BibleVersion.KJV;
        }
    }
    public static String GetDailyScripture() throws DailyScriptureReadException
    {
        try {
            Files.SetScripturePath("power.of.god/", false, dayPath, bv());
            URL url = new URL("http://godispower.us/DailyVerses/dv" + GetDay() + ".txt");
            Scanner s = new Scanner(url.openStream());
            ArrayList<String> fileLines = new ArrayList<>();
            while (s.hasNextLine())
            {
                fileLines.add(s.nextLine());
            }
            String finalString = "Today's verse: ";
            for (String files:fileLines)
            {                       //01234567
                if (files.startsWith("Verse"))
                {
                    finalString += "<b>" + parseJson(files.substring(8)) + "</b><br>";
                }
            }
            return finalString + fileLines.get(0);
        } catch(Exception ex) {
            throw new DailyScriptureReadException(ex);
        }
    }
}

class TransferObjVerses
{
    public String Book;
    public int Chapter;
    public int Verse;
}
