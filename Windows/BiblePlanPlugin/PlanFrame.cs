using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Forms;
using BiblePlanPlugin.BibPlan;
using Power_of_God_Lib.GUI.Controls;
using Power_of_God_Lib.Utilities;

namespace BiblePlanPlugin
{
    public partial class PlanFrame : PluginFrame
    {
        public PlanFrame()
        {
            InitializeComponent();
            Parser.PlanDays.CollectionChanged += CollectionChanged;
            Plugin.WBrowser.DocumentCompleted += ParseChange;
            
        }

        private void ParseChange(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            planView.DocumentText = Plugin.WBrowser.DocumentText;
        }

        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var newList = new List<string>();
            var items = Parser.PlanDays.ToList();
            var intCount = 1;
            foreach (var i in items)
            {
                if (intCount <= Parser.CurrentPlan.VerseList.Count)
                {
                    newList.Add(i);
                }
                intCount++;
            }
            Content.SetListItems(newList);
        }

        private void PlanFrame_Load(object sender, EventArgs e)
        {
            
        }

        public override void FrameLoad()
        {
            var bPlanDialog = new BibPlanDialog();
            bPlanDialog.Show();
        }

    }
}
