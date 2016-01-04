<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditorForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditorForm))
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.VersePanel = New System.Windows.Forms.Panel()
        Me.cboBookEnd = New System.Windows.Forms.ComboBox()
        Me.lblBookEnd = New System.Windows.Forms.Label()
        Me.lblEnd = New System.Windows.Forms.Label()
        Me.numVerseEnd = New System.Windows.Forms.NumericUpDown()
        Me.lblVerseEnd = New System.Windows.Forms.Label()
        Me.numChapterEnd = New System.Windows.Forms.NumericUpDown()
        Me.lblChapterEnd = New System.Windows.Forms.Label()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.rtbVerse = New System.Windows.Forms.RichTextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.numVerseStart = New System.Windows.Forms.NumericUpDown()
        Me.lblVerseStart = New System.Windows.Forms.Label()
        Me.numChapterStart = New System.Windows.Forms.NumericUpDown()
        Me.lblChapterStart = New System.Windows.Forms.Label()
        Me.lboVerses = New System.Windows.Forms.ListBox()
        Me.cboBookStart = New System.Windows.Forms.ComboBox()
        Me.lblBookStart = New System.Windows.Forms.Label()
        Me.gboLogin = New System.Windows.Forms.GroupBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.chkSaveUnknown = New System.Windows.Forms.CheckBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.lboNotice = New System.Windows.Forms.Label()
        Me.VersePanel.SuspendLayout()
        CType(Me.numVerseEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numChapterEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numVerseStart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numChapterStart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboLogin.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(13, 13)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(35, 13)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Name"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(55, 13)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(285, 20)
        Me.txtName.TabIndex = 1
        '
        'VersePanel
        '
        Me.VersePanel.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.VersePanel.Controls.Add(Me.cboBookEnd)
        Me.VersePanel.Controls.Add(Me.lblBookEnd)
        Me.VersePanel.Controls.Add(Me.lblEnd)
        Me.VersePanel.Controls.Add(Me.numVerseEnd)
        Me.VersePanel.Controls.Add(Me.lblVerseEnd)
        Me.VersePanel.Controls.Add(Me.numChapterEnd)
        Me.VersePanel.Controls.Add(Me.lblChapterEnd)
        Me.VersePanel.Controls.Add(Me.lblStart)
        Me.VersePanel.Controls.Add(Me.rtbVerse)
        Me.VersePanel.Controls.Add(Me.btnAdd)
        Me.VersePanel.Controls.Add(Me.btnDelete)
        Me.VersePanel.Controls.Add(Me.numVerseStart)
        Me.VersePanel.Controls.Add(Me.lblVerseStart)
        Me.VersePanel.Controls.Add(Me.numChapterStart)
        Me.VersePanel.Controls.Add(Me.lblChapterStart)
        Me.VersePanel.Controls.Add(Me.lboVerses)
        Me.VersePanel.Controls.Add(Me.cboBookStart)
        Me.VersePanel.Controls.Add(Me.lblBookStart)
        Me.VersePanel.Location = New System.Drawing.Point(16, 39)
        Me.VersePanel.Name = "VersePanel"
        Me.VersePanel.Size = New System.Drawing.Size(324, 174)
        Me.VersePanel.TabIndex = 2
        '
        'cboBookEnd
        '
        Me.cboBookEnd.FormattingEnabled = True
        Me.cboBookEnd.Location = New System.Drawing.Point(66, 29)
        Me.cboBookEnd.Name = "cboBookEnd"
        Me.cboBookEnd.Size = New System.Drawing.Size(44, 21)
        Me.cboBookEnd.TabIndex = 22
        '
        'lblBookEnd
        '
        Me.lblBookEnd.AutoSize = True
        Me.lblBookEnd.Location = New System.Drawing.Point(66, 13)
        Me.lblBookEnd.Name = "lblBookEnd"
        Me.lblBookEnd.Size = New System.Drawing.Size(32, 13)
        Me.lblBookEnd.TabIndex = 21
        Me.lblBookEnd.Text = "Book"
        '
        'lblEnd
        '
        Me.lblEnd.AutoSize = True
        Me.lblEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnd.Location = New System.Drawing.Point(66, 0)
        Me.lblEnd.Name = "lblEnd"
        Me.lblEnd.Size = New System.Drawing.Size(29, 13)
        Me.lblEnd.TabIndex = 20
        Me.lblEnd.Text = "End"
        '
        'numVerseEnd
        '
        Me.numVerseEnd.Location = New System.Drawing.Point(66, 108)
        Me.numVerseEnd.Name = "numVerseEnd"
        Me.numVerseEnd.Size = New System.Drawing.Size(44, 20)
        Me.numVerseEnd.TabIndex = 18
        '
        'lblVerseEnd
        '
        Me.lblVerseEnd.AutoSize = True
        Me.lblVerseEnd.Location = New System.Drawing.Point(66, 92)
        Me.lblVerseEnd.Name = "lblVerseEnd"
        Me.lblVerseEnd.Size = New System.Drawing.Size(34, 13)
        Me.lblVerseEnd.TabIndex = 19
        Me.lblVerseEnd.Text = "Verse"
        '
        'numChapterEnd
        '
        Me.numChapterEnd.Location = New System.Drawing.Point(66, 69)
        Me.numChapterEnd.Name = "numChapterEnd"
        Me.numChapterEnd.Size = New System.Drawing.Size(44, 20)
        Me.numChapterEnd.TabIndex = 16
        '
        'lblChapterEnd
        '
        Me.lblChapterEnd.AutoSize = True
        Me.lblChapterEnd.Location = New System.Drawing.Point(66, 53)
        Me.lblChapterEnd.Name = "lblChapterEnd"
        Me.lblChapterEnd.Size = New System.Drawing.Size(44, 13)
        Me.lblChapterEnd.TabIndex = 17
        Me.lblChapterEnd.Text = "Chapter"
        '
        'lblStart
        '
        Me.lblStart.AutoSize = True
        Me.lblStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStart.Location = New System.Drawing.Point(0, 0)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(34, 13)
        Me.lblStart.TabIndex = 15
        Me.lblStart.Text = "Start"
        '
        'rtbVerse
        '
        Me.rtbVerse.Location = New System.Drawing.Point(128, 114)
        Me.rtbVerse.Name = "rtbVerse"
        Me.rtbVerse.ReadOnly = True
        Me.rtbVerse.Size = New System.Drawing.Size(196, 57)
        Me.rtbVerse.TabIndex = 14
        Me.rtbVerse.Text = ""
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(0, 151)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(34, 23)
        Me.btnAdd.TabIndex = 5
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(40, 151)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(46, 23)
        Me.btnDelete.TabIndex = 6
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'numVerseStart
        '
        Me.numVerseStart.Location = New System.Drawing.Point(0, 108)
        Me.numVerseStart.Name = "numVerseStart"
        Me.numVerseStart.Size = New System.Drawing.Size(44, 20)
        Me.numVerseStart.TabIndex = 4
        '
        'lblVerseStart
        '
        Me.lblVerseStart.AutoSize = True
        Me.lblVerseStart.Location = New System.Drawing.Point(0, 92)
        Me.lblVerseStart.Name = "lblVerseStart"
        Me.lblVerseStart.Size = New System.Drawing.Size(34, 13)
        Me.lblVerseStart.TabIndex = 5
        Me.lblVerseStart.Text = "Verse"
        '
        'numChapterStart
        '
        Me.numChapterStart.Location = New System.Drawing.Point(0, 69)
        Me.numChapterStart.Name = "numChapterStart"
        Me.numChapterStart.Size = New System.Drawing.Size(44, 20)
        Me.numChapterStart.TabIndex = 3
        '
        'lblChapterStart
        '
        Me.lblChapterStart.AutoSize = True
        Me.lblChapterStart.Location = New System.Drawing.Point(0, 53)
        Me.lblChapterStart.Name = "lblChapterStart"
        Me.lblChapterStart.Size = New System.Drawing.Size(44, 13)
        Me.lblChapterStart.TabIndex = 3
        Me.lblChapterStart.Text = "Chapter"
        '
        'lboVerses
        '
        Me.lboVerses.FormattingEnabled = True
        Me.lboVerses.Location = New System.Drawing.Point(128, 0)
        Me.lboVerses.Name = "lboVerses"
        Me.lboVerses.Size = New System.Drawing.Size(196, 108)
        Me.lboVerses.TabIndex = 2
        '
        'cboBookStart
        '
        Me.cboBookStart.FormattingEnabled = True
        Me.cboBookStart.Location = New System.Drawing.Point(0, 29)
        Me.cboBookStart.Name = "cboBookStart"
        Me.cboBookStart.Size = New System.Drawing.Size(44, 21)
        Me.cboBookStart.TabIndex = 2
        '
        'lblBookStart
        '
        Me.lblBookStart.AutoSize = True
        Me.lblBookStart.Location = New System.Drawing.Point(0, 13)
        Me.lblBookStart.Name = "lblBookStart"
        Me.lblBookStart.Size = New System.Drawing.Size(32, 13)
        Me.lblBookStart.TabIndex = 0
        Me.lblBookStart.Text = "Book"
        '
        'gboLogin
        '
        Me.gboLogin.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.gboLogin.Controls.Add(Me.txtPassword)
        Me.gboLogin.Controls.Add(Me.lblPassword)
        Me.gboLogin.Controls.Add(Me.btnLogin)
        Me.gboLogin.Controls.Add(Me.txtUsername)
        Me.gboLogin.Controls.Add(Me.lblUsername)
        Me.gboLogin.Location = New System.Drawing.Point(16, 220)
        Me.gboLogin.Name = "gboLogin"
        Me.gboLogin.Size = New System.Drawing.Size(324, 69)
        Me.gboLogin.TabIndex = 3
        Me.gboLogin.TabStop = False
        Me.gboLogin.Text = "Login"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(69, 43)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(162, 20)
        Me.txtPassword.TabIndex = 8
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(8, 46)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(53, 13)
        Me.lblPassword.TabIndex = 3
        Me.lblPassword.Text = "Password"
        '
        'btnLogin
        '
        Me.btnLogin.Location = New System.Drawing.Point(237, 17)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(87, 46)
        Me.btnLogin.TabIndex = 9
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(69, 17)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(162, 20)
        Me.txtUsername.TabIndex = 7
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Location = New System.Drawing.Point(8, 20)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(55, 13)
        Me.lblUsername.TabIndex = 0
        Me.lblUsername.Text = "Username"
        '
        'chkSaveUnknown
        '
        Me.chkSaveUnknown.AutoSize = True
        Me.chkSaveUnknown.Location = New System.Drawing.Point(16, 295)
        Me.chkSaveUnknown.Name = "chkSaveUnknown"
        Me.chkSaveUnknown.Size = New System.Drawing.Size(135, 17)
        Me.chkSaveUnknown.TabIndex = 11
        Me.chkSaveUnknown.Text = "Save as unknown user"
        Me.chkSaveUnknown.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(226, 295)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(114, 23)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnLogout
        '
        Me.btnLogout.Enabled = False
        Me.btnLogout.Location = New System.Drawing.Point(226, 353)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(114, 23)
        Me.btnLogout.TabIndex = 12
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(226, 382)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(114, 23)
        Me.btnBack.TabIndex = 13
        Me.btnBack.Text = "Main Menu"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "bibplan"
        Me.SaveFileDialog1.Filter = ".bibplan |"
        Me.SaveFileDialog1.RestoreDirectory = True
        Me.SaveFileDialog1.ShowHelp = True
        Me.SaveFileDialog1.SupportMultiDottedExtensions = True
        Me.SaveFileDialog1.Title = "Save Your Bible Plan"
        '
        'btnUpload
        '
        Me.btnUpload.Location = New System.Drawing.Point(226, 324)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(114, 23)
        Me.btnUpload.TabIndex = 14
        Me.btnUpload.Text = "Upload"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'lboNotice
        '
        Me.lboNotice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lboNotice.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lboNotice.Location = New System.Drawing.Point(16, 319)
        Me.lboNotice.Name = "lboNotice"
        Me.lboNotice.Size = New System.Drawing.Size(204, 86)
        Me.lboNotice.TabIndex = 15
        Me.lboNotice.Text = "Please note that the more verses you add in one day for your plan will increase l" &
    "ag."
        '
        'EditorForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(352, 419)
        Me.Controls.Add(Me.lboNotice)
        Me.Controls.Add(Me.btnUpload)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnLogout)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.chkSaveUnknown)
        Me.Controls.Add(Me.gboLogin)
        Me.Controls.Add(Me.VersePanel)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblName)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "EditorForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Power of God Bible Plans Editor"
        Me.VersePanel.ResumeLayout(False)
        Me.VersePanel.PerformLayout()
        CType(Me.numVerseEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numChapterEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numVerseStart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numChapterStart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboLogin.ResumeLayout(False)
        Me.gboLogin.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblName As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents VersePanel As Panel
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents numVerseStart As NumericUpDown
    Friend WithEvents lblVerseStart As Label
    Friend WithEvents numChapterStart As NumericUpDown
    Friend WithEvents lblChapterStart As Label
    Friend WithEvents lboVerses As ListBox
    Friend WithEvents cboBookStart As ComboBox
    Friend WithEvents lblBookStart As Label
    Friend WithEvents gboLogin As GroupBox
    Friend WithEvents chkSaveUnknown As CheckBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnLogin As Button
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents lblUsername As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents rtbVerse As RichTextBox
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents btnUpload As Button
    Friend WithEvents cboBookEnd As ComboBox
    Friend WithEvents lblBookEnd As Label
    Friend WithEvents lblEnd As Label
    Friend WithEvents numVerseEnd As NumericUpDown
    Friend WithEvents lblVerseEnd As Label
    Friend WithEvents numChapterEnd As NumericUpDown
    Friend WithEvents lblChapterEnd As Label
    Friend WithEvents lblStart As Label
    Friend WithEvents lboNotice As Label
End Class
