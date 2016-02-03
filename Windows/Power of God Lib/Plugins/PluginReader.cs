using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Power_of_God_Lib.Plugins
{
    public class PluginReader
    {
        public static void StartUp(Plugin pl)
        {
            pl.PerformStartAction();
        }

        public static string x = " ";
        public static void LoadPlugins()
        {
            var dir = "power.of.god/plugins/";
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            foreach (var b in from file in Directory.GetFiles(dir)
                              let extension = Path.GetExtension(file)
                              where extension != null && extension.Contains("dll")
                              select Assembly.Load(AssemblyName.GetAssemblyName(file)) 
                              into a select a.GetTypes().ToList() 
                              into myTypeList from b in myTypeList select b)
            {
                x += b.Name;
            }
            
        }
    }
}
