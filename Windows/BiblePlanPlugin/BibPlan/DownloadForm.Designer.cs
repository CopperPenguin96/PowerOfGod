namespace BiblePlanPlugin.BibPlan
{
    partial class DownloadForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadForm));
            this.lblAuthorName = new System.Windows.Forms.Label();
            this.txtAuthorName = new System.Windows.Forms.TextBox();
            this.lboContent = new System.Windows.Forms.ListBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblInfoContent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAuthorName
            // 
            this.lblAuthorName.AutoSize = true;
            this.lblAuthorName.Location = new System.Drawing.Point(13, 13);
            this.lblAuthorName.Name = "lblAuthorName";
            this.lblAuthorName.Size = new System.Drawing.Size(89, 13);
            this.lblAuthorName.TabIndex = 0;
            this.lblAuthorName.Text = "Search by Author";
            // 
            // txtAuthorName
            // 
            this.txtAuthorName.Location = new System.Drawing.Point(108, 10);
            this.txtAuthorName.Name = "txtAuthorName";
            this.txtAuthorName.Size = new System.Drawing.Size(107, 20);
            this.txtAuthorName.TabIndex = 1;
            // 
            // lboContent
            // 
            this.lboContent.FormattingEnabled = true;
            this.lboContent.Location = new System.Drawing.Point(16, 38);
            this.lboContent.Name = "lboContent";
            this.lboContent.Size = new System.Drawing.Size(256, 108);
            this.lboContent.TabIndex = 2;
            this.lboContent.SelectedIndexChanged += new System.EventHandler(this.lboContent_SelectedIndexChanged);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(197, 195);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 3;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(221, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(51, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblInfoContent
            // 
            this.lblInfoContent.AutoSize = true;
            this.lblInfoContent.Location = new System.Drawing.Point(16, 153);
            this.lblInfoContent.Name = "lblInfoContent";
            this.lblInfoContent.Size = new System.Drawing.Size(76, 13);
            this.lblInfoContent.TabIndex = 5;
            this.lblInfoContent.Text = "Name:\\nDays:";
            // 
            // DownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 230);
            this.Controls.Add(this.lblInfoContent);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.lboContent);
            this.Controls.Add(this.txtAuthorName);
            this.Controls.Add(this.lblAuthorName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DownloadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Download Plans";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAuthorName;
        private System.Windows.Forms.TextBox txtAuthorName;
        private System.Windows.Forms.ListBox lboContent;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblInfoContent;
    }
}