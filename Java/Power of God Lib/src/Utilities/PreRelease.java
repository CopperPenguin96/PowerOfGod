/*
 * The MIT License
 *
 * Copyright 2016 super.
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
package Utilities;

/**
 *
 * @author super
 */
public class PreRelease {
    private final static String Phase = Network.VersionLetter();
    
    private static String VersionCode()
    {
        String text = Network.LatestStable(true);
        text = text.substring(text.indexOf(" ") + 1);
        for (int i = 1; i <= 26; i++)
        {
            String verText = i + ".0";
            if (text.equals(verText))
            {
                return i + "";
            }
        }
        return text;
    }
    
    private static String CurrentRelease()
    {
        if (Network.ReleaseNumber < 10)
        {
            return "00" + Network.ReleaseNumber;
        }
        else if (Network.ReleaseNumber < 100)
        {
            return "0" + Network.ReleaseNumber;
        }
        else
        {
            return "" + Network.ReleaseNumber;
        }
    }
    
    public static String GetString()
    {
        String phase = Phase;
        String vc = VersionCode() + "b";
        String cr = CurrentRelease();
        String combined = phase + vc + cr;
        return combined;
    }
}
