Imports System.IO
Imports System.Net
Imports NetBible.Books
Imports Newtonsoft.Json
Imports Power_of_God_Lib.BibPlan
Imports Power_of_God_Lib.NetBible.Books
Imports Power_of_God_Lib.pSystem

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
    Dim _verseList As New List(Of List(Of VerseObj))

    Private Sub EditorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'NetBible.Books.Bible.SetLocation("bible.xml")
        For Each b In Bible.AllBooks()
            cboBookStart.Items.Add(b.Name)
            cboBookEnd.Items.Add(b.Name)
        Next

        If StartForm.IsNewFile Then
            Dim fileReader = File.ReadAllText(StartForm.EditorPath)
            Dim obj = JsonConvert.DeserializeObject(Of BibPlan)(fileReader)
            txtName.Text = obj.Name
            _verseList = obj.VerseList
            _verseList = New List(Of List(Of VerseObj))
            For Each x In obj.VerseList
                Dim e1 = x.ElementAt(0)
                Dim e2 = x.ElementAt(1)
                lboVerses.Items.Add(e1.Book & " " & e1.Chapter & ":" & e1.Verse &
                                       " to " & e2.Book & " " & e2.Chapter & ":" & e2.Verse)
            Next
            Select Case obj.VerseAuthor
                Case "Unknown"
                    chkSaveUnknown.Checked = True
                Case Else
                    chkSaveUnknown.Checked = False
                    txtUsername.Text = obj.VerseAuthor
            End Select
        End If
    End Sub
    Private Sub AddToList(v1 As String, v2 As String)
        lboVerses.Items.Add(v1 & " to " & v2)
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
    Dim _selectedBookStart As Book
    Dim _selectedBookEnd As Book
    Private Sub cboBook_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBookStart.SelectedIndexChanged
        numChapterStart.Value = 1
        Dim foundOne = False
        ' ReSharper disable once LoopCanBePartlyConvertedToQuery
        For Each b In Bible.AllBooks()
            If b.Name = cboBookStart.SelectedItem AndAlso Not foundOne Then
                foundOne = True
                _selectedBookStart = b
            End If
        Next
        numChapterStart.Maximum = _selectedBookStart.ChapterCount
    End Sub

    Private Sub cboBookEnd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBookEnd.SelectedIndexChanged
        numChapterEnd.Value = 1
        Dim foundOne = False
        ' ReSharper disable once LoopCanBePartlyConvertedToQuery
        For Each b In Bible.AllBooks()
            If b.Name = cboBookEnd.SelectedItem AndAlso Not foundOne Then
                foundOne = True
                _selectedBookEnd = b
            End If
        Next
        numChapterEnd.Maximum = _selectedBookEnd.ChapterCount
    End Sub

    Private Sub numChapter_ValueChanged(sender As Object, e As EventArgs) Handles numChapterStart.ValueChanged
        numVerseStart.Value = 1
        Try
            numVerseStart.Maximum = _selectedBookStart.VerseCount(numChapterStart.Value)
        Catch ex As Exception
            ' MsgBox("Unable to collect verse count. Please try again")
            ' Ignored
        End Try
    End Sub

    Private Sub numChapterEnd_ValueChanged(sender As Object, e As EventArgs) Handles numChapterEnd.ValueChanged
        numVerseEnd.Value = 1
        Try
            numVerseEnd.Maximum = _selectedBookEnd.VerseCount(numChapterEnd.Value)
        Catch ex As Exception
            ' MsgBox("Unable to collect verse count. Please try again")
            ' Ignored
        End Try
    End Sub


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not cboBookStart.SelectedIndex = -1 OrElse Not cboBookEnd.SelectedIndex = -1 Then
            Dim verseStartString = cboBookStart.SelectedItem & " " & numChapterStart.Value & ":" & numVerseStart.Value
            Dim verseEndString = cboBookEnd.SelectedItem & " " & numChapterEnd.Value & ":" & numVerseEnd.Value

            Dim v1 As New VerseObj
            Dim v2 As New VerseObj
            v1.Book = cboBookStart.SelectedItem
            v1.Chapter = numChapterStart.Value
            v1.Verse = numVerseStart.Value
            v2.Book = cboBookEnd.SelectedItem
            v2.Chapter = numChapterEnd.Value
            v2.Verse = numVerseEnd.Value


            Dim book1Int = GetBookIndex(cboBookStart.SelectedItem)
            Dim book2Int = GetBookIndex(cboBookEnd.SelectedItem)
            Dim maxVerses1 = numVerseStart.Maximum

            If book1Int > book2Int Then
                MsgBox("Selected Start Verse cannot be before Selected End Verse")
                Return
            ElseIf (book2Int - book1Int) > 1
                MsgBox("Sorry, there cannot be that big of gap between books. Too many verses!")
                Return
            Else
                If book1Int = book2Int Then
                    If numChapterStart.Value > numChapterEnd.Value Then
                        MsgBox("Selected Start Verse cannot be before Selected End Verse")
                        Return
                    Else
                        If numChapterStart.Value = numChapterEnd.Value Then
                            If numVerseStart.Value > numVerseEnd.Value Then
                                MsgBox("Selected Start Verse cannot be before Selected End Verse")
                                Return
                            End If
                        End If
                    End If
                End If
            End If
            ' Should only reach this point if the verses selected for a day are OK
            AddToList(verseStartString, verseEndString)
            _verseList.Add(New VerseObj() {v1, v2}.ToList())
            Dim strContent As String = verseStartString & " - " & verseEndString & " (KJV) - "
            If book1Int = book2Int Then ' Books are the same
                If numChapterStart.Value = numChapterEnd.Value Then
                    For x = numVerseStart.Value To numVerseEnd.Value
                        strContent &= _selectedBookStart.ReadPlainVerse(numChapterStart.Value, x) & " "
                    Next
                ElseIf numChapterStart.Value < numChapterEnd.Value Then
                    Dim y = numChapterEnd.Value - numChapterStart.Value
                    For z = 0 To y
                        Select Case z
                            Case 0
                                For x = numVerseStart.Value To maxVerses1
                                    strContent &= _selectedBookStart.ReadPlainVerse(numChapterStart.Value, x) & " "
                                Next
                            Case numChapterEnd.Value
                                For x = 1 To numVerseEnd.Value
                                    strContent &= _selectedBookStart.ReadPlainVerse(numChapterEnd.Value, x) & " "
                                Next
                            Case Else
                                If (numChapterEnd.Value - numChapterStart.Value) > 1 Then
                                    For x = 1 To _selectedBookStart.VerseCount(y + z)
                                        strContent &= _selectedBookStart.ReadPlainVerse(numChapterEnd.Value, x) & " "
                                    Next
                                Else
                                    For x = 1 To numVerseEnd.Value
                                        strContent &= _selectedBookStart.ReadPlainVerse(numChapterEnd.Value, x) & " "
                                    Next
                                End If
                        End Select
                    Next
                End If
            ElseIf book2Int > book1Int
                Dim bookList As New List(Of Book)
                For a = book1Int To book2Int
                    bookList.Add(Bible.AllBooks().ElementAt(a))
                Next
                If (book2Int - book1Int) = 1 Then
                    For a = numChapterStart.Value To bookList.ElementAt(0).ChapterCount
                        Select Case a
                            Case numChapterStart.Value
                                For x = numVerseStart.Value To bookList.ElementAt(0).VerseCount(a)
                                    strContent &= bookList.ElementAt(0).ReadPlainVerse(a, x) & " "
                                Next
                            Case Else
                                For x = 1 To bookList.ElementAt(0).VerseCount(a)
                                    strContent &= bookList.ElementAt(0).ReadPlainVerse(a, x) & " "
                                Next
                        End Select
                    Next
                    For a = 1 To numChapterEnd.Value
                        Select Case a
                            Case numChapterEnd.Value
                                For x = 1 To numVerseEnd.Value
                                    strContent &= bookList.ElementAt(1).ReadPlainVerse(a, x) & " "
                                Next
                            Case Else
                                For x = 1 To bookList.ElementAt(1).VerseCount(a)
                                    strContent &= bookList.ElementAt(1).ReadPlainVerse(a, x) & " "
                                Next
                        End Select
                    Next
                End If
            End If
            rtbVerse.Text = strContent
        End If
    End Sub
    Private Function GetBookIndex(nameStr As String) As Integer
        Dim loopCount = 0
        For Each b As Book In Bible.AllBooks()
            If b.Name = nameStr Then
                Return loopCount
            End If
            loopCount += 1
        Next
        Return -1
    End Function
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        StartForm.Show()
        Hide()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim obj As BibPlan
        If txtName.Text = String.Empty Then
            MsgBox("Please give your Bible Plan a name")
        ElseIf lboVerses.Items.Count = 0
            MsgBox("Please add verses to your Bible Plan")
        Else
            Try
                obj = New BibPlan(txtName.Text,
                    New CMd5Hash().Md5FromString(txtName.Text & ' Unique ID system for idenitfication of Bible Plans
                    _userName &
                    Now.ToLongDateString() &
                    Now.ToLongTimeString()),
                    _verseList,
                    _userName, True)
                Dim jsonString = JsonConvert.SerializeObject(obj)
                SaveFileDialog1.ShowDialog()
                Dim fileWriter = File.CreateText(SaveFileDialog1.FileName)
                fileWriter.Write(jsonString)
                fileWriter.Flush()
                fileWriter.Close()
                _isSaved = True
            Catch ex As Exception
                MsgBox(ex.ToString() & (Chr(13) & ex.StackTrace))
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

