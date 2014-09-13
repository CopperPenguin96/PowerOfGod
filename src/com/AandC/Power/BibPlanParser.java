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
	public static String[] getInstalledPlans() throws IOException, InvalidBibPlanException {
		if (!Files.appFiles[3].exists()) {
			Files.appFiles[3].mkdirs();
			System.out.println("Check #1");
			return new String[] {
				"No installed Plans. Get some!",
				"Sorry..."
			};
		} else {
			
			return null;
		}
	}
	public static String getExtension(String fileName) {
		String extension = "";
		int iX = fileName.lastIndexOf('.');
		if (iX >= 0) {
			extension = fileName.substring(iX+1);
		}
		return extension;
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
