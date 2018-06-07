using static pogLib.Global;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.IO;
using pogLib.Utils;
using static pogLib.Global;

namespace pogLib.GUI
{
    public partial class SplashScreen : Form
    {

        private string[] messages1 = new string[]
        {
            "Welcome!",
            "Saved... not by works Ephesians 2:8-9",
            "Coming soon... Plugins",
            "Not ashamed... Romans 1:16"
        };

        private string[] messages2 = new string[]
        {
            "We are glad you're here!",
            "Don't worry about what you are dressed in",
            "Jesus loves you this I know...",
            "Can't wait to hear from you!"
        };

        private int heightLocation;

        // private Point leftPoint;
        private Point midPoint;
        private Point rightPoint;
        public SplashScreen()
        {
            InitializeComponent();
            lblCopyright_Splash.Text = GetCopyright() + " Visit our website at http://godispower.com/";
            lblText1.Width = this.Width;
            lblText2.Width = this.Width;
            heightLocation = lblText1.Location.Y;
            lblText1.Location = new Point(0, heightLocation);
            lblText2.Location = new Point(this.Width + 1, heightLocation);

            midPoint = lblText1.Location;
            rightPoint = lblText2.Location;
        }

        private int currentMilli = 0;
        private int setNum = 0;
        
        private string GetText()
        {
            switch (setNum)
            {
                case 0:
                    return messages1[0];
                case 1:
                    return messages2[0];
                case 2:
                    return messages1[1];
                case 3:
                    return messages2[1];
                case 4:
                    return messages1[2];
                case 5:
                    return messages2[2];
                case 6:
                    return messages1[3];
                case 7:
                    return messages2[3];
                default:
                    return "Welcome!";
            }
        }

        // bool pause = false;
        private void TextTimer_Tick(object sender, System.EventArgs e)
        {
            if (currentMilli == 50)
            {
                Global.MainForm.Show();
                Hide();
            }
            currentMilli++;
            /*if (currentMilli == 500 || pause)
            {
                pause = true;
                string message = GetText();
                if (setNum.IsEven()) lblText1.Text = message;
                else lblText2.Text = message;

                if (lblText1.Location == lblText2.Location)
                {
                    if (setNum.IsEven())
                    {
                        lblText1.Location = midPoint;
                        lblText2.Location = rightPoint;
                    }
                    else
                    {
                        lblText2.Location = midPoint;
                        lblText1.Location = rightPoint;
                    }
                }
                if (lblText1.Location == midPoint)
                {
                    while (lblText1.Location.X > this.Width - this.Width)
                    {
                        Point current = lblText1.Location;
                        lblText1.Location = new Point(current.X -= 5, current.Y);
                        Point current2 = lblText2.Location;
                        lblText2.Location = new Point(current2.X -= 5, current2.Y);
                    }
                    lblText1.Location = rightPoint;
                    setNum++;
                    currentMilli = 0;
                    pause = false;
                }
               
                if (lblText2.Location == midPoint)
                {
                    while (lblText2.Location.X > this.Width - this.Width)
                    {
                        Point current = lblText2.Location;
                        lblText2.Location = new Point(current.X -= 5, current.Y);
                        Point current1 = lblText1.Location;
                        lblText1.Location = new Point(current1.X -= 5, current1.Y);
                    }
                    lblText2.Location = rightPoint;
                    setNum++;
                    currentMilli = 0;
                    pause = false;
                }
            }
            else if (!pause)
            {
                currentMilli++;
            }*/
        }

        private void lblCopyright_Splash_Click(object sender, EventArgs e)
        {

        }

        private void lblText2_Click(object sender, EventArgs e)
        {

        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
        }
    }
}
