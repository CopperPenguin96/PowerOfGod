package power.of.god.User;

import java.io.*;
import org.json.simple.JSONObject;
import power.of.god.Files;

/**
 * Created by apotter96 on 4/8/2015.
 */
public final class UserInfo {
    public String name;
    public String email;
    public String username;
    
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
    
    public void WriteJson()
    {
        JSONObject obj = new JSONObject();
	obj.put("name", name);
	obj.put("email",email);
        obj.put("username", username);
        try {
            FileWriter file = new FileWriter(Files.filesStr()[3]);
            file.write(obj.toJSONString());
            file.flush();
            file.close();
	} catch (IOException e) {
            e.printStackTrace();
	}
    }
    
    
}
