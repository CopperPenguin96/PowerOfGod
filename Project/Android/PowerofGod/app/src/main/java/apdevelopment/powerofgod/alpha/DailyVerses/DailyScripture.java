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
package apdevelopment.powerofgod.alpha.DailyVerses;

import android.app.AlertDialog;
import android.os.Looper;
import android.webkit.WebView;

import Bible.Bible;
import Bible.BibleVersion;
import Books.Book;
import apdevelopment.powerofgod.alpha.Files;
import apdevelopment.powerofgod.alpha.User.Settings.Settings;

import java.io.*;
import java.net.*;
import java.text.*;
import java.util.*;
import java.util.logging.*;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.entity.BufferedHttpEntity;
import org.apache.http.impl.client.DefaultHttpClient;
import org.joda.time.LocalDateTime;
import org.joda.time.format.DateTimeFormatter;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;

/**
 *
 * @author apotter96
 */
public class DailyScripture {
    private static String dayPath = "/sdcard/Android/data/apdevelopment.powerofgod/Verses/";
    public static String DateString()
    {
        LocalDateTime ldt = LocalDateTime.now();
        String x = ldt.toString("MM-dd-yyyy");
        return x;
    }
    private static void WriteDay()
    {
        File f = new File(dayPath + DateString() + ".txt");
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
        for (Book b: Bible.AllBooks())
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
    static String finalReturn = "";
    private static String finalStr()
    {
        return finalReturn;
    }
    private static void setStr(String s)
    {
        finalReturn = s;
    }

    static ArrayList<String> fileLine = new ArrayList<>();
    static ArrayList<String> fileLines() {
        return fileLine;
    }

    public static String GetDailyScripture() throws DailyScriptureReadException
    {
        final ArrayList<String> fileLines = new ArrayList<>();
        try {
            Thread t = new Thread(new Runnable() {
                @Override
                public void run() {
                    Looper.prepare();
                    URL url = null;
                    try {
                        DefaultHttpClient httpclient = new DefaultHttpClient();
                        HttpGet httppost = new HttpGet("http://godispower.us/DailyVerses/dv" + GetDay() + ".txt");
                        HttpResponse response = httpclient.execute(httppost);
                        HttpEntity ht = response.getEntity();

                        BufferedHttpEntity buf = new BufferedHttpEntity(ht);

                        InputStream is = buf.getContent();


                        BufferedReader r = new BufferedReader(new InputStreamReader(is));

                        StringBuilder total = new StringBuilder();
                        String line;
                        while ((line = r.readLine()) != null) {
                            fileLines().add(line);
                        }
                        String finalString = "Today's verse: ";
                        for (String files:fileLines())
                        {                       //01234567
                            if (files.startsWith("Verse"))
                            {
                                finalString += "<b>" + parseJson(files.substring(8)) + "</b><br>";
                            }
                        }
                        setStr(finalString);
                        Book.DSFinished = true;
                    } catch (Exception e) {
                        e.printStackTrace();
                        setStr(":( Couldn't read scripture");
                    }
                }
            });
            t.start();
            while (!Book.DSFinished)
            {
                System.out.println("Waiting...");
            }
            return finalStr() + fileLines().get(0);
        } catch(Exception ex) {
            throw new DailyScriptureReadException(ex);
        }
    }
}
