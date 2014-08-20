package com.AandC.Power;

import android.app.*;
import android.os.*;
import android.view.*;
import android.widget.*;
import com.AandC.Power.StartUp.*;
import android.content.*;
import java.util.zip.*;
import java.util.*;
import java.io.*;
import javax.xml.parsers.*;
import org.w3c.dom.*;
import com.AandC.Power.Exceptions.*;

public class MainActivity extends Activity
{
    /** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState)
	{
        super.onCreate(savedInstanceState);
        setUp();
		UserInfo.setAndroidVersion();
		UserInfo.setAppVersion(this);
		UserInfo.setPhoneModel();
		
		MsgBox verDialog = new MsgBox(getResources().getString(R.string.ver), 
			"You are running Version " + getResources().getString(R.string.ver), this);
		verDialog.show();
		MsgBox.mainActivityContext = this; //So outside classes can show Alert Dialogues
		String filePath = "/sdcard/PowerOfGod/Plans/";
		File file = new File(filePath);
		if (!file.exists()) file.mkdirs();
		try
		{
			BibPlan testPlan = BibPlanParser.getBibPlan("planName");
		} catch (IOException e) {
			e.printStackTrace();
		} catch (InvalidBibPlanException e) {
			e.printStackTrace();
		}
    }
	
	void setUp() {
		if (!Files.checkFiles()) {
			//Enter info screen
			setContentView(R.layout.main);
		} else {
			setContentView(R.layout.mainmenu);
			/*
			4 Options Screen
				+ Bible Reading Plan (Read from .bibPlan file that
				is downloaded which is seen by dowbload screen)
				+ Sunday Lessons
				+ Thursday Lessons
				+ Quizzes
			*/
		}
	}
	
	public void sundayClick(View v) {
		
	}
	public void thursdayClick(View v) {
		
	}
	public void quizClick(View v) {
		
	}
	public void finishClick(View v) {
		EditText[] formBox = new EditText[] {
			(EditText) findViewById(R.id.txtName),
			(EditText) findViewById(R.id.txtAge),
			(EditText) findViewById(R.id.txtDen)
		};
		if (hasErrors(formBox)) {
			AlertDialog errorBox = new AlertDialog.Builder(this).create();
			errorBox.setTitle("Sorry...");
			errorBox.setMessage("There are errors in your responses. Please fix them.");
			errorBox.show();
		} else {
			UserInfo.setAge((short) Integer.parseInt(formBox[1].getText().toString()));
			UserInfo.setDen(formBox[2].getText().toString());
			UserInfo.setUserName(formBox[0].getText().toString());
			UserInfo.save();
			//Show Main Menu
		}
	}
	boolean hasErrors(EditText[] editText) {
		try {
			for (EditText txtLoop:editText) {
				if (isNull(txtLoop.getText().toString())) {
					return true;
				}
			}
			short age = (short) Integer.parseInt(editText[1].getText().toString());
			if (age < 13) {
				return true;
			} else if (age > 150) {
				return true;
			}
		} catch (Exception ex) {
			return true;
		}
		return false;
	}
	boolean isNull(String o) {
		if (o.equals(null)) {
			return true;
		} else {
			return false;
		}
	}
	
}
