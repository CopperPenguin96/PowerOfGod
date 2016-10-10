namespace BiblePlanPlugin.BibPlan
{
    partial class BibPlanDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BibPlanDialog));
            this.lboPlanList = new System.Windows.Forms.ListBox();
            this.btnDownloadSome = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lboPlanList
            // 
            this.lboPlanList.FormattingEnabled = true;
            this.lboPlanList.Location = new System.Drawing.Point(12, 12);
            this.lboPlanList.Name = "lboPlanList";
            this.lboPlanList.Size = new System.Drawing.Size(173, 212);
            this.lboPlanList.TabIndex = 0;
            this.lboPlanList.SelectedIndexChanged += new System.EventHandler(this.lboPlanList_SelectedIndexChanged);
            // 
            // btnDownloadSome
            // 
            this.btnDownloadSome.Location = new System.Drawing.Point(13, 231);
            this.btnDownloadSome.Name = "btnDownloadSome";
            this.btnDownloadSome.Size = new System.Drawing.Size(172, 23);
            this.btnDownloadSome.TabIndex = 1;
            this.btnDownloadSome.Text = "Download Some";
            this.btnDownloadSome.UseVisualStyleBackColor = true;
            this.btnDownloadSome.Click += new System.EventHandler(this.btnDownloadSome_Click);
            // 
            // BibPlanDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 261);
            this.Controls.Add(this.btnDownloadSome);
            this.Controls.Add(this.lboPlanList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BibPlanDialog";
            this.Text = "BibPlanDialog";
            this.Load += new System.EventHandler(this.BibPlanDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lboPlanList;
        private System.Windows.Forms.Button btnDownloadSome;
    }
}