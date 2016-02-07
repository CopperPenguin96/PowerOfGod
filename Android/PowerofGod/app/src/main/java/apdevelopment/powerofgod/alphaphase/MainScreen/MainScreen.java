package apdevelopment.powerofgod.alphaphase.MainScreen;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.os.Looper;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBar;
import android.support.v7.app.ActionBarActivity;
import android.text.Html;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.widget.TextView;

import java.io.File;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Timer;
import java.util.TimerTask;

import Bible.Bible;
import apdevelopment.powerofgod.alphaphase.R;
import apdevelopment.powerofgod.alphaphase.BibPlans.DownloadActivity;
import apdevelopment.powerofgod.alphaphase.BibPlans.Parser;
import apdevelopment.powerofgod.alphaphase.BibPlans.PowerList;
import apdevelopment.powerofgod.alphaphase.DailyVerses.DailyScripture;
import apdevelopment.powerofgod.alphaphase.DailyVerses.DailyScriptureReadException;
import apdevelopment.powerofgod.alphaphase.Events.PowerListEvent;
import apdevelopment.powerofgod.alphaphase.Events.PowerListListener;
import apdevelopment.powerofgod.alphaphase.MsgBox.ListMsgBox;
import apdevelopment.powerofgod.alphaphase.MsgBox.YesNoMsgBox;
import apdevelopment.powerofgod.alphaphase.Network.TitleExtractor;
import apdevelopment.powerofgod.alphaphase.Network.Updater;
import apdevelopment.powerofgod.alphaphase.Network.UpdaterConnect;
import apdevelopment.powerofgod.alphaphase.PrivacyPolicyActivity;
import apdevelopment.powerofgod.alphaphase.User.Settings.Settings;
import apdevelopment.powerofgod.alphaphase.User.Settings.SettingsActivity;

