package com.AandC.Power;
import com.AandC.Power.StartUp.*;
import java.io.*;
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
public class BibPlanParser
{
	private static String[] plans;
	//This method gets all the valid bibPlans
	public static String[] getInstalledPlans() {
		if (!Files.appFiles[3].exists()) {
			Files.appFiles[3].mkdirs();
			return new String[] {
				"No installed Plans. Get some!"
			};
		} else {
			File[] listOfFiles = Files.appFiles[3].listFiles();
			for (int i = 0; i < listOfFiles.length; i++) {
				if (listOfFiles[i].isFile()) {
					System.out.println("File " + listOfFiles[i].getName());
				} else if (listOfFiles[i].isDirectory()) {
					System.out.println("Directory " + listOfFiles[i].getName());
				}
			}
			String[] tempArray = new String[] {
				
			};
			int currentCount = 0;
			for (File f:listOfFiles) {
				String extension = "";
				int i = f.getName().lastIndexOf('.');
				if (i > 0) {
					extension = f.getName().substring(i+1);
				}
				if (extension.equals(".bibPlan")) {
					tempArray[currentCount] = f.getName().substring(0,i);
					currentCount++;
				}
			}
			
			if (tempArray[0] == null) {
				return new String[] {
					"No installed Plans. Get some!"
				};
			} else {
				return tempArray;
			}
		}
	}
	public static BibPlan getBibPlan(String planName) throws InvalidBibPlanException, IOException {
		String file = "/sdcard/PowerOfGod/Plans/" + planName + ".bibPlan";
		try {
			return new BibPlan(file);
		} catch (NullPointerException ex) {
			ex.printStackTrace();
			return null;
		}
	}
}
