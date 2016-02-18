package apdevelopment.powerofgod.alphaphase.MsgBox;

import android.app.Activity;
import android.content.Context;
import android.content.DialogInterface;
import android.webkit.WebView;
import android.widget.ArrayAdapter;

import java.io.File;
import java.util.ArrayList;

import apdevelopment.powerofgod.alphaphase.BibPlans.BibPlan;
import apdevelopment.powerofgod.alphaphase.BibPlans.BibPlanParser;
import apdevelopment.powerofgod.alphaphase.BibPlans.Parser;
import apdevelopment.powerofgod.alphaphase.Files;
import apdevelopment.powerofgod.alphaphase.R;

/**
 * Created by apotter96 on 2/17/16.
 */
public class PlanListMsgBox extends ListMsgBox {
    public PlanListMsgBox(String title, String message, Context c, ArrayList<String> items) {
        super(title, message, c, items);
        final ArrayAdapter<String> arrayAdapter = new ArrayAdapter<>(
                c, android.R.layout.select_dialog_singlechoice);
        for (String item:items)
        {
            arrayAdapter.add(item);
            System.out.println("Adding " + item + " to the seen plan list!");
        }
        builderSimple.setNegativeButton("Cancel",
                new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        dialog.dismiss();
                    }
                }
        );
        builderSimple.setAdapter(
                arrayAdapter,
                new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        _selectedItem = arrayAdapter.getItem(which);
                        SetWebView(Bible.Bible.StartActivityContext, _selectedItem);
                    }
                }
        );
    }
    public static WebView myWebView;
    public void SetWebView(Context c, String context)
    {
        try {
            String dir = "/sdcard/Android/data/apdevelopment.powerofgod/BibPlans/" + context;
            BibPlan bp = BibPlanParser.BiblicalPlan(Files.ReadAllText(new File(dir)));
            Parser.UpdateList(dir);
            String day = Parser.PlanDays.get(Parser.PlanDays.size() - 2).substring(5);
            int DayNumber = Integer.parseInt(day);
            myWebView.loadData("<html>" +
                    "<h1>" + bp.Name + "</h1><br>" +
                    "Day #" + (DayNumber + 1) + "<br>" +
                    Parser.HtmlText(dir, DayNumber) +
                    "</html>"
                    , "text/html", "UTF-8");
        } catch (Exception e) {
            e.printStackTrace();
            new MsgBox("Sorry", "There was an issue trying to load the Bible Plan. Please try again later.", Bible.Bible.StartActivityContext).Show();
        }
    }

}
