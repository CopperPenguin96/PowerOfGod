package apdevelopment.powerofgod;

import android.os.Environment;

import java.io.File;
import java.util.ArrayList;

/**
 * Created by apotter96 on 4/8/2015.
 */
public class Files {
    private static String mainPath = Environment.getExternalStorageDirectory().getPath() +
            "/Android/data/apdevelopment.powerofgod/";
    private static String[] files = new String[] {
            mainPath,
            mainPath + "userInfo.json",
            mainPath + "scripture.xml"
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
