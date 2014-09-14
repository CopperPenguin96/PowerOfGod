package com.AandC.Power.BibPlans;
import android.content.*;
import android.util.*;
import com.AandC.Power.*;
/*
 Copyright 2014 apotter96

 Licensed under the Apache License, Version 2.0 (the "License");
 you may not use this file except in compliance with the License.
 You may obtain a copy of the License at

 http://www.apache.org/licenses/LICENSE-2.0

 Unless required by applicable law or agreed to in writing, software
 distributed under the License is distributed on an "AS IS" BASIS,
 WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 See the License for the specific language governing permissions and
 limitations under the License.
 */
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
