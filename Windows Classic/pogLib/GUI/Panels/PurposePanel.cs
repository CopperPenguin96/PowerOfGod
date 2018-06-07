using NetBible.Bible;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pogLib.GUI.Panels
{
    public class PurposePanel : DefaultPanel
    {
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

        public PurposePanel()
        {
            InitializeComponent();
            label3.Text = "Welcome!";
            label2.Text = "Welcome to Power of God! Thank you for " +
                          "taking the time to visit with us! It could actually change your life!\n\nIf you are using " +
                          "this app expecting favor for a specific denomination, you are in for a surprise! " +
                          "This app is intended to be non-denominational! \n\nYou also may be wondering why such an " +
                          "app exists. Well, I believe that the Holy Bible is true. " +
                          NewTestament.Timothy2.ReadFormattedVerse(3, 16) + " With that in mind, I also believe that the " +
                          "holy power God has is beyond compare. " + NewTestament.Romans.ReadFormattedVerse(1, 16) + " We " +
                          "live to serve Jesus Christ, who is God, and will come back to earth take all who " +
                          "believe he died and rose again, to heaven. We use this so-called online church " +
                          "as a way to witness, to share the Gospel and to provide a church for those who can't find one " +
                          "or else for those who have churches that aren't teaching properly. \n\nWhatever the case, this is church " +
                          "for everyone. Anybody is allowed to participate in Power of God's services. In your PJ's? Perfect! Get " +
                          "comforatable and get prepared to praise Jesus!";
        }
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(131, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(632, 432);
            this.label2.TabIndex = 1;
            this.label2.Text = "TextLabel";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Heavy", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(318, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 61);
            this.label3.TabIndex = 2;
            this.label3.Text = "Welcome!";
            // 
            // PurposePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(886, 511);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "PurposePanel";
            this.ResumeLayout(false);

        }
    }
}
