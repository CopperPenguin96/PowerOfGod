namespace DailyScripture
{
    partial class ScriptureFrame
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
            this.htmlRichTextBox1 = new Power_of_God_Lib.Plugins.Controls.HtmlRichTextBox();
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
            // htmlRichTextBox1
            // 
            this.htmlRichTextBox1.Location = new System.Drawing.Point(3, 0);
            this.htmlRichTextBox1.Name = "htmlRichTextBox1";
            this.htmlRichTextBox1.Size = new System.Drawing.Size(446, 387);
            this.htmlRichTextBox1.TabIndex = 2;
            this.htmlRichTextBox1.Text = "";
            // 
            // ScriptureFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.htmlRichTextBox1);
            this.Controls.Add(this.lessonBox);
            this.Name = "ScriptureFrame";
            this.Load += new System.EventHandler(this.ScriptureFrame_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Power_of_God_Lib.Plugins.Controls.HtmlRichTextBox lessonBox;
        private Power_of_God_Lib.Plugins.Controls.HtmlRichTextBox htmlRichTextBox1;
    }
}
