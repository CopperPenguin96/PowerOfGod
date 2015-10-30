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

import Bible.BibleVersion;
import Bible.Files;
import Books.Book;
import java.io.*;
import java.net.*;
import java.text.*;
import java.time.*;
import java.util.*;
import java.util.logging.*;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import power.of.god.Settings.Settings;

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
    // Scripture -> Stopped at verse 148 used
    // Last # on official list: 211 (http://www.topverses.com/Bible)
    private static String parseJson(String json) throws org.json.simple.parser.ParseException
    {
        JSONParser jP = new JSONParser();
        Object obj = jP.parse(json);
        JSONObject jsonObject = (JSONObject) obj;
        Book foundBook = new Book();
        for (Book b: Bible.Bible.AllBooks())
        {
            if (b.getName().equalsIgnoreCase((String)jsonObject.get("Book")))
            {
                foundBook = b;
            }
        }
        Long chap = (Long) jsonObject.get("Chapter");
        Long verse = (Long) jsonObject.get("Verse");
        return foundBook.readFormattedVerse(chap.intValue(), verse.intValue());
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
