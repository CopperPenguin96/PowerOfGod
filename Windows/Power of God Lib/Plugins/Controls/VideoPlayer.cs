using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Power_of_God_Lib.Properties;

namespace Power_of_God_Lib.Plugins.Controls
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
