package com.AandC.Power;
import com.AandC.Power.StartUp.*;
import java.io.*;
import com.AandC.Power.Exceptions.*;

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
		return new BibPlan(planName);
	}
}
