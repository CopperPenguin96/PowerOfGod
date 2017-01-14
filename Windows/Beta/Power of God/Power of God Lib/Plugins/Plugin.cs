using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using Power_of_God_Lib.GUI;
using Power_of_God_Lib.Utilities;

namespace Power_of_God_Lib.Plugins
{
    public enum PluginMethods { AppLoad, PluginLoad }
    public enum PluginFunctions {  }
    public class Plugin
    {
        public string Name;
        public string FileName;
        public PluginCategory[] Categories;
        public int MainFrame = 0;
        public bool HasTab;

        public PluginReader.PowerOfGodLoad AppLoad;
        public PluginReader.PluginLoad PluginLoad;
        public PluginReader.PluginUninstall PluginUninstall;
        public string ManifestLocation;
        public PowerTabPage[] TabPages =
        {

        };

        public Plugin()
        {
            PreparePlugin();
        }

        public virtual void PreparePlugin()
        {
            /*AppLoad = AppLoaded;
            PluginLoad = PluginLoaded;*/
            ManifestLocation = FileSystem.Directories[3] + Name + "/" + "manifest.xml";
            //LoadManifest(); // Loads Manifest
        }

        public void SaveManifest()
        {
            var xmlSettings = new XmlWriterSettings
            {
                Indent = true,
                CloseOutput = true
            };
            var xmlWriter = XmlWriter.Create(ManifestLocation, xmlSettings);
            
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Plugin");
            xmlWriter.WriteElementString("FileName", FileName);
            xmlWriter.WriteStartElement("Categories");
            foreach (var c in Categories)
            {
                xmlWriter.WriteElementString("Category", "" + (int) c);
            }
            xmlWriter.WriteEndElement();
            xmlWriter.WriteElementString("MainFrame", "" + MainFrame);
            xmlWriter.WriteElementString("HasTab", HasTab ? "true" : "false");
            // Include here any new variables that go with the xml writer
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();

        }

        public void LoadManifest()
        {
            var doc = new XmlDocument();
            doc.Load(ManifestLocation);
            var xmlElement = doc.DocumentElement;
            if (xmlElement == null || xmlElement.Name != "Plugin") throw new PluginException("Not a valid plugin file");
            foreach (XmlNode cn in xmlElement.ChildNodes)
            {
                switch (cn.Name)
                {
                    case "FileName":
                        FileName = cn.InnerText;
                        break;
                    case "Categories":
                        Categories =
                            (from XmlNode c in cn.ChildNodes
                                where c.Name == "Category"
                                select (PluginCategory) int.Parse(c.InnerText)).ToArray();
                        break;
                    case "MainFrame":
                        MainFrame = int.Parse(cn.InnerText);
                        break;
                    case "HasTab":
                        HasTab = cn.InnerText == "true";
                        break;
                }
            }
        }
        public void ExecutePluginMethod(PluginMethods pm)
        {
            if (pm == PluginMethods.AppLoad) AppLoad();
            if (pm == PluginMethods.PluginLoad) PluginLoad();
        }

        public object ExecutePluginFunction(PluginFunctions fm)
        {
            throw new Exception("No functions yet.");
        }
        public void PluginLoaded()
        {
            //throw new NotImplementedException();
        }

        public void AppLoaded()
        {
            //MessageBox.Show("On Power of God Load");
        }
    }
}
