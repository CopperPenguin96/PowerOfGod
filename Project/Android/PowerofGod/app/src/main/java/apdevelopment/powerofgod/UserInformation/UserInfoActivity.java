package apdevelopment.powerofgod.UserInformation;

import android.app.AlertDialog;
import android.content.Intent;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.EditText;

import java.io.File;

import Bible.BibleConnect;
import apdevelopment.powerofgod.Files;
import apdevelopment.powerofgod.JsonWriteException;
import apdevelopment.powerofgod.MainScreen.MainScreen;
import apdevelopment.powerofgod.POGActivity;
import apdevelopment.powerofgod.POGEditText;
import apdevelopment.powerofgod.R;


public class UserInfoActivity extends POGActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_user_info);
        this.isUserInfoActivity = true;
        try {
            File f = Files.filesObj()[2];
            if (!f.exists())
            {
                f.createNewFile();
                (new Thread(new BibleConnect())).start();
            }

        } catch (Exception e) {
            ShowMsgBox("App Error", "The app could not be run because of an error with the scripture");
            e.printStackTrace();
        }
        txtName = (POGEditText) findViewById(R.id.txtName);
        txtAge = (POGEditText) findViewById(R.id.txtAge);
        txtDen = (POGEditText) findViewById(R.id.txtDen);
        if (Files.filesObj()[0].exists() && Files.filesObj()[1].exists())
        {
            this.startActivity(new Intent(this, MainScreen.class));
        }
    }
    public void GetHelp(View v)
    {
        ShowMsgBox("User Info Help", "The User Info is simple. Before you start, if you have not " +
            "read the Privacy Policy concerning this application, it is advised you do so. Go to " +
            "http://godispower.us/privacy.html to read it. \n" +
            "\nPower of God collects the follow information: \n" +
            "Name (Can be anything but is recommended that you use your real first name)" +
            "\nAge (Please use your real age. This app needs to be able to see demograpics)" +
            "\nDenomination (What kind of church? Baptist? Catholic? Church of Christ?)");
    }
    POGEditText txtName;
    POGEditText txtAge;
    POGEditText txtDen;
    String changingString = "You need to fix the following errors: \n\n";
    final String finalString = "You need to fix the following errors: \n\n";
    public void SubmitForm(View v)
    {
        changingString = finalString; //Must be reset, or user can't continue after corrections
        if (FormHasError())
        {
            ShowMsgBox("Mistakes in form", changingString);
        }
        else
        {
            UserInfo.SetName(txtName.toString());
            UserInfo.SetAge(Integer.parseInt(txtAge.toString()));
            UserInfo.SetDenomination(txtDen.toString());
            try {
                Json.Write();
                this.startActivity(new Intent(this, MainScreen.class));
            } catch (JsonWriteException e) {
                e.printStackTrace();
                ShowMsgBox("Error!", "There was an error when trying to save your info");
            }
        }
    }

    boolean FormHasError()
    {
        if (txtName.toString().matches("")) {
            AppendErrors("You must enter in a name");
        }
        else
        {
            if (txtName.toString().length() > 250)
            {
                AppendErrors("A name over 250 characters is not allowed. You have " +
                    txtName.toString().length() + " characters");
            }
        }
        if (txtAge.toString().matches("")) {
            AppendErrors("What? Your age can't be nothing!");
        }
        else
        {
            try
            {
                int age = Integer.parseInt(txtAge.toString());
                if (age < 13)
                {
                    AppendErrors("You must be at least 13 to use this app.");
                }
                else if (age > 200)
                {
                    AppendErrors("I don't think you are over 200 years old!");
                }
            }
            catch (NumberFormatException ex)
            {
                AppendErrors("Numbers only in your age, please");
            }
        }
        if (txtDen.toString().matches(""))
        {
            AppendErrors("Your denomination is important! If you are non-denominational, then put that!");
            txtDen.setText("non-denominational");
        }
        return !(changingString.equals(finalString));
    }

    void AppendErrors(String s)
    {
        changingString += "-" + s + "\n";
    }
}
