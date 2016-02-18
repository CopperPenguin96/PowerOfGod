package apdevelopment.powerofgod.alphaphase.BibPlans;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.os.Looper;
import android.support.v7.app.ActionBarActivity;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Toast;

import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;

import apdevelopment.powerofgod.alphaphase.ErrorLogging;
import apdevelopment.powerofgod.alphaphase.Global;
import apdevelopment.powerofgod.alphaphase.MsgBox.MsgBox;
import apdevelopment.powerofgod.alphaphase.MsgBox.ProgressBarMsgBox;
import apdevelopment.powerofgod.alphaphase.R;

public class DownloadActivity extends ActionBarActivity {

    public final Context Me = this;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_download);
        Button b;
        try {
            b = btnSearch();
            b.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    try {
                        new Thread() {
                            public void run() {
                                Looper.prepare();
                                try {
                                    String username = txtUser().getText().toString();
                                    ArrayList<String> items = new ArrayList<>();
                                    ArrayList<String> finalList = new ArrayList<>();
                                    try {
                                        Document doc = Jsoup.connect("http://godispower.us/BiblePlans/" + username + "/").get();
                                        for (Element file: doc.getAllElements())
                                        {
                                            items.add(file.attr("href"));
                                        }
                                    } catch (IOException e) {
                                        e.printStackTrace();
                                    }
                                    for (String x : items) {
                                        try {
                                            String subValue = x.substring(x.lastIndexOf("."));
                                            if (subValue.contains("bibplan")) {
                                                finalList.add(x);
                                            }
                                        } catch (Exception e) {
                                            // Skip this one.
                                        }
                                    }
                                    final ArrayAdapter<String> adapter = new ArrayAdapter<>(Me, android.R.layout.simple_list_item_1, finalList);
                                    runOnUiThread(new Runnable() {
                                        @Override
                                        public void run()
                                        {
                                            lV().setAdapter(adapter);
                                            lV().setOnItemClickListener(new AdapterView.OnItemClickListener() {
                                                @Override
                                                public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                                                    int itemPosition = position;
                                                    String itemValue = (String) lV().getItemAtPosition(position);
                                                    String url = "http://godispower.us/BiblePlans/" + txtUser().getText().toString() + "/" + itemValue;
                                                    String localPath = "/sdcard/Android/data/apdevelopment.powerofgod/BibPlans/";
                                                    File lpObj = new File(localPath);
                                                    if (!lpObj.exists()) lpObj.mkdirs();
                                                    new ProgressBarMsgBox(
                                                            "Downloading", "Downloading " + itemValue + " by " + txtUser().getText().toString(),
                                                            Me, url, "/sdcard/Android/data/apdevelopment.powerofgod/BibPlans/" + itemValue,false, false, R.drawable.progressbar2
                                                    ).Show();
                                                }
                                            });
                                        }

                                    });

                                }
                                catch (Exception ex)
                                {
                                    ex.printStackTrace();
                                    new MsgBox("Error", Global.GetStackTrace(ex), Me).Show();
                                }
                            }
                        }.start();
                    }
                    catch (Exception ex)
                    {
                        ex.printStackTrace();
                        new MsgBox("Error", Global.GetStackTrace(ex), Me).Show();
                        ErrorLogging.Write(ex);
                    }

                }
            });
        }
        catch (Exception ex)
        {
            ex.printStackTrace();
            new MsgBox("Error", "Something went wrong and it has been logged.", Me).Show();
            ErrorLogging.Write(ex);
        }
    }

    private EditText txtUser()
    {
        return (EditText) findViewById(R.id.txtGetPlans);
    }
    private ListView lV()
    {
        return (ListView) findViewById(R.id.lstDownloads);
    }

    private Button btnSearch()
    {
        return (Button) findViewById(R.id.btnSearchUser);
    }
    public void DownloadSaidPlan(View v)
    {
        if (listSize() < 1)
        {
            new MsgBox("Sorry",
                    "Either user has no Bible Plans or you have not selected one. Please try again.",
                    this
            ).Show();
        }
        else
        {

        }
    }
    public int listSize()
    {
        return lV().getCount();
    }


}
