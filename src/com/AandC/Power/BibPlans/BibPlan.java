package com.AandC.Power.BibPlans;
import android.text.format.*;
import java.util.zip.*;
import java.util.*;
import java.io.*;
import com.AandC.Power.Exceptions.*;
import com.AandC.Power.StartUp.*;
import javax.xml.parsers.*;
import org.w3c.dom.*;
import com.AandC.Power.*;
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
public class BibPlan
{
	//Variables that make up the Object
	public int id;
	public String name;
	public int dayCount;
	public String[] planDays;
	public Boolean[] hasRead;
	
	String tempPath;
	File xmlFile;
	String tempX;
	int count = 0;
	//ZipFile stuff
	ZipFile zipFile;
	Enumeration<? extends ZipEntry> entries;
	//Constructor for the BibPlan Object
	//Checks for missing files in BibPlan file
	public BibPlan(String fileName) throws IOException, InvalidBibPlanException {
		if (fileName.equals(null)) {
			 throw new IllegalArgumentException();
		} else {
			try {
				zipFile = new ZipFile(fileName);
				entries = zipFile.entries();
				if (entries.hasMoreElements()){
					moreEntries();
				}
				String[] en = new String[count];
				Enumeration<? extends ZipEntry> entriesNew = zipFile.entries();
				count = 0;
				while(entriesNew.hasMoreElements()) {
					en[count] = entriesNew.nextElement().toString();
					count++;
				}
				int st;
				for (st = 0; st <= 2; st++) {
					try {
						System.out.println(en[st]);
					} catch (Exception ex) {
						System.out.println("Bad # " + st);
					}
				}
				boolean hasBaseFile = false;
				for (String currentFile:en) {
					try {
						if (currentFile.equals("base.xml")) {
							hasBaseFile = true;
						}
					} catch (NullPointerException ex) {
					}
				}
				System.out.println(hasBaseFile);
				if (!hasBaseFile) {
					throw new InvalidBibPlanException("Base File is Missing from Archive");
				}
				parse(zipFile, "base.xml");
				//If it has made it to this point, then the days Count has been satisfied
				//Now time to check if all exist
				int days = 0;
				while (days <= dayCount) {
					boolean hasDay = false;
					days++;
					for (String x:en) {
						try {
							int num = Integer.parseInt(x.substring(0,1));
							if (days == num) {
								hasDay = true;
							}
							if (!hasDay) {
								throw new InvalidBibPlanException("Day #" + days + " is missing.");
							}
						} catch (Exception ex) {
							//Stops on unneeded String items
						} 
					}
				}
			} catch (Exception ex) {
				ex.printStackTrace();
			}
		}
	}
	public void moreEntries() {
		try {
			count++;
			if (entries.hasMoreElements()) {
				moreEntries();
			}
		} catch (StackOverflowError ex) {
			//Prevents overflowing
		}
	}
	String path;
	void parse(ZipFile file, String fileName) throws InvalidBibPlanException, IOException {
		try {
			if (!Files.appFiles[4].exists()) {
				Files.appFiles[4].mkdirs();
			}
			// length - 8
			File tempDir = new File(file.getName().substring(0,25));
			if (tempDir.exists()) tempDir.delete();
			tempDir.mkdirs();
			ZipExtractor.unzip(file.getName(), 
				file.getName().substring(0, file.getName().length() - 8) + "/");
			xmlFile = new File(file.getName().substring(0, file.getName().length() - 8) + "/base.xml");
			path = file.getName().substring(0, file.getName().length() - 8) + "/";
			parseXML();
		} catch (NullPointerException ex) {
			System.exit(0);
		}
	}
	public void parseXML() throws InvalidBibPlanException, IOException {
		try {
			File fXmlFile = xmlFile;
			DocumentBuilderFactory dbFactory = DocumentBuilderFactory.newInstance();
			DocumentBuilder dBuilder = dbFactory.newDocumentBuilder();
			Document doc = dBuilder.parse(fXmlFile);
			doc.getDocumentElement().normalize();
			System.out.println("Root element :" + doc.getDocumentElement().getNodeName());
			NodeList nList = doc.getElementsByTagName("BibPlan");
			System.out.println("----------------------------");
			for (int temp = 0; temp < nList.getLength(); temp++) {
				Node nNode = nList.item(temp);
				System.out.println("\nCurrent Element :" + nNode.getNodeName());
				if (nNode.getNodeType() == Node.ELEMENT_NODE) {
					Element eElement = (Element) nNode;
					String[] attributes = new String[] {
						"ID : " + eElement.getAttribute("id"),
						"Plan Name : " + eElement.getAttribute("name"),
						"Length of Days : " + eElement.getAttribute("days")
					};
					id = Integer.parseInt(attributes[0].substring(5));
					name = attributes[1].substring(12);
					dayCount = Integer.parseInt(attributes[2].substring(17));
					System.out.println("ID = " + id);
					System.out.println("Name = " + name);
					System.out.println("Days = " + dayCount);
				}
			}
		} catch (Exception e) {
			e.printStackTrace();
		} finally {
			setDays();
		}
	}
	
