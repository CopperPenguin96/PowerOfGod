package Bible;


import android.content.Context;

import java.io.BufferedInputStream;
import java.io.ByteArrayOutputStream;
import java.io.FileOutputStream;
import java.io.InputStream;
import java.net.URL;

import Books.Book;
import Books.NewTestament.Acts;
import Books.NewTestament.Colossians;
import Books.NewTestament.Corinthians1;
import Books.NewTestament.Corinthians2;
import Books.NewTestament.Ephesians;
import Books.NewTestament.Galatians;
import Books.NewTestament.Hebrews;
import Books.NewTestament.James;
import Books.NewTestament.John;
import Books.NewTestament.John1;
import Books.NewTestament.John2;
import Books.NewTestament.John3;
import Books.NewTestament.Jude;
import Books.NewTestament.Luke;
import Books.NewTestament.Mark;
import Books.NewTestament.Matthew;
import Books.NewTestament.Peter1;
import Books.NewTestament.Peter2;
import Books.NewTestament.Philemon;
import Books.NewTestament.Philippians;
import Books.NewTestament.Revelation;
import Books.NewTestament.Romans;
import Books.NewTestament.Thessalonians1;
import Books.NewTestament.Thessalonians2;
import Books.NewTestament.Timothy1;
import Books.NewTestament.Timothy2;
import Books.NewTestament.Titus;
import Books.OldTestament.Amos;
import Books.OldTestament.Chronicles1;
import Books.OldTestament.Chronicles2;
import Books.OldTestament.Daniel;
import Books.OldTestament.Dueteronomy;
import Books.OldTestament.Ecclesiastes;
import Books.OldTestament.Esther;
import Books.OldTestament.Exodus;
import Books.OldTestament.Ezekiel;
import Books.OldTestament.Ezra;
import Books.OldTestament.Genesis;
import Books.OldTestament.Habakkuk;
import Books.OldTestament.Haggai;
import Books.OldTestament.Hosea;
import Books.OldTestament.Isaiah;
import Books.OldTestament.Jeremiah;
import Books.OldTestament.Job;
import Books.OldTestament.Joel;
import Books.OldTestament.Jonah;
import Books.OldTestament.Joshua;
import Books.OldTestament.Judges;
import Books.OldTestament.Kings1;
import Books.OldTestament.Kings2;
import Books.OldTestament.Lamentations;
import Books.OldTestament.Leviticus;
import Books.OldTestament.Malachi;
import Books.OldTestament.Micah;
import Books.OldTestament.Nahum;
import Books.OldTestament.Nehemiah;
import Books.OldTestament.Numbers;
import Books.OldTestament.Obadiah;
import Books.OldTestament.Proverbs;
import Books.OldTestament.Psalms;
import Books.OldTestament.Ruth;
import Books.OldTestament.Samuel1;
import Books.OldTestament.Samuel2;
import Books.OldTestament.SongOfSolomon;
import Books.OldTestament.Zechariah;
import Books.OldTestament.Zephaniah;
import apdevelopment.powerofgod.alphaphase.Files;

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

