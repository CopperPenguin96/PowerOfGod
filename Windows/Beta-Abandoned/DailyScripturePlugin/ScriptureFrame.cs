using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Power_of_God_Lib.GUI.Controls;
using Power_of_God_Lib.GUI.DialogBox;
using Power_of_God_Lib.Plugins;
using Power_of_God_Lib.Utilities;

namespace DailyScripture
{
    public partial class ScriptureFrame : PluginFrame
    {
        public ScriptureFrame()
        {
            InitializeComponent();
            Plugin.Browser1.DocumentCompleted += UpdateText;
        }

        private void UpdateText(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            htmlRichTextBox1.SetHtmlText(Plugin.Browser1.DocumentText);
        }

        private void ScriptureFrame_Load(object sender, EventArgs e)
        {
            var listStr = new List<string>();
            var currentScripture = Directory.GetFiles("power.of.god/Verses/").Length;
            for (var x = 0; x <= currentScripture; x++)
            {
                listStr.Add("Day #" + (x + 1));
            }
            Content.SetListItems(listStr);
            try
            {
                var html = !Network.DailyScriptureAlreadyPulled ? DailyScripture.GetDailyScripture() : DailyScripture.GetDailyScripture(Directory.GetFiles("power.of.god/Verses/").Length);
                htmlRichTextBox1.SetHtmlText(html);
            }
            catch (Exception ex)
            {
                ErrorLogging.Write(ex);
                new DialogBox("None today", "Sorry, there were no verse(s) for today. Check back tomorrow!").Show();
            }

        }
    }
}
