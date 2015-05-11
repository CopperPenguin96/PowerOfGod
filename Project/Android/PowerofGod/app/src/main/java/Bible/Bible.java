package Bible;


import java.io.*;
import java.net.*;
import java.nio.channels.Channels;
import java.nio.channels.ReadableByteChannel;

import apdevelopment.powerofgod.Files;

public class Bible
{
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

