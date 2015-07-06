package apdevelopment.powerofgod.Network;

import apdevelopment.powerofgod.Network.Updater;

public class UpdaterConnect implements Runnable {
    public void run() {
        try {
            System.out.println("WHAT");
            Updater.UpdateResult = Updater.UpdateNotice();
        } catch (Exception e) {
            Updater.UpdateResult = e.toString();
        }
    }
    public UpdaterConnect()
    {}

}