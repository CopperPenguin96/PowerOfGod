package apdevelopment.powerofgod.User.Online;

import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.*;
import android.content.*;
import Books.OldTestament.*;
import apdevelopment.powerofgod.ActivityBases.POGActivity;
import apdevelopment.powerofgod.ActivityBases.POGEditText;
import apdevelopment.powerofgod.MainScreen.MainScreen;
import apdevelopment.powerofgod.R;
import apdevelopment.powerofgod.User.UserInfo;

public class RegisterActivity extends POGActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register);
    }
    String txtUsername() { return ((POGEditText) findViewById(R.id.txtUsername)).Text(); }
    String txtPassword() { return ((POGEditText) findViewById(R.id.txtPassword)).Text(); }
    String txtEmail() { return ((POGEditText) findViewById(R.id.txtEmail)).Text(); }
    String txtName() { return ((POGEditText) findViewById(R.id.txtName)).Text(); }
    public void attemptRegister(View v)
    {
        UserInfo uInfo = UserInfo.CreateObject(
                txtName(), txtEmail(), txtUsername()
        );
        try {
            if (!Database.Insert(uInfo, txtPassword()))
            {
                this.ShowMsgBox("Invalid Response(s)", Database.InvalidMessage);
            }
            else
            {
                //TODO - Save and Continue!
                this.ShowMsgBox("Success!", "Thank you using Power of God!");
                UserInfo newCreatedObj = UserInfo.CreateObject(
                        txtName(),
                        txtEmail(),
                        txtUsername()
                );
                newCreatedObj.WriteJson();
                startActivity(new Intent(this, MainScreen.class));
                this.finish();
            }
        } catch (Exception e) {
            e.printStackTrace();
            this.ShowMsgBox("Oh no!", e.toString());
        }
    }

    public void StartLogin(View v)
    {
        startActivity(new Intent(this, LoginActivity.class));
        this.finish();
    }
}
