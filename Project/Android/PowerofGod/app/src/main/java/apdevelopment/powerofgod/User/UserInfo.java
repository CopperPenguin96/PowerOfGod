package apdevelopment.powerofgod.User;

import java.io.*;
import org.json.JSONException;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;

/**
 * Created by apotter96 on 4/8/2015.
 */
public final class UserInfo {
    public String name;
    public String email;
    public String username;
    @Override
    public String toString()
    {
        JSONObject jObject = new JSONObject();
        jObject.put("name", name);
        jObject.put("email", email);
        jObject.put("username", username);
        return jObject.toJSONString();
    }

    public UserInfo(String localName, String localEmail, String localUser)
    {
        name = localName;
        email = localEmail;
        username = localUser;
    }
    public static UserInfo CreateObject(String localName, String localEmail, String localUser)
    {
        return new UserInfo(localName, localEmail, localUser);
    }
    public static UserInfo ParseFromFile() throws IOException, JSONException, ParseException
    {
        JSONParser parser = new JSONParser();
        try {
            Object obj = parser.parse(new FileReader(apdevelopment.powerofgod.Files.filesObj()[3]));
            JSONObject jsonObject = (JSONObject) obj;
            String name = (String) jsonObject.get("name");
            String email = (String) jsonObject.get("email");
            String username = (String) jsonObject.get("username");
            return CreateObject(name, email, username);
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        } catch (ParseException e) {
            e.printStackTrace();
        }
        return null; //At this point, it's a fail.
    }
    public UserInfo() { }
    public void WriteJson()
    {
        JSONObject obj = new JSONObject();
        obj.put("name", name);
        obj.put("email",email);
        obj.put("username", username);
        try {
            try (FileWriter file = new FileWriter(apdevelopment.powerofgod.Files.filesStr()[3])) {
                file.write(obj.toJSONString());
                file.flush();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
