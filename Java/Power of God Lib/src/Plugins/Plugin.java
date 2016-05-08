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

import GUI.Controls.*;
import java.util.*;

/**
 *
 * @author apotter96
 */
public class Plugin {
    public void InitPlugin()
    {
      
    }
    
    public String Name;
    public String GetName()
    {
        return Name;
    }
    
    public String Developer;
    public Category CCategory;
    public int Priority = -1;
    
    public ArrayList<PluginFrame> FrameIdList()
    {
        ArrayList<PluginFrame> aList = new ArrayList<>();
        // TODO - Developer should use aList.add(--Frame--);
        // Default frame should be first added
        return aList;
    }
    
    public PluginFrame GetFrame (String idStr)
    {
        for (PluginFrame frame : FrameIdList())
        {
            if (frame.FrameID == null ? idStr == null : frame.FrameID.equals(idStr))
            {
                return frame;
            }
        }
        return new PluginFrame();
    }
    
    public boolean DoAppLoadStuff = true;
    
    public Plugin()
    {        
    }
    public Plugin(String name, String dev, Category cat, int iPriority)
    {
        Name = name;
        Developer = dev;
        CCategory = cat;
        Priority = iPriority;
    }
    public Plugin(String name, String dev, Category cat, boolean DoAppLoad)
    {
        DoAppLoadStuff = DoAppLoad;
    }
    
    public void PerformStartAction()
    {
        
    }
    
    public void AppLoad()
    {
        
    }
    
    public void LboSelection(int index)
    {
        
    }
    
    public void ClearFrame()
    {
        //PluginReader.CurrentFrame = new PluginFrame();
    }
    public void ReplaceFrame(PluginFrame plFrame)
    {
        ClearFrame();
        //PluginReader.SetFrame(plFrame);
    }
}
