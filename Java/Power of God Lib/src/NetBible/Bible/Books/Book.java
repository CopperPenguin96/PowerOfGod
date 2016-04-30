/*
 * The MIT License
 *
 * Copyright 2015-16 apotter96.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
package NetBible.Bible.Books;
import NetBible.Bible.Files;
import java.io.*;
import javax.xml.parsers.*;
import org.w3c.dom.*;
import org.xml.sax.SAXException;


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
			":" + verse + " (" + Files.needVers + ") - \"" + readPlainVerse(chapter, verse) + "\"";
	}
    public static boolean IsKjv()
    {
        System.out.print(Files.needVers);
        return true;
    }
    public int verseCount(int chapterLocal)
    {
        try {
            File file = new File(Files.GetScripturePath());
            DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
            DocumentBuilder db = dbf.newDocumentBuilder();
            Document doc = db.parse(file);
            doc.getDocumentElement().normalize();
            NodeList nodeLst = doc.getElementsByTagName("book");
            Node[] nL = convertToArray(nodeLst);
            for (Node n: nL) {
                if (GetAttribute(n).equals(this.getName())) {
                    Node chapNode = n.getChildNodes().item(ToOdd(chapterLocal));
                    return chapNode.getChildNodes().getLength() / 2;
                }
            }
        } catch (ParserConfigurationException | SAXException | IOException | DOMException | NullPointerException e) {
            System.out.println(IsKjv());
            e.printStackTrace();
        }
        return -1; // It failed :(
    }
	public String readPlainVerse(int chapter, int verse) {
        try {
            File file = new File(Files.GetScripturePath());
            DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
            DocumentBuilder db = dbf.newDocumentBuilder();
            Document doc = db.parse(file);
            doc.getDocumentElement().normalize();
            NodeList nodeLst = doc.getElementsByTagName("book");
            Node[] nL = convertToArray(nodeLst);
            for (Node n: nL) {
                if (GetAttribute(n).equals(this.getName())) {
                    Node chapNode = n.getChildNodes().item(ToOdd(chapter));
                    Node versBode = chapNode.getChildNodes().item(ToOdd(verse));
                    return versBode.getTextContent();
                }
            }
        } catch (ParserConfigurationException | SAXException | IOException | DOMException | NullPointerException e) {
            System.out.println(IsKjv());
            e.printStackTrace();
        }
        return "Error loading verse";
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
