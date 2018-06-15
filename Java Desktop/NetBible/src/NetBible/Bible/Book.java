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
	
	public static ArrayList<Chapter> Chapters = new ArrayList<>();
	
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
			return String.format("%1$s %2$s:%3$s (%4$s) - \"%4$s\"",
					GetName(), chapter, verse, BibleReader.Version, ReadVerse(chapter, verse));
		}
	}
	
	public String ReadMultipleVerses(int chapter1, int verse1, int chapter2, int verse2, boolean includeVerseNumbers) throws ArgumentException
	{
		if (chapter1 > chapter2) throw new ArgumentException("chapter1 > chapter2");
		if (chapter1 == chapter2)
		{
			if (verse1 > verse2) throw new ArgumentException("chapter 1 == chapter2; verse1 > verse2");
		}
		
		ArrayList<Chapter> chapterList = new ArrayList<>();
		for (int x = chapter1; x <= chapter2; x++)
		{
			chapterList.add(Chapters.get(x - 1));
		}
		String fullSet = "";
		int loopChap = chapter1 - 1;
		for (Chapter chap : chapterList)
		{
			loopChap++;
			ArrayList<String> verses = new ArrayList<>();
			int loopCount = 0;
			if (loopChap == chapter1)
			{
				loopCount = verse1;
			}
			for (String verse : chap.Verses)
			{
				if (loopCount > 0)
				{
					if (loopChap == chapter2)
					{
						if (loopCount > verse2) continue;
					}
					if (loopCount > Chapters.get(loopCount).Verses.size() - 1) continue;
					String partial = ReadVerse(loopChap, loopCount);
					String chapz = "";
					if (loopCount == 1)
					{
						chapz = "Chapter " + loopChap + " ";
					}
					else
					{
						if (includeVerseNumbers) chapz = loopCount + " ";
					}
					if (includeVerseNumbers)
					{
						verses.add(chapz + partial + " ");
					}
					else
					{
						verses.add(partial + " ");
					}
				}
				loopCount++;
			}
			for (String x : verses)
			{
				fullSet += x;
			}
		}
		return fullSet;
	}
}
