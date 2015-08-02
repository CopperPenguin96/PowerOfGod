package apdevelopment.powerofgod.MainScreen;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.Intent;
import android.os.Looper;
import android.support.v7.app.ActionBar;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.os.Bundle;
import android.support.v7.app.ActionBarActivity;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.support.v4.widget.DrawerLayout;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.widget.TextView;

import java.io.IOException;
import java.util.Timer;
import java.util.TimerTask;

import javax.script.ScriptException;

import Books.NewTestament.*;
import apdevelopment.powerofgod.ActivityBases.POGabActivity;
import apdevelopment.powerofgod.Global;
import apdevelopment.powerofgod.PrivacyPolicyActivity;
import apdevelopment.powerofgod.R;
import apdevelopment.powerofgod.Network.TitleExtractor;
import apdevelopment.powerofgod.Network.UpdaterConnect;
import apdevelopment.powerofgod.Network.Updater;
import apdevelopment.powerofgod.User.Online.RegisterActivity;
import apdevelopment.powerofgod.User.Settings.SettingsActivity;

public class MainScreen extends ActionBarActivity
        implements NavigationDrawerFragment.NavigationDrawerCallbacks {

    /**
     * Fragment managing the behaviors, interactions and presentation of the navigation drawer.
     */
    private NavigationDrawerFragment mNavigationDrawerFragment;

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
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main_screen);

        Bible.Bible.StartActivityContext = this;
        mNavigationDrawerFragment = (NavigationDrawerFragment)
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
                        if (!Updater.myResult.equals("Updated")) ShowMsgBox("Checking", Updater.UpdateNotice());
                        Looper.loop();
                    } catch (ScriptException e) {
                        e.printStackTrace();
                    } catch (IOException e) {
                        e.printStackTrace();
                    } catch (NoSuchMethodException e) {
                        e.printStackTrace();
                    }
                }
            });
            t.start();
        } catch (Exception e) {
            e.printStackTrace();
        }

        TimerTask task = new Exit();
        Timer timer = new Timer();
        timer.schedule(task, 1, 1);
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
                PlaceholderFragment.CurrentScreenID = R.layout.fragment_feature_notready;
                break;
            case 4:
                mTitle = getString(R.string.title_section4);
                PlaceholderFragment.CurrentScreenID = R.layout.fragment_feature_notready;
                break;
            case 5:
                mTitle = getString(R.string.title_section5);
                PlaceholderFragment.CurrentScreenID = R.layout.fragment_feature_notready;
                break;
            case 6:
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

        public void InitFragment(ActionBarActivity abAct) { theActivity = abAct; }
        public static String SundayOrThursday = "NoDay";
        @Override
        public View onCreateView(LayoutInflater inflater, ViewGroup container,
                                 Bundle savedInstanceState) {

            View v = inflater.inflate(CurrentScreenID, container, false);
            int[] idArray = new int[]{R.layout.fragment_main_screen, R.layout.fragment_lesson,
                                      R.layout.fragment_about_screen};
            if (CurrentScreenID == idArray[0]) {
                TextView tV = (TextView) v.findViewById(R.id.lblNotice);
                tV.setText("Welcome to Power of God! Thank you for " +
                        "taking the time to view this app! It could actually change your life!\n\nIf you are using " +
                        "this app expecting favor for a specific denomination, you are in for a surprise! " +
                        "This app is intended to be non-denominational! \nYou also may be wondering why such an " +
                        "app exists. Well, I believe that the Holy Bible is true. \n\n" +
                        new Timothy2().readFormattedVerse(3, 16) + " With that in mind, I also believe that the " +
                        "holy power God has is beyond compare. \n\n" + new Romans().readFormattedVerse(1, 16) + " I " +
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
