package apdevelopment.powerofgod.alphaphase;

import android.app.Activity;
import android.content.Context;

import java.io.PrintWriter;
import java.io.StringWriter;

/**
 * Created by apotter96 on 7/1/2015.
 */
public class Global {
    //public static UserInfo CurrentUserInfo;
    public static boolean NeedsToClose = false;
    public static Activity GetActivityFromContext(Context c)
    {
        return (Activity) c;
    }

    public static String GetStackTrace(Exception ex)
    {
        StringWriter sw = new StringWriter();
        PrintWriter pw = new PrintWriter(sw);
        ex.printStackTrace(pw);
        return sw.toString();
    }
}
