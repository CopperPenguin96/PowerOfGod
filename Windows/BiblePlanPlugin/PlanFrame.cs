using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Forms;
using BiblePlanPlugin.BibPlan;
using Power_of_God.pSystem;
using Power_of_God_Lib.pSystem;
using Power_of_God_Lib.Plugins.Controls;

namespace BiblePlanPlugin
{
    public partial class PlanFrame : PluginFrame
    {
        public PlanFrame()
        {
            InitializeComponent();
            Parser.PlanDays.CollectionChanged += CollectionChanged;
            Plugin.WBrowser.DocumentCompleted += ParseChange;
            if (Plugin.AlreadyStarted) return;
            var bPlanDialog = new BibPlanDialog();
            bPlanDialog.Show();
            Plugin.AlreadyStarted = true;
        }

        private void ParseChange(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            planView.DocumentText = Plugin.WBrowser.DocumentText;
        }

        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Content.SetListItems(Parser.PlanDays.ToList());
        }

        private void PlanFrame_Load(object sender, EventArgs e)
        {
            
        }
    }
}
