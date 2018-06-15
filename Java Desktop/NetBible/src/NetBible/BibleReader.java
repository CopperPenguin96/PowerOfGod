package NetBible;

import javax.xml.parsers.*;
import org.w3c.dom.*;

import NetBible.Bible.*;
import NetBible.Utils.ArgumentException;

import static NetBible.Utils.XmlUtil.asList;

import java.util.ArrayList;

public class BibleReader {
	public static String Version;
	public static boolean Ready = false;
	
	public static void main(String args[])
	{
		
	    if (LoadXml("KJV.xml"))
	    {
	    	System.out.println("SUCCESS");
	    }
	    else {
	    	System.out.println("FAIL");
	    }
	    
	    System.out.println(NewTestament.Timothy2.ReadVerse(2,  15));
	}
	public static String LoadXmlErrorLog;
	public static boolean LoadXml(String path) {
		try {
			System.out.println("----------Attempting to Load NETBIBLE----------");
			DocumentBuilderFactory dbFactory = DocumentBuilderFactory.newInstance();
			DocumentBuilder dBuilder = dbFactory.newDocumentBuilder();
			Document doc = dBuilder.parse(path);
			
			doc.getDocumentElement().normalize();
			
			Node bible = doc.getElementsByTagName("bible").item(0);
			Version = bible.getAttributes().item(0).getNodeValue();
			if (!Version.equals("")) System.out.println("Bible Version: " + Version);
			
			int loopCount = 0;
			for (Node node : asList(bible.getChildNodes()))
			{
				if (node.getNodeName().equalsIgnoreCase("book"))
				{
					String bookName = node.getAttributes().item(0).getNodeValue().toLowerCase();
					LoadOldTestament(bookName, loopCount, node);
					// LoadNewTestament(bookName, loopCount, node);
					loopCount++;
				}
			}
			LoadXmlErrorLog = "No errors";
			Ready = true;
			System.out.println("NetBible loaded successfully");
			return true;
		} catch (Exception ex) {
			LoadXmlErrorLog = ex.getStackTrace().toString();
			Ready = false;
			System.out.println("ERROR: NetBible failed to load... (" + ex.toString() + ")");
			return false;
		}
	}
	
	private static void LoadOldTestament(String bookName, int loopCount, Node node) throws ArgumentException
	{
		switch (bookName)
		{
		case "genesis":
            OldTestament.Genesis = LoadBook(bookName, loopCount, node);
            break;
        case "exodus":
            OldTestament.Exodus = LoadBook(bookName, loopCount, node);
            break;
        case "leviticus":
            OldTestament.Leviticus = LoadBook(bookName, loopCount, node);
            break;
        case "numbers":
            OldTestament.Numbers = LoadBook(bookName, loopCount, node);
            break;
        case "deuteronomy":
            OldTestament.Deuteronomy = LoadBook(bookName, loopCount, node);
            break;
        case "joshua":
            OldTestament.Joshua = LoadBook(bookName, loopCount, node);
            break;
        case "judges":
            OldTestament.Judges = LoadBook(bookName, loopCount, node);
            break;
        case "ruth":
            OldTestament.Ruth = LoadBook(bookName, loopCount, node);
            break;
        case "1 samuel":
            OldTestament.Samuel1 = LoadBook(bookName, loopCount, node);
            break;
        case "2 samuel":
            OldTestament.Samuel2 = LoadBook(bookName, loopCount, node);
            break;
        case "1 kings":
            OldTestament.Kings1 = LoadBook(bookName, loopCount, node);
            break;
        case "2 kings":
            OldTestament.Kings2 = LoadBook(bookName, loopCount, node);
            break;
        case "1 chronicles":
            OldTestament.Chronicles1 = LoadBook(bookName, loopCount, node);
            break;
        case "2 chronicles":
            OldTestament.Chronicles2 = LoadBook(bookName, loopCount, node);
            break;
        case "ezra":
            OldTestament.Ezra = LoadBook(bookName, loopCount, node);
            break;
        case "nehemiah":
            OldTestament.Nehemiah = LoadBook(bookName, loopCount, node);
            break;
        case "esther":
            OldTestament.Esther = LoadBook(bookName, loopCount, node);
            break;
        case "job":
            OldTestament.Job = LoadBook(bookName, loopCount, node);
            break;
        case "psalms":
            OldTestament.Psalms = LoadBook(bookName, loopCount, node);
            break;
        case "proverbs":
            OldTestament.Proverbs = LoadBook(bookName, loopCount, node);
            break;
        case "ecclesiastes":
            OldTestament.Ecclesiastes = LoadBook(bookName, loopCount, node);
            break;
        case "song of solomon":
            OldTestament.SongofSolomon = LoadBook(bookName, loopCount, node);
            break;
        case "isaiah":
            OldTestament.Isaiah = LoadBook(bookName, loopCount, node);
            break;
        case "jeremiah":
            OldTestament.Jeremiah = LoadBook(bookName, loopCount, node);
            break;
        case "lamentations":
            OldTestament.Lamentations = LoadBook(bookName, loopCount, node);
            break;
        case "ezekiel":
            OldTestament.Ezekiel = LoadBook(bookName, loopCount, node);
            break;
        case "daniel":
            OldTestament.Daniel = LoadBook(bookName, loopCount, node);
            break;
        case "hosea":
            OldTestament.Hosea = LoadBook(bookName, loopCount, node);
            break;
        case "joel":
            OldTestament.Joel = LoadBook(bookName, loopCount, node);
            break;
        case "amos":
            OldTestament.Amos = LoadBook(bookName, loopCount, node);
            break;
        case "obadiah":
            OldTestament.Obadiah = LoadBook(bookName, loopCount, node);
            break;
        case "jonah":
            OldTestament.Jonah = LoadBook(bookName, loopCount, node);
            break;
        case "micah":
            OldTestament.Micah = LoadBook(bookName, loopCount, node);
            break;
        case "nahum":
            OldTestament.Nahum = LoadBook(bookName, loopCount, node);
            break;
        case "habakkuk":
            OldTestament.Habakkuk = LoadBook(bookName, loopCount, node);
            break;
        case "zephaniah":
            OldTestament.Zephaniah = LoadBook(bookName, loopCount, node);
            break;
        case "haggai":
            OldTestament.Haggai = LoadBook(bookName, loopCount, node);
            break;
        case "zechariah":
            OldTestament.Zechariah = LoadBook(bookName, loopCount, node);
            break;
        case "malachi":
            OldTestament.Malachi = LoadBook(bookName, loopCount, node);
            break;

		}
	}
	
