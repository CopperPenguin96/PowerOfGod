using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Power_of_God_Lib.Plugins
{
    public class PluginReader
    {
        public static void StartUp(Plugin pl)
        {
            PerformMethod(pl, "Plugin", "PerformStartAction", new object[] { });
        }

        public static void AppLoad(Plugin pl)
        {
            PerformMethod(pl, "Plugin", "AppLoad", new object[] {});
        }
        public static void PerformMethod(Plugin pl, string classStr, string methodStr, object[] parems)
        {
            var xlocal = System.IO.Directory.GetCurrentDirectory();
            var y = (xlocal + "\\power.of.god\\Plugins\\" + pl.Name + ".dll");
            var myLibrary = Assembly.LoadFile(y);
            if (myLibrary == null) return;
            myLibrary.GetType(classStr);
            var z = myLibrary.GetTypes();
            
            var instanceOfMyType = z[0];
            var m2 = Activator.CreateInstance(instanceOfMyType, "PurposePlugin", "apotter96", Category.Basic, false);
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
            foreach (var files in Files())
            {
                var pl = GetPlugin(files);
                if (strName == pl.Name) continue;
                if (strFileName == files.Substring(files.LastIndexOf("/", StringComparison.Ordinal))) continue;
                strName = pl.Name;
                strFileName = files;
                PluginList.Add(GetPlugin(files));
            }

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

        public static void DeleteBaddies(string baseName)
        {
            var arrayOfBadFiles = new[]
                       {
                            "Newtonsoft.Json.dll", "Newtonsoft.Json.pdb", "Newtonsoft.Json.xml", "Power of God Lib.dll",
                            "Power of God Lib.pdb", baseName + ".pdb"
                        };
            foreach (var z in arrayOfBadFiles)
            {
                File.Delete("power.of.god/Plugins/" + z);
            }
        }
        public static Plugin GetPlugin(string name)
        {
            var fArray = Files();
            if (!fArray.Any(file => file.Contains(name))) throw new Exception("Failed to read plugin.");
            var baseName = name.Substring(21, name.LastIndexOf(".", StringComparison.Ordinal) - 21);
            if (!File.Exists("power.of.god/Plugins/" + baseName + ".pogplugin"))
            {
                DeleteBaddies(baseName);
                // ReSharper disable once TailRecursiveCall
                return GetPlugin(name);
            }
            DeleteBaddies(baseName);
            var text = "power.of.god/Plugins/" + baseName + ".pogplugin";
            var jsonContent = JsonConvert.DeserializeObject<Plugin>(File.ReadAllText(text));
            return jsonContent;
        }
    }
}