	public void setDays() throws InvalidBibPlanException, IOException {
		int loopCount;
		planDays = new String[dayCount];
		for (loopCount = 1; loopCount <= dayCount; loopCount++) {
			File file = new File(path + "Day" + loopCount + ".txt");
			file.setReadable(true);
			BufferedReader br = null;
			br = new BufferedReader(new FileReader(file));
			planDays[loopCount - 1] = br.readLine();
		}
	}
	int read = 1;
	Time time = new Time();
	public String currentReading() throws IOException, InvalidBibPlanException {
		time.setToNow();
		File readingFile = new File("/sdcard/PowerOfGod/Plans/reading-" + name + ".txt");
		if (!readingFile.exists()) {
			readingFile.createNewFile();
			writeReads(0);
		}
		readingFile.setReadable(true);
		BufferedReader br = null;
		try
		{
			br = new BufferedReader(new FileReader(readingFile));
		} catch (FileNotFoundException e) { 
			throw new InvalidBibPlanException();
		} catch (IOException e) {
			throw new InvalidBibPlanException();
		} finally {
			int loopCount;
			hasRead = new Boolean[dayCount];
			for (loopCount = 1; loopCount <= dayCount; loopCount++) {
				if (br.readLine().equals("true")) {
					hasRead[loopCount] = true;
				} else {
					hasRead[loopCount] = false;
				}
			}
			int read = 1;
			for (boolean readers:hasRead) {
				if (readers == true) {
					read++;
				}
			}
			MsgBox magBox = new MsgBox("Daily Reading","Your daily reading is " + planDays[read - 1],
									   MsgBox.mainActivityContext); /*Applying this context makes it appear
			 in MainActivity */
			magBox.show();
			if (!readToday()) {
				writeReads(read);
			}
		}
		return null;
	}
	String currentDate;
	public boolean readToday() throws IOException {
		File day = new File("/sdcard/PowerOfGod/Plans/DaysRead - " + name + ".txt");
		if (!day.exists()) {
			day.createNewFile();
			return false;
		} else {
			currentDate = time.month + "/" + time.monthDay + 
				"/" + time.year;
			for (String lines:fileContent(day)) {
				if (lines.equals(currentDate)) {
					return true;
				}
			}
		}
		return false;
	}
	String[] fileContent(File f) throws IOException {
		if (!f.exists()) f.createNewFile();
		String[] fileLines = new String[dayCount];
		int loop;
		BufferedReader br = new BufferedReader(new FileReader(f));
		for (loop = 1; loop <= dayCount; loop++) {
			fileLines[loop - 1] = br.readLine();
		}
		return fileLines; //Originally was null... my goof
	}
	int loopCount;
	public void writeReads(int daysRead) throws IOException {
		File[] files = new File[]{
			new File("/sdcard/PowerOfGod/Plans/reading-" + name + ".txt"),
			new File("/sdcard/PowerOfGod/Plans/DaysRead - " + name + ".txt")
		};
		String[] readingText = fileContent(files[0]);
		String[] daysText = fileContent(files[1]);
		readingText[daysRead] = "true";
		daysText[daysRead] = currentDate;

		String[] finalTexts = new String[1];
		for (String x:readingText) {
			finalTexts[0] += x + "\n";
		}
		for (String x:daysText) {
			finalTexts[1] += x + "\n";
		}
		for (loopCount = 0; loopCount <= 1; loopCount++) {
			write(files[loopCount], finalTexts[loopCount]);
		}
	}
	void write(File outputFile, String finalText) throws IOException {
		outputFile = new File(Files.appFiles[1], "userInfo.txt");
		FileOutputStream fos = new FileOutputStream(outputFile);
		byte[] data = new String(finalText).getBytes();
		fos.write(data);
		fos.flush();
		fos.close();
	}
	
}
