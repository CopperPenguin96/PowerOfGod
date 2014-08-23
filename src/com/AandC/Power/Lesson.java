package com.AandC.Power;
import android.app.*;
import android.os.*;
import android.content.pm.*;
import com.AandC.Power.Exceptions.*;
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
	private static String day;
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.lesson);
		MsgBox.lessonContext = this;
		day = day.toLowerCase();
		if (day.equals("sunday")) Sunday();
		else if (day.equals("thursday")) Thursday();
	}
	public void Sunday() {
		
	}
	
	public void Thursday() {
		
	}
	
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
