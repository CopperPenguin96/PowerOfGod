using System.Windows.Forms;
using CefSharp.WinForms;

namespace Power_of_God_Lib.GUI.Controls
{
    public partial class VideoPlayer : UserControl
    {
        public VideoPlayer()
        {
            InitializeComponent();
        }

        public void SetVideo(string path)
        {
            // "https://www.youtube.com/embed/jsNuIrO9bjU"
            var newBrowser = new ChromiumWebBrowser(path);
            Controls.Add(newBrowser);
        }
        
    }

}
