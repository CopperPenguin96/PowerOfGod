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

import Utilities.FileSystem;
import com.google.gson.*;
import com.google.gson.stream.JsonWriter;
import java.io.*;

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
        File fileObj = FileSystem.filesObj()[6];
        if (fileObj.exists())
        {
            try {
                Gson gson = new GsonBuilder().create();
                TransferObj f = gson.fromJson(FileSystem.ReadAllText(fileObj), TransferObj.class);
                BibPlansEnabled = f.bibplansenabled;
                BibleVersion = f.scriptver;
            } catch (IOException | JsonSyntaxException e) {
                e.printStackTrace();
            }
        }
        else
        {
            // Ignored
        }
    }
    public static void SaveToJson()
    {
        JsonWriter writer;
        try
        {
            writer = new JsonWriter(new FileWriter(FileSystem.filesObj()[6]));
            writer.beginObject();
            writer.name("bibplansenabled").value(false);
            writer.name("scriptver").value(BibleVersion);
            writer.endObject();
            writer.flush();
            writer.close();
            System.out.println(">>> Saved settings.");
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
        
    }
}

class TransferObj
{
    public Boolean bibplansenabled;
    public String scriptver;
}
