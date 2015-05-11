package apdevelopment.powerofgod.MainScreen;

import android.app.Activity;
import android.support.v7.app.ActionBarActivity;
import android.support.v7.app.ActionBar;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.content.Context;
import android.os.Build;
import android.os.Bundle;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.support.v4.widget.DrawerLayout;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import java.io.IOException;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;

import Bible.BibleConnect;
import Books.NewTestament.*;
import Books.OldTestament.*;
import apdevelopment.powerofgod.POGabActivity;
import apdevelopment.powerofgod.R;
import apdevelopment.powerofgod.TitleConnect;
import apdevelopment.powerofgod.TitleExtractor;

public class MainScreen extends POGabActivity
        implements NavigationDrawerFragment.NavigationDrawerCallbacks {

    /**
     * Fragment managing the behaviors, interactions and presentation of the navigation drawer.
     */
    private NavigationDrawerFragment mNavigationDrawerFragment;

    /**
     * Used to store the last screen title. For use in {@link #restoreActionBar()}.
     */
    private CharSequence mTitle;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main_screen);

        mNavigationDrawerFragment = (NavigationDrawerFragment)
                getSupportFragmentManager().findFragmentById(R.id.navigation_drawer);
        mTitle = getTitle();

        // Set up the drawer.
        mNavigationDrawerFragment.setUp(
                R.id.navigation_drawer,
                (DrawerLayout) findViewById(R.id.drawer_layout));
        PlaceholderFragment.CurrentScreenID = R.layout.fragment_main_screen;

    }

    @Override
    public void onNavigationDrawerItemSelected(int position) {
        // update the main content by replacing fragments
        FragmentManager fragmentManager = getSupportFragmentManager();
        fragmentManager.beginTransaction()
                .replace(R.id.container, PlaceholderFragment.newInstance(position + 1, this))
                .commit();

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
                mTitle = getString(R.string.title_section2);
                PlaceholderFragment.SundayOrThursday = "thursday";
                PlaceholderFragment.CurrentScreenID = R.layout.fragment_lesson;
                break;
            case 4:
                mTitle = getString(R.string.title_section3);
                PlaceholderFragment.CurrentScreenID = R.layout.fragment_feature_notready;
                break;
            case 5:
                mTitle = getString(R.string.title_section4);
                PlaceholderFragment.CurrentScreenID = R.layout.fragment_feature_notready;
                break;
            case 6:
                mTitle = getString(R.string.title_section5);
                PlaceholderFragment.CurrentScreenID = R.layout.fragment_feature_notready;
                break;
            case 7:
                mTitle = getString(R.string.title_section6);
                PlaceholderFragment.CurrentScreenID = R.layout.fragment_feature_notready;
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
        public static int CurrentScreenID = 0;
        /**
         * The fragment argument representing the section number for this
         * fragment.
         */
        private static final String ARG_SECTION_NUMBER = "section_number";

        /**
         * Returns a new instance of this fragment for the given section
         * number.
         */
        public static PlaceholderFragment newInstance(int sectionNumber, POGabActivity pGact) {
            PlaceholderFragment fragment = new PlaceholderFragment();
            fragment.InitFragment(pGact);
            Bundle args = new Bundle();
            args.putInt(ARG_SECTION_NUMBER, sectionNumber);
            fragment.setArguments(args);
            return fragment;
        }
        private POGabActivity theActivity = null;
        public PlaceholderFragment() {}
        public void InitFragment(POGabActivity abAct) { theActivity = abAct; }
        public static String SundayOrThursday = "NoDay";
        @Override
        public View onCreateView(LayoutInflater inflater, ViewGroup container,
                                 Bundle savedInstanceState) {

            View v = inflater.inflate(CurrentScreenID, container, false);
            int[] idArray = new int[]{R.layout.fragment_main_screen, R.layout.fragment_lesson};
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
            }
            return v;
        }

        private int CurrentCount = 0;
        private boolean displayedGood = false;
        void ConnectToWebPage(String day, View v)
        {
            String dayChosen = "http://godispower.us/";
            switch (day) {
                case "sunday":
                    dayChosen += "Sundays/" + theLastSunday(CurrentCount);
                    break;
                case "thursday":
                    dayChosen += "Thursdays/" + theLastThursday(CurrentCount);
                    break;
            }
            dayChosen += ".html";
            final int AllowedAttemptCount = 10;
            TextView lessonTitleText = (TextView) v.findViewById(R.id.lblLessonTitle);
            if (!displayedGood)
            {
                try {
                    System.out.println("---Connecting attempt for attempt " + CurrentCount +
                            " of " + AllowedAttemptCount + " for");
                    lessonTitleText.setText(TitleExtractor.getPageTitle(dayChosen));
                    WebView lessonView = (WebView) v.findViewById(R.id.lessonWebPage);
                    lessonView.setWebViewClient(new WebViewClient());
                    lessonView.getSettings().setJavaScriptEnabled(true);
                    lessonView.loadUrl(dayChosen);
                    displayedGood = true;
                    if (CurrentCount > 1)
                    {
                        theActivity.ShowMsgBox("Sorry for the delay", "The lesson you are trying to view " +
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
                        theActivity.ShowMsgBox("Error loading Lesson!", "No lesson could be loaded");
                        lessonTitleText.setText("(Error Loading Lesson)");
                        CurrentCount = 0;
                    }
                }
            }
        }
        private String theLastSunday(int neededDay)
        {
            Calendar c = Calendar.getInstance();
            c.set(Calendar.DAY_OF_WEEK,Calendar.SUNDAY);
            c.set(Calendar.HOUR_OF_DAY,0);
            c.set(Calendar.MINUTE,0);
            c.set(Calendar.SECOND,0);
            DateFormat df = new SimpleDateFormat("MM.dd.yyyy");
            if (neededDay >= 1)
            {
                for (int loopCount = 1; loopCount <= neededDay; loopCount++)
                {
                    c.add(Calendar.DATE,-7 );
                }
            }
            return df.format(c.getTime());
        }
        private String theLastThursday(int neededDay)
        {
            Calendar c = Calendar.getInstance();
            c.set(Calendar.DAY_OF_WEEK,Calendar.THURSDAY);
            c.set(Calendar.HOUR_OF_DAY,0);
            c.set(Calendar.MINUTE,0);
            c.set(Calendar.SECOND,0);
            DateFormat df = new SimpleDateFormat("MM.dd.yyyy");
            if (neededDay >= 1)
            {
                for (int loopCount = 1; loopCount <= neededDay; loopCount++)
                {
                    c.add(Calendar.DATE,-7 );
                }
            }
            return df.format(c.getTime());
        }
        @Override
        public void onAttach(Activity activity) {
            super.onAttach(activity);
            ((MainScreen) activity).onSectionAttached(
                    getArguments().getInt(ARG_SECTION_NUMBER));
        }
    }

}
