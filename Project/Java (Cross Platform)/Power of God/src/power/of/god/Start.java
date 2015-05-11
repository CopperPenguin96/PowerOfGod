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

import java.io.File;
import java.io.IOException;
import java.net.URISyntaxException;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.codejava.swing.download.DownloadTask;
import net.codejava.swing.download.DownloaderScreen;
import power.of.god.MainScreen.MainScreen;
import power.of.god.UserInformation.UserInfoFrameForm;

/**
 *
 * @author apotter96
 */
public class Start {
    static boolean HasBeenDownloaded = false;
    static boolean HasBeenStarted = false;
    static void XmlProcess() throws Exception
    {
        if (!Files.filesObj()[2].exists())
        {   
            if (!HasBeenStarted) 
            {
                Bible.Bible.DownloadXmlFile();
                HasBeenStarted = true;
            }
        }
        else
        {
            HasBeenDownloaded = true;
        }
    }
    static int loopNum = 0;
    public static void restartApplication()
    {
        final String javaBin = System.getProperty("java.home") + File.separator + "bin" + File.separator + "java";
        File currentJar = null;
        try {
            currentJar = new File(Start.class.getProtectionDomain().getCodeSource().getLocation().toURI());
        } catch (URISyntaxException ex) {
            Logger.getLogger(DownloadTask.class.getName()).log(Level.SEVERE, null, ex);
        }

        /* is it a jar file? */
        if(!currentJar.getName().endsWith(".jar"))
            return;

        /* Build command: java -jar application.jar */
        final ArrayList<String> command = new ArrayList<String>();
        command.add(javaBin);
        command.add("-jar");
        command.add(currentJar.getPath());

        final ProcessBuilder builder = new ProcessBuilder(command);
        try {
            builder.start();
        } catch (IOException ex) {
            Logger.getLogger(DownloadTask.class.getName()).log(Level.SEVERE, null, ex);
        }
        System.exit(0);
    }
    public static void main(String[] args)
    {
        if (!Files.filesObj()[2].exists()) 
        {
            DownloaderScreen ds = new DownloaderScreen();
            ds.show();
            while (!DownloadTask.IsFinished)
            {
                System.out.println("Download isn't finished yet. Waiting...");
            }
            ds.hide();
        }
        Bible.Files.SetScripturePath("power.of.god/", false, "don't do it");
        try {
            if (!Files.filesObj()[1].exists())
            {
                new UserInfoFrameForm().show();
                
            }
            else
            {
                MainScreen mScreen = new MainScreen();
                mScreen.pack();
                mScreen.setSize( 710, 450); // [677, 406] 33, 44
                mScreen.setVisible(true);
                mScreen.setLocationRelativeTo(null);
            }
        } catch (Exception ex) {
            Logger.getLogger(Start.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
}
