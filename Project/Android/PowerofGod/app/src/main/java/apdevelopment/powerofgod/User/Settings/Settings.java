package apdevelopment.powerofgod.User.Settings;

import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;

import apdevelopment.powerofgod.Files;

/**
 * Created by apotter96 on 7/2/2015.
 */
public class Settings {

    public static String defaultJsonSettings()
    {
        return "{\"bibplansenabled\":false,\"scriptver\":\"KJV\"}";
    }
    public static boolean BibPlansEnabled = false;
    public static String BibleVersion = "KJV";
    public static void LoadFromJson()
    {
        File fileObj = Files.filesObj()[6];
        if (fileObj.exists())
        {
            JSONParser parser = new JSONParser();
            try {
                Object obj = parser.parse(new FileReader(fileObj));
                JSONObject jsonObject = (JSONObject) obj;
                BibPlansEnabled = (boolean) jsonObject.get("bibplansenabled");
                BibleVersion = (String) jsonObject.get("scriptver");
            } catch (IOException e) {
                e.printStackTrace();
            } catch (ParseException e) {
                e.printStackTrace();
            }
        }
        else
        {

        }
    }
    public static void SaveToJson()
    {
        JSONObject obj = new JSONObject();
        obj.put("bibplansenabled", false);
        obj.put("scriptver",BibleVersion);
        try {
            File fileObj = Files.filesObj()[6];
            if (fileObj.exists()) fileObj.delete();
            fileObj.createNewFile();
            FileWriter file = new FileWriter(fileObj);
            file.write(obj.toJSONString());
            file.flush();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
