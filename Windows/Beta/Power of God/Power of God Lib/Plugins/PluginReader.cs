using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Power_of_God_Lib.Utilities;
using System.Xml;

namespace Power_of_God_Lib.Plugins
{
    public class PluginReader
    {
        public static List<Plugin> PluginList = new List<Plugin>();
        public delegate void PowerOfGodLoad();

        public delegate void PluginLoad();

        /// <summary>
        /// Gets object value from non-static function
        /// </summary>
        /// <typeparam name="T">The Type needed</typeparam>
        /// <param name="pl">The Plugin</param>
        /// <param name="constructArgs">The arguments passed through the type's constructor</param>
        /// <returns>object based on type and its constructors</returns>
        public static T GetObject<T>(Plugin pl, object[] constructArgs)
        {
            var xlocal = Directory.GetCurrentDirectory();
            var y = xlocal + "/power.of.god/Plugins/" + pl.Name + ".dll";
            var myLibrary = Assembly.LoadFile(y);
            if (myLibrary == null)
                throw new Exception("Could not get requested object type " + typeof(T).Name + " from plugin " + pl.Name);
            var z = myLibrary.GetTypes();
            foreach (var items in z.Where(items => items == typeof(T)))
            {
                return (T) Activator.CreateInstance(items, pl.Name, constructArgs);
            }
            throw new Exception("Could not get requested object type " + typeof(T).Name + " from plugin " + pl.Name);
        }

        /// <summary>
        /// Peforms a method in a plugin
        /// </summary>
        /// <param name="pl">The plugin</param>
        /// <param name="classStr">The class</param>
        /// <param name="methodStr">The method</param>
        /// <param name="parems">The args</param>
        public static void PerformMethod(Plugin pl, string classStr, string methodStr, object[] parems)
        {
            var xlocal = Directory.GetCurrentDirectory();
            var y = (xlocal + "\\power.of.god\\Plugins\\dll\\" + pl.Name + ".dll");
            var myLibrary = Assembly.LoadFile(y);
            if (myLibrary == null) return;
            myLibrary.GetType(classStr);
            var z = myLibrary.GetTypes();

            var instanceOfMyType = z[0];
            foreach (var f in z.Where(f => f.Name == classStr))
            {
                instanceOfMyType = f;
            }
            var m2 = Activator.CreateInstance(instanceOfMyType);
            var thisType = m2.GetType();
            var theMethod = thisType.GetMethod(methodStr);
            theMethod.Invoke(m2, parems);
        }

        
        public static void PluginInit()
        {
            var x2 = Directory.GetFiles(FileSystem.Directories[2]);
            foreach (var f in x2)
            {

                if (Path.HasExtension(f) && Path.GetExtension(f) == ".dll")
                {
                    // Ignores all other file types
                    try
                    {
                        var appPath = Application.ExecutablePath;
                        var x = appPath.Substring(0, appPath.Length - 17) + "\\" + f.Replace("/", "\\");
                        PluginList.Add(LoadPlugin(x));
                    }
                    catch (Exception ex)
                    {
                        // Ignored
                    }
                }
            }
        }

        public static Plugin LoadPlugin(string filename)
        {
            var y = filename.Replace("/", "\\");
            var myLibrary = Assembly.LoadFile(y);
            if (myLibrary == null) throw new FileNotFoundException();
            var z = myLibrary.GetTypes();

            var instanceOfMyType = z[0];
            foreach (var f in z.Where(f => f.Name == "Plugin"))
            {
                instanceOfMyType = f;
            }
            var m2 = Activator.CreateInstance(instanceOfMyType);
            var plugin =  (Plugin)m2;
            plugin.LoadManifest();
            plugin.PreparePlugin();
            return plugin;
        }

    }
    public enum PluginCategory
    {
        Basic,
        Scripture,
        Devotional,
        Game,
        Children,
        Youth,
        College,
        Single,
        Married,
        Elderly
    }
}
