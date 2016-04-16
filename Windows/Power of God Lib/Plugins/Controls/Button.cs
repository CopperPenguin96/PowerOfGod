using System;
using System.Drawing;
using System.Windows.Forms;
using Power_of_God_Lib.Properties;
using Power_of_God_Lib.Utilities;

namespace Power_of_God_Lib.Plugins.Controls
{
    public partial class Button : UserControl
    {
        public Button()
        {
            InitializeComponent();
            
        }
        public Plugin Plugin;
        public bool IsPlugin;
        public Button(Plugin pl, bool isPlugin)
        {
            InitializeComponent();
            if (isPlugin) Plugin = pl;
            IsPlugin = isPlugin;
        }
        public void MouseLeaveEvent(object sender, EventArgs e)
        {
            SetBack(Resources.button_regular);
        }

        public void MouseClickEvent(object sender, MouseEventArgs e)
        {
            SetBack(Resources.button_clicked);
            if (!IsPlugin) return;
            Content.ButtonPressed = true;
            PluginReader.PerformMethod(Plugin, "Plugin", "PerformStartAction", new object[] {});
            PluginReader.SetFrame(PluginReader.GetDefaultFrame(Plugin));
            PluginReader.CurrentPlugin = Plugin;
            PluginReader.CurrentFrame.FrameLoad();
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
