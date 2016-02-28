using System;
using Power_of_God_Lib.pSystem;
using Power_of_God_Lib.Plugins;

namespace PurposePlugin
{
    public class Plugin : Power_of_God_Lib.Plugins.Plugin
    {
        public Plugin(string name, string dev, Category cat, bool act) : base(name, dev, cat, act)
        {
            
        }

        public override void AppLoad()
        {
            // Add any needed plugin start up content
            PerformStartAction(); /* If your start action trigers any events, it needs to be called 
            * first in the constructor and 2nd in the
            * Button click */
        }
        public Plugin()
        {
            Console.WriteLine("Default Constructor Init");
            
        }
        public override void PerformStartAction()
        {
            UpdateWeb.UpdateWebContent(
                "<html><head><title>Purpose</title></head><body>Welcome to Power of God! Thank you for " +
                "taking the time to view this app! It could actually change your life!<br><br>If you are using " +
                "this app expecting favor for a specific denomination, you are in for a surprise! " +
                "This app is intended to be non-denominational! <br><br>You also may be wondering why such an " +
                "app exists. Well, I believe that the Holy Bible is true. " +
                PurposeVerses.GetVerse(0) + " With that in mind, I also believe that the " +
                "holy power God has is beyond compare. " + PurposeVerses.GetVerse(1) + " I " +
                "live to serve Jesus Christ, who is God, and will come back to earth take all who " +
                "believe he died and rose again, to heaven. I use this app as a way to witness, to share " +
                "this amazing truth. God bless and I hope you learn some stuff about God.</body></html>");
        }
    }
}
