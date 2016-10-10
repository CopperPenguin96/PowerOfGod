using System.Windows.Forms;

namespace LessonPlugin
{
    partial class LessonPage
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroListView1 = new MetroFramework.Controls.MetroListView();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(12, 12);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(592, 247);
            this.webBrowser1.TabIndex = 0;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Location = new System.Drawing.Point(12, 266);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(275, 147);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "About this message-------------------------\r\n\r\nName: {Name}\r\nDate: {Date}";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel1.WrapToLine = true;
            // 
            // metroListView1
            // 
            this.metroListView1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.metroListView1.FullRowSelect = true;
            this.metroListView1.Location = new System.Drawing.Point(294, 266);
            this.metroListView1.MultiSelect = false;
            this.metroListView1.Name = "metroListView1";
            this.metroListView1.OwnerDraw = true;
            this.metroListView1.Size = new System.Drawing.Size(310, 113);
            this.metroListView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.metroListView1.TabIndex = 2;
            this.metroListView1.UseCompatibleStateImageBehavior = false;
            this.metroListView1.UseSelectable = true;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(502, 385);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(102, 28);
            this.metroButton1.TabIndex = 3;
            this.metroButton1.Text = "Watch Live";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // LessonPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 422);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroListView1);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.webBrowser1);
            this.Name = "LessonPage";
            this.Text = "About this message--------";
            this.ResumeLayout(false);

        }

        #endregion

        private WebBrowser webBrowser1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroListView metroListView1;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}