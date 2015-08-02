package apdevelopment.powerofgod.User.Settings;

import android.content.Intent;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.CheckBox;
import android.widget.Spinner;

import org.json.JSONException;
import org.json.simple.parser.ParseException;

import java.io.IOException;

import apdevelopment.powerofgod.ActivityBases.POGEditText;
import apdevelopment.powerofgod.ActivityBases.POGabActivity;
import apdevelopment.powerofgod.Global;
import apdevelopment.powerofgod.R;
import apdevelopment.powerofgod.StartActivity;
import apdevelopment.powerofgod.User.Online.Database;
import apdevelopment.powerofgod.User.UserInfo;

public class SettingsActivity extends POGabActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_settings);

        Spinner spinner = (Spinner) findViewById(R.id.spinnerBible);
        // Create an ArrayAdapter using the string array and a default spinner layout
        ArrayAdapter<CharSequence> adapter = ArrayAdapter.createFromResource(this,
                R.array.bible_array, android.R.layout.simple_spinner_item);
        // Specify the layout to use when the list of choices appears
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        // Apply the adapter to the spinner
        spinner.setAdapter(adapter);
        Settings.LoadFromJson();
        try {
            Global.CurrentUserInfo = UserInfo.ParseFromFile();
        } catch (IOException e) {
            e.printStackTrace();
        } catch (JSONException e) {
            e.printStackTrace();
        } catch (ParseException e) {
            e.printStackTrace();
        }
        UserInfo thisInfo = Global.CurrentUserInfo;
        txtName().setText(thisInfo.name);
        txtEmail().setText(thisInfo.email);
        txtUsername().setText(thisInfo.username);
        defaultUsername = txtName().Text();
        int loopCount = 0;
        String[] bibs = new String[] {"KJV", "NIV", "ESV", "NLT"};
        for (String x:bibs)
        {
            if (x.equals(Settings.BibleVersion))
            {
                bibleVersions().setSelection(loopCount);
            }
            loopCount++;
        }
    }
    private String defaultUsername;
    private POGEditText txtName()
    {
        return (POGEditText) findViewById(R.id.txtSettingsName);
    }
    private POGEditText txtUsername()
    {
        return (POGEditText) findViewById(R.id.txtSettingsUsername);
    }
    private POGEditText txtEmail()
    {
        return (POGEditText) findViewById(R.id.txtSettingsEmail);
    }
    private POGEditText txtPassword()
    {
        return (POGEditText) findViewById(R.id.txtSettingsPassword);
    }
    //          10        20        30       40         50        60       70       80
    //0123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789
    //http://godispower.us/Application/Users/external/updateRecord.php?oldName=Alex%20Potter&password=xrxy3749&email=alex364981@gmail.com
    private Spinner bibleVersions()
    {
        return (Spinner) findViewById(R.id.spinnerBible);
    }
    private CheckBox bibPlansEnabled()
    {
        return (CheckBox) findViewById(R.id.checkBoxBibPlans);
    }
    public void SaveGeneralSettings(View v)
    {
        Settings.BibPlansEnabled = bibPlansEnabled().isEnabled();
        Settings.BibleVersion = bibleVersions().getSelectedItem().toString();
        Settings.SaveToJson();
        this.ShowMsgBox("Saved", "Application must now close for the effect to take place.");
        Global.NeedsToClose = true;
        System.exit(0);

    }
    public void SaveAccountSettings(View v)
    {
        UserInfo uInfo = UserInfo.CreateObject(txtName().Text(), txtEmail().Text(), txtUsername().Text());
        try {
            String theUsername = Global.CurrentUserInfo.username;
            String thePassword = txtPassword().Text();
            if (!Database.Login(theUsername, thePassword)) {
                this.ShowMsgBox("Invalid Login", "Invalid password. Please try again.");
            } else {
                try {
                    if (!Database.Update(theUsername, txtPassword().Text(), uInfo)) { //Extra security
                        this.ShowMsgBox("Failed Update", "Something went wrong when trying to update. Sorry");
                    } else {
                        this.ShowMsgBox("Awesome Sauce!", "Your information was updated successfully! Application will now restart");
                        UserInfo newInformation = UserInfo.CreateObject(txtName().Text(), txtEmail().Text(), txtUsername().Text());
                        newInformation.WriteJson();
                        Intent i = getBaseContext().getPackageManager()
                                .getLaunchIntentForPackage(getBaseContext().getPackageName());
                        i.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                        this.finish();
                        startActivity(i);
                    }
                } catch (Exception ex) {
                    this.ShowMsgBox("Application Error", "Some internal issue happened and so your updates will not " +
                            "take effect.");
                }
            }
        }
        catch (Exception myException)
        {
            myException.printStackTrace();
        }
    }

}
