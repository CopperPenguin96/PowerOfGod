using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Power_of_God_Lib.pSystem;
using Power_of_God_Lib.pSystem.DialogBox;
using Power_of_God_Lib.Plugins;
using Power_of_God_Lib.Plugins.Controls;
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
            var currentScripture = Directory.GetFiles("Verses/").Length;
            for (var x = 1; x <= currentScripture; x++)
            {
                listStr.Add("Day #" + x);
            }
            Content.SetListItems(listStr);
            try
            {
                var html = DailyScripture.GetDailyScripture();
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
