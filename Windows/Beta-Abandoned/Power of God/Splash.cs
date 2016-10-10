using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Power_of_God.Properties;
using Power_of_God_Lib.GUI;
using Power_of_God_Lib.Utilities;

namespace Power_of_God
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
           
        }

        public int timeLeft
        {
            get;
            set;
        }
        private void Splash_Load(object sender, EventArgs e)
        {
            fade_in();
            label1.Text = Content.CopyrightText + "\n\n" + label1.Text +
                "\n\n- Team Leader: Alex Potter\n" +
                "- Daily Verses: Lynn Ryle and Rosetta Smith\n" +
                "- Music Ministry: Caleb Parry\n\n" +
                "Power of God is forever grateful for its team members.";
            timeLeft = 100;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
            }
            else
            {
                timer1.Stop();
                new MainForm().Show();
                Hide();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void fade_in()
        {
            for (var FadeIn = 0.0; FadeIn <= 1.1; FadeIn += 0.1)
            {
                this.Opacity = FadeIn;
                this.Refresh();
                Thread.Sleep(100);
            }
        }
        //Fade out:
        public void fade_out()
        {
            for (var FadeOut = 90; FadeOut >= 10; FadeOut += -10)
            {
                this.Opacity = FadeOut / 100;
                this.Refresh();
                Thread.Sleep(50);
            }
        }
    }
}
