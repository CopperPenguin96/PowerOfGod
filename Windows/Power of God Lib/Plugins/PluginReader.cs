using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Windows.Forms.VisualStyles;
using Power_of_God_Lib.GUI.Controls;
using Power_of_God_Lib.pSystem;
using Power_of_God_Lib.Utilities;

namespace Power_of_God_Lib.Plugins
{
    public class PluginReader
    {

        #region ActionStarted System
        
        private static List<bool> _actionStartedList = new List<bool>();
        private static readonly List<string> ActionStartedIdList = new List<string>();

        /// <summary>
        /// Check if your item in the ActionStartedList is started
        /// </summary>
        /// <param name="id">The ID you received when you called the AssignNewAction() function</param>
        /// <returns>Returns true if Started</returns>
        public static bool CheckIfStarted(string id)
        {
            var index = -1 + ActionStartedIdList.Count(str => str == id);
            return _actionStartedList.ElementAt(index);
        }
        /// <summary>
        /// Assigns a new action
        /// </summary>
        /// <returns>Returns the ID for this action</returns>
        public static string AssignNewAction(Plugin plugin, PluginFrame plFrame)
        {
            var newMd5Hash = Md5Hasher.GetMd5Hash(MD5.Create(), plugin.Name + plugin.Developer + plugin + plFrame.FrameID);
            ActionStartedIdList.Add(newMd5Hash);
            _actionStartedList.Add(false);
            return newMd5Hash;
        }
        /// <summary>
        /// Tells the system that your action is finished
        /// </summary>
        /// <param name="id">The ID your received when you called the AssignNewAction() function</param>
        /// <returns>Returns true if successful. False if something went wrong</returns>
        public static bool AssignActionFinished(string id)
        {
            try
            {
                if (!ActionStartedIdList.Contains(id)) return true;
                if (CheckIfStarted(id)) return true;
                var oldList = _actionStartedList.ToArray();
                var index = -1 + ActionStartedIdList.Count(str => str == id);
                oldList[index] = true;
                _actionStartedList = oldList.ToList();

                return true;
            }
            catch (Exception ex)
            {
                ErrorLogging.Write(ex);
                return false;
            }
        }

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        #endregion

        public static Plugin CurrentPlugin;
        public static T GetObject<T>(Plugin pl, object[] constructArgs)
        {
            var xlocal = System.IO.Directory.GetCurrentDirectory();
            var y = (xlocal + "/power.of.god/Plugins/" + pl.Name + ".dll");
            var myLibrary = Assembly.LoadFile(y);
            if (myLibrary == null) throw new Exception("Could not get requested object type " + typeof(T).Name + " from plugin " + pl.Name);
            var z = myLibrary.GetTypes();

            foreach (var items in z.Where(items => items == typeof(T)))
            {
                return (T) Activator.CreateInstance(items, pl.Name, constructArgs);
            }
            throw new Exception("Could not get requested object type " + typeof(T).Name + " from plugin " + pl.Name);
        }

        public static PluginFrame CurrentFrame;
        public static PluginFrame OldFrame;
        public static void SetFrame(PluginFrame plFrame)
        {
            try
            {
                CurrentFrame.Dispose();
            }
            catch (Exception)
            {
                // Ignored -> First time a plugin button is pressed
            }
            if (OldFrame != null)
            {
                OldFrame = CurrentFrame;
            }
            CurrentFrame = plFrame;
        }
        public static PluginFrame GetFrame(Plugin pl, string frameid)
        {
            var xlocal = System.IO.Directory.GetCurrentDirectory();
            var y = (xlocal + "/power.of.god/Plugins/" + pl.Name + ".dll");
            var myLibrary = Assembly.LoadFile(y);
            if (myLibrary == null) return null;
            myLibrary.GetType("Plugin");
            var z = myLibrary.GetTypes();

            var instanceOfMyType = z[0];
            foreach (var f in z.Where(f => f.Name == "Plugin"))
            {
                instanceOfMyType = f;
            }
            var m2 = Activator.CreateInstance(instanceOfMyType, pl.Name, pl.Name, pl.CCategory, false);
            var m = (Plugin)m2;
            return m.GetFrame(frameid);
        }

