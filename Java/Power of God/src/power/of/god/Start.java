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
import Plugins.Plugin;
import java.io.*;
import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLClassLoader;
import java.util.*;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author apotter96
 */
public class Start {
    
    public static void main(String[] args)
    {
        try {
        //MainScreen.main(args);
            MainScreen mS = new MainScreen();
            File f = new File("lessons.jar");
            URL[] f2 = new URL[] {f.toURL()};
            URLClassLoader child = new URLClassLoader (f2, mS.getClass().getClassLoader());
            Class classToLoad = Class.forName ("Lessons.Plugin", true, child);
            //Method method = classToLoad.getDeclaredMethod ("myMethod");
            Object instance = classToLoad.newInstance ();
            //Object result = method.invoke (instance);
            Plugin p = (Plugin) instance;
            System.out.println("Found this plugin: " + p.GetName());
        }
        catch (ClassNotFoundException | SecurityException | InstantiationException | IllegalAccessException | IllegalArgumentException e)
        {
            
            System.out.println(e);
        } catch (MalformedURLException ex) {
            Logger.getLogger(Start.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
}
