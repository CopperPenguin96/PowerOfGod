package apdevelopment.powerofgod.alphaphase;

import org.joda.time.DateTime;

import java.io.File;
import java.io.PrintWriter;
import java.io.StringWriter;
import java.util.ArrayList;

/**
 * Created by apotter96 on 2/6/2016.
 */
public class ErrorLogging {
    private static DateTime _now = DateTime.now();
    private static String Nl = "\n";
    public static void Write(Exception ex)
    {
        File dirObj = new File("/sdcard/Android/data/apdevelopment.powerofgod/AlphaLogs/");
        if (!dirObj.exists()) dirObj.mkdirs();
        ArrayList<String> fileLines = new ArrayList<>();
        fileLines.add("-----Power of God Error Log-----");
        fileLines.add(Nl);
        try
        {
            fileLines.add("Exception Message: " + ex.getMessage());
        }
        catch (Exception exf)
        {
            fileLines.add(Nl);
        }
        fileLines.add(ex.toString());
        fileLines.add(Nl + Nl);
        StringWriter sw = new StringWriter();
        PrintWriter pw = new PrintWriter(sw);
        ex.printStackTrace(pw);
        fileLines.add(sw.toString());
        fileLines.add("log wrote at " + _now.hourOfDay() + ":" + _now.minuteOfHour() + ":" + _now.secondOfMinute() + " on " + _now.toString());
        String[] fileF = new String[fileLines.size()];
        String writingPath = "Logs/" + _now.hourOfDay() + ":" + _now.minuteOfHour() + ":" + _now.secondOfMinute() + _now.toString();
        try {
            if (!(new File(writingPath)).exists()) new File(writingPath).createNewFile();
            Files.WriteToOrdinaryFile(new File(writingPath), fileLines.toArray(fileF));
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