        public static PluginFrame GetDefaultFrame(Plugin pl)
        {
            var xlocal = System.IO.Directory.GetCurrentDirectory();
            var y = (xlocal + "/power.of.god/Plugins/" + pl.Name + ".dll");
            var myLibrary = Assembly.LoadFile(y);
            if (myLibrary == null) return null;
            myLibrary.GetType("Plugin");
            var z = myLibrary.GetTypes();

            var instanceOfMyType = z[0];
            foreach (var f in z.Where(f => f.Name == "Plugin"))
            {
                instanceOfMyType = f;
            }
            var m2 = Activator.CreateInstance(instanceOfMyType, pl.Name, pl.Name, pl.CCategory, false);
            var m = (Plugin)m2;
            var frameId = m.FrameIdList()[0];
            return frameId;
        }
        public static void StartUp(Plugin pl)
        {
            PluginLoaded(pl); // Tells the system the plugin is loaded
            PerformMethod(pl, "Plugin", "PerformStartAction", new object[] { });
        }

        
        public static void AppLoad(Plugin pl)
        {
            PerformMethod(pl, "Plugin", "AppLoad", new object[] {});
        }
        public static void PerformMethod(Plugin pl, string classStr, string methodStr, object[] parems)
        {
            var xlocal = System.IO.Directory.GetCurrentDirectory();
            var y = (xlocal + "/power.of.god/Plugins/" + pl.Name + ".dll");
            var myLibrary = Assembly.LoadFile(y);
            if (myLibrary == null) return;
            myLibrary.GetType(classStr);
            var z = myLibrary.GetTypes();
            
            var instanceOfMyType = z[0];
            foreach (var f in z.Where(f => f.Name == classStr))
            {
                instanceOfMyType = f;
            }
            var m2 = Activator.CreateInstance(instanceOfMyType, pl.Name, pl.Name, pl.CCategory, false);
            var m = (Plugin)m2;
            var thisType = m.GetType();
            var theMethod = thisType.GetMethod(methodStr);
            theMethod.Invoke(m, parems);
        }

        public static List<Plugin> PluginList;

        public static string X = " ";
        public const string Directory = "power.of.god/Plugins/";
        public static void LoadPlugins()
        {
            PluginList = new List<Plugin>();
            const string dir = Directory;
            if (!System.IO.Directory.Exists(dir)) System.IO.Directory.CreateDirectory(dir);
            var strName = "";
            var strFileName = "";
            var tempList = new List<Plugin>();
            foreach (var files in Files())
            {
                try
                {
                    var pl = GetPlugin(files);
                    if (strName == pl.Name) continue;
                    if (strFileName == files.Substring(files.LastIndexOf("/", StringComparison.Ordinal))) continue;
                    strName = pl.Name;
                    strFileName = files;
                    tempList.Add(pl);
                }
                catch (Exception e)
                {
                    ErrorLogging.Write(e);
                }

            }
            
            tempList.Sort(SortByPriority);
            foreach (var t in tempList)
            {
                PluginList.Add(t);
            }
        }

        static int SortByPriority(Plugin pl1, Plugin pl2)
        {
            return pl1.Priority.CompareTo(pl2.Priority);
        }
        /*
        foreach (var b in from file in Directory.GetFiles(dir)
                              let extension = Path.GetExtension(file)
                              where extension != null && extension.Contains("dll")
                              select Assembly.Load(AssemblyName.GetAssemblyName(file)) 
                              into a select a.GetTypes().ToList() 
                              into myTypeList from b in myTypeList select b)
            {
                x += b.Name;
                if (x == "Plugin")
                {

                }
            }
        */
        public static string[] Files()
        {
            return System.IO.Directory.GetFiles(Directory);
        }

        private static readonly List<string> PluginsLoaded = new List<string>();

        public static void PluginLoaded(Plugin pl)
        {
            foreach (var p in PluginsLoaded.Where(p => p != pl.GetName()))
            {
                PluginsLoaded.Add(pl.GetName());
            }
        }

        public static bool GetPluginLoaded(string name)
        {
            return PluginsLoaded.Contains(name);
        }

        public static void DeleteBaddies(string baseName)
        {
            /*var arrayOfBadFiles = new[]
                       {
                            "Newtonsoft.Json.dll", "Newtonsoft.Json.pdb", "Newtonsoft.Json.xml", "Power of God Lib.dll",
                            "Power of God Lib.pdb", baseName + ".pdb"
                        };
            foreach (var z in arrayOfBadFiles)
            {
                File.Delete("power.of.god/Plugins/" + z);
            }*/
        }
        public static Plugin GetPlugin(string name)
        {
            var fArray = Files();

            if (fArray.Any(f => Path.GetExtension(f) == ".dll" /*|| Path.GetExtension(f) == ".pogplugin"*/))
            {
                var baseName = name.Substring(21, name.LastIndexOf(".", StringComparison.Ordinal) - 21);
                if (!fArray.Any(file => file.Contains(name))) throw new Exception("Failed to read plugin.");
                
                if (!File.Exists("power.of.god/Plugins/" + baseName + ".pogplugin"))
                {
                    throw new PluginParseException(name + " is missing the .pogplugin file");
                }
                var text = "power.of.god/Plugins/" + baseName + ".pogplugin";
                var jsonContent = JsonConvert.DeserializeObject<Plugin>(File.ReadAllText(text));
                return jsonContent;
            }
            else
            {
                throw new PluginParseException("Not a plugin");
            }

        }

        public static void ActivatePluginListMethod(int index)
        {
            PerformMethod(CurrentPlugin, "Plugin", "LboSelection", new object[] { index });
        }

        
    }

    public class PluginParseException : Exception
    {
        public PluginParseException()
        {
            
        }

        public PluginParseException(string message) : base(message)
        {
            
        }

        public PluginParseException(string message, Exception e) : base(message, e)
        {
            
        }
    }
}



