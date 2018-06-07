using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pogLib.GUI.Panels
{
    public partial class DefaultPanel : Form
    {
        public DefaultPanel()
        {
            InitializeComponent();
        }

        public List<Control> ControlList()
        {
            List<Control> cc = new List<Control>();
            foreach (Control c in Controls)
            {
                cc.Add(c);
            }
            return cc;
        }
    }
}
