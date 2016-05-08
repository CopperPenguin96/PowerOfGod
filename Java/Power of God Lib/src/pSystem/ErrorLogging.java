/*
 * The MIT License
 *
 * Copyright 2016 apotter96.
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
import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Date;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author apotter96
 */
public class ErrorLogging {
    private static final Date _now = new Date();
    private final static String Nl = System.lineSeparator();
    public static void Write(Exception e5)
    {
        PowerException ex = (PowerException) e5;
        File dirObj = new File("power.of.god/Logs/");
        if (dirObj.exists()) dirObj.mkdirs();
        ArrayList<String> fileLines = new ArrayList<>();
        fileLines.add("-----Power of God Error Log-----" + Nl);
        try
        {
            fileLines.add("Exception Message: " + ex.getMessage());
        }
        catch (Exception e)
        {
            System.out.println(e);
            fileLines.add(Nl);
        }
        fileLines.add(ex.toString());
        fileLines.add(Nl + Nl);
        fileLines.add(ex.getStackTrace(ex));
        fileLines.add("Log wrote at " + _now.toString());
        String writingPath = "power.of.god/Logs/" + _now.toString() + _now.getTime() + ".txt";
        File newFileObj = new File(writingPath);
        try {
            newFileObj.createNewFile();
            String[] f = new String[fileLines.size()];
            FileSystem.WriteToOrdinaryFile(newFileObj, fileLines.toArray(f));
        } catch (IOException ex1) {
            Logger.getLogger(ErrorLogging.class.getName()).log(Level.SEVERE, null, ex1);
        } catch (Exception ex1) {
            Logger.getLogger(ErrorLogging.class.getName()).log(Level.SEVERE, null, ex1);
        }
        
    }
}
