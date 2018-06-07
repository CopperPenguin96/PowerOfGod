using pogLib.Properties;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using static pogLib.Global;

namespace pogLib.GUI.Controls
{
    
    public class Button : UserControl
    {
        private Label label1;
        private PictureBox pictureBox1;

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int ID { get; set; }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get => label1.Text;
            set => label1.Text = value;
        }
        
        
        public Button(): base()
        {
            InitializeComponent();
            SetButtonHandlers();
            Width = 193;
            Height = 47;

            BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
            BackgroundImage = Resources.button_default;
            BackgroundImageLayout = ImageLayout.Center;
            ID = 0;
        }
        

        private void SetButtonHandlers()
        {
            label1.MouseHover += Hover;
            label1.MouseLeave += HoverLeave;
            label1.MouseDown += Down;
            label1.MouseUp += Up;
            Click += Clicked;
           
        }

        public new event EventHandler Click
        {
            add
            {
                base.Click += value;
                foreach (Control control in Controls)
                {
                    control.Click += value;
                }
            }
            remove
            {
                base.Click -= value;
                foreach (Control control in Controls)
                {
                    control.Click -= value;
                }
            }
        }

        private void Clicked(object sender, EventArgs e)
        {
            if (ID != CurrentScreen)
            {
                foreach (Control control in Parent.Controls)
                {
                    string type = "pogLib.GUI.Controls.Button";
                    if (control.GetType().ToString() == type)
                    {
                        control.BackgroundImage = Resources.button_default;
                    }
                }
                BackgroundImage = Resources.button_clicked;
                CurrentScreen = ID;
            }
        }

        private void Up(object sender, MouseEventArgs e)
        {
            if (ID != CurrentScreen)
            {
                IsDown = false;
                BackgroundImage = Resources.button_hover;
            }
        }

        private void Down(object sender, MouseEventArgs e)
        {
            if (ID != CurrentScreen)
            {
                IsDown = true;
                BackgroundImage = Resources.button_click;
            }
        }

        private void HoverLeave(object sender, EventArgs e)
        {
            if (ID != CurrentScreen)
            {
                BackgroundImage = Resources.button_default;
            }
        }
        public bool IsDown = false;
        private void Hover(object sender, EventArgs e)
        {
            if (ID != CurrentScreen) BackgroundImage = Resources.button_hover;
        }

        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(193, 47);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Button
            // 
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Button";
            this.Size = new System.Drawing.Size(193, 47);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
