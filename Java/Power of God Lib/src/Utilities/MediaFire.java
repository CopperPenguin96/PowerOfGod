
package Utilities;

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.BufferedReader;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.logging.Logger;
/**
 * Downloads Files off MediaFire's Web Host
 * @author Emily Perkins (emilah@live.com)
 * @since 3/26/2012 11:48 PM
 * @version 1.2.0
 *
 */
public class MediaFire {
	
	public MediaFire() {
		try {
			logger.info("Opening Stream...");
			String host = getHyperLinkURL();
			String fileName = host.split("/")[5];
			logger.info("Hyperlink Url: "+host);
			BufferedInputStream input = new BufferedInputStream(new URL(host).openStream());
			logger.info("Downloading: "+fileName);
			BufferedOutputStream output = new BufferedOutputStream(new FileOutputStream("resources/" + fileName), BUFFER_SIZE);
			int bytesRead = 0;
			byte[] buffer = new byte[BUFFER_SIZE];
			while((bytesRead = input.read(buffer, 0, BUFFER_SIZE)) >= 0)
				output.write(buffer, 0, bytesRead);
			output.close();
			input.close();
			logger.info("Finished Downloading...");
		} catch (MalformedURLException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	public String getHyperLinkURL() {
		try {
			BufferedReader reader = new BufferedReader(new InputStreamReader(new URL(DOWNLOAD_LINK).openStream()));
			String line = "";
			while((line = reader.readLine()) != null) {
				if(line.contains("<div class=\"download_link\"")) 
					return reader.readLine().split("href=\"")[1].split("\" onclick")[0];
			}
		} catch (MalformedURLException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}
		return null;
	}
        
	
	public static void main(String[] args) {
		new MediaFire();
	}
	
	private final int BUFFER_SIZE = 1024;
	
	private final String DOWNLOAD_LINK = "http://www.mediafire.com/?3aw9hljbr9ve378";
	
	static Logger logger = Logger.getLogger(MediaFire.class.getName());

}
