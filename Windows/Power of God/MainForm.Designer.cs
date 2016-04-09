using Power_of_God_Lib.Plugins;
using Power_of_God_Lib.Plugins.Controls;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnBibPlans = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lboListOfItems = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.headerpanel = new System.Windows.Forms.Panel();
            this.picMinimize = new System.Windows.Forms.PictureBox();
            this.picExit = new System.Windows.Forms.PictureBox();
            this.picMain = new System.Windows.Forms.PictureBox();
            this.PluginUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.button2 = new Power_of_God_Lib.Plugins.Button();
            this.headerpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBibPlans
            // 
            this.btnBibPlans.Location = new System.Drawing.Point(633, 383);
            this.btnBibPlans.Name = "btnBibPlans";
            this.btnBibPlans.Size = new System.Drawing.Size(70, 31);
            this.btnBibPlans.TabIndex = 4;
            this.btnBibPlans.Text = "Bible Plans";
            this.btnBibPlans.UseVisualStyleBackColor = true;
            this.btnBibPlans.Click += new System.EventHandler(this.btnBibPlans_Click);
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Oklahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(284, 3);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(366, 37);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Beta 1.0";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lboListOfItems
            // 
            this.lboListOfItems.FormattingEnabled = true;
            this.lboListOfItems.Location = new System.Drawing.Point(622, 88);
            this.lboListOfItems.Name = "lboListOfItems";
            this.lboListOfItems.Size = new System.Drawing.Size(121, 355);
            this.lboListOfItems.TabIndex = 12;
            this.lboListOfItems.SelectedIndexChanged += new System.EventHandler(this.lboListOfItems_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 49);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(141, 395);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // headerpanel
            // 
            this.headerpanel.BackColor = System.Drawing.Color.Transparent;
            this.headerpanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.headerpanel.Controls.Add(this.picMinimize);
            this.headerpanel.Controls.Add(this.picExit);
            this.headerpanel.Controls.Add(this.picMain);
            this.headerpanel.Location = new System.Drawing.Point(0, 0);
            this.headerpanel.Name = "headerpanel";
            this.headerpanel.Size = new System.Drawing.Size(755, 43);
            this.headerpanel.TabIndex = 10;
            // 
            // picMinimize
            // 
            this.picMinimize.BackColor = System.Drawing.Color.Transparent;
            this.picMinimize.Image = ((System.Drawing.Image)(resources.GetObject("picMinimize.Image")));
            this.picMinimize.Location = new System.Drawing.Point(660, 0);
            this.picMinimize.Name = "picMinimize";
            this.picMinimize.Size = new System.Drawing.Size(43, 43);
            this.picMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMinimize.TabIndex = 3;
            this.picMinimize.TabStop = false;
            this.picMinimize.Click += new System.EventHandler(this.picMinimize_Click);
            // 
            // picExit
            // 
            this.picExit.BackColor = System.Drawing.Color.Transparent;
            this.picExit.Image = ((System.Drawing.Image)(resources.GetObject("picExit.Image")));
            this.picExit.Location = new System.Drawing.Point(709, 0);
            this.picExit.Name = "picExit";
            this.picExit.Size = new System.Drawing.Size(43, 43);
            this.picExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picExit.TabIndex = 2;
            this.picExit.TabStop = false;
            this.picExit.Click += new System.EventHandler(this.picExit_Click);
            // 
            // picMain
            // 
            this.picMain.BackColor = System.Drawing.Color.Transparent;
            this.picMain.Image = ((System.Drawing.Image)(resources.GetObject("picMain.Image")));
            this.picMain.Location = new System.Drawing.Point(12, 3);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(266, 37);
            this.picMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMain.TabIndex = 1;
            this.picMain.TabStop = false;
            // 
            // PluginUpdateTimer
            // 
            this.PluginUpdateTimer.Enabled = true;
            this.PluginUpdateTimer.Interval = 1;
            this.PluginUpdateTimer.Tick += new System.EventHandler(this.PluginUpdateTimer_Tick);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(160, 49);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(456, 394);
            this.flowLayoutPanel2.TabIndex = 17;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(622, 49);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 33);
            this.button2.TabIndex = 18;
            this.button2.Load += new System.EventHandler(this.button2_Load);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Power_of_God.Properties.Resources.goldenraysabstract;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(755, 456);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnBibPlans);
            this.Controls.Add(this.headerpanel);
            this.Controls.Add(this.lboListOfItems);
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
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnBibPlans;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel headerpanel;
        private System.Windows.Forms.PictureBox picMain;
        private System.Windows.Forms.PictureBox picExit;
        private System.Windows.Forms.PictureBox picMinimize;
        public System.Windows.Forms.ListBox lboListOfItems;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private PluginFrame pluginFrame;
        private System.Windows.Forms.Timer PluginUpdateTimer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Button button2;
    }
}

