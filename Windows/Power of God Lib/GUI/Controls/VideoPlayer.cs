using System.Windows.Forms;

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
            axWindowsMediaPlayer1.URL = @path;
        }
        
    }

}