public class MainScreen extends ActionBarActivity
        implements NavigationDrawerFragment.NavigationDrawerCallbacks {

    /**
     * Used to store the last screen title. For use in {@link #restoreActionBar()}.
     */
    private CharSequence mTitle;

    public void ShowMsgBox(String title, String message)
    {
        AlertDialog aDialog = new AlertDialog.Builder(this).create();
        aDialog.setTitle(title);
        aDialog.setMessage(message);
        aDialog.show();
    }

    public void listPlans(View v)
    {
        ListMsgBox lMsgBox = new ListMsgBox("Choose a Plan", "Select the plan that you would like " +
                "to read from today.", Bible.StartActivityContext, plans());
        lMsgBox.Show();

    }

    private void ChangedItem(String i)
    {
        String dir = "/sdcard/Android/data/apdevelopment.powerofgod/" + i.replace(".bibplan", "") + "/";
        File dirObj = new File(dir);
        if (!dirObj.exists())
        {
            dirObj.mkdirs();
        }
        Date currentDate = new Date();
        int currentDay = dirObj.list().length;
        File cText = new File(dir + new SimpleDateFormat("dd.MM.yyyy").format(currentDate));
        for (int x = 0; x <= currentDay; x++)
        {
            try
            {
                if (!dirObj.list()[x].contains(currentDate.toString()))
                {
                    try
                    {
                        cText.createNewFile();
                    }
                    catch (Exception e)
                    {
                        e.printStackTrace();
                    }
                }
            }
            catch (Exception ex) {
                try
                {
                    ex.printStackTrace();
                    cText.createNewFile();
                }
                catch (Exception e4)
                {
                    ex.printStackTrace();
                    e4.printStackTrace();
                }
            }
        }

    }
    public void UpdateList()
    {
        // TODO - Update Bible Plan list items here
    }
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main_screen);
        Settings.LoadFromJson();
        Bible.StartActivityContext = this;
        Parser.PlanDays = new PowerList<String>();
        /*
      Fragment managing the behaviors, interactions and presentation of the navigation drawer.
     */
        NavigationDrawerFragment mNavigationDrawerFragment = (NavigationDrawerFragment)
                getSupportFragmentManager().findFragmentById(R.id.navigation_drawer);
        mTitle = getTitle();
        // Set up the drawer.
        mNavigationDrawerFragment.setUp(
                R.id.navigation_drawer,
                (DrawerLayout) findViewById(R.id.drawer_layout));
        PlaceholderFragment.CurrentScreenID = R.layout.fragment_main_screen;
        try {
            UpdaterConnect uConnect = new UpdaterConnect();
            Thread t = new Thread(new Runnable() {

                @Override
                public void run() {
                    try {
                        Looper.prepare();
                        String updateMessage = Updater.UpdateNotice();
                        if (!Updater.UpdateWord().equals("Updated")) ShowMsgBox("Update Information", Updater.UpdateNotice());
                        Looper.loop();
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                }
            });
            t.start();
        } catch (Exception e) {
            e.printStackTrace();
        }
        Parser.PlanDays.addListListener(new PowerListListener() {
            @Override
            public void listReceived(PowerListEvent event) {

            }
        });

        /*new ProgressBarMsgBox(
                "Downloading", "I am now downloading a stupid file!",
                this, "http://godispower.us/Application/kjv.xml", "/sdcard/test.xml",
                true, false, ProgressDialog.STYLE_HORIZONTAL
        ).Show();*/
        TimerTask task = new Exit();
        Timer timer = new Timer();
        timer.schedule(task, 1, 1);

    }
    public void DownloadPlans(View v)
    {
        // TODO - Create a new window for downloading plans
        // TODO - Create a dialog that says "Please wait..... downloading" with a progress bar
        // TODO - Downloading Dialog to be called "DownloadMsgBox" and will be used for Downloding
        // Scripture in Beta 1.0
        startActivity(new Intent(this, DownloadActivity.class));
    }
    public ArrayList<String> plans()
    {
        File dir = new File("/sdcard/Android/data/apdevelopment.powerofgod/BibPlans/");
        ArrayList x = new ArrayList<>();
        for (String x2:dir.list())
        {
            x.add(x2);
        }
        return x;
    }
    @Override
    public void onBackPressed() {
        System.exit(0);
    }
    @Override
    public void onNavigationDrawerItemSelected(int position) {
        // update the main content by replacing fragments
        FragmentManager fragmentManager = getSupportFragmentManager();
        fragmentManager.beginTransaction()
                .replace(R.id.container, PlaceholderFragment.newInstance(position + 1, this))
                .commit();
    }
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_user_info, menu);
        return true;
    }
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
        else if (id == R.id.action_settings)
        {
            startActivity(new Intent(this, SettingsActivity.class));
        }
        return super.onOptionsItemSelected(item);
    }
    public void onSectionAttached(int number) {
        switch (number) {
            case 1:
                mTitle = "Power of God";
                PlaceholderFragment.CurrentScreenID = R.layout.fragment_main_screen;
                break;
            case 2:
                mTitle = getString(R.string.title_section1);
                PlaceholderFragment.SundayOrThursday = "sunday";
                PlaceholderFragment.CurrentScreenID = R.layout.fragment_lesson;
                break;
            case 3:
                mTitle = getString(R.string.title_section3);
                PlaceholderFragment.CurrentScreenID = R.layout.fragment_bibplan;
                break;
            case 4:
                mTitle = getString(R.string.title_section4);
                PlaceholderFragment.CurrentScreenID = R.layout.fragment_dailyverses;
                break;
            case 5:
                mTitle = getString(R.string.title_section6);
                PlaceholderFragment.CurrentScreenID = R.layout.fragment_about_screen; //Released in Alpha 1.3
                break;
        }
    }

    public void restoreActionBar() {
        ActionBar actionBar = getSupportActionBar();
        actionBar.setNavigationMode(ActionBar.NAVIGATION_MODE_STANDARD);
        actionBar.setDisplayShowTitleEnabled(true);
        actionBar.setTitle(mTitle);
    }


    /**
     * A placeholder fragment containing a simple view.
     */
    public static class PlaceholderFragment extends Fragment {
        static Context myActivityContext;
        public static int CurrentScreenID = 0;
        /**
         * The fragment argument representing the section number for this
         * fragment.
         */
        private static final String ARG_SECTION_NUMBER = "section_number";

        public void ShowMsgBox(String title, String message)
        {
            AlertDialog aDialog = new AlertDialog.Builder(myActivityContext).create();
            aDialog.setTitle(title);
            aDialog.setMessage(message);
            aDialog.show();
        }
        /**
         * Returns a new instance of this fragment for the given section
         * number.
         */
        public static PlaceholderFragment newInstance(int sectionNumber, ActionBarActivity pGact) {
            PlaceholderFragment fragment = new PlaceholderFragment();
            fragment.InitFragment(pGact);
            Bundle args = new Bundle();
            args.putInt(ARG_SECTION_NUMBER, sectionNumber);
            fragment.setArguments(args);
            myActivityContext = pGact;
            return fragment;
        }
        private ActionBarActivity theActivity = null;
        public PlaceholderFragment() {}

        public ArrayList<String> plans()
        {
            File dir = new File("/sdcard/Android/data/apdevelopment.powerofgod/BibPlans/");
            ArrayList x = new ArrayList<>();
            for (String x2:dir.list())
            {
                x.add(x2);
            }
            return x;
        }

        public void InitFragment(ActionBarActivity abAct) { theActivity = abAct; }
        public static String SundayOrThursday = "NoDay";
        @Override
        public View onCreateView(LayoutInflater inflater, ViewGroup container,
                                 Bundle savedInstanceState) {

            View v = inflater.inflate(CurrentScreenID, container, false);
            int[] idArray = new int[]{R.layout.fragment_main_screen, R.layout.fragment_lesson,
                                      R.layout.fragment_about_screen, R.layout.fragment_bibplan, R.layout.fragment_dailyverses};
            DailyScripture.DateString();
            if (CurrentScreenID == idArray[0]) {
                TextView tV = (TextView) v.findViewById(R.id.lblNotice);
                tV.setText("Welcome to Power of God! Thank you for " +
                        "taking the time to view this app! It could actually change your life!\n\nIf you are using " +
                        "this app expecting favor for a specific denomination, you are in for a surprise! " +
                        "This app is intended to be non-denominational! \nYou also may be wondering why such an " +
                        "app exists. Well, I believe that the Holy Bible is true. \n\n" +
                        PurposeVerses.GetVerse(0) + " With that in mind, I also believe that the " +
                        "holy power God has is beyond compare. \n\n" + PurposeVerses.GetVerse(1) + "\" I " +
                        "live to serve Jesus Christ, who is God, and will come back to earth take all who " +
                        "believe he died and rose again, to heaven. I use this app as a way to witness, to share " +
                        "this amazing truth. God bless and I hope you learn some stuff about God.");
            } else if (CurrentScreenID == idArray[1]) {
                CurrentCount = 0;
                displayedGood = false;
                ConnectToWebPage(SundayOrThursday, v);
            } else if (CurrentScreenID == idArray[2]) {
                TextView tV2 = (TextView) v.findViewById(R.id.textView3);
                tV2.setText(Updater.LatestStable());
            } else if (CurrentScreenID == idArray[4]) {
                TextView contentText = (TextView) v.findViewById(R.id.lblDaily);
                try {
                    contentText.setText(Html.fromHtml(DailyScripture.GetDailyScripture()));
                } catch (DailyScriptureReadException e) {
                    contentText.setText(":( We were unable to retrieve your verse!");
                    e.printStackTrace();
                }
            } else if (CurrentScreenID == idArray[3]) {
                //Parser.UpdateList();
                WebView wv = (WebView) v.findViewById(R.id.webView);
                wv.loadUrl("http://godispower.us/Application/welcome_bibplan.html");
                if (plans().size() < 1)
                {
                    YesNoMsgBox noPlansBox = new YesNoMsgBox("No Plans", "You don't have any plans downloaded yet. " +
                            "Would you like to download some now?", Bible.StartActivityContext);
                    if (noPlansBox.Response)
                    {
                        Bible.StartActivityContext.startActivity(new Intent(Bible.StartActivityContext,
                                DownloadActivity.class));
                    }
                    // TODO use wv.loadData("<html></html>", "text/html", "UTF-8"); to load into webview content
                }
            }
            return v;
        }

        private int CurrentCount = 0;
        private boolean displayedGood = false;
        void ConnectToWebPage(String day, View v)
        {
            String dayChosen = "http://godispower.us/Application/Lessons/" + day + ".html";
            final int AllowedAttemptCount = 10;
            final TextView lessonTitleText = (TextView) v.findViewById(R.id.lblLessonTitle);
            if (!displayedGood)
            {
                try {
                    System.out.println("---Connecting attempt for attempt " + CurrentCount +
                            " of " + AllowedAttemptCount + " for");
                    lessonTitleText.setText(TitleExtractor.getPageTitle(dayChosen));
                    WebView lessonView = (WebView) v.findViewById(R.id.lessonWebPage);
                    lessonView.setWebViewClient(new WebViewClient() {
                        @Override
                        public void onPageFinished(WebView view, String url)
                        {
                            lessonTitleText.setText(view.getTitle());
                        }
                    });
                    lessonView.getSettings().setJavaScriptEnabled(true);

                    lessonView.loadUrl(dayChosen);
                    displayedGood = true;
                    if (CurrentCount > 1)
                    {
                        ShowMsgBox("Sorry for the delay", "The lesson you are trying to view " +
                                "has not been uploaded yet. Please be patient");
                    }
                    CurrentCount = 0;
                } catch (Exception ex) {
                    ex.printStackTrace();
                    //Logger.getLogger(MainScreen.class.getName()).log(Level.SEVERE, null, ex);
                    if (CurrentCount < AllowedAttemptCount)
                    {
                        CurrentCount++;
                        ConnectToWebPage(day, v);
                    }
                    else {
                        ShowMsgBox("Error loading Lesson!", "No lesson could be loaded");
                        lessonTitleText.setText("(Error Loading Lesson)");
                        CurrentCount = 0;
                    }
                }
            }
        }
        @Override
        public void onAttach(Activity activity) {
            super.onAttach(activity);
            ((MainScreen) activity).onSectionAttached(
                    getArguments().getInt(ARG_SECTION_NUMBER));
        }
    }

}
