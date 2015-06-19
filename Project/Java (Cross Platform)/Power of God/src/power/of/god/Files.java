package power.of.god;


import java.io.File;
import java.util.ArrayList;

/**
 * Created by apotter96 on 4/8/2015.
 */
public class Files {
    private static String mainPath = "power.of.god/";
    private static String[] files = new String[] {
            mainPath,
            mainPath + "userInfo.json", //Old format file
            mainPath + "kjv.xml",
            mainPath + "userInfo.powerinfo" //New user format - still json
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
