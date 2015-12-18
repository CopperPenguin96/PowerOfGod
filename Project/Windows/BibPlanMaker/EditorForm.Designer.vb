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
        Me.rtbVerse = New System.Windows.Forms.RichTextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.numVerse = New System.Windows.Forms.NumericUpDown()
        Me.lblVerse = New System.Windows.Forms.Label()
        Me.numChapter = New System.Windows.Forms.NumericUpDown()
        Me.lblChapter = New System.Windows.Forms.Label()
        Me.lboVerses = New System.Windows.Forms.ListBox()
        Me.cboBook = New System.Windows.Forms.ComboBox()
        Me.lblBook = New System.Windows.Forms.Label()
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
        Me.VersePanel.SuspendLayout()
        CType(Me.numVerse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numChapter, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.txtName.Size = New System.Drawing.Size(217, 20)
        Me.txtName.TabIndex = 1
        '
        'VersePanel
        '
        Me.VersePanel.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.VersePanel.Controls.Add(Me.rtbVerse)
        Me.VersePanel.Controls.Add(Me.btnAdd)
        Me.VersePanel.Controls.Add(Me.btnDelete)
        Me.VersePanel.Controls.Add(Me.numVerse)
        Me.VersePanel.Controls.Add(Me.lblVerse)
        Me.VersePanel.Controls.Add(Me.numChapter)
        Me.VersePanel.Controls.Add(Me.lblChapter)
        Me.VersePanel.Controls.Add(Me.lboVerses)
        Me.VersePanel.Controls.Add(Me.cboBook)
        Me.VersePanel.Controls.Add(Me.lblBook)
        Me.VersePanel.Location = New System.Drawing.Point(16, 39)
        Me.VersePanel.Name = "VersePanel"
        Me.VersePanel.Size = New System.Drawing.Size(256, 174)
        Me.VersePanel.TabIndex = 2
        '
        'rtbVerse
        '
        Me.rtbVerse.Location = New System.Drawing.Point(128, 114)
        Me.rtbVerse.Name = "rtbVerse"
        Me.rtbVerse.ReadOnly = True
        Me.rtbVerse.Size = New System.Drawing.Size(128, 57)
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
        'numVerse
        '
        Me.numVerse.Location = New System.Drawing.Point(0, 104)
        Me.numVerse.Name = "numVerse"
        Me.numVerse.Size = New System.Drawing.Size(120, 20)
        Me.numVerse.TabIndex = 4
        '
        'lblVerse
        '
        Me.lblVerse.AutoSize = True
        Me.lblVerse.Location = New System.Drawing.Point(0, 88)
        Me.lblVerse.Name = "lblVerse"
        Me.lblVerse.Size = New System.Drawing.Size(34, 13)
        Me.lblVerse.TabIndex = 5
        Me.lblVerse.Text = "Verse"
        '
        'numChapter
        '
        Me.numChapter.Location = New System.Drawing.Point(0, 65)
        Me.numChapter.Name = "numChapter"
        Me.numChapter.Size = New System.Drawing.Size(120, 20)
        Me.numChapter.TabIndex = 3
        '
        'lblChapter
        '
        Me.lblChapter.AutoSize = True
        Me.lblChapter.Location = New System.Drawing.Point(0, 48)
        Me.lblChapter.Name = "lblChapter"
        Me.lblChapter.Size = New System.Drawing.Size(44, 13)
        Me.lblChapter.TabIndex = 3
        Me.lblChapter.Text = "Chapter"
        '
        'lboVerses
        '
        Me.lboVerses.FormattingEnabled = True
        Me.lboVerses.Location = New System.Drawing.Point(128, 0)
        Me.lboVerses.Name = "lboVerses"
        Me.lboVerses.Size = New System.Drawing.Size(128, 108)
        Me.lboVerses.TabIndex = 2
        '
        'cboBook
        '
        Me.cboBook.FormattingEnabled = True
        Me.cboBook.Location = New System.Drawing.Point(0, 20)
        Me.cboBook.Name = "cboBook"
        Me.cboBook.Size = New System.Drawing.Size(121, 21)
        Me.cboBook.TabIndex = 2
        '
        'lblBook
        '
        Me.lblBook.AutoSize = True
        Me.lblBook.Location = New System.Drawing.Point(0, 4)
        Me.lblBook.Name = "lblBook"
        Me.lblBook.Size = New System.Drawing.Size(32, 13)
        Me.lblBook.TabIndex = 0
        Me.lblBook.Text = "Book"
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
        Me.gboLogin.Size = New System.Drawing.Size(256, 100)
        Me.gboLogin.TabIndex = 3
        Me.gboLogin.TabStop = False
        Me.gboLogin.Text = "Login"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(69, 43)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(120)
        Me.txtPassword.Size = New System.Drawing.Size(88, 20)
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
        Me.btnLogin.Location = New System.Drawing.Point(163, 17)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(87, 77)
        Me.btnLogin.TabIndex = 9
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(69, 17)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(88, 20)
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
        Me.chkSaveUnknown.Location = New System.Drawing.Point(16, 327)
        Me.chkSaveUnknown.Name = "chkSaveUnknown"
        Me.chkSaveUnknown.Size = New System.Drawing.Size(135, 17)
        Me.chkSaveUnknown.TabIndex = 11
        Me.chkSaveUnknown.Text = "Save as unknown user"
        Me.chkSaveUnknown.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(158, 323)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(114, 23)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnLogout
        '
        Me.btnLogout.Enabled = False
        Me.btnLogout.Location = New System.Drawing.Point(158, 381)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(114, 23)
        Me.btnLogout.TabIndex = 12
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(158, 410)
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
        Me.btnUpload.Location = New System.Drawing.Point(158, 352)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(114, 23)
        Me.btnUpload.TabIndex = 14
        Me.btnUpload.Text = "Upload"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'EditorForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 437)
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
        CType(Me.numVerse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numChapter, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents numVerse As NumericUpDown
    Friend WithEvents lblVerse As Label
    Friend WithEvents numChapter As NumericUpDown
    Friend WithEvents lblChapter As Label
    Friend WithEvents lboVerses As ListBox
    Friend WithEvents cboBook As ComboBox
    Friend WithEvents lblBook As Label
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
End Class
