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
package apdevelopment.powerofgod.alpha.User.Online;

import android.os.AsyncTask;
import android.os.StrictMode;
import android.widget.TextView;

import java.io.*;
import java.net.URLEncoder;
import java.security.*;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Locale;
import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.impl.client.HttpClientBuilder;
import org.apache.http.client.HttpClient;
import org.apache.http.util.EntityUtils;

import apdevelopment.powerofgod.alpha.Exceptions.*;
import apdevelopment.powerofgod.alpha.*;
import apdevelopment.powerofgod.alpha.User.*;

/**
 *
 * @author apotter96
 */
public class Database
{
    private static String hashString(String message, String algorithm)
        throws HashGenerationException {
 
        try {
            MessageDigest digest = MessageDigest.getInstance(algorithm);
            byte[] hashedBytes = digest.digest(message.getBytes("UTF-8"));
 
            return convertByteArrayToHexString(hashedBytes);
        } catch (NoSuchAlgorithmException | UnsupportedEncodingException ex) {
            throw new HashGenerationException(
                "Could not generate hash from String", ex);
        }
    }
    private static String convertByteArrayToHexString(byte[] arrayBytes) {
        StringBuilder stringBuffer = new StringBuilder();
        for (int i = 0; i < arrayBytes.length; i++) {
            stringBuffer.append(Integer.toString((arrayBytes[i] & 0xff) + 0x100, 16)
                .substring(1));
        }
        return stringBuffer.toString();
    }
    
    public static String generateMD5(String message) throws HashGenerationException {
        return hashString(message, "MD5");
    }
    public static String InvalidMessage;
    private static String htmlR(String url) throws Exception
    {
        DownloadWebpageTask x = new DownloadWebpageTask();
        x.execute(url);
        return x.get();
    }
    public static boolean Update(String oldUsername, String pass, UserInfo newInfo) throws Exception
    {
        String url = "http://godispower.us/Application/Users/external/updateRecord.php" + URLEncoder.encode("?" +
                "oldName=" + oldUsername +
                "&password=" + pass +
                "&email=" + newInfo.email +
                "&username=" + newInfo.username +
                "&name=" + newInfo.name, "UTF-8");
        String updateResponse = htmlR(url).trim();
        System.out.println("Update Response: Check for null: " + url);
        return !updateResponse.contains("Error");
    }
    public static boolean Insert(UserInfo uInfo, String usedPass) throws Exception
    {
        String url = "http://godispower.us/Application/Users/external/ExternalConnect.php?" +
                    "email=" + uInfo.email + 
                    "&name=" + uInfo.name +
                    "&uname=" + uInfo.username +
                    "&pass=" + generateMD5(usedPass) +
                    "&conf=" + generateMD5(uInfo.email);
        
        String htmlResponse = htmlR(url);
        for (int x = 0; x <= 1; x++)
        {
            if (htmlResponse.contains(items[x]))
            {
                InvalidMessage = getMessagePerPage(items[x]);
                return false;
            }
        }
        //If by this point a return hasn't been made, then
        //Then the user must have entered in good information
        //Still we check for error checking purposes - If I was to goof up
        // c h e c k s o u t
        // 0 1 2 3 4 5 6 7 8
        if (!htmlResponse.contains("checksout"))
        {
            InvalidMessage = "The server returned an invalid response that " +
                    "wasn't recognized. (Server Response: " + htmlResponse + ")";
            System.out.println(htmlResponse);
            System.out.println("Length = " + htmlResponse.length());
            //Character[] charObjectArray = ArrayUtils.toObject(charArray);
            return false;
        }
        else
        {
            return true;
        }
    }
    private final static String[] items = new String[] {
        "usernameexists", "emailexists", "checksout", null
    };
    private static String getMessagePerPage(String pagemessage)
    {
        if (pagemessage.equals(items[0]))
        {
            return "Username already exists";
        }
        else if (pagemessage.equals(items[1]))
        {
            return "Email already exists";
        }
        else
        {
            return "checksout";
        }
    }
    
    // Below is logging in
    /*Date format: DD-MM-YYYY.
        If it has been 60 days since the user has last used the app
        Then the user will have to relogin to the app
    */
    // User has logged in within the 60 day time limit. Can continue!
    public static void ReturningLogin() throws Exception
    {
        WriteLastLogin(Global.CurrentUserInfo); // Writes this returning login
    }
    
    public static boolean Login(String username, String password)
    {
        try
        {
            if (username == null || password == null)
            {
                throw new IncorrectLoginInfoException("Login details can't be empty!");
            }
            if (!CheckLogin(username, password))
            {
                throw new IncorrectLoginInfoException("Either the username or password is incorrect");
            }
            else
            {
                String emailResponse = "http://godispower.us/Application/" +
                    "Users/external/info.php?data=email&username=" + username;
                String nameResponse = "http://godispower.us/Application/" +
                    "Users/external/info.php?data=name&username=" + username;
                UserInfo myNewInfo = UserInfo.CreateObject(
                    htmlR(nameResponse), htmlR(emailResponse), username );
                myNewInfo.WriteJson(); // Writes to Json
                WriteLastLogin(myNewInfo); // Writes login time to file
                System.out.println(myNewInfo);
                return true;
            }
        }
        catch (Exception ex)
        {
            ex.printStackTrace();
            System.out.println("WOO");
            return false;
        }
    }
    
