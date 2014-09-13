package com.AandC.Power;
import android.app.*;
import android.os.*;
import android.content.pm.*;
import com.AandC.Power.Exceptions.*;
import android.widget.*;
import java.io.*;
import com.AandC.Power.Extractors.*;
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
public class Lesson extends Activity
{
	@Override
	private static String day = null;
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.lesson);
		//Allows for other classes to display MsgBox in this activity
		MsgBox.lessonContext = this;
		//Lower Case in case
		day = day.toLowerCase();
		try {
			//Sets per which button was pressed
			if (day.equals("sunday")) Sunday();
			else if (day.equals("thursday")) Thursday();
		} catch (IOException e) {
			MsgBox msgBox = new MsgBox("Error", "Something went wrong", 
				MsgBox.lessonContext);
			msgBox.show();
			e.printStackTrace();
		}
	}
	//Where we get our web content from
	String url = "http://PowerOfGod.1apps.com/";
	//The Sunday method presented above
	public void Sunday() throws IOException {
		String localUrl = url + "Sunday/";
		String[] fileArray = new String[] {
			localUrl + "title.html",
			localUrl + "message.html"
		};
		String[] c = new String[] {
			TitleExtractor.getPageTitle(fileArray[0]),
			TitleExtractor.getPageTitle(fileArray[1])
		};
		setContent(c);
	}
	//The Thursday method
	public void Thursday() throws IOException {
		String localUrl = url + "Thursday/";
		String[] fileArray = new String[] {
			localUrl + "title.html",
			localUrl + "message.html"
		};
		String[] c = new String[] {
			TitleExtractor.getPageTitle(fileArray[0]),
			TitleExtractor.getPageTitle(fileArray[1])
		};
		setContent(c);
	}
	//Sets the textviews to display lesson info
	void setContent(String[] content) {
		TextView lblTitle = (TextView) findViewById(R.id.lblTitle);
		TextView lblMessage = (TextView) findViewById(R.id.lblMessage);
		lblTitle.setText(content[0]);
		lblMessage.setText(content[1]);
	}
	//For when the MainActivity wants to go into this one, it sends which day first
	public static void setDay(String strDay) throws BadDayException {
		String[] days = new String[] {
			"sunday", "thursday"
		};
		boolean isSafe = false;
		for (String validDays:days) {
			if (validDays.equals(strDay)) {
				isSafe = true;
			}
		}
		if (!isSafe) throw new BadDayException();
		else {
			day = strDay;
		}
	}
}
