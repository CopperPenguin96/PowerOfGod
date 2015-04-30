package Books;
import Bible.Files;
import java.io.*;
import javax.xml.parsers.*;
import org.w3c.dom.*;
import java.util.*;


//Default book class
//Never use unless extending
public class Book
{
        
	private String _name;
	public String getName() {
		return this._name;
	}
	public void setName(String s) {
		this._name = s;
	}
	private int _bookNum;
	public int getBookNum() {
		return this._bookNum;
	}
	public void setBookNum(int s) {
		this._bookNum = s;
	}
	private int _chapterCount;
	public int getChapterCount() {
		return this._chapterCount;
	}
	public void setChapterCount(int s) {
		this._chapterCount = s;
	}
	public Book() {
		this.setName("Do Not Use");
		this.setChapterCount(0);
		this.setBookNum(0);
	}
	public String readFormattedVerse(int chapter, int verse) {
		return this.getName() + " " + chapter +
			":" + verse + " (KJB) - \"" + readPlainVerse(chapter, verse) + "\"";
	}
	public String readPlainVerse(int chapter, int verse) {
		try {
			File file = new File(Files.GetScripturePath());
			DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
			DocumentBuilder db = dbf.newDocumentBuilder();
			Document doc = db.parse(file);
			doc.getDocumentElement().normalize();
			System.out.println("Root element " + doc.getDocumentElement().getNodeName());
			NodeList nodeLst = doc.getElementsByTagName("book");
			System.out.println(nodeLst.item(0).getAttributes().item(0));
			Node[] nL = convertToArray(nodeLst);
			for (Node n: nL) {
				if (GetAttribute(n).equals(this.getName())) {
					Node chapNode = n.getChildNodes().item(ToOdd(chapter));
					Node versBode = chapNode.getChildNodes().item(ToOdd(verse));
					return versBode.getTextContent();
				}
			}
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		return null;
	}
	static int ToOdd(int normz) {
		return normz + (normz - 1);
	}
	static String GetAttribute(Node n) {
		return n.getAttributes().getNamedItem("name").getNodeValue();
	}
	public static Node[] convertToArray(NodeList list)
	{
		int length = list.getLength();
		Node[] copy = new Node[length];
		for (int n = 0; n < length; ++n) {
			copy[n] = list.item(n);
		}
		return copy;
	}
}
