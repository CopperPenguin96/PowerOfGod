package Bible;


import java.io.*;

public class Files
{
    private static String scripturePath = "kjv.xml";
    public static String GetScripturePath()
    {
        return scripturePath;
    }
    public static void SetScripturePath(String theDesiredPath, boolean IsAndroid, String IfisAndroidAppPackage)
    {
        if (IsAndroid)
        {
            scripturePath = "/sdcard/Android/data/" + IfisAndroidAppPackage + "/" + 
                    theDesiredPath + "/kjv.xml";
        }
        else
        {
            scripturePath = theDesiredPath + "kjv.xml";
        }
    }
}
