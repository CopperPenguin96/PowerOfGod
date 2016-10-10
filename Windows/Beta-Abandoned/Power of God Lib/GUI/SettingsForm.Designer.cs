namespace Power_of_God_Lib.GUI
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.picMain = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkUpdateChecking = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboBibleVersion = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.gboPlugins = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnDeletePlugin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gboPlugins.SuspendLayout();
            this.SuspendLayout();
            // 
            // picMain
            // 
            this.picMain.BackColor = System.Drawing.Color.Transparent;
            this.picMain.Image = ((System.Drawing.Image)(resources.GetObject("picMain.Image")));
            this.picMain.Location = new System.Drawing.Point(18, 13);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(163, 60);
            this.picMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMain.TabIndex = 1;
            this.picMain.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblName.Location = new System.Drawing.Point(187, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(180, 60);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "Settings";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.chkUpdateChecking);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboBibleVersion);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Location = new System.Drawing.Point(13, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 68);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General Settings";
            // 
            // chkUpdateChecking
            // 
            this.chkUpdateChecking.AutoSize = true;
            this.chkUpdateChecking.Checked = true;
            this.chkUpdateChecking.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdateChecking.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkUpdateChecking.Location = new System.Drawing.Point(17, 41);
            this.chkUpdateChecking.Name = "chkUpdateChecking";
            this.chkUpdateChecking.Size = new System.Drawing.Size(145, 17);
            this.chkUpdateChecking.TabIndex = 2;
            this.chkUpdateChecking.Text = "Enable Update Checking";
            this.chkUpdateChecking.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(14, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bible Version";
            // 
            // cboBibleVersion
            // 
            this.cboBibleVersion.FormattingEnabled = true;
            this.cboBibleVersion.Items.AddRange(new object[] {
            "KJV",
            "ESV",
            "NIV",
            "NLT"});
            this.cboBibleVersion.Location = new System.Drawing.Point(88, 14);
            this.cboBibleVersion.MaxDropDownItems = 4;
            this.cboBibleVersion.Name = "cboBibleVersion";
            this.cboBibleVersion.Size = new System.Drawing.Size(64, 21);
            this.cboBibleVersion.TabIndex = 0;
            this.cboBibleVersion.SelectedIndexChanged += new System.EventHandler(this.cboBibleVersion_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(13, 153);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(354, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gboPlugins
            // 
            this.gboPlugins.BackColor = System.Drawing.Color.Transparent;
            this.gboPlugins.Controls.Add(this.btnDeletePlugin);
            this.gboPlugins.Controls.Add(this.label2);
            this.gboPlugins.Controls.Add(this.listBox1);
            this.gboPlugins.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.gboPlugins.Location = new System.Drawing.Point(13, 183);
            this.gboPlugins.Name = "gboPlugins";
            this.gboPlugins.Size = new System.Drawing.Size(354, 146);
            this.gboPlugins.TabIndex = 11;
            this.gboPlugins.TabStop = false;
            this.gboPlugins.Text = "Plugins";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(133, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 91);
            this.label2.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(7, 20);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 121);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btnDeletePlugin
            // 
            this.btnDeletePlugin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDeletePlugin.Location = new System.Drawing.Point(134, 117);
            this.btnDeletePlugin.Name = "btnDeletePlugin";
            this.btnDeletePlugin.Size = new System.Drawing.Size(94, 23);
            this.btnDeletePlugin.TabIndex = 2;
            this.btnDeletePlugin.Text = "Delete Plugin";
            this.btnDeletePlugin.UseVisualStyleBackColor = true;
            this.btnDeletePlugin.Click += new System.EventHandler(this.btnDeletePlugin_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Power_of_God_Lib.Properties.Resources.goldenraysabstract;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(379, 341);
            this.Controls.Add(this.gboPlugins);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picMain);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gboPlugins.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picMain;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboBibleVersion;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkUpdateChecking;
        private System.Windows.Forms.GroupBox gboPlugins;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDeletePlugin;
    }
}