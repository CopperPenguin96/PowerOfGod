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
package power.of.god;

import GUI.*;
import GUI.DialogBox.ChoiceDialogBox;
import GUI.DialogBox.DialogBox;
import GUI.DialogBox.DownloadDialogBox;
import Plugins.Plugin;
import Utilities.FileSystem;
import Utilities.Network;
import java.io.*;
import java.util.logging.Level;
import java.util.logging.Logger;
import pSystem.ErrorLogging;

/**
 *
 * @author apotter96
 */
public class Start {
    
    
    public static void main(String[] args)
    {
        String mLink = "http://www.mediafire.com/download/9psfe1gevh8q863/Alpha_0.0.zip";
        try {
            System.out.println(Network.MediaFire(mLink));
            /*
            try {
            
            String mainPath = "power.of.god/";
            String bibPath = "power.of.god/Bibles/";
            File mainPathObj = FileSystem.GetFileObj(mainPath);
            File bibPathObj = FileSystem.GetFileObj(bibPath);
            if (!mainPathObj.exists()) mainPathObj.mkdirs();
            if (!bibPathObj.exists()) bibPathObj.mkdirs();
            boolean safeToRun = false;
            try
            {
            String n = Network.LatestStable(false);
            if (n.contains("Pre-Release"))
            {
            ConsoleFrame cf = new ConsoleFrame();
            cf.show();
            System.out.println(">>> Power of God Debug Console <<<");
            System.out.println("-------------------------------------------------------");
            System.out.println("http://powerofgodonline.net/");
            
            System.out.println("You will be using Power of God " + Network.LatestStable(false));
            }
            
            else if (!Network.UpdateWord().equals("Updated"))
            {
            ChoiceDialogBox cBox = new ChoiceDialogBox("Updater",
            "It is recommended that you get Power of God " + Network.LatestOnline() +
            ", because you have now " +
            Network.LatestStable(false) +
            ".\n\nWould you like us to update it for you? This is the " +
            "recommended option.",
            "Yes", "No");
            cBox.setVisible(true);
            switch (cBox.GetResult())
            {
            case Choice1:
            File updater = new File("Updater.exe");
            if (!updater.exists())
            {
            System.out.println("Starting the Updater Form...");
            new UpdaterForm().setVisible(true);
            }
            else
            {
            new DialogBox("Failed to Update", "We can't update without Updater.exe. " +
            "You will hve to download the update yourself.").setVisible(true);
            }
            break;
            case Choice2:
            new DialogBox("Not a Good Idea!",
            "You have chosen not to update. Some features might not work or you " +
            "will not get access to new things.").setVisible(true);
            safeToRun = true;
            break;
            }
            }
            if (safeToRun)
            {
            new MainScreen().setVisible(true);
            }
            }
            catch (Exception ex)
            {
            ErrorLogging.Write(ex);
            }
            //MainScreen.main(args);
            
            /*File f = new File("lessons.jar");
            URL[] f2 = new URL[] {f.toURL()};
            URLClassLoader child = new URLClassLoader (f2, mS.getClass().getClassLoader());
            Class classToLoad = Class.forName ("Lessons.Plugin", true, child);
            //Method method = classToLoad.getDeclaredMethod ("myMethod");
            Object instance = classToLoad.newInstance ();
            //Object result = method.invoke (instance);
            Plugin p = (Plugin) instance;
            System.out.println("Found this plugin: " + p.GetName());*/
            /*}
            catch (Exception e)
            {
            ErrorLogging.Write(e);
            }*/
        } catch (Exception ex) {
            Logger.getLogger(Start.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
}
