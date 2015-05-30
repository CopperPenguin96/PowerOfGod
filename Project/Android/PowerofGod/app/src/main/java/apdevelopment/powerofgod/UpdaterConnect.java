package apdevelopment.powerofgod;

import apdevelopment.powerofgod.UserInformation.Updater;

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