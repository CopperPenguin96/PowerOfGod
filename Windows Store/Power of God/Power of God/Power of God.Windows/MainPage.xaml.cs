using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Power_of_God.Books.Old_Testament;
//using Power_of_God.Books.New_Testament;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Power_of_God
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            
            StartApp();
        }

        private static async void StartApp()
        {
            Ezra genesisBook = new Ezra();
            genesisBook.ShowMessage("Scripture", genesisBook.ReadFormattedVerse(1, 1));
        }

    }
}
