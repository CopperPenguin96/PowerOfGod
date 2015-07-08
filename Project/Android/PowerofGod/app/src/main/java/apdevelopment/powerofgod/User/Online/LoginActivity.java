package apdevelopment.powerofgod.User.Online;

import android.content.Intent;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;

import apdevelopment.powerofgod.ActivityBases.POGActivity;
import apdevelopment.powerofgod.ActivityBases.POGEditText;
import apdevelopment.powerofgod.MainScreen.MainScreen;
import apdevelopment.powerofgod.R;

public class LoginActivity extends POGActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login2);
    }
    String txtUsername() { return ((POGEditText) findViewById(R.id.txtUsername)).Text(); }
    String txtPassword() { return ((POGEditText) findViewById(R.id.txtPassword)).Text(); }
    public void LoginAction(View v)
    {
        if (txtUsername() == null || txtPassword() == null)
        {
            ShowMsgBox("Error", "Responses cannot be null. Please try again");
        }
        else
        {
            boolean LoginResult = Database.Login(txtUsername(), txtPassword());
            if (!LoginResult)
            {
                ShowMsgBox("Sorry", "Either the username or password did not match");
            }
            else
            {
                ShowMsgBox("Welcome back!", "Welcome back to Power of God!");
                startActivity(new Intent(this, MainScreen.class));
                this.finish();
            }
        }
    }
}
