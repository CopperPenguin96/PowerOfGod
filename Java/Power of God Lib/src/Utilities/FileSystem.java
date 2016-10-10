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


import java.io.*;

/**
 * Created by apotter96 on 4/8/2015.
 */
public class FileSystem {
    private final static String mainPath = "power.of.god/";
    private static final String[] files = new String[] {
            mainPath, // 0
            mainPath + "userInfo.json", //Old format file // 1
            mainPath + "KJV.xml", // 2
            mainPath + "userInfo.powerinfo", //New user format - still json // 3
            mainPath + "logins.txt", // 4
            mainPath + "lastopen.txt", // 5
            mainPath + "settings.json", // 6
            mainPath + "ESV.xml", // Newer Bible versions added in Alpha 1.3 // 7
            mainPath + "NIV.xml", // 8
            mainPath + "NLT.xml", // 9
            mainPath + "dailyscripture.json", // Daily Scripture added in Alpha 1.3 // 10
            mainPath + "lastds.txt" // 11
    };
    public static String[] filesStr()
    {
        if (!new File(files[0]).exists())
        {
            new File(files[0]).mkdirs(); // Making sure that the directory is ready for use
        }
        return files;
    }
    public static File[] filesObj()
    {
        File[] arrayHere = new File[filesStr().length];
        int loopCount = 0;
        for (String s:filesStr())
        {
            arrayHere[loopCount] = new File(s);
            loopCount++;
        }
        return arrayHere;
    }
    public static void WriteToOrdinaryFile(File obj, String[] Contents) throws Exception
    {
        try {
                // Assume default encoding.
                FileWriter fileWriter = new FileWriter(obj);
                BufferedWriter bufferedWriter = new BufferedWriter(fileWriter);
                String writeThis = "";
                for (String s:Contents)
                {
                    writeThis += s + "\n";
                }
                bufferedWriter.write(writeThis);
                bufferedWriter.flush();
                bufferedWriter.close();
        } 
        catch (Exception ex)
        {
                throw new Exception("Was not able to retrieve to save", ex);
        }
    }
    //THIS METHOD WILL OVERWRITE THE FILE
    public static void WriteToFile(int fileIndex, String[] Contents) throws Exception
    {
        File theFile = filesObj()[fileIndex - 1];
        if (theFile.exists()) {
            theFile.delete();
            WriteToFile(fileIndex, Contents);
        } else
        {
            theFile.createNewFile();
            try {
                // Assume default encoding.
                FileWriter fileWriter = new FileWriter(theFile);
                BufferedWriter bufferedWriter = new BufferedWriter(fileWriter);
                String writeThis = "";
                for (String s:Contents)
                {
                    writeThis += s + "\n";
                }
                bufferedWriter.write(writeThis);
                bufferedWriter.flush();
                bufferedWriter.close();
            } 
            catch (Exception ex)
            {
                throw new Exception("Was not able to retrieve to save", ex);
            }
        }
    }
    public static String ReadAllText(File f) throws FileNotFoundException, IOException
    {
        FileReader fr = new FileReader(f);
        BufferedReader textReader = new BufferedReader(fr);
        
        String fullText = "";
        String line = null;
        while((line = textReader.readLine()) != null) {
            fullText += line;
        }  
        return fullText;
    }
    
    public static File GetFileObj(String path)
    {
        return new File(path);
    }
}
