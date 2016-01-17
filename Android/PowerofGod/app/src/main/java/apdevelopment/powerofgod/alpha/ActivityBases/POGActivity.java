package apdevelopment.powerofgod.alpha.ActivityBases;

import android.app.AlertDialog;
import android.content.Intent;
import android.support.v7.app.ActionBarActivity;
import android.view.Menu;
import android.view.MenuItem;

import apdevelopment.powerofgod.alpha.*;
import apdevelopment.powerofgod.alpha.User.Settings.SettingsActivity;

/**
 * Created by apotter96 on 4/6/2015.
 */
public class POGActivity extends ActionBarActivity {
    //Global items are put in this class so that they can be accessed across activities
    public boolean isUserInfoActivity = false;
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
            startActivity(new Intent(this, SettingsActivity.class));
        }

        return super.onOptionsItemSelected(item);
    }
}
