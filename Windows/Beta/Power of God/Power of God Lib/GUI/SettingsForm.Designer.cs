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
            this.chkEnablePlugins = new System.Windows.Forms.CheckBox();
            this.gboPlugins = new System.Windows.Forms.GroupBox();
            this.gboLogging = new System.Windows.Forms.GroupBox();
            this.chkSendCrashReports = new System.Windows.Forms.CheckBox();
            this.chkEnableCrashReports = new System.Windows.Forms.CheckBox();
            this.chkSendLogs = new System.Windows.Forms.CheckBox();
            this.chkEnableLogs = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.gboPlugins.SuspendLayout();
            this.gboLogging.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkEnablePlugins
            // 
            this.chkEnablePlugins.AutoSize = true;
            this.chkEnablePlugins.Location = new System.Drawing.Point(6, 19);
            this.chkEnablePlugins.Name = "chkEnablePlugins";
            this.chkEnablePlugins.Size = new System.Drawing.Size(96, 17);
            this.chkEnablePlugins.TabIndex = 0;
            this.chkEnablePlugins.Text = "Enable Plugins";
            this.chkEnablePlugins.UseVisualStyleBackColor = true;
            this.chkEnablePlugins.CheckedChanged += new System.EventHandler(this.chkEnablePlugins_CheckedChanged);
            // 
            // gboPlugins
            // 
            this.gboPlugins.Controls.Add(this.chkEnablePlugins);
            this.gboPlugins.Location = new System.Drawing.Point(23, 63);
            this.gboPlugins.Name = "gboPlugins";
            this.gboPlugins.Size = new System.Drawing.Size(198, 154);
            this.gboPlugins.TabIndex = 1;
            this.gboPlugins.TabStop = false;
            this.gboPlugins.Text = "Plugins";
            // 
            // gboLogging
            // 
            this.gboLogging.Controls.Add(this.chkSendCrashReports);
            this.gboLogging.Controls.Add(this.chkEnableCrashReports);
            this.gboLogging.Controls.Add(this.chkSendLogs);
            this.gboLogging.Controls.Add(this.chkEnableLogs);
            this.gboLogging.Location = new System.Drawing.Point(227, 63);
            this.gboLogging.Name = "gboLogging";
            this.gboLogging.Size = new System.Drawing.Size(198, 154);
            this.gboLogging.TabIndex = 3;
            this.gboLogging.TabStop = false;
            this.gboLogging.Text = "Logging";
            // 
            // chkSendCrashReports
            // 
            this.chkSendCrashReports.AutoSize = true;
            this.chkSendCrashReports.Location = new System.Drawing.Point(6, 88);
            this.chkSendCrashReports.Name = "chkSendCrashReports";
            this.chkSendCrashReports.Size = new System.Drawing.Size(185, 17);
            this.chkSendCrashReports.TabIndex = 3;
            this.chkSendCrashReports.Text = "Send Crash Reports to Developer";
            this.chkSendCrashReports.UseVisualStyleBackColor = true;
            // 
            // chkEnableCrashReports
            // 
            this.chkEnableCrashReports.AutoSize = true;
            this.chkEnableCrashReports.Location = new System.Drawing.Point(6, 65);
            this.chkEnableCrashReports.Name = "chkEnableCrashReports";
            this.chkEnableCrashReports.Size = new System.Drawing.Size(129, 17);
            this.chkEnableCrashReports.TabIndex = 2;
            this.chkEnableCrashReports.Text = "Enable Crash Reports";
            this.chkEnableCrashReports.UseVisualStyleBackColor = true;
            this.chkEnableCrashReports.CheckedChanged += new System.EventHandler(this.chkEnableCrashReports_CheckedChanged);
            // 
            // chkSendLogs
            // 
            this.chkSendLogs.AutoSize = true;
            this.chkSendLogs.Location = new System.Drawing.Point(6, 42);
            this.chkSendLogs.Name = "chkSendLogs";
            this.chkSendLogs.Size = new System.Drawing.Size(141, 17);
            this.chkSendLogs.TabIndex = 1;
            this.chkSendLogs.Text = "Send Logs to Developer";
            this.chkSendLogs.UseVisualStyleBackColor = true;
            this.chkSendLogs.CheckedChanged += new System.EventHandler(this.chkSendLogs_CheckedChanged);
            // 
            // chkEnableLogs
            // 
            this.chkEnableLogs.AutoSize = true;
            this.chkEnableLogs.Location = new System.Drawing.Point(6, 19);
            this.chkEnableLogs.Name = "chkEnableLogs";
            this.chkEnableLogs.Size = new System.Drawing.Size(85, 17);
            this.chkEnableLogs.TabIndex = 0;
            this.chkEnableLogs.Text = "Enable Logs";
            this.chkEnableLogs.UseVisualStyleBackColor = true;
            this.chkEnableLogs.CheckedChanged += new System.EventHandler(this.chkEnableLogs_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(23, 223);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 265);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gboLogging);
            this.Controls.Add(this.gboPlugins);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.gboPlugins.ResumeLayout(false);
            this.gboPlugins.PerformLayout();
            this.gboLogging.ResumeLayout(false);
            this.gboLogging.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkEnablePlugins;
        private System.Windows.Forms.GroupBox gboPlugins;
        private System.Windows.Forms.GroupBox gboLogging;
        private System.Windows.Forms.CheckBox chkEnableLogs;
        private System.Windows.Forms.CheckBox chkSendCrashReports;
        private System.Windows.Forms.CheckBox chkEnableCrashReports;
        private System.Windows.Forms.CheckBox chkSendLogs;
        private System.Windows.Forms.Button btnSave;
    }
}