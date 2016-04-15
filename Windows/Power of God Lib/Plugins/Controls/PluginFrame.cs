using System.Windows.Forms;

namespace Power_of_God_Lib.Plugins.Controls
{
    public partial class PluginFrame : UserControl
    {
        // ReSharper disable once InconsistentNaming
        public string FrameID;
        public PluginFrame()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Use this for frame load.
        /// 
        /// Information regarding this method: If this is NOT the main frame for the method, it won't be activated unless the plugin dev
        /// calls it themselves.
        /// 
        /// This method will only be called by the Power of God system IF the frame was loaded on the Plugin Button press on the main screen of the app
        /// </summary>
        public virtual void FrameLoad()
        {
            // Perform any frame-load content here
        }
    }
}
