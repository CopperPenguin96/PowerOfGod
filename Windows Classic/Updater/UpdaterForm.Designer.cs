namespace Updater
{
    partial class UpdaterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdaterForm));
            this.picStacked = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboVersionSelector = new System.Windows.Forms.ComboBox();
            this.btnInstall = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblResults = new System.Windows.Forms.Label();
            this.chkAlpha = new System.Windows.Forms.CheckBox();
            this.chkBeta = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picStacked)).BeginInit();
            this.SuspendLayout();
            // 
            // picStacked
            // 
            this.picStacked.Image = global::Updater.Properties.Resources.stacked;
            this.picStacked.Location = new System.Drawing.Point(12, 14);
            this.picStacked.Name = "picStacked";
            this.picStacked.Size = new System.Drawing.Size(253, 248);
            this.picStacked.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picStacked.TabIndex = 0;
            this.picStacked.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(271, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(385, 58);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome! To update your app, please select which version to upgrade to, then clic" +
    "k \"Install\" right below.";
            // 
            // cboVersionSelector
            // 
            this.cboVersionSelector.FormattingEnabled = true;
            this.cboVersionSelector.Location = new System.Drawing.Point(271, 75);
            this.cboVersionSelector.Name = "cboVersionSelector";
            this.cboVersionSelector.Size = new System.Drawing.Size(304, 21);
            this.cboVersionSelector.TabIndex = 2;
            this.cboVersionSelector.SelectedIndexChanged += new System.EventHandler(this.cboVersionSelector_SelectedIndexChanged);
            // 
            // btnInstall
            // 
            this.btnInstall.Enabled = false;
            this.btnInstall.Location = new System.Drawing.Point(581, 73);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(75, 23);
            this.btnInstall.TabIndex = 3;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(271, 239);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(385, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // lblResults
            // 
            this.lblResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResults.Location = new System.Drawing.Point(271, 145);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(385, 91);
            this.lblResults.TabIndex = 5;
            this.lblResults.Text = "{Result}";
            this.lblResults.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblResults.Visible = false;
            // 
            // chkAlpha
            // 
            this.chkAlpha.AutoSize = true;
            this.chkAlpha.Location = new System.Drawing.Point(271, 100);
            this.chkAlpha.Name = "chkAlpha";
            this.chkAlpha.Size = new System.Drawing.Size(130, 17);
            this.chkAlpha.TabIndex = 6;
            this.chkAlpha.Text = "Show Alpha Releases";
            this.chkAlpha.UseVisualStyleBackColor = true;
            this.chkAlpha.CheckedChanged += new System.EventHandler(this.chkAlpha_CheckedChanged);
            // 
            // chkBeta
            // 
            this.chkBeta.AutoSize = true;
            this.chkBeta.Location = new System.Drawing.Point(271, 123);
            this.chkBeta.Name = "chkBeta";
            this.chkBeta.Size = new System.Drawing.Size(125, 17);
            this.chkBeta.TabIndex = 7;
            this.chkBeta.Text = "Show Beta Releases";
            this.chkBeta.UseVisualStyleBackColor = true;
            this.chkBeta.CheckedChanged += new System.EventHandler(this.chkBeta_CheckedChanged);
            // 
            // UpdaterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 274);
            this.Controls.Add(this.chkBeta);
            this.Controls.Add(this.chkAlpha);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.cboVersionSelector);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picStacked);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdaterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Power of God Updater";
            ((System.ComponentModel.ISupportInitialize)(this.picStacked)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picStacked;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboVersionSelector;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.CheckBox chkAlpha;
        private System.Windows.Forms.CheckBox chkBeta;
    }
}

