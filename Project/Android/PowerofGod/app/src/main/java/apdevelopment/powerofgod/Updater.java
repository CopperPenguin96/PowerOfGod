
package apdevelopment.powerofgod;

import android.webkit.WebView;

import org.mozilla.javascript.Context;
import org.mozilla.javascript.Function;
import org.mozilla.javascript.Scriptable;

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
    public static String UpdateResult = "Local";
    private static String VersionPrefix = "Alpha";
    private static String[] CurrentVersion = new String[]
    {
        "1", "3",null, null
    };
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
        switch (VersionPrefix) {
            case "Alpha":
                return 0;
            case "Beta":
                return 1;
            default:
                return 2;
        }
    }
    public static String ServerResponse = "Nothing Yet";
    public static String UpdateNotice() throws ScriptException, IOException, NoSuchMethodException
    {
        String returnValue = "Nothing Decided";
        Object[] params = new Object[] { CurrentPrefixInt(), CurrentVersion };

        // Every Rhino VM begins with the enter()
        // This Context is not Android's Context
        Context rhino = Context.enter();

        // Turn off optimization to make Rhino Android compatible
        rhino.setOptimizationLevel(-1);
        String currentVersionNeeded = "What?";
        try {
            Scriptable scope = rhino.initStandardObjects();

            // Note the forth argument is 1, which means the JavaScript source has
            // been compressed to only one line using something like YUI
            rhino.evaluateString(scope,
                    getUrlSource("http://godispower.us/Application/Updates.js"),
                    "JavaScript", 1, null);

            // Get the functionName defined in JavaScriptCode
            Object obj = scope.get("VersionUpdateNotice", scope);

            if (obj instanceof Function) {
                Function jsFunction = (Function) obj;

                // Call the function with params
                Object jsResult = jsFunction.call(rhino, scope, scope, params);
                // Parse the jsResult object to a String
                String result = Context.toString(jsResult);
                returnValue = result;
            }

            Object currentVers = scope.get("GetLatestStable", scope);
            if (obj instanceof Function) {
                Function jsFunction = (Function) currentVers;
                Object jsResult = jsFunction.call(rhino, scope, scope, params);
                String result = Context.toString(jsResult);
                currentVersionNeeded = result;
            }
        } finally {
            Context.exit();
        }
        switch (returnValue) {
            case "Updated":
                return "You are currently updated to the most recent version";
            case "Outdated":
                return "You do not have the most recent version. You should consider " +
                        "updating to " + currentVersionNeeded;
            default:
                return "You are using an unsupported version of Power of God. Please consider " +
                        "using the current version, " + currentVersionNeeded +
                        ", because your version might not be stable. (Response from " +
                        "server: " + returnValue + ")";
        }
    }
    private static String getUrlSource(String urlF) throws IOException {
        URL url = new URL(urlF);
        URLConnection urlCon = url.openConnection();
        BufferedReader in;

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
