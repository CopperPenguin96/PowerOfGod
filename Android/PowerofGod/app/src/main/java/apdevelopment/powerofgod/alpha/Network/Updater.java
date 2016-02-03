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
package apdevelopment.powerofgod.alpha.Network;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.URL;
import java.net.URLConnection;
import java.util.ArrayList;
import java.util.zip.GZIPInputStream;

/**
 *
 * @author apotter96
 */
public class Updater {
    public static String UpdateResult;
    private static final String VersionPrefix = "Alpha";
    private static final String[] CurrentVersion = new String[]
            {
                    "1", "5", null, null
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
        switch (VersionPrefix)
        {
            case "Alpha":
                return 0;
            case "Beta":
                return 1;
            default:
                return 2;
        }
    }
    public static String ServerResponse = "Nothing Yet";
    //Checking version based on javascript execution is now legacy
    //reading based on txt file from web concept thanks to Horfius on #coders (irc.esper.net)
    public static String UpdateNotice() throws IOException
    {
        switch (UpdateWord())
        {
            case "Updated":
                return "You are currently updated to the most recent version";
            case "Outdated":
                return "You do not have the most recent version. You should consider " +
                        "updating to " + LatestOnline();
            default:
                return "You are using an unsupported version of Power of God. Please consider " +
                        "using the current version, " + LatestOnline() +
                        ", because your version could possibly be unstable.";

        }
    }
    public static String UpdateWord() throws IOException
    {
        int OnlinePrefix;
        switch (getUrlSource(url).get(0).substring(1))
        {
            case "Alpha": OnlinePrefix = 0; break;
            case "Beta": OnlinePrefix = 1; break;
            default: OnlinePrefix = 2; break;
        }
        int Item1 = Integer.parseInt(getUrlSource(url).get(1));
        int Item2 = Integer.parseInt(getUrlSource(url).get(2));
        int Item3 = -1; // If these values stay as -1 then the app will know to not read them
        int Item4 = -1;
        try
        {
            Item3 = Integer.parseInt(getUrlSource(url).get(3));
            try
            {
                Item4 = Integer.parseInt(getUrlSource(url).get(4));
            }
            catch (Exception ex)
            {
                Item4 = -1;
            }
        }
        catch (Exception ex)
        {
            Item3 = -1;
            System.out.println("Caught on Updater: " + ex.toString());
        }
        System.out.println("Online Minor = " + Item2);
        System.out.println("Local Minor = " + CurrentVersionInt().get(1));
        if (OnlinePrefix > CurrentPrefixInt()) return "Outdated";
        if (OnlinePrefix < CurrentPrefixInt()) return "Unsupported";
        if (Item1 > CurrentVersionInt().get(0)) return "Outdated";
        if (Item1 < CurrentVersionInt().get(0)) return "Unsupported";
        if (Item2 > CurrentVersionInt().get(1)) return "Outdated";
        if (Item2 < CurrentVersionInt().get(1)) return "Unsupported";
        if (Item3 > -1)
        {
            int local3 = CurrentVersionInt().get(2);
            if (Item3 > local3) return "Outdated";
            if (Item3 < local3) return "Unsupported";
            if (Item4 > -1)
            {
                int local4 = CurrentVersionInt().get(3);
                if (Item4 > local4) return "Outdated";
                if (Item4 < local4) return "Unsupported";
            }
            else
            {
                String localHere = CurrentVersion[3];
                if (localHere != null) return "Unsupported";
            }
        }
        else
        {
            String localHere = CurrentVersion[2];
            if (localHere != null) return "Unsupported";
        }
        return "Updated"; // If it gets to this point - the user has passed all checks. They are updated!
    }
    private static ArrayList<Integer> CurrentVersionInt()
    {
        ArrayList<Integer> xList = new ArrayList<>();
        for (String x:CurrentVersion)
        {
            try
            {
                xList.add(Integer.parseInt(x));
            }
            catch (Exception ex)
            {
                xList.add(-1);
            }
        }
        return xList;
    }
    private static String url = "http://godispower.us/Application/Updates.txt";
    public static String LatestOnline() throws IOException
    {
        String x = getUrlSource(url).get(0) + " ";
        int VersionStoppedAt = 0;
        for (int x2 = 1; x2 <= 4; x2++)
        {
            if (x2 < 5)
            {
                if (!getUrlSource(url).get(x2).equals("NR"))
                {
                    if (x2 < 4) x += "" + getUrlSource(url).get(x2) + ".";
                    else if (x2 == 4) x += "" + getUrlSource(url).get(x2);
                }
                else
                {
                    VersionStoppedAt = x2;
                }
            }
        }
        if (VersionStoppedAt == 3 || VersionStoppedAt == 4)
        {
            return x.substring(0, x.length() - 1);
        }
        return x;
    }
    public static ArrayList<String> getUrlSource(String urlF) throws IOException {
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
            theList.add(inputLine);
        in.close();
        ArrayList<String> newList = new ArrayList<>();
        for (String s:theList)
        {
            if (!s.equals(""))
            {
                newList.add(s);
            }
        }
        return newList;
    }
}
