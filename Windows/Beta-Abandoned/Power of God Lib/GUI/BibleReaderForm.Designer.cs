using Power_of_God_Lib.GUI.Controls;

namespace Power_of_God_Lib.GUI
{
    partial class BibleReaderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BibleReaderForm));
            this.cboBook = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numChapter = new System.Windows.Forms.NumericUpDown();
            this.picBibLogo = new System.Windows.Forms.PictureBox();
            this.biblePane1 = new BiblePane();
            this.version = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numChapter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBibLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // cboBook
            // 
            this.cboBook.FormattingEnabled = true;
            this.cboBook.Location = new System.Drawing.Point(51, 6);
            this.cboBook.Name = "cboBook";
            this.cboBook.Size = new System.Drawing.Size(121, 21);
            this.cboBook.TabIndex = 7;
            this.cboBook.SelectedIndexChanged += new System.EventHandler(this.cboBook_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Book";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Book";
            // 
            // numChapter
            // 
            this.numChapter.Location = new System.Drawing.Point(217, 6);
            this.numChapter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numChapter.Name = "numChapter";
            this.numChapter.Size = new System.Drawing.Size(70, 20);
            this.numChapter.TabIndex = 10;
            this.numChapter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numChapter.ValueChanged += new System.EventHandler(this.numChapter_ValueChanged);
            // 
            // picBibLogo
            // 
            this.picBibLogo.Image = global::Power_of_God_Lib.Properties.Resources.bible_reader_logo1;
            this.picBibLogo.Location = new System.Drawing.Point(16, 495);
            this.picBibLogo.Name = "picBibLogo";
            this.picBibLogo.Size = new System.Drawing.Size(365, 87);
            this.picBibLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBibLogo.TabIndex = 6;
            this.picBibLogo.TabStop = false;
            // 
            // biblePane1
            // 
            this.biblePane1.AutoScroll = true;
            this.biblePane1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("biblePane1.BackgroundImage")));
            this.biblePane1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.biblePane1.Location = new System.Drawing.Point(16, 32);
            this.biblePane1.Name = "biblePane1";
            this.biblePane1.Size = new System.Drawing.Size(365, 457);
            this.biblePane1.TabIndex = 2;
            this.biblePane1.Load += new System.EventHandler(this.biblePane1_Load);
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.ForeColor = System.Drawing.Color.Red;
            this.version.Location = new System.Drawing.Point(293, 9);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(35, 13);
            this.version.TabIndex = 11;
            this.version.Text = "label3";
            // 
            // BibleReaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 594);
            this.Controls.Add(this.version);
            this.Controls.Add(this.numChapter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboBook);
            this.Controls.Add(this.picBibLogo);
            this.Controls.Add(this.biblePane1);
            this.Name = "BibleReaderForm";
            this.Text = "BibleReaderForm";
            this.Load += new System.EventHandler(this.BibleReaderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numChapter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBibLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BiblePane biblePane1;
        private System.Windows.Forms.PictureBox picBibLogo;
        private System.Windows.Forms.ComboBox cboBook;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numChapter;
        private System.Windows.Forms.Label version;
    }
}