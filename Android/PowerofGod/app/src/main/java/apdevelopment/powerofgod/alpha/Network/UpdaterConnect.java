package apdevelopment.powerofgod.alpha.Network;

import apdevelopment.powerofgod.alpha.Network.Updater;

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