package com.AandC.Power.User;
import java.io.*;
import java.util.*;
import org.apache.http.*;
import org.json.simple.parser.*;
import org.json.*;
import com.AandC.Power.*;
import android.content.*;
import android.os.*;
;
public class UserInfo
{
	private static UserInfoObj uInfo = new UserInfoObj();
	public static String getName() {
		try {
			JSONParser parser = new JSONParser();
			Object obj = parser.parse(new FileReader(Files.FileSys[1]));
			JSONObject jsonObject = (JSONObject) obj;
			return jsonObject.get("name").toString();
		} catch (Exception e) {
			e.printStackTrace();
			return null;
		}
	}
	public static void setName(String n) {
		uInfo.name = n;
	}
	
	public static int getAge() {
		try {
			JSONParser parser = new JSONParser();
			Object obj = parser.parse(new FileReader(Files.FileSys[1]));
			JSONObject jsonObject = (JSONObject) obj;
			return jsonObject.get("age");
		} catch (Exception e) {
			e.printStackTrace();
			return 13;
		}
	}
	public static void setAge(int a) {
		uInfo.age = a;
	}
	
	public static String getDen() {
		try {
			JSONParser parser = new JSONParser();
			Object obj = parser.parse(new FileReader(Files.FileSys[1]));
			JSONObject jsonObject = (JSONObject) obj;
			return jsonObject.get("den").toString();
		} catch (Exception e) {
			e.printStackTrace();
			return null;
		}
	}
	public static void setDen(String d) {
		uInfo.den = d;
	}
	public static Context c;
	public static void Update() throws JSONException, IOException {
		File configFile = Files.getFiles()[1];
		//Write to JSON file
		JSONObject configObj = new JSONObject();
        configObj.put("name", uInfo.name);
		configObj.put("age", uInfo.age);
        configObj.put("den", uInfo.den);
		configObj.put("android", android.os.Build.VERSION.RELEASE);
		configObj.put("app", c.getResources().getString(R.string.ver));
		configObj.put("device", getDeviceName());
		configFile.createNewFile();
		FileWriter fileWriter = new FileWriter(configFile);
		System.out.println("Writing JSON object to file");
		System.out.println("-----------------------");
		System.out.print(configObj.toString());
		fileWriter.write(configObj.toString());
		fileWriter.flush();
		fileWriter.close();
	}
	
	private static String getDeviceName() {
		String manufacturer = Build.MANUFACTURER;
		String model = Build.MODEL;
		if (model.startsWith(manufacturer)) {
			return capitalize(model);
		} else {
			return capitalize(manufacturer) + " " + model;
		}
	}


	private static String capitalize(String s) {
		if (s == null || s.length() == 0) {
			return "";
		}
		char first = s.charAt(0);
		if (Character.isUpperCase(first)) {
			return s;
		} else {
			return Character.toUpperCase(first) + s.substring(1);
		}
	} 
}
