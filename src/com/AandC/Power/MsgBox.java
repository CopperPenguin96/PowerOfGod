package com.AandC.Power;
import android.content.*;
import android.app.*;

public class MsgBox
{
	public static Context mainActivityContext;
	AlertDialog ad;
	public MsgBox(String title, String message, Context c) {
		ad = new AlertDialog.Builder(c).create();
		ad.setMessage(message);
		ad.setTitle(title);
	}
	public void show() {
		ad.show();
	}
}
