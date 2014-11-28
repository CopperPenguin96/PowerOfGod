package com.AandC.Power;

import android.app.*;
import android.os.*;
import android.view.*;
import android.widget.*;
import android.content.*;
import java.util.zip.*;
import java.util.*;
import java.io.*;
import javax.xml.parsers.*;
import org.w3c.dom.*;
import android.support.v4.app.*;
import com.AandC.Power.User.*;
import org.json.simple.parser.*;
import org.json.*;
import MsgBox;
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
public class MainActivity extends Activity
{
    /** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		//Activity serves as bridge on Application Start
		UserInfo.c = this;
		ReviveJson();
		SetupDir();
		if (Files.getFiles()[1].exists()) {
			//TODO - Start Main Menu
		} else {
			startActivity(new Intent(this, UserInfoActivity.class));
		}
		this.finish();
	}
	void SetupDir() {
		if (!Files.getFiles()[0].exists()) {
			Files.getFiles()[0].mkdirs();
		}
	}
	void ReviveJson() {
		if (Files.getFiles()[1].exists()) {
			try {
				JSONParser parser = new JSONParser();
				Object obj = parser.parse(new FileReader(Files.FileSys[1]));
				JSONObject jsonObject = (JSONObject) obj;
				UserInfo.setName(jsonObject.get("name").toString());
				UserInfo.setAge(Integer.parseInt(jsonObject.get("age").toString()));
				UserInfo.setDen(jsonObject.get("den").toString());
			} catch (Exception e) {
				e.printStackTrace();
				(new MsgBox("Problem", "There was a problem loading your information. " + 
					"You will have to restart", this)).Show();
				Files.getFiles()[1].delete();
			}
		}
	}
	
}
