using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Power_of_God_Lib.GUI
{
    public partial class PowerTabPage : Form
    {
        public PowerTabPage()
        {
            InitializeComponent();
            TopLevel = false;
            Location = new Point(0, 0);
            // ReSharper disable once VirtualMemberCallInConstructor
            Dock = DockStyle.Fill;
            Visible = true;
        }
    }
}
