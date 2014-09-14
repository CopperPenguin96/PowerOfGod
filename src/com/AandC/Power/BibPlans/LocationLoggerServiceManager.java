package com.AandC.Power.BibPlans;
import android.content.*;
import android.util.*;
import com.AandC.Power.*;

public class LocationLoggerServiceManager extends BroadcastReceiver {

	public static final String TAG = "LocationLoggerServiceManager";
	@Override
	public void onReceive(Context context, Intent intent) {
		// just make sure we are getting the right intent (better safe than sorry)
		if( "android.intent.action.BOOT_COMPLETED".equals(intent.getAction())) {
			ComponentName comp = new ComponentName(context.getPackageName(), MainActivity.class.getName());
			ComponentName service = context.startService(new Intent().setComponent(comp));
			if (null == service){
				// something really wrong here
				Log.e(TAG, "Could not start service " + comp.toString());
			}
		} else {
			Log.e(TAG, "Received unexpected intent " + intent.toString());   
		}
	}
}
