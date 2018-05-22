using static pogLib.Global;
using System.Windows.Forms;

namespace pogLib.GUI
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            lblCopyright_Splash.Text = GetCopyright() + " Visit our website at http://godispower.com/";
        }
    }
}
