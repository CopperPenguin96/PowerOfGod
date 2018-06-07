namespace pogLib.GUI
{
    partial class SplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.picSplash_Logo = new System.Windows.Forms.PictureBox();
            this.lblCopyright_Splash = new System.Windows.Forms.Label();
            this.picSpinner = new System.Windows.Forms.PictureBox();
            this.lblText1 = new System.Windows.Forms.Label();
            this.lblText2 = new System.Windows.Forms.Label();
            this.TextTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picSplash_Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // picSplash_Logo
            // 
            this.picSplash_Logo.BackColor = System.Drawing.Color.Transparent;
            this.picSplash_Logo.Image = global::pogLib.Properties.Resources.web;
            this.picSplash_Logo.Location = new System.Drawing.Point(13, 1);
            this.picSplash_Logo.Name = "picSplash_Logo";
            this.picSplash_Logo.Size = new System.Drawing.Size(783, 155);
            this.picSplash_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSplash_Logo.TabIndex = 0;
            this.picSplash_Logo.TabStop = false;
            // 
            // lblCopyright_Splash
            // 
            this.lblCopyright_Splash.BackColor = System.Drawing.Color.Transparent;
            this.lblCopyright_Splash.Location = new System.Drawing.Point(13, 319);
            this.lblCopyright_Splash.Name = "lblCopyright_Splash";
            this.lblCopyright_Splash.Size = new System.Drawing.Size(784, 23);
            this.lblCopyright_Splash.TabIndex = 1;
            this.lblCopyright_Splash.Text = "Copyright (c)";
            this.lblCopyright_Splash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCopyright_Splash.Click += new System.EventHandler(this.lblCopyright_Splash_Click);
            // 
            // picSpinner
            // 
            this.picSpinner.BackColor = System.Drawing.Color.Transparent;
            this.picSpinner.Image = ((System.Drawing.Image)(resources.GetObject("picSpinner.Image")));
            this.picSpinner.Location = new System.Drawing.Point(335, 199);
            this.picSpinner.Name = "picSpinner";
            this.picSpinner.Size = new System.Drawing.Size(138, 117);
            this.picSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSpinner.TabIndex = 2;
            this.picSpinner.TabStop = false;
            // 
            // lblText1
            // 
            this.lblText1.BackColor = System.Drawing.Color.Transparent;
            this.lblText1.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText1.Location = new System.Drawing.Point(12, 159);
            this.lblText1.Name = "lblText1";
            this.lblText1.Size = new System.Drawing.Size(784, 37);
            this.lblText1.TabIndex = 3;
            this.lblText1.Text = "Welcome!";
            this.lblText1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblText2
            // 
            this.lblText2.BackColor = System.Drawing.Color.Transparent;
            this.lblText2.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText2.Location = new System.Drawing.Point(110, 196);
            this.lblText2.Name = "lblText2";
            this.lblText2.Size = new System.Drawing.Size(784, 37);
            this.lblText2.TabIndex = 4;
            this.lblText2.Text = "Welcome!";
            this.lblText2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblText2.Visible = false;
            this.lblText2.Click += new System.EventHandler(this.lblText2_Click);
            // 
            // TextTimer
            // 
            this.TextTimer.Enabled = true;
            this.TextTimer.Interval = 1;
            this.TextTimer.Tick += new System.EventHandler(this.TextTimer_Tick);
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(809, 351);
            this.Controls.Add(this.lblText2);
            this.Controls.Add(this.lblText1);
            this.Controls.Add(this.picSpinner);
            this.Controls.Add(this.lblCopyright_Splash);
            this.Controls.Add(this.picSplash_Logo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Power of God";
            this.Load += new System.EventHandler(this.SplashScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picSplash_Logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSpinner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picSplash_Logo;
        private System.Windows.Forms.Label lblCopyright_Splash;
        private System.Windows.Forms.PictureBox picSpinner;
        private System.Windows.Forms.Label lblText1;
        private System.Windows.Forms.Label lblText2;
        private System.Windows.Forms.Timer TextTimer;
    }
}