	public static void LoadNewTestament(String bookName, int loopCount, Node node) throws ArgumentException
	{
		switch (bookName)
		{
		case "matthew":
            NewTestament.Matthew = LoadBook(bookName, loopCount, node);
            break;
        case "mark":
            NewTestament.Mark = LoadBook(bookName, loopCount, node);
            break;
        case "luke":
            NewTestament.Luke = LoadBook(bookName, loopCount, node);
            break;
        case "john":
            NewTestament.John = LoadBook(bookName, loopCount, node);
            break;
        case "acts":
            NewTestament.Acts = LoadBook(bookName, loopCount, node);
            break;
        case "romans":
            NewTestament.Romans = LoadBook(bookName, loopCount, node);
            break;
        case "1 corinthians":
            NewTestament.Corinthians1 = LoadBook(bookName, loopCount, node);
            break;
        case "2 corinthians":
            NewTestament.Corinthians2 = LoadBook(bookName, loopCount, node);
            break;
        case "galatians":
            NewTestament.Galatians = LoadBook(bookName, loopCount, node);
            break;
        case "ephesians":
            NewTestament.Ephesians = LoadBook(bookName, loopCount, node);
            break;
        case "philippians":
            NewTestament.Philippians = LoadBook(bookName, loopCount, node);
            break;
        case "colossians":
            NewTestament.Colossians = LoadBook(bookName, loopCount, node);
            break;
        case "1 thessalonians":
            NewTestament.Thessalonians1 = LoadBook(bookName, loopCount, node);
            break;
        case "2 thessalonians":
            NewTestament.Thessalonians2 = LoadBook(bookName, loopCount, node);
            break;
        case "1 timothy":
            NewTestament.Timothy1 = LoadBook(bookName, loopCount, node);
            break;
        case "2 timothy":
            NewTestament.Timothy2 = LoadBook(bookName, loopCount, node);
            break;
        case "titus":
            NewTestament.Titus = LoadBook(bookName, loopCount, node);
            break;
        case "philemon":
            NewTestament.Philemon = LoadBook(bookName, loopCount, node);
            break;
        case "hebrews":
            NewTestament.Hebrews = LoadBook(bookName, loopCount, node);
            break;
        case "james":
            NewTestament.James = LoadBook(bookName, loopCount, node);
            break;
        case "1 peter":
            NewTestament.Peter1 = LoadBook(bookName, loopCount, node);
            break;
        case "2 peter":
            NewTestament.Peter2 = LoadBook(bookName, loopCount, node);
            break;
        case "1 john":
            NewTestament.John1 = LoadBook(bookName, loopCount, node);
            break;
        case "2 john":
            NewTestament.John2 = LoadBook(bookName, loopCount, node);
            break;
        case "3 john":
            NewTestament.John3 = LoadBook(bookName, loopCount, node);
            break;
        case "jude":
            NewTestament.Jude = LoadBook(bookName, loopCount, node);
            break;
        case "revelation":
            NewTestament.Revelation = LoadBook(bookName, loopCount, node);
            break;

		}
	}
	
	private static Book LoadBook(String name, int loopCount, Node node) throws ArgumentException
	{
		if (name.equals(null)) throw new ArgumentException("name");
		Book lam = new Book(loopCount);
		lam.SetName(name);
		
		for (Node chapters : asList(node.getChildNodes())) {
			if (!chapters.getNodeName().equalsIgnoreCase("chapter")) continue;
			Chapter chapter = new Chapter();
			ArrayList<String> def = new ArrayList<>();
			def.add(""); // First value is always blank so that numbering can remain 1 based not 0 based
			chapter.Verses = def;
			for (Node verses : asList(chapters.getChildNodes()))
			{
				if (!verses.getNodeName().equalsIgnoreCase("verse")) continue;
				String content = verses.getNodeValue();
				chapter.Verses.add(content);
			}
			lam.Chapters.add(chapter);
		}
		
		String bookName = name;
		char[] chars = bookName.toCharArray();
		if (bookName.equalsIgnoreCase("song of solomon"))
		{
			bookName = "Song of Solomon";
		}
		else if(!Character.isDigit(chars[0]))
		{
			chars[0] = Character.toUpperCase(chars[0]);
			bookName = new String(chars);
		}
		else
		{
			if (bookName.equalsIgnoreCase("2 timothy"))
			{
				char x = chars[2];
				char y = Character.toUpperCase(chars[2]);
				bookName = new String(chars);
				System.out.println(bookName);
			}
			chars[2] = Character.toUpperCase(chars[2]);
			bookName = new String(chars);
		}
		
		System.out.println(bookName = " loaded...");
		lam.SetName(bookName);
		return lam;
	}
}
