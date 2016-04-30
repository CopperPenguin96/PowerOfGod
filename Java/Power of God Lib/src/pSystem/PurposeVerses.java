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
package pSystem;

import pSystem.Settings;


/**
 *
 * @author apotter96
 */
public class PurposeVerses {
    public static String GetTimothyKjv()
    {
        return "2 Timtohy 3:16 (KJV) - \"All scripture is given by inspiration of God, and is profitable for doctrine, for reproof, for correction, for instruction in righteousness:\"";
    }
    public static String GetRomansKjv()
    {
        return "Romans 1:16 (KJV) - \"For I am not ashamed of the gospel of Christ: for it is the power of God unto salvation to every one that believeth; to the Jew first, and also to the Greek.\"";
    }
    
    public static String GetTimothyNiv()
    {
        return "2 Timothy 3:16 (NIV) - \"All Scripture is God-breathed and is useful for teaching, rebuking, correcting and training in righteousness,\"";
    }
    
    public static String GetRomansNiv()
    {
        return  "Romans 1:16 (NIV) - \"I am not ashamed of the gospel, because it is the power of God for the salvation of everyone who believes: first for the Jew, then for the Gentile.";
    }
    
    public static String GetTimothyEsv()
    {
        return "2 Timothy 3:16 (ESV) - \"All Scripture is breathed out by God and profitable for teaching, for reproof, for correction, and for training in righteousness,";
    }
    
    public static String GetRomansEsv()
    {
        return "Romans 1:16 (ESV) - \"For I am not ashamed of the gospel, for it is the power of God for salvation to everyone who believes, to the Jew first and also to the Greek.\"";
    }
    
    public static String GetTimothyNlt()
    {
        return "2 Timothy 3:16 (NLT) - \"All Scripture is inspired by God and is useful to teach us what is true and to make us realize what is wrong in our lives. It straightens us out and teaches us to do what is right.\"";
    }
    
    public static String GetRomansNlt()
    {
        return "Romans 1:16 (NLT) - \"For I am not ashamed of this Good News about Christ. It is the power of God at work, saving everyone who believes--Jews first and also Gentiles.\"";
    }
    
    public static String GetVerse(int verse)
    {
        switch (Settings.BibleVersion)
        {
            case "KJV":
                if (verse == 0) return GetTimothyKjv();
                else if (verse == 1) return GetRomansKjv();
            case "NIV":
                if (verse == 0) return GetTimothyNiv();
                else if (verse == 1) return GetRomansNiv();
            case "ESV":
                if (verse == 0) return GetTimothyEsv();
                else if (verse == 1) return GetRomansEsv();
            case "NLT":
                if (verse == 0) return GetTimothyNlt();
                else if (verse == 1) return GetRomansNlt();
        }
        return "Scripture Load Error.";
    }
}
