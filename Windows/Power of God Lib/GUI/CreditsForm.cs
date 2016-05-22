using System;
using System.Linq;
using System.Windows.Forms;
using Power_of_God_Lib.pSystem;
using Power_of_God_Lib.Plugins;

namespace Power_of_God_Lib.GUI
{
    public partial class CreditsForm : Form
    {
        public CreditsForm()
        {
            InitializeComponent();
        }

        private void CreditsForm_Load(object sender, EventArgs e)
        {
            label1.Text = "Credit for this application goes to God, the one who made all of this possible.\n" +
                          "However, there are some people He has worked in to bring you this content.\n" +
                          "Alex oversees everything - the lessons, verses, and programming. Lynn and Rosetta do the daily verses. And Caleb does the lessons.";
        }
    }
}
