package apdevelopment.powerofgod.alpha.MainScreen;

import java.util.TimerTask;

import apdevelopment.powerofgod.alpha.Global;

/**
 * Created by apotter96 on 7/26/2015.
 */
public class Exit extends TimerTask {
    @Override
    public void run() {
        if (Global.NeedsToClose) System.exit(0);
    }
}
