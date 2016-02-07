package apdevelopment.powerofgod.alphaphase.Network;

public class UpdaterConnect implements Runnable {
    public void run() {
        try {
            Updater.UpdateResult = Updater.UpdateNotice();
        } catch (Exception e) {
            Updater.UpdateResult = e.toString();
        }
    }
    public UpdaterConnect()
    {}

}