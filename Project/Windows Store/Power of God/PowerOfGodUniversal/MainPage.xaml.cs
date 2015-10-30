using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Power_of_God;
using Power_of_God.Network;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PowerOfGodUniversal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string _lastLesson;
        public MainPage()
        {
            InitializeComponent();
            ContentBrowser.NavigationCompleted += SetTitle;
           // lblVersion.Text = "Version: " + Updater.LatestStable();
            btnPurpose_Click(new object(), new RoutedEventArgs());
            //SuspensionManager.
            //this.Frame.Navigate(typeof(Register));
            
        }

        private void SetTitle(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            textName.Text = ContentBrowser.DocumentTitle;
           /* if (Files.FileExists(11).Result) new MsgBox("HA", "I found it").ShowDialog();
            else new MsgBox("NO!", "IT IS GONE!").ShowDialog();*/
        }

        private void textBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void SetContent(bool isString, string content)
        {
            switch (isString)
            {
                case true:
                    ContentBrowser.NavigateToString(content);
                    break;
                case false:
                    ContentBrowser.Source = new Uri(content);
                    break;
            }
        }

        private void btnPurpose_Click(object sender, RoutedEventArgs e)
        {
            SetContent(true, Power_of_God.Content.Purpose());
        }

        private void btnLessons_Click(object sender, RoutedEventArgs e)
        {
            SetContent(false, Power_of_God.Content.LessonUrl());
        }

        private MsgBox Unavailable(string name)
        {
            return new MsgBox("Coming Soon!",
                "We are sorry, but the feature you requested, (" + name +
                "), isn't available yet! Keep checking back for it!");
        }

        private void btnBibPlans_Click(object sender, RoutedEventArgs e)
        {
            Unavailable("Bible Plans").ShowDialog();
        }

        private void btnDailyScripture_Click(object sender, RoutedEventArgs e)
        {
            Unavailable("Daily Scripture").ShowDialog();
        }

        private void btnRadio_Click(object sender, RoutedEventArgs e)
        {
            Unavailable("Radio").ShowDialog();
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            Unavailable("About").ShowDialog();
        }

        private void btnLessons_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void textBlock_SelectionChanged_1(object sender, RoutedEventArgs e)
        {

        }

        private void ContentBrowser_LoadCompleted(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {

        }

        private void textBlock_SelectionChanged_2(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
