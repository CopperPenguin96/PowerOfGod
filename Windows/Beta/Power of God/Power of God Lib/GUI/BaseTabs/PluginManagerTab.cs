using System.Windows.Forms;
using Power_of_God_Lib.Plugins;
using Power_of_God_Lib.Utilities;

namespace Power_of_God_Lib.GUI.BaseTabs
{
    public partial class PluginManagerTab : PowerTabPage
    {
        public PluginManagerTab()
        {
            InitializeComponent();
            foreach (Control c in Controls)
            {
                Logging.Log(">>> Control: " + c.Name);
            }
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            switch (metroComboBox1.SelectedIndex)
            {
                case 0:
                    button1.Hide();
                    button2.Show();
                    button1.Enabled = false;
                    foreach (var p in PluginReader.PluginList)
                    {
                        metroListView1.Items.Add(p.Name);
                    }
                    break;
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            PluginReader.PluginList[metroListView1.SelectedIndices[0]].PluginUninstall();
        }

        private void metroListView1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            button2.Enabled = metroListView1.SelectedItems.Count > 0;
        }
    }
}
