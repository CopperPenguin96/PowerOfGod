package apdevelopment.powerofgod.alpha;

import android.os.Environment;

import java.io.File;
import java.util.ArrayList;

/**
 * Created by apotter96 on 4/8/2015.
 */
public class Files {
    private final static String mainPath = "/sdcard/Android/data/apdevelopment.powerofgod/";
    private static final String[] files = new String[] {
            mainPath,
            mainPath + "userInfo.json", //Old format file
            mainPath + "KJV.xml",
            mainPath + "userInfo.powerinfo", //New user format - still json
            mainPath + "logins.txt",
            mainPath + "lastopen.txt",
            mainPath + "settings.json",
            mainPath + "ESV.xml", // Newer Bible versions added in Alpha 1.3
            mainPath + "NIV.xml",
            mainPath + "NLT.xml"
    };
    public static String[] filesStr()
    {
        if (!new File(files[0]).exists())
        {
            new File(files[0]).mkdirs(); // Making sure that the directory is ready for use
        }
        return files;
    }
    public static File[] filesObj()
    {
        File[] arrayHere = new File[filesStr().length];
        int loopCount = 0;
        for (String s:filesStr())
        {
            arrayHere[loopCount] = new File(s);
            loopCount++;
        }
        return arrayHere;
    }
}
