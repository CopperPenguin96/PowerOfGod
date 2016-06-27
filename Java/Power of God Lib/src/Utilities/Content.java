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
package Utilities;

import java.awt.*;
import java.awt.image.BufferedImage;
import java.io.ByteArrayOutputStream;
import java.security.MessageDigest;
import java.util.*;
import java.util.logging.Level;
import java.util.logging.Logger;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javax.swing.*;
import pSystem.ErrorLogging;

/**
 *
 * @author apotter96
 */
public class Content
{
    public static ByteArrayOutputStream bos = new ByteArrayOutputStream();
    private static void replaceColor(BufferedImage image, Color oldColor, Color newColor)
    {
        for (int y=0; y<image.getHeight(); y++)
        {
            for (int x=0; x<image.getWidth(); x++)
            {
                int color = image.getRGB(x, y);
                if (color == oldColor.getRGB())
                {
                    image.setRGB(x, y, newColor.getRGB());
                }
            }
        }
    }
    public static Image iconToImage(Icon icon)
    {
        if (icon instanceof ImageIcon) {
            return ((ImageIcon)icon).getImage();
        } 
        else
        {

            int w = icon.getIconWidth();
            int h = icon.getIconHeight();
            GraphicsEnvironment ge = GraphicsEnvironment.getLocalGraphicsEnvironment();
            GraphicsDevice gd = ge.getDefaultScreenDevice();
            GraphicsConfiguration gc = gd.getDefaultConfiguration();
            BufferedImage image = gc.createCompatibleImage(w, h);
            Graphics2D g = image.createGraphics();
            icon.paintIcon(null, g, 0, 0);
            g.dispose();
            return image;
        }
    }
    
    public static String OldTitle;
    public static String CurrentTitle;
    public static boolean ButtonPressed;
    public static void SetTitle(String text)
    {
        if (OldTitle != null)
        {
            OldTitle = CurrentTitle;
        }
        CurrentTitle = text;
    }
    
    public static String CurrentListId = "";
    
    public static String GenerateMd5(String original)
    {
        try {
            MessageDigest md = MessageDigest.getInstance("MD5");
            md.update(original.getBytes());
            byte[] digest = md.digest();
            StringBuilder sb = new StringBuilder();
            for (byte b: digest)
            {
                sb.append(String.format("%02x", b & 0xff));
            }
            return sb.toString();
        } catch (Exception ex) {
            ErrorLogging.Write(ex);
            Logger.getLogger(Content.class.getName()).log(Level.SEVERE, null, ex);
            return "Failed to generate md5 hash";
        }
        
    }
    public static ObservableList<String> ObservedList = FXCollections.observableList(new ArrayList<String>());
    public static void SetListItems(ArrayList<String> items)
    {
        ObservedList.clear();
        Set<String> uniqueItems = new HashSet<>(items);
        uniqueItems.stream().forEach((value) -> {
            if (!ButtonPressed) ObservedList.add(value);
        });
    }
}

