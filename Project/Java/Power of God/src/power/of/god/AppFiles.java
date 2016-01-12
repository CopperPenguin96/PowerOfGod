package power.of.god;


import java.io.*;

/**
 * Created by apotter96 on 4/8/2015.
 */
public class AppFiles {
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
}
