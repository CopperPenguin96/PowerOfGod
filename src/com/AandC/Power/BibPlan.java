package com.AandC.Power;
import android.text.format.*;
import java.util.zip.*;
import java.util.*;
import java.io.*;
import com.AandC.Power.Exceptions.*;
import com.AandC.Power.StartUp.*;
import javax.xml.parsers.*;
import org.w3c.dom.*;


public class BibPlan
{
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

	public boolean readToday() throws IOException {
		File day = new File("/sdcard/PowerOfGod/Plans/DaysRead - " + name + ".txt");
		if (!day.exists()) {
			day.createNewFile();
			return false;
		} else {
			String currentDate = time.month + "/" + time.monthDay + 
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
		return null;
	}
	public void writeReads(int daysRead) {
		File[] files = new File[]{
			new File("/sdcard/PowerOfGod/Plans/reading-" + name + ".txt"),
			new File("/sdcard/PowerOfGod/Plans/DaysRead - " + name + ".txt")
		};
		
	}
	public int id;
	public String name;
	public int dayCount;
	public String[] planDays;
	public Boolean[] hasRead;
	
	String tempPath;
	File xmlFile;
	String tempX;
	
	//Constructor for the BibPlan Object
	//Checks for missing files in BibPlan file
	public BibPlan(String fileName) throws IOException, InvalidBibPlanException {
		if (fileName.equals(null)) throw new NullPointerException();
		else {
			/*
			 TODO

			 Read for BibPlan Base file
			 And BibPlan Day Files and set to file
			 
			 Use temp directory for reading files
			 */
			ZipFile zipFile = new ZipFile(fileName);
			Enumeration<? extends ZipEntry> entries = zipFile.entries();
			int count = 0;
			while(entries.hasMoreElements()){
				count++;
			}
			String[] en = new String[count];
			Enumeration<? extends ZipEntry> entriesNew = zipFile.entries();
			count = 0;
			while(entriesNew.hasMoreElements()) {
				en[count] = entriesNew.nextElement().toString();
			}
			boolean hasBaseFile = false;
			for (String currentFile:en) {
				if (currentFile.equals("base.xml")) {
					hasBaseFile = true;
				}
			}
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
					int num = Integer.parseInt(x.substring(0,0));
					if (days == num) {
						hasDay = true;
					}
				}
				if (!hasDay) {
					throw new InvalidBibPlanException("Day #" + days + " is missing.");
				}
			}
		}
	}
	void parse(ZipFile file, String fileName) throws InvalidBibPlanException, IOException {
		if (!Files.appFiles[4].exists()) {
			Files.appFiles[4].mkdirs();
		}
		// length - 4
		String PlanName = fileName.substring(0, fileName.length() - 4);
		String directoryName = "/sdcard/PowerOfGod/Plans/" + PlanName;
		tempPath = directoryName;
		tempX = tempPath + "Base.xml";
		xmlFile = new File(tempX);
		File planDir = new File(directoryName);
		if (!planDir.exists()) {
			planDir.mkdirs();
		} else {
			planDir.delete();
			planDir.mkdirs(); //Prevents tampering with contents
		}
		ZipExtractor.unzip(fileName, directoryName);
		parseXML();
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
					id = Integer.parseInt(attributes[0]);
					name = attributes[1];
					dayCount = Integer.parseInt(attributes[2]);
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
			File file = new File(tempPath + "Day" + loopCount + ".txt");
			file.setReadable(true);
			BufferedReader br = null;
			try
			{
				br = new BufferedReader(new FileReader(file));
			} catch (FileNotFoundException e) { 
				throw new InvalidBibPlanException("Unable to read Day " + loopCount);
			} catch (IOException e) {
				throw new InvalidBibPlanException("Unable to read Day " + loopCount);
			} finally {
				planDays[loopCount - 1] = br.readLine();
			}
		}
	}
}
