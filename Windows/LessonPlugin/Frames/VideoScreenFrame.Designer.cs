using Power_of_God_Lib.GUI.Controls;

namespace Lesson.Frames
{
    partial class VideoScreenFrame
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.videoPlayer1 = new Power_of_God_Lib.GUI.Controls.VideoPlayer();
            this.btnRegularLessons = new System.Windows.Forms.Button();
            this.lblVids = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // videoPlayer1
            // 
            this.videoPlayer1.BackColor = System.Drawing.Color.White;
            this.videoPlayer1.Location = new System.Drawing.Point(3, 3);
            this.videoPlayer1.Name = "videoPlayer1";
            this.videoPlayer1.Size = new System.Drawing.Size(366, 267);
            this.videoPlayer1.TabIndex = 0;
            // 
            // btnRegularLessons
            // 
            this.btnRegularLessons.Location = new System.Drawing.Point(3, 276);
            this.btnRegularLessons.Name = "btnRegularLessons";
            this.btnRegularLessons.Size = new System.Drawing.Size(122, 23);
            this.btnRegularLessons.TabIndex = 1;
            this.btnRegularLessons.Text = "Past Written Lessons";
            this.btnRegularLessons.UseVisualStyleBackColor = true;
            this.btnRegularLessons.Click += new System.EventHandler(this.btnRegularLessons_Click);
            // 
            // lblVids
            // 
            this.lblVids.Location = new System.Drawing.Point(132, 277);
            this.lblVids.Name = "lblVids";
            this.lblVids.Size = new System.Drawing.Size(237, 42);
            this.lblVids.TabIndex = 2;
            this.lblVids.Text = "To view more video lessons, visit http://godispower.us/Videos/Lessons/";
            // 
            // VideoScreenFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblVids);
            this.Controls.Add(this.btnRegularLessons);
            this.Controls.Add(this.videoPlayer1);
            this.Name = "VideoScreenFrame";
            this.Load += new System.EventHandler(this.VideoScreenFrame_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private VideoPlayer videoPlayer1;
        private System.Windows.Forms.Button btnRegularLessons;
        private System.Windows.Forms.Label lblVids;
    }
}
