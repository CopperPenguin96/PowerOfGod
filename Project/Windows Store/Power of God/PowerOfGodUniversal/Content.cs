using System;
using System.Collections.Generic;
using System.Text;
using Power_of_God.Books;

namespace Power_of_God
{
    public class Content
    {
        public static string Purpose()
        {
            return "<html><head><title>Purpose</title></head><body>Welcome to Power of God! Thank you for " +
                   "taking the time to view this app! It could actually change your life!<br><br>If you are using " +
                   "this app expecting favor for a specific denomination, you are in for a surprise! " +
                   "This app is intended to be non-denominational! <br><br>You also may be wondering why such an " +
                   "app exists. Well, I believe that the Holy Bible is true.<br><br>" +
                   PurposeVerses.GetVerse(0) + " With that in mind, I also believe that the " +
                   "holy power God has is beyond compare. <br><br>" + PurposeVerses.GetVerse(1) + " I " +
                   "live to serve Jesus Christ, who is God, and will come back to earth take all who " +
                   "believe he died and rose again, to heaven. I use this app as a way to witness, to share " +
                   "this amazing truth. God bless and I hope you learn some stuff about God.</body></html>";
        }

        public static string LessonUrl()
        {
            return "http://godispower.us/Application/Lessons/sunday.html";
        }
    }
}
