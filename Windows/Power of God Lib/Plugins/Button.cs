using System;
using System.Drawing;
using System.Windows.Forms;
using Power_of_God_Lib.pSystem;
using Power_of_God_Lib.Properties;

namespace Power_of_God_Lib.Plugins
{
    public partial class Button : UserControl
    {
        public Button()
        {
            InitializeComponent();
            
        }
        public Plugin Plugin;
        public Button(Plugin pl)
        {
            InitializeComponent();
            Plugin = pl;
        }
        public void MouseLeaveEvent(object sender, EventArgs e)
        {
            SetBack(Resources.button_regular);
        }

        public void MouseClickEvent(object sender, MouseEventArgs e)
        {
            SetBack(Resources.button_clicked);
            Content.ButtonPressed = true;
            //PluginReader.PerformMethod(Plugin, "Plugin", "PerformStartAction", new object[] {});
            PluginReader.SetFrame(PluginReader.GetDefaultFrame(Plugin));

        }

        public void MouseHoverEvent(object sender, EventArgs e)
        {
            SetBack(Resources.button_inverted);
        }
        private void SetBack(Image b)
        {
            BackgroundImage = b;
        }
        public void SetText(string text)
        {
            label1.Text = text; 
        }

        private void Button_Load(object sender, EventArgs e)
        {
            label1.MouseHover += MouseHoverEvent;
            label1.MouseDown += MouseClickEvent;
            label1.MouseLeave += MouseLeaveEvent;
        }

        private void HandleMe(object sender, EventArgs e)
        {
            label1.Width = Width;
            label1.Height = Height;
        }
        //Use for TextChanged Event IF EVER NEEDED
        // [EditorBrowsable(EditorBrowsableState.Always), Browsable(true)] public new event EventHandler TextChanged;
    }
}
