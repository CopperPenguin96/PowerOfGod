package Bible;

/**
 * Created by apotter96 on 4/18/2015.
 */
public class BibleConnect implements Runnable {

    public void run() {
        try {
            Bible.DownloadXmlFile();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static void main(String args[]) {

    }

}