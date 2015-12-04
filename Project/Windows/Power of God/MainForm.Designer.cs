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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.picMain = new System.Windows.Forms.PictureBox();
            this.btnPurpose = new System.Windows.Forms.Button();
            this.btnLessons = new System.Windows.Forms.Button();
            this.btnDailyVerses = new System.Windows.Forms.Button();
            this.btnBibPlans = new System.Windows.Forms.Button();
            this.btnRadio = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.lblName = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.appToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picMain
            // 
            this.picMain.Image = ((System.Drawing.Image)(resources.GetObject("picMain.Image")));
            this.picMain.Location = new System.Drawing.Point(14, 27);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(333, 60);
            this.picMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMain.TabIndex = 0;
            this.picMain.TabStop = false;
            // 
            // btnPurpose
            // 
            this.btnPurpose.Location = new System.Drawing.Point(14, 93);
            this.btnPurpose.Name = "btnPurpose";
            this.btnPurpose.Size = new System.Drawing.Size(54, 23);
            this.btnPurpose.TabIndex = 1;
            this.btnPurpose.Text = "Purpose";
            this.btnPurpose.UseVisualStyleBackColor = true;
            this.btnPurpose.Click += new System.EventHandler(this.btnPurpose_Click);
            // 
            // btnLessons
            // 
            this.btnLessons.Location = new System.Drawing.Point(74, 93);
            this.btnLessons.Name = "btnLessons";
            this.btnLessons.Size = new System.Drawing.Size(56, 23);
            this.btnLessons.TabIndex = 2;
            this.btnLessons.Text = "Lessons";
            this.btnLessons.UseVisualStyleBackColor = true;
            this.btnLessons.Click += new System.EventHandler(this.btnLessons_Click);
            // 
            // btnDailyVerses
            // 
            this.btnDailyVerses.Location = new System.Drawing.Point(136, 93);
            this.btnDailyVerses.Name = "btnDailyVerses";
            this.btnDailyVerses.Size = new System.Drawing.Size(84, 23);
            this.btnDailyVerses.TabIndex = 3;
            this.btnDailyVerses.Text = "Daily Scripture";
            this.btnDailyVerses.UseVisualStyleBackColor = true;
            this.btnDailyVerses.Click += new System.EventHandler(this.btnDailyVerses_Click);
            // 
            // btnBibPlans
            // 
            this.btnBibPlans.Enabled = false;
            this.btnBibPlans.Location = new System.Drawing.Point(226, 93);
            this.btnBibPlans.Name = "btnBibPlans";
            this.btnBibPlans.Size = new System.Drawing.Size(70, 23);
            this.btnBibPlans.TabIndex = 4;
            this.btnBibPlans.Text = "Bible Plans";
            this.btnBibPlans.UseVisualStyleBackColor = true;
            // 
            // btnRadio
            // 
            this.btnRadio.Enabled = false;
            this.btnRadio.Location = new System.Drawing.Point(302, 93);
            this.btnRadio.Name = "btnRadio";
            this.btnRadio.Size = new System.Drawing.Size(45, 23);
            this.btnRadio.TabIndex = 5;
            this.btnRadio.Text = "Radio";
            this.btnRadio.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(20, 196);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(327, 255);
            this.webBrowser1.TabIndex = 6;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Oklahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(14, 119);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(333, 74);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Purpose";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(359, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // appToolStripMenuItem
            // 
            this.appToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.appToolStripMenuItem.Name = "appToolStripMenuItem";
            this.appToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.appToolStripMenuItem.Text = "App";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 456);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnRadio);
            this.Controls.Add(this.btnBibPlans);
            this.Controls.Add(this.btnDailyVerses);
            this.Controls.Add(this.btnLessons);
            this.Controls.Add(this.btnPurpose);
            this.Controls.Add(this.picMain);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Power of God";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picMain;
        private System.Windows.Forms.Button btnPurpose;
        private System.Windows.Forms.Button btnLessons;
        private System.Windows.Forms.Button btnDailyVerses;
        private System.Windows.Forms.Button btnBibPlans;
        private System.Windows.Forms.Button btnRadio;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem appToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}

