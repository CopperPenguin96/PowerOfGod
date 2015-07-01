package Bible;


import java.io.*;

public class Files
{
    private static String scripturePath = "kjv.xml";
    public static String GetScripturePath()
    {
        return scripturePath;
    }
    public static void SetScripturePath(String theDesiredPath, boolean IsAndroid, String IfisAndroidAppPackage, BibleVersion bVersion)
    {
        String fileName = "kjv";
        switch (bVersion)
        {
            case KJV:
                fileName = "kjv";
                break;
            case ESV:
                fileName = "esv";
                break;
            case NIV:
                fileName = "niv";
                break;
            case NLT:
                fileName = "nlt";
                break;
        }
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
