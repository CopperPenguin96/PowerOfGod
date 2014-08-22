package com.AandC.Power.StartUp;
import android.os.*;
import android.content.*;
import com.AandC.Power.*;
import java.io.*;
/*
 Copyright 2014 apotter96

 Licensed under the Apache License, Version 2.0 (the "License");
 you may not use this file except in compliance with the License.
 You may obtain a copy of the License at

 http://www.apache.org/licenses/LICENSE-2.0

 Unless required by applicable law or agreed to in writing, software
 distributed under the License is distributed on an "AS IS" BASIS,
 WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 See the License for the specific language governing permissions and
 limitations under the License.
 */
public class UserInfo
{
	private static String userName;
	private static String androidVersion;
	private static String phoneModel;
	private static String appVersion;
	private static short age;
	private static String denomination;
	public static void save() {
		if (!Files.appFiles[1].exists()) {
			Files.appFiles[1].mkdirs();
		}
		if (!Files.appFiles[0].exists()) {
			try
			{
				Files.appFiles[0].createNewFile();
			} catch (IOException e) {
				System.exit(0);
			} finally {
				File outputFile;
				String finalText = userName + "\n" +
					androidVersion + "\n" +
					phoneModel+ "\n" +
					appVersion + "\n" +
					age + "\n" +
					denomination;
				try {
					outputFile = new File(Files.appFiles[1], "userInfo.txt");
					FileOutputStream fos = new FileOutputStream(outputFile);
					byte[] data = new String(finalText).getBytes();
					try {
						fos.write(data);
						fos.flush();
						fos.close();
					} catch (FileNotFoundException e) {
						// handle exception
						System.exit(0);
					} catch (IOException e) {
						// handle exception
						System.exit(0);
					} 
				} catch (Exception ex) {
					System.exit(0);
				}
			}
		} else {
			Files.appFiles[0].delete();
			save(); //Info might update
			//Keeps it updated in the file
		}
	}
	public static String getDen() {
		return denomination;
	}
	public static void setDen(String d) {
		denomination = d;
	}
	public static short getAge() {
		return age;
	}
	public static void setAge(short a) {
		age = a;
	}
	public static String getUserName() {
		return userName;
	}
	public static void setUserName(String user) {
		userName = user;
	}
	
	public static String getAndroidVersion() {
		String ver = Build.VERSION.RELEASE;
		if (androidVersion != ver) {
			setAndroidVersion();
		}
		return androidVersion;
	}
	public static void setAndroidVersion() {
		androidVersion = Build.VERSION.RELEASE;
	} 
	
	public static String getPhoneModel() {
		String finalProduct;
		String manufacturer = Build.MANUFACTURER;
		String model = Build.MODEL;
		if (model.startsWith(manufacturer)) {
			finalProduct = capitalize(model);
		} else {
			finalProduct = capitalize(manufacturer) + " " + model;
		}
		if (phoneModel != finalProduct) {
			phoneModel = finalProduct;
		}
		return phoneModel;
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
	public static void setPhoneModel() {
		phoneModel = getPhoneModel();
	}
	
	public static String getAppVersion(Context c) {
		String l = c.getResources().getString(R.string.ver);
		if (l != appVersion) {
			setAppVersion(c);
		}
		return appVersion;
	}
	
	public static void setAppVersion(Context c) {
		appVersion = c.getResources().getString(R.string.ver);
	}
}
