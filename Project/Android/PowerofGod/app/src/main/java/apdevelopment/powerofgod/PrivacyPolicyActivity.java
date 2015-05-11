package apdevelopment.powerofgod;

import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.webkit.WebView;


public class PrivacyPolicyActivity extends POGActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_privacy_policy);
        WebView wView = (WebView) findViewById(R.id.privacyPolicyWebView);
        wView.loadUrl("http://godispower.us/privacy.html");
        ShowMsgBox("Privacy Policy", "This is the privacy policy governing this application. " +
            "You may press the back button on your device at any time to go back.");
    }


}
