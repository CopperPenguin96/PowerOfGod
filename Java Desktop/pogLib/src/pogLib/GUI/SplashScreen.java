package pogLib.GUI;

import java.awt.*;
import java.awt.image.*;
import java.io.*;
import java.net.MalformedURLException;
import java.net.URL;

import pogLib.Global;
import javax.swing.*;

import com.sun.prism.paint.Color;

import NetBible.Utils.ArgumentException;
import pogLib.Utils.*;


public class SplashScreen extends JFrame {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	/**
	 * Create the panel.
	 */
	public SplashScreen() {
		try {
			Init();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (ArgumentException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	private JLabel picSplash_Logo;
	private JLabel lblCopyright_Splash;
	private JLabel picSpinner;
	private JLabel lblText1;
	private JLabel lblText2;
	
	private Color transparent = Color.TRANSPARENT;
	private java.awt.Color transparent_color = new java.awt.Color(
			transparent.getRed(),
			transparent.getBlue(),
			transparent.getGreen());
	
	private URL GetImageFile(String name) throws ArgumentException, MalformedURLException
	{
		switch (name.toLowerCase())
		{
		case "bg":
			return new File("images/bg.jpg").toURI().toURL();
		case "spinner":
			return new File("images/spinner.gif").toURI().toURL();
		case "web":
			
			return new File("images/web.png").toURI().toURL();
		default:
			throw new ArgumentException("GetImageFile: name");
		}
	}
	private ImageIcon getImage(URL url, int width, int height)
	{
		try {
			BufferedImage myPic = GetScaledImage(ImageUtil.makeColorTransparent(url.getFile(), 0,0,0), width, height);
			return new ImageIcon(myPic);
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
			return null;
		}
		
	}
	private void Init() throws IOException, ArgumentException
	{
		this.setUndecorated(true);
	    this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.picSplash_Logo = new JLabel();
		this.lblCopyright_Splash = new JLabel();
		this.picSpinner = new JLabel();
		this.lblText1 = new JLabel();
		this.lblText2 = new JLabel();
		//
		// picSplash_Logo
		//
		// this.picSplash_Logo = new JLabel(getImage("images/web.png", 783, 155));
		this.picSplash_Logo = new JLabel(getImage(GetImageFile("web"), 783, 155));
		this.picSplash_Logo.setBackground(java.awt.Color.BLACK);
		this.picSplash_Logo.setBackground(transparent_color);
		this.picSplash_Logo.setLocation(new Point(13,1));
		this.picSplash_Logo.setName("picSplash_Logo");
		this.picSplash_Logo.setSize(783, 155);
		this.picSplash_Logo.setHorizontalAlignment(SwingConstants.CENTER);
		this.picSplash_Logo.setVerticalAlignment(SwingConstants.TOP);
		//
		// lblCopyright_Splash
		//
		this.lblCopyright_Splash.setBackground(transparent_color);
		this.lblCopyright_Splash.setLocation(new Point(13, 319));
		this.lblCopyright_Splash.setName("lblCopyright_Splash");
		this.lblCopyright_Splash.setSize(784, 23);
		this.lblCopyright_Splash.setText(Global.GetCopyright());
		this.lblCopyright_Splash.setHorizontalAlignment(SwingConstants.CENTER);
		this.lblCopyright_Splash.setVerticalAlignment(SwingConstants.CENTER);
		//
		// picSpinner
		//
		this.picSpinner = new JLabel();
		this.picSpinner.setBackground(java.awt.Color.BLACK);
		this.picSpinner.setBackground(transparent_color);
		this.picSpinner.setLocation(new Point(335, 199));
		this.picSpinner.setName("picSpinner");
		this.picSpinner.setSize(138, 117);
		this.picSpinner.setIcon(new ImageIcon("images/spinner.gif"));
		this.picSpinner.setVisible(false);
		//
		// lblText1
		//
		this.lblText1.setBackground(transparent_color);
		this.lblText1.setLocation(new Point(12, 159));
		this.lblText1.setFont(new Font("Tahoma", Font.BOLD, (int) 21.75F));
		this.lblText1.setName("lblText1");
		this.lblText1.setSize(784, 37);
		this.lblText1.setText("Welcome!");
		this.lblText1.setHorizontalAlignment(SwingConstants.CENTER);
		this.lblText1.setVerticalAlignment(SwingConstants.CENTER);
		//
		// lblText2
		//
		this.lblText2.setBackground(transparent_color);
		this.lblText2.setFont(new Font("Tahoma", Font.BOLD, (int) 21.75F));
		this.lblText2.setLocation(new Point(110, 196));
		this.lblText2.setName("lblText2");
		this.lblText2.setSize(784, 37);
		this.lblText2.setText("Welcome!");
		this.lblText2.setHorizontalAlignment(SwingConstants.CENTER);
		this.lblText2.setVerticalAlignment(SwingConstants.CENTER);
		this.lblText2.setVisible(false);
		//
		// SplashScreen
		//
		this.setSize(809, 351);
		this.backgroundImage = getImage(GetImageFile("bg"), this.getWidth(), this.getHeight());
		JLabel bg = new JLabel(this.backgroundImage);
		bg.setSize(this.getWidth(), this.getHeight());
		bg.setVisible(true);
		bg.setLocation(0,0);
		this.setContentPane(bg);
		this.add(this.lblText2);
		this.add(this.lblText1);
		this.add(this.picSpinner);
		this.add(this.lblCopyright_Splash);
		this.add(this.picSplash_Logo);
		this.setName("SplashScreen");
		Dimension dim = Toolkit.getDefaultToolkit().getScreenSize();
		this.setLocation(dim.width/2-this.getSize().width/2, dim.height/2-this.getSize().height/2);
	}
	
	
	
	String dumytext;
	public ImageIcon backgroundImage;
	
	private BufferedImage GetScaledImage(BufferedImage file, int width, int height)
	{
		
		BufferedImage img = null;
		try {
			img = file;
			BufferedImage dimg = ImageUtil.toBufferedImage(img.getScaledInstance(width, height, Image.SCALE_SMOOTH));
			return dimg;
		} catch (Exception e) {
			e.printStackTrace();
			System.out.println("IMAGE FILE: " + file + " WIDTH/HEIGHT=" + width + "/" + height);
			return null;
		}
	}
}
