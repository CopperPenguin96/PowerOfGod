Imports System.IO
Imports System.Net
Imports BibPlans
Imports NetBible.Books
Imports Newtonsoft.Json
Imports System.Net.Sockets
Imports System.Threading
Imports System.Text
Imports System.Collections

Public Class EditorForm
    Private Sub chkSaveUnknown_CheckedChanged(sender As Object, e As EventArgs) Handles chkSaveUnknown.CheckedChanged
        Dim saveUnknownChecked = chkSaveUnknown.Checked
        gboLogin.Enabled = Not saveUnknownChecked
        btnSave.Enabled = saveUnknownChecked
    End Sub
    Private _userName = "Unknown"
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim loginSuccess = Database.Login(txtUsername.Text, txtPassword.Text)
        If loginSuccess Then
            Select Case MsgBox("Are you sure you want to login as " & txtUsername.Text & "?",
                               MsgBoxStyle.YesNo, "Are you " & txtUsername.Text & "?")
                Case MsgBoxResult.Yes
                    gboLogin.Enabled = False
                    btnSave.Enabled = True
                    chkSaveUnknown.Enabled = False
                    btnLogout.Enabled = True
                    _userName = txtUsername.Text
                Case MsgBoxResult.No
                    txtUsername.Text = String.Empty
                    txtPassword.Text = String.Empty
            End Select
        Else
            MsgBox("Login was unsuccessful. Please try again.", MsgBoxStyle.OkOnly, "Failed")
        End If
    End Sub
    Dim _verseList As New List(Of VerseObj)
    Private Sub EditorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Bible.SetLocation("bible.xml")
        For Each b In Bible.AllBooks()
            cboBook.Items.Add(b.Name)
        Next

        If StartForm.IsNewFile Then
            Dim fileReader = File.ReadAllText(StartForm.EditorPath)
            Dim obj = JsonConvert.DeserializeObject(Of BibPlanJsonObject)(fileReader)
            txtName.Text = obj.Name
            _verseList = obj.Verses.ToList()
            For Each x In obj.Verses
                lboVerses.Items.Add(x.Book & " " & x.Chapter & ":" & x.Verse)
            Next
            Select Case obj.Author
                Case "Unknown"
                    chkSaveUnknown.Checked = True
                Case Else
                    chkSaveUnknown.Checked = False
                    txtUsername.Text = obj.Author
            End Select
        End If
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Select Case MsgBox("Are you sure you want to log off of account " & Database.LoggedUsername,
                           MsgBoxStyle.YesNo, "Logout?")
            Case MsgBoxResult.Yes
                gboLogin.Enabled = True
                txtUsername.Text = String.Empty
                txtPassword.Text = String.Empty
                btnLogout.Enabled = False
                chkSaveUnknown.Enabled = True
                chkSaveUnknown.Checked = False
                btnSave.Enabled = False
        End Select
    End Sub
    Dim _selectedBook As Book
    Private Sub cboBook_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBook.SelectedIndexChanged
        numChapter.Value = 1
        Dim foundOne = False
        ' ReSharper disable once LoopCanBePartlyConvertedToQuery
        For Each b In Bible.AllBooks()
            If b.Name = cboBook.SelectedItem AndAlso Not foundOne Then
                foundOne = True
                _selectedBook = b
            End If
        Next
        numChapter.Maximum = _selectedBook.ChapterCount
    End Sub

    Private Sub numChapter_ValueChanged(sender As Object, e As EventArgs) Handles numChapter.ValueChanged
        numVerse.Value = 1
        Try
            numVerse.Maximum = _selectedBook.VerseCount(numChapter.Value)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim verseString = cboBook.SelectedItem.ToString & " " &
            numChapter.Value & ":" & numVerse.Value
        Dim obj = New VerseObj()
        obj.Book = cboBook.SelectedItem.ToString()
        obj.Chapter = numChapter.Value
        obj.Verse = numVerse.Value
        _verseList.Add(obj)
        lboVerses.Items.Add(verseString)
        rtbVerse.Text = _selectedBook.ReadFormattedVerse(obj.Chapter, obj.Verse)
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        StartForm.Show()
        Hide()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim obj As New BibPlanJsonObject
        If txtName.Text = String.Empty Then
            MsgBox("Please give your Bible Plan a name")
        ElseIf lboVerses.Items.Count = 0
            MsgBox("Please add verses to your Bible Plan")
        Else
            Try
                obj.Name = txtName.Text
                obj.Author = _userName
                obj.Verses = _verseList.ToArray()
                Dim jsonString = JsonConvert.SerializeObject(obj)
                SaveFileDialog1.ShowDialog()
                Dim fileWriter = File.CreateText(SaveFileDialog1.FileName)
                fileWriter.Write(jsonString)
                fileWriter.Flush()
                fileWriter.Close()
                MsgBox("File Saved Successfully")
                _isSaved = True
            Catch
                MsgBox("Sorry, there was an error when trying to save the file. Please try again.")
            End Try
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        lboVerses.Items.Remove(lboVerses.SelectedItem)
    End Sub
    Private _isSaved = False
    Private _triedTwice = False
    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        If chkSaveUnknown.Checked Then
            MsgBox("You need to be logged in to upload your Bible Plan")
        Else
            If Not _isSaved Then
                MsgBox("You need to save your bible plan before uploading")
            Else
                Database.ConnectToFtp()
                Try
                    Dim strFileName = SaveFileDialog1.FileName
                    Database.UploadFile(strFileName, _userName)
                Catch ex As WebException
                    Try
                        Database.CreateNewFolder(_userName)
                        If Not _triedTwice Then
                            btnUpload_Click(sender, e)
                            _triedTwice = True
                        End If
                    Catch
                        MsgBox("Something went wrong. Check your internet connection.")
                    End Try
                End Try
            End If
        End If
    End Sub
End Class

Public Class BibPlanJsonObject
    Public Name As String
    Public Verses As VerseObj()
    Public Author As String
End Class
