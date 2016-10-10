using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetBible.Books.New_Testament;

namespace Power_of_God_Lib.GUI.BaseTabs
{
    public partial class PurposeTab : PowerTabPage
    {

        public PurposeTab()
        {
            InitializeComponent();
            metroLabel1.Text = "Welcome to Power of God! Thank you for " +
                          "taking the time to view this app! It could actually change your life!\n\nIf you are using " +
                          "this app expecting favor for a specific denomination, you are in for a surprise! " +
                          "This app is intended to be non-denominational! \n\nYou also may be wondering why such an " +
                          "app exists. Well, I believe that the Holy Bible is true. " +
                          new Timothy2().ReadFormattedVerse(3, 16) + " With that in mind, I also believe that the " +
                          "holy power God has is beyond compare. " + new Romans().ReadFormattedVerse(1, 16) + " I " +
                          "live to serve Jesus Christ, who is God, and will come back to earth take all who " +
                          "believe he died and rose again, to heaven. I use this app as a way to witness, to share " +
                          "this amazing truth. God bless and I hope you learn some stuff about God.";
        }
    }
}
