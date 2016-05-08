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
package Plugins;

import GUI.*;
import GUI.Controls.*;
import java.io.*;
import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.net.*;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;
import java.util.logging.*;
import pSystem.ErrorLogging;
import pSystem.PowerException;

/**
 *
 * @author apotter96
 */
public class PluginReader {
    public static Plugin CurrentPlugin;
    public static <T> T GetObject(Plugin pl, Object[] constructArgs, String objectType)
    {
        try {
            MainScreen mS = new MainScreen();
            File f = GetFile(pl.GetName());
            URL[] f2 = new URL[] {f.toURL()};
            URLClassLoader child = new URLClassLoader (f2, mS.getClass().getClassLoader());
            Class classToLoad = Class.forName (pl.GetName() + "." + objectType, true, child);
            //Method method = classToLoad.getDeclaredMethod ("myMethod");
            Object instance = classToLoad.newInstance ();
            //Object result = method.invoke (instance);
            return (T) instance;
        } catch (ClassNotFoundException | InstantiationException | IllegalAccessException | MalformedURLException ex) {
            Logger.getLogger(PluginReader.class.getName()).log(Level.SEVERE, null, ex);
        }
        return null;
    }
   
    public static File GetFile(String pluginName)
    {
        return new File("Plugins/" + pluginName + ".jar");
    }
    public static Plugin GetPlugin(String name)
    {
        try {
            MainScreen mS = new MainScreen();
            File f = new File("Plugins/" + name + ".jar");
            URL[] f2 = new URL[] {f.toURL()};
            URLClassLoader child = new URLClassLoader (f2, mS.getClass().getClassLoader());
            Class classToLoad = Class.forName (name + ".Plugin", true, child);
            //Method method = classToLoad.getDeclaredMethod ("myMethod");
            Object instance = classToLoad.newInstance ();
            //Object result = method.invoke (instance);
            Plugin p = (Plugin) instance;
            return p;
        }
        catch (ClassNotFoundException | SecurityException | InstantiationException | IllegalAccessException | IllegalArgumentException | MalformedURLException e)
        {
            
            System.out.println(e);
        }
        return null;
    }
    
    public static PluginFrame CurrentFrame;
    public static PluginFrame OldFrame;
    public static void SetFrame(PluginFrame plFrame)
    {
        try
        {
            CurrentFrame = null;
        }
        catch (Exception e)
        {
            // Ignored
        }
        if (OldFrame != null)
        {
            OldFrame = CurrentFrame;
        }
        CurrentFrame = plFrame;
    }
    public static PluginFrame GetFrame(Plugin pl, String frameid)
    {
        Plugin p = GetPlugin(pl.GetName());
        return p.GetFrame(frameid);
    }
    
    public static PluginFrame GetDefaultFrame(Plugin pl)
    {
        Plugin p = GetPlugin(pl.GetName());
        return p.FrameIdList().get(0);
    }
    
    public static void StartUp(Plugin pl)
    {
        PluginLoaded(pl);
        PerformMethod(pl, "Plugin", "PerformStartAction", new Object[] {});
    }
    
    public static void AppLoad(Plugin pl)
    {
        PerformMethod(pl, "Plugin", "AppLoad", new Object[] {});
    }
    
    public static void PerformMethod(Plugin pl, String classStr, String methodStr, Object[] parems)
    {
        try {
            MainScreen mS = new MainScreen();
            File f = new File("Plugins/" + pl.GetName() + ".jar");
            URL[] f2 = new URL[] {f.toURL()};
            URLClassLoader child = new URLClassLoader (f2, mS.getClass().getClassLoader());
            Class classToLoad = Class.forName (pl.GetName() + "." , true, child);
            Method method = classToLoad.getDeclaredMethod (methodStr);
            Object instance = classToLoad.newInstance ();
            method.invoke(instance);
        }
        catch (ClassNotFoundException | SecurityException | InstantiationException | IllegalAccessException | IllegalArgumentException | MalformedURLException e)
        {
            
            System.out.println(e);
        } catch (NoSuchMethodException | InvocationTargetException ex) {
            Logger.getLogger(PluginReader.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
    public static ArrayList<Plugin> PluginList;
    
    public static String X = " ";
    public final static String Directory = "power.of.god/Plugins/";
    public static void LoadPlugins()
    {
        PluginList = new ArrayList<>();
        String dir = Directory;
        File dirObj = new File(dir);
        if (!dirObj.exists())
        {
            dirObj.mkdirs();
        }
        String strName = "";
        String strFileName = "";
        ArrayList<Plugin> tempList = new ArrayList<>();
        for (String files : Files())
        {
            try
            {
                Plugin pl = GetPlugin(files.substring(0, files.lastIndexOf(".")));
                if (strName.equals(pl.GetName())) continue;
                if (strFileName.equals(files.substring(files.lastIndexOf("/")))) continue;
                strName = pl.Name;
                strFileName = files;
                tempList.add(pl);
            }
            catch (Exception e)
            {
                ErrorLogging.Write(e);
            }
        }
        List<Plugin> tem = tempList;
        Collections.sort(tem, new Comparator<Plugin>() {

            @Override
            public int compare(Plugin o1, Plugin o2) {
                return o1.Priority - o2.Priority;
            }
            
        });
    }
    
    public static String[] Files() {
        File dir = new File(Directory);
        Collection<String> files = new ArrayList<>();

        if(dir.isDirectory()){
            File[] listFiles = dir.listFiles();
            for(File file : listFiles){
                if(file.isFile()) {
                    files.add(file.getName());
                }
            }
        }
        return files.toArray(new String[]{});
    }
    public final static ArrayList<String> PluginsLoaded = new ArrayList<>();
    public static void PluginLoaded(Plugin pl)
    {
        PluginsLoaded.stream().filter((p) -> (p == null ? pl.GetName() != null : !p.equals(pl.GetName()))).forEach((_item) -> {
            PluginsLoaded.add(pl.GetName());
        });
    }
    
    public static boolean GetPluginLoaded(String name)
    {
        return PluginsLoaded.contains(name);
    }
    
    public static Plugin(String name)
    {
        String[] fArray = Files();
        for (String f : fArray)
        {
            File fObj = new File(f);
            if (fObj.getAbsolutePath().substring(f.lastIndexOf(".")).contains("dll"))
            {
                String baseName = name.substring(21, name.lastIndexOf(".") - 21);
                
            }
        }
    }
}
