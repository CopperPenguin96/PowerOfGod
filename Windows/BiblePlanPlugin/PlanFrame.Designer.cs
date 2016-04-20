using Power_of_God_Lib.GUI.Controls;

namespace BiblePlanPlugin
{
    partial class PlanFrame
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
            this.lessonBox = new HtmlRichTextBox();
            this.planView = new System.Windows.Forms.WebBrowser();
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
            // planView
            // 
            this.planView.Location = new System.Drawing.Point(4, 3);
            this.planView.MinimumSize = new System.Drawing.Size(20, 20);
            this.planView.Name = "planView";
            this.planView.Size = new System.Drawing.Size(445, 384);
            this.planView.TabIndex = 2;
            // 
            // PlanFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.planView);
            this.Controls.Add(this.lessonBox);
            this.Name = "PlanFrame";
            this.Load += new System.EventHandler(this.PlanFrame_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private HtmlRichTextBox lessonBox;
        private System.Windows.Forms.WebBrowser planView;
    }
}
