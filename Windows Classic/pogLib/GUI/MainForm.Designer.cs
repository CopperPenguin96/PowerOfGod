namespace pogLib.GUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.button1 = new pogLib.GUI.Controls.Button();
            this.button2 = new pogLib.GUI.Controls.Button();
            this.button3 = new pogLib.GUI.Controls.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.picWeLive = new System.Windows.Forms.PictureBox();
            this.picWeLive2 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWeLive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeLive2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Font = new System.Drawing.Font("ABeeZee", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ID = 0;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(193, 47);
            this.button1.TabIndex = 0;
            this.button1.Text = "Purpose";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Font = new System.Drawing.Font("ABeeZee", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ID = 1;
            this.button2.Location = new System.Drawing.Point(202, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(193, 47);
            this.button2.TabIndex = 1;
            this.button2.Text = "Service";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.Font = new System.Drawing.Font("ABeeZee", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ID = 2;
            this.button3.Location = new System.Drawing.Point(401, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(193, 47);
            this.button3.TabIndex = 2;
            this.button3.Text = "More Coming Soon!";
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Image = global::pogLib.Properties.Resources.web;
            this.picLogo.Location = new System.Drawing.Point(210, 13);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(490, 78);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 3;
            this.picLogo.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.button3);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(156, 97);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(599, 51);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 154);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(886, 511);
            this.panel1.TabIndex = 5;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BackgroundImage = global::pogLib.Properties.Resources.settings_icon2;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(761, 101);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(43, 44);
            this.button4.TabIndex = 6;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 668);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(886, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Copyright © 2014-18 by AP Development and the Power of God Team. All rights reser" +
    "ved. | Version: Corinth 1.0";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picWeLive
            // 
            this.picWeLive.BackColor = System.Drawing.Color.Transparent;
            this.picWeLive.Image = global::pogLib.Properties.Resources.LIVE;
            this.picWeLive.Location = new System.Drawing.Point(12, 12);
            this.picWeLive.Name = "picWeLive";
            this.picWeLive.Size = new System.Drawing.Size(189, 79);
            this.picWeLive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picWeLive.TabIndex = 8;
            this.picWeLive.TabStop = false;
            this.picWeLive.Visible = false;
            // 
            // picWeLive2
            // 
            this.picWeLive2.BackColor = System.Drawing.Color.Transparent;
            this.picWeLive2.Image = global::pogLib.Properties.Resources.LIVE;
            this.picWeLive2.Location = new System.Drawing.Point(709, 12);
            this.picWeLive2.Name = "picWeLive2";
            this.picWeLive2.Size = new System.Drawing.Size(189, 79);
            this.picWeLive2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picWeLive2.TabIndex = 9;
            this.picWeLive2.TabStop = false;
            this.picWeLive2.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::pogLib.Properties.Resources.promo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(910, 699);
            this.Controls.Add(this.picWeLive2);
            this.Controls.Add(this.picWeLive);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.picLogo);
            this.MaximumSize = new System.Drawing.Size(926, 738);
            this.MinimumSize = new System.Drawing.Size(926, 738);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picWeLive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeLive2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.Button button1;
        private Controls.Button button2;
        private Controls.Button button3;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picWeLive;
        private System.Windows.Forms.PictureBox picWeLive2;
        private System.Windows.Forms.Timer timer1;
    }
}