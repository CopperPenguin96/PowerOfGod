/*
 * The MIT License
 *
 * Copyright 2015 apotter96.
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
package power.of.god.DailyScripture;

import Books.Book;
import java.io.ByteArrayInputStream;
import java.io.FileReader;
import java.io.IOException;
import java.util.Arrays;
import java.util.Iterator;
import java.util.Random;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import jdk.internal.org.xml.sax.SAXException;
import org.json.simple.*;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;
import org.w3c.dom.Document;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import power.of.god.AppFiles;

/**
 *
 * @author apotter96
 */
public class DailyScripture {
    public final static int VERSE_COUNT = 148;
    private static final Random rnd = new Random();
    // Scripture -> Stopped at verse 148 used
    // Last # on official list: 211 (http://www.topverses.com/Bible)
    public static String GetDailyScripture() throws DailyScriptureReadException
    {
        int SetUpRnd = rnd.nextInt(VERSE_COUNT);
        if (SetUpRnd < 0)
        {
            return GetDailyScripture();
        }
        if (SetUpRnd > VERSE_COUNT)
        {
            return GetDailyScripture();
        }
        if (SetUpRnd == YesterdayVerse())
        {
            return GetDailyScripture();
        }
        JSONParser parser = new JSONParser();
        try {
            Object obj = parser.parse(new FileReader(AppFiles.filesObj()[10]));
            JSONObject jsonObject = (JSONObject) obj;
            JSONArray verses = (JSONArray) jsonObject.get("Verses");
            Iterator<String> iterator = verses.iterator();
            int loopCount = 0;
            while (iterator.hasNext()) {
                if (loopCount == SetUpRnd)
                {
                    return readScripture(iterator.next());
                }
                else
                {
                    loopCount++; 
                }
            }

        } catch (IOException | ParseException | ParserConfigurationException | org.xml.sax.SAXException ex) {
            throw new DailyScriptureReadException("Error On File Reading", ex);
        }
        return null;
    }
    private static int YesterdayVerse()
    {
        return 1;
    }
    
    private static String readScripture(String xmlContent) throws ParserConfigurationException, 
            org.xml.sax.SAXException, IOException
    {
        String foundVerse = "Scripture Not Read Yet...";
        DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
        DocumentBuilder db = dbf.newDocumentBuilder();
        Document doc = db.parse(new ByteArrayInputStream(xmlContent.getBytes("UTF-8")));
        doc.getDocumentElement().normalize();
        String baseNode = doc.getDocumentElement().getNodeName();
        if (baseNode.equals("book"))
        {
            Node bookNode = doc.getDocumentElement();
            String book = bookNode.getAttributes().getNamedItem("name").getNodeValue();
            int chapter = Integer.parseInt(bookNode.getAttributes().getNamedItem("chapter").getNodeValue());
            int verse = Integer.parseInt(bookNode.getAttributes().getNamedItem("verse").getNodeValue());
            for (Book b: Bible.Bible.AllBooks())
            {
                if (b.getName().equals(book))
                {
                    foundVerse = b.readFormattedVerse(chapter, verse);
                }
            }
        }
        return foundVerse;
    }
}
