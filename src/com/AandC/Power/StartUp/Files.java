package com.AandC.Power.StartUp;
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
