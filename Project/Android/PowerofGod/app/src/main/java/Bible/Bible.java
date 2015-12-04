package Bible;


import android.content.Context;

import java.io.*;
import java.net.*;
import java.nio.channels.Channels;
import java.nio.channels.ReadableByteChannel;

import Books.Book;
import Books.OldTestament.*;
import Books.NewTestament.*;
import apdevelopment.powerofgod.alpha.Files;

public class Bible
{
    public static Context StartActivityContext; // So scripture can be read from assets
	public static Book[] AllBooks()
	{
		return new Book[] {
			new Genesis(), new Exodus(), new Leviticus(), new Numbers(), new Dueteronomy(), new Joshua(),
				new Judges(), new Ruth(), new Samuel1(), new Samuel2(), new Kings1(), new Kings2(),
				new Chronicles1(), new Chronicles2(), new Ezra(), new Nehemiah(), new Esther(),
				new Job(), new Psalms(), new Proverbs(), new Ecclesiastes(), new SongOfSolomon(),
				new Isaiah(), new Jeremiah(), new Lamentations(), new Ezekiel(), new Daniel(), new Hosea(),
				new Joel(), new Amos(), new Obadiah(), new Jonah(), new Micah(), new Nahum(), new Habakkuk(),
				new Zephaniah(), new Haggai(), new Zechariah(), new Malachi(),
				new Matthew(), new Mark(), new Luke(), new John(), new Acts(), new Romans(), new Corinthians1(),
				new Corinthians2(), new Galatians(), new Ephesians(), new Philippians(), new Colossians(),
				new Thessalonians1(), new Thessalonians2(), new Timothy1(), new Timothy2(), new Titus(), new Philemon(),
				new Hebrews(), new James(), new Peter1(), new Peter2(), new John1(), new John2(), new John3(),
				new Jude(), new Revelation()
		};
	}
	public static void DownloadXmlFile() throws Exception {
                URL link = new URL("http://gemscraft.net/kjv.xml"); //The file that you want to download
		
                //Code to download
		 InputStream in = new BufferedInputStream(link.openStream());
		 ByteArrayOutputStream out = new ByteArrayOutputStream();
		 byte[] buf = new byte[1024];
		 int n = 0;
		 while (-1!=(n=in.read(buf)))
		 {
		    out.write(buf, 0, n);
		 }
		 out.close();
		 in.close();
		 byte[] response = out.toByteArray();
 
		 FileOutputStream fos = new FileOutputStream(Files.filesStr()[2]);
		 fos.write(response);
		 fos.close();
	}

	
}

