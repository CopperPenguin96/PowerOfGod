namespace Lesson.Frames
{
    partial class LessonFrame
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
            this.lessonBox = new Power_of_God_Lib.Plugins.Controls.HtmlRichTextBox();
            this.SuspendLayout();
            // 
            // lessonBox
            // 
            this.lessonBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lessonBox.Location = new System.Drawing.Point(3, 0);
            this.lessonBox.Name = "lessonBox";
            this.lessonBox.ReadOnly = true;
            this.lessonBox.Size = new System.Drawing.Size(449, 387);
            this.lessonBox.TabIndex = 1;
            this.lessonBox.Text = "";
            // 
            // LessonFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lessonBox);
            this.Name = "LessonFrame";
            this.Load += new System.EventHandler(this.LessonFrame_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Power_of_God_Lib.Plugins.Controls.HtmlRichTextBox lessonBox;
    }
}
