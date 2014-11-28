package com.AandC.Power;
import java.io.*;

public class Files
{
	public static boolean IsNew = false;
	static String mainPath = "/sdcard/Android/data/com.AandC.Power/";
	public static String[] FileSys = new String[]{
		mainPath,
		mainPath + "userInfo.json",
	};
	public static File[] getFiles() {
		File[] seeParh = new File[FileSys.length];
		int fileCount = 0;
		for (String s : FileSys) {
			seeParh[fileCount] = new File(s);
			fileCount++;
		}
		return seeParh;
	}
}
