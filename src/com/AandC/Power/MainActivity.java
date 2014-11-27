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
		if (Files.getFiles()[1].exists()) {
			//TODO - Start Main Menu
		} else {
			startActivity(new Intent(this, UserInfoActivity.class));
		}
		this.finish();
	}
	
}
