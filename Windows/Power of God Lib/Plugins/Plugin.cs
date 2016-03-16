using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_of_God_Lib.Plugins
{
    public class Plugin
    {
        /// <summary>
        /// Initializes the plugin
        /// </summary>
        public virtual void InitPlugin()
        {
            // Plugin developer is to define plugin name and other information here.
            // Also create and start up other things the plugin needs to run
        }

        /// <summary>
        /// The name of the plugin
        /// </summary>
        public string Name;
        /// <summary>
        /// The developer of the plugin
        /// </summary>
        public string Developer;
        /// <summary>
        /// The Category of the plugin
        /// </summary>
        public Category CCategory;

        /// <summary>
        /// Not to be used. Only here for Json Parsing
        /// </summary>
        public Plugin()
        {

        }
        /// <summary>
        /// Creates the plugin object. Use if you know the cateogory, but wish to be as "Unknown"
        /// </summary>
        /// <param name="name">The plugin name</param>
        /// <param name="c">The category</param>
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

        /// <summary>
        /// Developer defined list of PluginFrames used by the plugin
        /// </summary>
        private readonly List<PluginFrame> _frames = new List<PluginFrame>
        {

        };
        /// <summary>
        /// Method to retrieve _frames
        /// </summary>
        /// <returns></returns>
        public virtual List<PluginFrame> FrameIdList()
        {
            return _frames;
        }
        /// <summary>
        /// Gets a frame by it's id
        /// </summary>
        /// <param name="idStr"></param>
        /// <returns></returns>
        public virtual PluginFrame GetFrame(string idStr)
        {
            foreach (var frame in FrameIdList().Where(frame => frame.FrameID == idStr))
            {
                return frame;
            }
            return new PluginFrame();
        }
        /// <summary>
        /// Should the app performt the app load things?
        /// </summary>
        public bool DoAppLoadStuff = true;
        /// <summary>
        /// Initializes the plugin. Recommended method
        /// </summary>
        /// <param name="name">The name of the plugin</param>
        /// <param name="dev">The name of the developer</param>
        /// <param name="cat">The category the plugin is under</param>
        /// <param name="DoAppLoad">Should this plugin be ran at appload?</param>
        public Plugin(string name, string dev, Category cat, bool DoAppLoad)
        {
            DoAppLoadStuff = DoAppLoad;
        }
        /// <summary>
        /// Performs any start action defined by the plugin developer
        /// </summary>
        public virtual void PerformStartAction()
        {
            // Perform the first function done when the user hit the button to enter your plugin
        }
        /// <summary>
        /// Performs any start actions that are to happen when Power of God starts
        /// </summary>
        public virtual void AppLoad()
        {
            // Perform any action you want to do at start up of the Power of God App
        }
        /// <summary>
        /// Performs method based on what the list box selection was
        /// </summary>
        /// <param name="index"></param>
        public virtual void LboSelection(int index)
        {
            
        }
    }

    public enum Category
    {
        Basic, Entertainment, Scripture, Study, Lessons, Other
    }
}
