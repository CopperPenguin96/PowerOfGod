package NetBible.Bible;

import java.util.ArrayList;

import NetBible.BibleReader;
import NetBible.Utils.ArgumentException;

// 0 - 38 = Old Testament
// 39 - 65 = New Testament
public class Book {
	public Book(int _id)
	{
		Id = _id;
	}
	
	public int Id;
	private String nameVal = "";
	public String GetName()
	{
		if (nameVal == "")
		{
			return BookList.fromInteger(Id).toString();
		}
		else
		{
			return nameVal;
		}
	}
	
	public void SetName(String value)
	{
		nameVal = value;
	}
	
	public Testament GetTestament()
	{
		if (Id > 0 && Id < 39) return Testament.Old;
		if (Id > 38 && Id < 66) return Testament.New;
		return Testament.fromInteger(-1);
	}
	
	public ArrayList<Chapter> Chapters = new ArrayList<>();
	
	public String ReadChapter(int chapter, boolean includeVerseNumbers)
	{
		ArrayList<String> verses = new ArrayList<>();
		for (int x = 1; x <= Chapters.size(); x++) 
		{
			if (x == chapter)
			{
				Chapter chap = Chapters.get(x - 1);
				int loopCount = 0;
				for (String verse : chap.Verses)
				{
					if (loopCount > 0)
					{
						if (includeVerseNumbers)
						{
							verses.add(loopCount + " " + verse + " ");
						}
						else
						{
							verses.add(verse + " ");
						}
					}
					loopCount++;
				}
			}
		}
		String finalString = "";
		for (String v : verses)
		{
			finalString += v;
		} 
		return finalString;
	}
	
	public String ReadVerse(int chapter, int verse)
	{
		Chapter chap = Chapters.get(chapter - 1);
		if (verse == chap.Verses.size())
		{
			return Chapters.get(chapter - 1).Verses.get(verse - 1);
		}
		else
		{
			return Chapters.get(chapter - 1).Verses.get(verse);
		}
	}
	
	public String ReadFormattedVerse(int chapter, int verse)
	{
		if (BibleReader.Version.equalsIgnoreCase(""))
		{
			return String.format("%1$s %2$s:%3$s - \"%4$s\"",
					GetName(), chapter, verse, ReadVerse(chapter, verse));
		}
		else
		{
			return String.format("%1$s %2$s:%3$s (%4$s) - \"%5$s\"",
					GetName(), chapter, verse, BibleReader.Version, ReadVerse(chapter, verse));
		}
	}
	
	
}
