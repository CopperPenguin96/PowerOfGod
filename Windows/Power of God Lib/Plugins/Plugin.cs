using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_of_God_Lib.Plugins
{
    public class Plugin
    {
        public string Name;
        public string Developer;
        public Category CCategory;
        /// <summary>
        /// Creates the plugin object. Use if you know the cateogory, but wish to be as "Unknown"
        /// </summary>
        /// <param name="name"></param>
        /// <param name="c"></param>
        public Plugin(string name, Category c)
        {
            Name = name;
            Developer = "Unknown";
            CCategory = c;
        }
        /// <summary>
        /// Creates the plugin object. Use if you wish to be as "Unknown" and the Category is just basic
        /// </summary>
        /// <param name="name">The name of the plugin</param>
        public Plugin(string name)
        {
            Name = name;
            Developer = "Unknown";
            CCategory = Category.Basic;
        }
        /// <summary>
        /// Creates the plugin object. Use if the Category is just basic
        /// </summary>
        /// <param name="name">The name of the plugin</param>
        /// <param name="dev">Your username</param>
        public Plugin(string name, string dev)
        {
            Name = name;
            Developer = dev;
            CCategory = Category.Basic;
        }
        /// <summary>
        /// Creates the plugin object.
        /// </summary>
        /// <param name="name">The name of the plugin</param>
        /// <param name="dev">Your username</param>
        /// <param name="cat">The category the plugin is under. Use "other" if you don't know</param>
        public Plugin(string name, string dev, Category cat)
        {
            Name = name;
            Developer = dev;
            CCategory = cat;
        }

    }

    public enum Category
    {
        Basic, Entertainment, Scripture, Study, Lessons, Other
    }
}
