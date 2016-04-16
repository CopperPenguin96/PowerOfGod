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
            this.videoPlayer1 = new Power_of_God_Lib.Plugins.Controls.VideoPlayer();
            this.SuspendLayout();
            // 
            // videoPlayer1
            // 
            this.videoPlayer1.BackColor = System.Drawing.Color.White;
            this.videoPlayer1.Location = new System.Drawing.Point(43, 62);
            this.videoPlayer1.Name = "videoPlayer1";
            this.videoPlayer1.Size = new System.Drawing.Size(366, 267);
            this.videoPlayer1.TabIndex = 0;
            // 
            // VideoScreenFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.videoPlayer1);
            this.Name = "VideoScreenFrame";
            this.Load += new System.EventHandler(this.VideoScreenFrame_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Power_of_God_Lib.Plugins.Controls.VideoPlayer videoPlayer1;
    }
}
