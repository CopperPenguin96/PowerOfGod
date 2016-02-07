package apdevelopment.powerofgod.alphaphase.ActivityBases;

import android.app.AlertDialog;
import android.content.Intent;
import android.support.v7.app.ActionBarActivity;
import android.view.Menu;
import android.view.MenuItem;

import apdevelopment.powerofgod.alphaphase.R;
import apdevelopment.powerofgod.alphaphase.MainScreen.NavigationDrawerFragment;
import apdevelopment.powerofgod.alphaphase.PrivacyPolicyActivity;

/**
 * Created by apotter96 on 4/18/2015.
 */
public class POGabActivity extends ActionBarActivity {
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
        getMenuInflater().inflate(R.menu.main_screen_menu, menu);
        return true;
    }
    public static NavigationDrawerFragment mNavigationDrawerFragment;
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
        return super.onOptionsItemSelected(item);
    }
}
