using pogLib.GUI;
using System;

namespace pogLib
{
    public class Global
    {
        
        public static SplashScreen SplashScreen => new SplashScreen();

        public static string GetCopyright()
        {
            string year = ("" + DateTime.Now.Year).Substring(2);
            return $"Copyright © 2014-{year} by AP Development and the Power of God Team. All rights reserved.";
        }
    }
}
