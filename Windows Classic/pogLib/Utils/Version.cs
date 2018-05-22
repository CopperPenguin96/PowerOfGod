using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pogLib.Utils
{
    public class Version
    {
        public string Name;
        public int Major;
        public int Minor;
        public int Build;
        public int Revision;

        /// <summary>
        /// Default Constructor for JSON use
        /// </summary>
        public Version()
        {

        }

        public Version(string name, int major, int minor)
        {
            Name = name;
            Major = major;
            Minor = minor;
            Build = -1;
            Revision = -1;
        }

        public Version(string name, int major, int minor, int build)
        {
            Name = name;
            Major = major;
            Minor = minor;
            Build = build;
            Revision = -1;
        }

        public Version(string name, int major, int minor, int build, int revision)
        {
            Name = name;
            Major = major;
            Minor = minor;
            Build = build;
            Revision = revision;
        }

        public override string ToString()
        {
            string finalVersion = Name + " " + Major + "." + Minor;
            if (Build > -1)
            {
                finalVersion += "." + Build;
                if (Revision > -1)
                {
                    finalVersion += "." + Revision;
                }
            }
            return finalVersion;
        }
    }
}
