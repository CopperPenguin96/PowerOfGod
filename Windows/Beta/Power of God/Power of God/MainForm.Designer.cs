namespace Power_of_God
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.settingsButton = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.settingsToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.purposeTab = new System.Windows.Forms.TabPage();
            this.MainSystem = new MetroFramework.Controls.MetroTabControl();
            ((System.ComponentModel.ISupportInitialize)(this.settingsButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.MainSystem.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.Location = new System.Drawing.Point(241, 529);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(347, 45);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Copyright © {year} by apotter96 and the Power of God Team. All rights reserved.";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel1.WrapToLine = true;
            // 
            // settingsButton
            // 
            this.settingsButton.Image = global::Power_of_God.Properties.Resources.settingsgear;
            this.settingsButton.Location = new System.Drawing.Point(594, 529);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(45, 45);
            this.settingsButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.settingsButton.TabIndex = 3;
            this.settingsButton.TabStop = false;
            this.settingsToolTip.SetToolTip(this.settingsButton, "Opens the settings window");
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Power_of_God.Properties.Resources.main;
            this.pictureBox1.Location = new System.Drawing.Point(23, 529);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(212, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // purposeTab
            // 
            this.purposeTab.Location = new System.Drawing.Point(4, 38);
            this.purposeTab.Name = "purposeTab";
            this.purposeTab.Size = new System.Drawing.Size(616, 418);
            this.purposeTab.TabIndex = 0;
            this.purposeTab.Text = "Purpose";
            // 
            // MainSystem
            // 
            this.MainSystem.Controls.Add(this.purposeTab);
            this.MainSystem.Location = new System.Drawing.Point(15, 63);
            this.MainSystem.Name = "MainSystem";
            this.MainSystem.SelectedIndex = 0;
            this.MainSystem.Size = new System.Drawing.Size(624, 460);
            this.MainSystem.TabIndex = 2;
            this.MainSystem.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.MainSystem.UseSelectable = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 597);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.MainSystem);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.metroLabel1);
            this.Name = "MainForm";
            this.Text = "Power of God";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.settingsToolTip.SetToolTip(this, "Open the settings window");
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.settingsButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.MainSystem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox settingsButton;
        private System.Windows.Forms.ToolTip settingsToolTip;
        private System.Windows.Forms.TabPage purposeTab;
        private MetroFramework.Controls.MetroTabControl MainSystem;
    }
}

