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
import java.security.NoSuchAlgorithmException;
import java.util.*;
import java.util.logging.Level;
import java.util.logging.Logger;
import power.of.god.DailyScripture.DailyScripture;
import power.of.god.MainScreen.*;
import power.of.god.Settings.Settings;
import power.of.god.User.*;

/**
 *
 * @author apotter96
 */
public class Start {
    public static void RestartApplication(int exitCode) throws URISyntaxException, IOException
    {
        final String javaBin = System.getProperty("java.home") + File.separator + "bin" + File.separator + "java";
        final File currentJar = new File(Start.class.getProtectionDomain().getCodeSource().getLocation().toURI());
        /* is it a jar file? */
        if(!currentJar.getName().endsWith(".jar"))
            return;

        /* Build command: java -jar application.jar */
        final ArrayList<String> command = new ArrayList<>();
        command.add(javaBin);
        command.add("-jar");
        command.add(currentJar.getPath());

        final ProcessBuilder builder = new ProcessBuilder(command);
        builder.start();
        System.exit(exitCode);
    }
    public static UserInfo CurrentUserInfo;
    public static void main(String[] args)
    {
        try {
            System.out.println(DailyScripture.GetDailyScripture());
            boolean Obj1 = AppFiles.filesObj()[3].exists();
            boolean Obj2 = AppFiles.filesObj()[1].exists();
            if ((Obj1 && Obj2) || (Obj1 && !Obj2))
            {
                if (!AppFiles.filesObj()[4].exists()) AppFiles.filesObj()[4].createNewFile();
                if (Database.NeedsNewLogin()) Login.main(args);
                else {
                    CurrentUserInfo = UserInfo.ParseFromFile();
                    Database.ReturningLogin();
                    StartMain();
                }
            }
            else if (!Obj1 && Obj2)
            {
                SignUp.main(args, true);
            }
            else if (!Obj1 && !Obj2)
            {
                SignUp.main(args, false);
            }
            
            
        } catch (Exception ex) {
            Logger.getLogger(Start.class.getName()).log(Level.SEVERE, null, ex);
        } 
    }
    static void StartMain()
    {
        if (AppFiles.filesObj()[6].exists())
        {
            Settings.LoadFromJson();
        }
        else
        {
            Settings.SaveToJson(); // Will start with Default JSON values
        }
        Bible.Files.SetScripturePath("power.of.god/", false, "don't do it", ConvertToEnumObject());
            MainScreen mScreen = new MainScreen();
            mScreen.pack();
            mScreen.setSize( 710, 450); // [677, 406] 33, 44
            mScreen.setVisible(true);
            mScreen.setLocationRelativeTo(null);
            
    }
    private static Bible.BibleVersion ConvertToEnumObject()
    {
        String bibVers = Settings.BibleVersion;
        System.out.println("-----------> " + bibVers);
        if (bibVers.equals("KJV")) return Bible.BibleVersion.KJV;
        if (bibVers.equals("ESV")) return Bible.BibleVersion.ESV;
        if (bibVers.equals("NIV")) return Bible.BibleVersion.NIV;
        if (bibVers.equals("NLT")) return Bible.BibleVersion.NLT;
        
        return Bible.BibleVersion.KJV;
    }
}
