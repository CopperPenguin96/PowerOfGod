package apdevelopment.powerofgod.alphaphase.User.Settings;

import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.CheckBox;
import android.widget.Spinner;

import apdevelopment.powerofgod.alphaphase.R;
import apdevelopment.powerofgod.alphaphase.ActivityBases.POGabActivity;
import apdevelopment.powerofgod.alphaphase.Global;

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

}
