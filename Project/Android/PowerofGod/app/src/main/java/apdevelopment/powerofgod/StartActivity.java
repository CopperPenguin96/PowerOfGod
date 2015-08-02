package apdevelopment.powerofgod;

import android.content.Intent;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.*;

import apdevelopment.powerofgod.MainScreen.*;
import apdevelopment.powerofgod.User.Online.*;
import apdevelopment.powerofgod.User.*;
import apdevelopment.powerofgod.User.Settings.Settings;


public class StartActivity extends ActionBarActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        //setContentView(R.layout.activity_start); //Content view not needed
        Bible.Bible.StartActivityContext = this;
        main();
    }
    public static UserInfo CurrentUserInfo;
    public void main()
    {
        try {
            boolean UserInfoExists = Files.filesObj()[3].exists();
            if (UserInfoExists)
            {
                if (!Files.filesObj()[4].exists()) Files.filesObj()[4].createNewFile();
                if (Database.NeedsNewLogin())
                {
                    startActivity(new Intent(this, LoginActivity.class));
                }
                else {
                    CurrentUserInfo = UserInfo.ParseFromFile();
                    Global.CurrentUserInfo = CurrentUserInfo;
                    Database.ReturningLogin();
                    StartMain();
                }
            }
            else {
                startActivity(new Intent(this, RegisterActivity.class));
            }
            this.finish();
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }
    void StartMain()
    {
        System.out.println("MAIN TEST");
        if (Files.filesObj()[6].exists())
        {
            Settings.LoadFromJson();
        }
        else
        {
            Settings.SaveToJson(); // Will start with Default JSON values
        }
        System.out.println("DOING THIS");
        startActivity(new Intent(this, MainScreen.class));

    }
    private static Bible.BibleVersion ConvertToEnumObject()
    {
        String bibVers = Settings.BibleVersion;
        System.out.println("-----------> " + bibVers);
        if (bibVers.equals("KJV")) return Bible.BibleVersion.KJV;
        if (bibVers.equals("ESV")) return Bible.BibleVersion.ESV;
        if (bibVers.equals("NIV")) return Bible.BibleVersion.NIV;
        if (bibVers.equals("NLT")) return Bible.BibleVersion.NLT;

        return Bible.BibleVersion.KJV;
    }
}
