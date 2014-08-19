package com.AandC.Power.StartUp;
import java.io.*;

public final class Files
{
	public static final String path = "/sdcard/PowerOfGod/";
	public static File[] appFiles = new File[] {
		new File(path + "userInfo.txt"),
		new File(path),
		new File(path + "lastCrash.txt"),
		new File(path + "/Plans/"),
		new File(path + "/Plans/Temp/")
	};
		/*
			Username
			Android Version
			Age
			Model
			App Version
			Denomination
		*/
	
	public static String currentFile;
	public static int stepProgress;
	public static boolean checkFiles() {
		if (appFiles[0].exists()) {
			return true;
		} else {
			return false;
		}
	}
}
