using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Power_of_God_Lib.pSystem;
using Power_of_God_Lib.Plugins;
using Power_of_God_Lib.Plugins.Controls;
using Power_of_God_Lib.Utilities;
using PurposePlugin;

namespace Purpose.Frames
{
    public partial class PurposeFrame : PluginFrame
    {
        public PurposeFrame()
        {
            InitializeComponent();
            label1.Text = "Welcome to Power of God! Thank you for " +
                          "taking the time to view this app! It could actually change your life!\n\nIf you are using " +
                          "this app expecting favor for a specific denomination, you are in for a surprise! " +
                          "This app is intended to be non-denominational! \n\nYou also may be wondering why such an " +
                          "app exists. Well, I believe that the Holy Bible is true. " +
                          PurposeVerses.GetVerse(0) + " With that in mind, I also believe that the " +
                          "holy power God has is beyond compare. " + PurposeVerses.GetVerse(1) + " I " +
                          "live to serve Jesus Christ, who is God, and will come back to earth take all who " +
                          "believe he died and rose again, to heaven. I use this app as a way to witness, to share " +
                          "this amazing truth. God bless and I hope you learn some stuff about God.";
            Content.SetTitle("Purpose");
        }
    }
}
