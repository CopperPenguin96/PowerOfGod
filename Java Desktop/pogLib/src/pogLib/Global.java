package pogLib;

import java.util.Calendar;

import pogLib.GUI.*;
public class Global {
	//public static Version Version = new Version("Corinth", 1, 0);
	
	public static SplashScreen SplashScreen = new SplashScreen();
	// public static MainForm MainForm = new MainForm();
	public static int CurrentScreen = -1;
	public static String GetCopyright()
	{
		String year = ("" + Calendar.getInstance().get(Calendar.YEAR)).substring(2);
		return "Copyright © 2014-" + year + " by AP Development and the Power of God Team. All rights reserved.";
	}
}
