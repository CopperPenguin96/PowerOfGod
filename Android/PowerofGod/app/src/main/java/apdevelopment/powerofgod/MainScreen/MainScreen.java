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
                .replace(R.id.container, PlaceholderFragment.newInstance(position + 1))
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
        public static PlaceholderFragment newInstance(int sectionNumber) {
            PlaceholderFragment fragment = new PlaceholderFragment();
            Bundle args = new Bundle();
            args.putInt(ARG_SECTION_NUMBER, sectionNumber);
            fragment.setArguments(args);
            return fragment;
        }

        public PlaceholderFragment() {

        }
        public static String SundayOrThursday = "NoDay";
        @Override
        public View onCreateView(LayoutInflater inflater, ViewGroup container,
                                 Bundle savedInstanceState) {

            View v = inflater.inflate(CurrentScreenID, container, false);
            int[] idArray = new int[]{R.layout.fragment_main_screen, R.layout.fragment_lesson};
            if (CurrentScreenID == idArray[0]) {
                TextView tV = (TextView) v.findViewById(R.id.lblNotice);
                tV.setText("Welcome to Power of God! Thank you for " +
                        "taking the time to view this app! It could actually change your life!\nIf you are using " +
                        "this app expecting favor for a specific denomination, you are in for a surprise! " +
                        "This app is intended to be non-denominational! \nYou also may be wondering why such an " +
                        "app exists. Well, I believe that the Holy Bible is true. " +
                        new Timothy2().readFormattedVerse(3, 16) + " With that in mind, I also believe that the " +
                        "holy power God has is beyond compare. " + new Romans().readFormattedVerse(1, 16) + " I " +
                        "live to serve Jesus Christ, who is God, and will come back to earth take all who " +
                        "believe he died and rose again, to heaven. I use this app as a way to witness, to share " +
                        "this amazing truth. God bless and I hope you learn some stuff about God.");
            } else if (CurrentScreenID == idArray[1]) {
                WebView lessonView = (WebView) v.findViewById(R.id.lessonWebPage);
                lessonView.setWebViewClient(new WebViewClient());
                lessonView.getSettings().setJavaScriptEnabled(true);
                lessonView.loadUrl(getWebPage(SundayOrThursday));
                TextView lessonTitleText = (TextView) v.findViewById(R.id.lblLessonTitle);
                try {
                    lessonTitleText.setText(TitleExtractor.getPageTitle(getWebPage(SundayOrThursday)));
                } catch (IOException e) {
                    e.printStackTrace();
                    lessonTitleText.setText("(Could Not Receive Title)");
                }
            }
            return v;
        }
        String getWebPage(String day)
        {
            switch (day.toLowerCase())
            {
                case "sunday":
                    return "http://godispower.us/sunday.html";
                case "thursday":
                    return "http://godispower.us/thursday.html";
                default:
                    return null;
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
