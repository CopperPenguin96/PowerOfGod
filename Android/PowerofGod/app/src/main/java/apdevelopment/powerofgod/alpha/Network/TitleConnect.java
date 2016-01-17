package apdevelopment.powerofgod.alpha.Network;

public class TitleConnect implements Runnable {
    public String urlToLoad = "nothing";
    public String urlContent = "Sunday Lesson";
    public void run() {
        try {
            urlContent = TitleExtractor.getPageTitle(urlToLoad);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}