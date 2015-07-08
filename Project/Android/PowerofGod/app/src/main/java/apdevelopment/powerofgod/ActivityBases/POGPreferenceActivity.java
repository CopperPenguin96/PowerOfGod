package apdevelopment.powerofgod.ActivityBases;

import android.app.AlertDialog;
import android.content.Intent;
import android.preference.PreferenceActivity;
import android.view.*;

import apdevelopment.powerofgod.*;
import apdevelopment.powerofgod.User.Settings.*;

/**
 * Created by apotter96 on 7/7/2015.
 */
public class POGPreferenceActivity extends PreferenceActivity {
    public void ShowMsgBox(String title, String message)
    {
        AlertDialog aDialog = new AlertDialog.Builder(this).create();
        aDialog.setTitle(title);
        aDialog.setMessage(message);
        aDialog.show();
    }
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_user_info, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_privacy) {
            startActivity(new Intent(this, PrivacyPolicyActivity.class));
            return true;
        }
        else if (id == R.id.action_settings)
        {
            //startActivity(new Intent(this, SettingsActivity.class));
            this.ShowMsgBox("Lol NO!", "Why do you want to do that? You are already there!");
        }

        return super.onOptionsItemSelected(item);
    }
}
