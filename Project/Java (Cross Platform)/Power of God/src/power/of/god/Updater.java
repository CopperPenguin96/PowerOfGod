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
package power.of.god;

import java.io.*;
import java.net.*;
import java.util.ArrayList;
import java.util.zip.*;
import javax.script.*;

/**
 *
 * @author apotter96
 */
public class Updater {
    private static String VersionPrefix = "Alpha";
    private static String[] CurrentVersion = new String[]
    {
        "1", "2","1", null
    };
    private static String TogetherNumbers()
    {
        int VersionPrefixCount = VersionPrefix.length();
        return LatestStable().substring(VersionPrefixCount + 1);
    }
    public static String LatestStable()
    {
        String returnValue = VersionPrefix + " " + CurrentVersion[0] + "." + 
                CurrentVersion[1];
        if (CurrentVersion[2] != null)
        {
            returnValue += "." + CurrentVersion[2];
            if (CurrentVersion[3] != null)
            {
                returnValue += "." + CurrentVersion[3];
            }
        }
        return returnValue;
    }
    private static int CurrentPrefixInt()
    {
        if (VersionPrefix.equals("Alpha")) return 0;
        else if (VersionPrefix.equals("Beta")) return 1;
        else return 2;
    }
    public static String ServerResponse = "Nothing Yet";
    public static String UpdateNotice() throws ScriptException, IOException, NoSuchMethodException
    {
        // create a script engine manager
        ScriptEngineManager factory = new ScriptEngineManager();
        // create a JavaScript engine
        ScriptEngine engine = factory.getEngineByName("JavaScript");
        // evaluate JavaScript code from String
        engine.eval(getUrlSource("http://godispower.us/Application/Updates.js"));
        // javax.script.Invocable is an optional interface.
        // Check whether your script engine implements or not!
        // Note that the JavaScript engine implements Invocable interface.
        Invocable inv = (Invocable) engine;
        String returnValue;
        
        returnValue = (String)inv.invokeFunction("VersionUpdateNotice", CurrentPrefixInt(), CurrentVersion);
        ServerResponse = returnValue;
        switch (returnValue) {
            case "Updated":
                return "You are currently updated to the most recent version";
            case "Outdated":
                return "You do not have the most recent version. You should consider " +
                        "updating to " + (String) inv.invokeFunction("GetLatestStable", "Script");
            default:
                return "You are using an unsupported version of Power of God. Please consider " +
                        "using the current version, " + (String)inv.invokeFunction("GetLatestStable", "Script") +
                        ", because your version could not be unstable. (Response from " +
                        "server: " + returnValue + ")";
        }
    }
    private static String getUrlSource(String urlF) throws IOException {
        URL url = new URL(urlF);
        URLConnection urlCon = url.openConnection();
        BufferedReader in = null;

        if (urlCon.getHeaderField("Content-Encoding") != null
                && urlCon.getHeaderField("Content-Encoding").equals("gzip")) {
            in = new BufferedReader(new InputStreamReader(new GZIPInputStream(
                    urlCon.getInputStream())));
        } else {
            in = new BufferedReader(new InputStreamReader(
                    urlCon.getInputStream()));
        }

        String inputLine;
        StringBuilder sb = new StringBuilder();
        ArrayList<String> theList = new ArrayList<>();
        while ((inputLine = in.readLine()) != null)
            theList.add(inputLine + "\n");
        in.close();
        String[] stockArr = new String[theList.size()];
        stockArr = theList.toArray(stockArr);
        for(String s : stockArr)
        {
            sb.append(s);
        }
        return sb.toString();
    }
}
