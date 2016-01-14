package Bible;


import java.io.*;

public class Files
{
    private static String scripturePath = "kjv.xml";
    public static String GetScripturePath()
    {
        return scripturePath;
    }
    public static String needVers;
    public static void SetScripturePath(String theDesiredPath, boolean IsAndroid, String IfisAndroidAppPackage, BibleVersion bVersion)
    {
        String fileName = "KJV";
        switch (bVersion)
        {
            case KJV:
                fileName = "KJV";
                break;
            case ESV:
                fileName = "ESV";
                break;
            case NIV:
                fileName = "NIV";
                break;
            case NLT:
                fileName = "NLT";
                break;
        }
        needVers = fileName;
        fileName += ".xml";
        if (IsAndroid)
        {
            scripturePath = "/sdcard/Android/data/" + IfisAndroidAppPackage + "/" + 
                    theDesiredPath + "/" + fileName;
        }
        else
        {
            scripturePath = theDesiredPath + fileName;
        }
    }
}