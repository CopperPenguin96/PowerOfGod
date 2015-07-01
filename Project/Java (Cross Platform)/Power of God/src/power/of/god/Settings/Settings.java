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
package power.of.god.Settings;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;
import power.of.god.AppFiles;
import static power.of.god.User.UserInfo.CreateObject;

/**
 *
 * @author apotter96
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
        File fileObj = AppFiles.filesObj()[6];
        if (fileObj.exists())
        {
            JSONParser parser = new JSONParser();
            try {
                Object obj = parser.parse(new FileReader(fileObj));
                JSONObject jsonObject = (JSONObject) obj;
                BibPlansEnabled = (boolean) jsonObject.get("bibplansenabled");
                BibleVersion = (String) jsonObject.get("scriptver");
            } catch (FileNotFoundException e) {
                e.printStackTrace();
            } catch (IOException e) {
                e.printStackTrace();
            } catch (ParseException e) {
                e.printStackTrace();
            }
        }
        else
        {
            JSONParser parser = new JSONParser();
        }
    }
    public static void SaveToJson()
    {
        JSONObject obj = new JSONObject();
	obj.put("bibplansenabled", false);
	obj.put("scriptver", "KJV");
        try {
            File fileObj = AppFiles.filesObj()[6];
            if (fileObj.exists()) fileObj.delete();
            fileObj.createNewFile();
            try (FileWriter file = new FileWriter(fileObj)) {
                file.write(obj.toJSONString());
                file.flush();
            }
	} catch (IOException e) {
            e.printStackTrace();
	}
    }
}