    private static void WriteLastLogin(UserInfo ui) throws Exception
    {
        
        File theLoginFile = new File("/sdcard/Android/data/apdevelopment.powerofgod/logins.txt");
        
        if (!theLoginFile.exists())
        {
            theLoginFile.createNewFile();
            try {
                // Assume default encoding.
                FileWriter fileWriter = new FileWriter(theLoginFile);
                BufferedWriter bufferedWriter = new BufferedWriter(fileWriter);
                    // Note that write() does not automatically
                    // append a newline character
                 bufferedWriter.write(TodayDateStr() + " " + ui.email + " " + ui.username + "");
                 // Always close files.
                bufferedWriter.flush();
                bufferedWriter.close();
            }
            catch(IOException ex) {
                System.out.println("Failure creating new file for logins");
            }
        }
        else
        {
            String textToTheFile = TodayDateStr() + " " + ui.email + " (" + ui.username + ")";
            FileWriter objWriter = new FileWriter("/sdcard/Android/data/apdevelopment.powerofgod//logins.txt", true);
            BufferedWriter bufferWritter = new BufferedWriter(objWriter);
                bufferWritter.newLine();
                bufferWritter.write(textToTheFile);
            bufferWritter.close();
            File lastLoginFile = Files.filesObj()[5];
            if (!lastLoginFile.exists())
            {
                lastLoginFile.createNewFile();
            }
            FileWriter writerOfTheLast = new FileWriter(lastLoginFile);
            BufferedWriter bufferWritter2 = new BufferedWriter(writerOfTheLast);
    	    bufferWritter2.write(TodayDateStr());
    	    bufferWritter2.close();
        }
    }
    private static boolean CheckLogin(String username, String pass) throws Exception
    {
        String loginUrl = "http://godispower.us/Application/Users/external/ExternalLogin.php?username=" + 
                username + "&password=" + pass;
        String htmlResponse = htmlR(loginUrl).trim();
        System.out.println("!!!!" + htmlResponse);
        return htmlResponse.contains("Login successful"); // Looks for the echo message
        // Must be incorrect details if it doesn't return properly!
    }
    
    public static Date ParseLastDate() throws IOException, ParseException
    {
        String sCurrentLine;
        BufferedReader br = new BufferedReader(new FileReader("/sdcard/Android/data/apdevelopment.powerofgod/logins.txt"));
        String lastLine = "";
        ArrayList<String> last2Items = new ArrayList<>();
        while ((sCurrentLine = br.readLine()) != null) 
        {
            last2Items.add(sCurrentLine);
        }
        ArrayList<String> array = new ArrayList<>();
        array.add(last2Items.get(last2Items.size()-1)); // The last
        array.add(last2Items.get(last2Items.size()-2)); // The one before the last
        String finalResponse = array.get(1) + " " + array.get(0);
        //TODO - Read from last line in file. Report the Date.
        DateFormat df = new SimpleDateFormat("MM/dd/yyyy HH:mm:ss", Locale.ENGLISH);

        return df.parse(finalResponse.substring(0,19));
    }
    private static String TodayDateStr() throws ParseException
    {
        DateFormat df = new SimpleDateFormat("MM/dd/yyyy HH:mm:ss");
        return df.format(TodayDate());
    }
    private static Date TodayDate() throws ParseException
    {
        DateFormat dateFormat = new SimpleDateFormat("MM/dd/yyyy HH:mm:ss");
        Date date = new Date();
        System.out.println(dateFormat.format(date));
        return dateFormat.parse(dateFormat.format(date));
    }
    public static boolean NeedsNewLogin() throws IOException, ParseException
    {
        Date lastLogin = ParseLastDate();
        Date todaysDate = TodayDate();
        int days = daysBetween(lastLogin, todaysDate);
        return days >= 60;
    }
    private static int daysBetween(Date d1, Date d2){
        return (int)( (d2.getTime() - d1.getTime()) / (1000 * 60 * 60 * 24));
    }
    public static String url;
    public static String result;
    public static boolean IsReadyToCheck = false;
    private static class DownloadWebpageTask extends AsyncTask<String, Void, String> {

        @Override
        protected String doInBackground(String... urls) {

            // params comes from the execute() call: params[0] is the url.
            try {
                String encodedUrl = urls[0];
                encodedUrl = encodedUrl.replace(" ", "%20");
                return downloadUrl(encodedUrl);
            } catch (IOException e) {
                return "Unable to retrieve web page. URL may be invalid.";
            }
        }
        // onPostExecute displays the results of the AsyncTask.
        @Override
        protected void onPostExecute(String result) {
            Database.result = result;
        }
        public String downloadUrl(String url) throws IOException {
            DefaultHttpClient httpclient = new DefaultHttpClient();
            HttpGet httpget = new HttpGet(url);
            HttpResponse response = httpclient.execute(httpget);
            BufferedReader in = new BufferedReader(new InputStreamReader(response.getEntity().getContent()));
            StringBuffer sb = new StringBuffer("");
            String line = "";
            String NL = System.getProperty("line.separator");
            while ((line = in.readLine()) != null) {
                sb.append(line + NL);
            }
            in.close();
            String result = sb.toString();
            return result;
        }

    }

}

/*
public String RunFunction() throws IOException {
        DefaultHttpClient httpclient = new DefaultHttpClient();
        HttpGet httpget = new HttpGet(Database.url);
        HttpResponse response = httpclient.execute(httpget);
        BufferedReader in = new BufferedReader(new InputStreamReader(response.getEntity().getContent()));
        StringBuffer sb = new StringBuffer("");
        String line = "";
        String NL = System.getProperty("line.separator");
        while ((line = in.readLine()) != null) {
            sb.append(line + NL);
        }
        in.close();
        String result = sb.toString();
        return result;
    }
 */