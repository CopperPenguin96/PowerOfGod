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
            this.btnPurpose = new System.Windows.Forms.Button();
            this.btnLessons = new System.Windows.Forms.Button();
            this.btnDailyVerses = new System.Windows.Forms.Button();
            this.btnBibPlans = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.lblName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.headerpanel = new System.Windows.Forms.Panel();
            this.picMinimize = new System.Windows.Forms.PictureBox();
            this.picExit = new System.Windows.Forms.PictureBox();
            this.picMain = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lboListOfItems = new System.Windows.Forms.ListBox();
            this.headerpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPurpose
            // 
            this.btnPurpose.Location = new System.Drawing.Point(20, 49);
            this.btnPurpose.Name = "btnPurpose";
            this.btnPurpose.Size = new System.Drawing.Size(54, 31);
            this.btnPurpose.TabIndex = 1;
            this.btnPurpose.Text = "Purpose";
            this.btnPurpose.UseVisualStyleBackColor = true;
            this.btnPurpose.Click += new System.EventHandler(this.btnPurpose_Click);
            // 
            // btnLessons
            // 
            this.btnLessons.Location = new System.Drawing.Point(80, 49);
            this.btnLessons.Name = "btnLessons";
            this.btnLessons.Size = new System.Drawing.Size(56, 31);
            this.btnLessons.TabIndex = 2;
            this.btnLessons.Text = "Lessons";
            this.btnLessons.UseVisualStyleBackColor = true;
            this.btnLessons.Click += new System.EventHandler(this.btnLessons_Click);
            // 
            // btnDailyVerses
            // 
            this.btnDailyVerses.Location = new System.Drawing.Point(142, 49);
            this.btnDailyVerses.Name = "btnDailyVerses";
            this.btnDailyVerses.Size = new System.Drawing.Size(84, 31);
            this.btnDailyVerses.TabIndex = 3;
            this.btnDailyVerses.Text = "Daily Scripture";
            this.btnDailyVerses.UseVisualStyleBackColor = true;
            this.btnDailyVerses.Click += new System.EventHandler(this.btnDailyVerses_Click);
            // 
            // btnBibPlans
            // 
            this.btnBibPlans.Location = new System.Drawing.Point(233, 49);
            this.btnBibPlans.Name = "btnBibPlans";
            this.btnBibPlans.Size = new System.Drawing.Size(70, 31);
            this.btnBibPlans.TabIndex = 4;
            this.btnBibPlans.Text = "Bible Plans";
            this.btnBibPlans.UseVisualStyleBackColor = true;
            this.btnBibPlans.Click += new System.EventHandler(this.btnBibPlans_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(12, 173);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(266, 277);
            this.webBrowser1.TabIndex = 6;
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.DimGray;
            this.lblName.Font = new System.Drawing.Font("Oklahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(12, 83);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(375, 74);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Purpose";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(308, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 31);
            this.button1.TabIndex = 9;
            this.button1.Text = "Settings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // headerpanel
            // 
            this.headerpanel.BackColor = System.Drawing.Color.Black;
            this.headerpanel.Controls.Add(this.picMinimize);
            this.headerpanel.Controls.Add(this.picExit);
            this.headerpanel.Controls.Add(this.picMain);
            this.headerpanel.Location = new System.Drawing.Point(0, 0);
            this.headerpanel.Name = "headerpanel";
            this.headerpanel.Size = new System.Drawing.Size(410, 43);
            this.headerpanel.TabIndex = 10;
            this.headerpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.headerpanel_Paint);
            // 
            // picMinimize
            // 
            this.picMinimize.Image = ((System.Drawing.Image)(resources.GetObject("picMinimize.Image")));
            this.picMinimize.Location = new System.Drawing.Point(301, 0);
            this.picMinimize.Name = "picMinimize";
            this.picMinimize.Size = new System.Drawing.Size(43, 43);
            this.picMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMinimize.TabIndex = 3;
            this.picMinimize.TabStop = false;
            this.picMinimize.Click += new System.EventHandler(this.picMinimize_Click);
            // 
            // picExit
            // 
            this.picExit.Image = ((System.Drawing.Image)(resources.GetObject("picExit.Image")));
            this.picExit.Location = new System.Drawing.Point(350, 0);
            this.picExit.Name = "picExit";
            this.picExit.Size = new System.Drawing.Size(43, 43);
            this.picExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picExit.TabIndex = 2;
            this.picExit.TabStop = false;
            this.picExit.Click += new System.EventHandler(this.picExit_Click);
            // 
            // picMain
            // 
            this.picMain.Image = ((System.Drawing.Image)(resources.GetObject("picMain.Image")));
            this.picMain.Location = new System.Drawing.Point(3, 3);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(266, 37);
            this.picMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMain.TabIndex = 1;
            this.picMain.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox1.Location = new System.Drawing.Point(0, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(410, 425);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // lboListOfItems
            // 
            this.lboListOfItems.FormattingEnabled = true;
            this.lboListOfItems.Location = new System.Drawing.Point(284, 173);
            this.lboListOfItems.Name = "lboListOfItems";
            this.lboListOfItems.Size = new System.Drawing.Size(109, 277);
            this.lboListOfItems.TabIndex = 12;
            this.lboListOfItems.SelectedIndexChanged += new System.EventHandler(this.lboListOfItems_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(399, 456);
            this.Controls.Add(this.lboListOfItems);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnBibPlans);
            this.Controls.Add(this.btnDailyVerses);
            this.Controls.Add(this.btnLessons);
            this.Controls.Add(this.btnPurpose);
            this.Controls.Add(this.headerpanel);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Power of God";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.headerpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnPurpose;
        private System.Windows.Forms.Button btnLessons;
        private System.Windows.Forms.Button btnDailyVerses;
        private System.Windows.Forms.Button btnBibPlans;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel headerpanel;
        private System.Windows.Forms.PictureBox picMain;
        private System.Windows.Forms.PictureBox picExit;
        private System.Windows.Forms.PictureBox picMinimize;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ListBox lboListOfItems;
    }
}

