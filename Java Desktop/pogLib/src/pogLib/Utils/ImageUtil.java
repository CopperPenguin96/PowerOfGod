package pogLib.Utils;

import java.awt.Color;
import java.awt.Graphics2D;
import java.awt.Image;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;
 
import javax.imageio.ImageIO;
 
public class ImageUtil {
 
	public static BufferedImage toBufferedImage(Image img)
	{
	    if (img instanceof BufferedImage)
	    {
	        return (BufferedImage) img;
	    }

	    // Create a buffered image with transparency
	    BufferedImage bimage = new BufferedImage(img.getWidth(null), img.getHeight(null), BufferedImage.TYPE_INT_ARGB);

	    // Draw the image on to the buffered image
	    Graphics2D bGr = bimage.createGraphics();
	    bGr.drawImage(img, 0, 0, null);
	    bGr.dispose();

	    // Return the buffered image
	    return bimage;
	}
	public static BufferedImage makeColorTransparent(String pathToSource, int red, int green, int blue) throws IOException {
	    // read original image with no transparency
	    BufferedImage original = ImageIO.read(new File(pathToSource.replace("%20", " ")));
	 
	    // get dimensions of image
	    int width = original.getWidth();
	    int height = original.getHeight();
	 
	    // create a new image that will have transparent colors
	    BufferedImage result = new BufferedImage(width, height, BufferedImage.TYPE_4BYTE_ABGR);
	 
	    // make color transparent
	    int oldRGB = new Color(red, green, blue).getRGB();
	    int newRGB = new Color(red, green, blue, 0).getRGB();
	    int currRGB;
	 
	    for (int x = 0; x < width; x++) {
	      for (int y = 0; y < height; y++) {
	        currRGB = original.getRGB(x, y);
	 
	        if (oldRGB == currRGB) {
	          result.setRGB(x, y, newRGB);
	        } else {
	          result.setRGB(x, y, currRGB);
	        }
	      }
	    }
	 
	    return result;
	  }
}