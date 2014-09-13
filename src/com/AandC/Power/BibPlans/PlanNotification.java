package com.AandC.Power.BibPlans;
import android.app.*;
import android.support.v4.app.*;
import com.AandC.Power.*;
import android.content.*;
import com.AandC.Power.StartUp.*;
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
public class PlanNotification
{
	void not() {
		try {
			NotificationCompat.Builder mBuilder =
				new NotificationCompat.Builder(AppContext.mainActivityContext)
				.setSmallIcon(R.drawable.ic_launcher)
				.setContentTitle("v")
				.setContentText(" is running!");
			// Creates an explicit intent for an Activity in your app
			Intent resultIntent = new Intent(AppContext.mainActivityContext, MainActivity.class);
			// The stack builder object will contain an artificial back stack for the
			// started Activity.
			// This ensures that navigating backward from the Activity leads out of
			// your application to the Home screen.
			android.app.TaskStackBuilder stackBuilder = android.app.TaskStackBuilder.create(AppContext.mainActivityContext);
			// Adds the back stack for the Intent (but not the Intent itself)
			stackBuilder.addParentStack(MainActivity.class);
			// Adds the Intent that starts the Activity to the top of the stack
			stackBuilder.addNextIntent(resultIntent);
			PendingIntent resultPendingIntent =
				stackBuilder.getPendingIntent(
				0,
				PendingIntent.FLAG_UPDATE_CURRENT
			);
			mBuilder.setContentIntent(resultPendingIntent);
			NotificationManager mNotificationManager =
				(NotificationManager) AppContext.mainActivityContext.getSystemService(Context.NOTIFICATION_SERVICE);
			// mId allows you to update the notification later on.
			mNotificationManager.notify(R.layout.main, mBuilder.build());
		} catch (Exception ex) {
			AlertDialog x = new AlertDialog.Builder(AppContext.mainActivityContext).create();
			x.setTitle(ex.toString());
			x.setMessage(ex.toString());
			x.show();
		}
	}
}
