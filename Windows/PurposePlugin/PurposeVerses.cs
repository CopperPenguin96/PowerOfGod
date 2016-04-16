using Power_of_God_Lib.User;

namespace PurposePlugin
{
    public class PurposeVerses
    {

        public static string GetTimothyKjv()
        {
            return "2 Timtohy 3:16 (KJV) - \"All scripture is given by inspiration of God, and is profitable for doctrine, for reproof, for correction, for instruction in righteousness:\"";
        }
        public static string GetRomansKjv()
        {
            return "Romans 1:16 (KJV) - \"For I am not ashamed of the gospel of Christ: for it is the power of God unto salvation to every one that believeth; to the Jew first, and also to the Greek.\"";
        }

        public static string GetTimothyNiv()
        {
            return "2 Timothy 3:16 (NIV) - \"All Scripture is God-breathed and is useful for teaching, rebuking, correcting and training in righteousness,\"";
        }

        public static string GetRomansNiv()
        {
            return "Romans 1:16 (NIV) - \"I am not ashamed of the gospel, because it is the power of God for the salvation of everyone who believes: first for the Jew, then for the Gentile.";
        }

        public static string GetTimothyEsv()
        {
            return "2 Timothy 3:16 (ESV) - \"All Scripture is breathed out by God and profitable for teaching, for reproof, for correction, and for training in righteousness,";
        }

        public static string GetRomansEsv()
        {
            return "Romans 1:16 (ESV) - \"For I am not ashamed of the gospel, for it is the power of God for salvation to everyone who believes, to the Jew first and also to the Greek.\"";
        }

        public static string GetTimothyNlt()
        {
            return "2 Timothy 3:16 (NLT) - \"All Scripture is inspired by God and is useful to teach us what is true and to make us realize what is wrong in our lives. It straightens us out and teaches us to do what is right.\"";
        }

        public static string GetRomansNlt()
        {
            return "Romans 1:16 (NLT) - \"For I am not ashamed of this Good News about Christ. It is the power of God at work, saving everyone who believes--Jews first and also Gentiles.\"";
        }

        public static string GetVerse(int verse)
        {
            switch (Settings.UserSettings.scriptver)
            {
                case "KJV":
                    switch (verse)
                    {
                        case 0:
                            return GetTimothyKjv();
                        case 1:
                            return GetRomansKjv();
                    }
                    break;
                case "NIV":
                    switch (verse)
                    {
                        case 0:
                            return GetTimothyNiv();
                        case 1:
                            return GetRomansNiv();
                    }
                    break;
                case "ESV":
                    switch (verse)
                    {
                        case 0:
                            return GetTimothyEsv();
                        case 1:
                            return GetRomansEsv();
                    }
                    break;
                case "NLT":
                    switch (verse)
                    {
                        case 0:
                            return GetTimothyNlt();
                        case 1:
                            return GetRomansNlt();
                    }
                    break;
            }
            return "Scripture Load Error.";
        }
    }
}
