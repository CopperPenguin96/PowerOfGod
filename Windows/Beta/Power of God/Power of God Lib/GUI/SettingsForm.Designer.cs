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
            this.SuspendLayout();
            // 
            // chkEnablePlugins
            // 
            this.chkEnablePlugins.AutoSize = true;
            this.chkEnablePlugins.Location = new System.Drawing.Point(23, 63);
            this.chkEnablePlugins.Name = "chkEnablePlugins";
            this.chkEnablePlugins.Size = new System.Drawing.Size(96, 17);
            this.chkEnablePlugins.TabIndex = 0;
            this.chkEnablePlugins.Text = "Enable Plugins";
            this.chkEnablePlugins.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 422);
            this.Controls.Add(this.chkEnablePlugins);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkEnablePlugins;
    }
}