Imports System.Windows.Forms
Imports BibPlans
Imports NetBible.Books

Public Class PatchClass
    Private Shared _selectedBookStart As Book
    Private Shared _selectedBookEnd As Book
    Private Sub cboBook_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _cboBookStart.SelectedIndexChanged
        _numChapterStart.Value = 1
        Dim foundOne = False
        ' ReSharper disable once LoopCanBePartlyConvertedToQuery
        For Each b In Bible.AllBooks()
            If b.Name = _cboBookStart.SelectedItem AndAlso Not foundOne Then
                foundOne = True
                _selectedBookStart = b
            End If
        Next
        _numChapterStart.Maximum = _selectedBookStart.ChapterCount
    End Sub

    Private Sub _cboBookEnd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _cboBookEnd.SelectedIndexChanged
        _numChapterEnd.Value = 1
        Dim foundOne = False
        ' ReSharper disable once LoopCanBePartlyConvertedToQuery
        For Each b In Bible.AllBooks()
            If b.Name = _cboBookEnd.SelectedItem AndAlso Not foundOne Then
                foundOne = True
                _selectedBookEnd = b
            End If
        Next
        _numChapterEnd.Maximum = _selectedBookEnd.ChapterCount
    End Sub

    Private Sub numChapter_ValueChanged(sender As Object, e As EventArgs) Handles _numChapterStart.ValueChanged
        _numVerseStart.Value = 1
        Try
            _numVerseStart.Maximum = _selectedBookStart.VerseCount(_numChapterStart.Value)
        Catch ex As Exception
            ' MsgBox("Unable to collect verse count. Please try again")
            ' Ignored
        End Try
    End Sub

    Private Sub _numChapterEnd_ValueChanged(sender As Object, e As EventArgs) Handles _numChapterEnd.ValueChanged
        _numVerseEnd.Value = 1
        Try
            _numVerseEnd.Maximum = _selectedBookEnd.VerseCount(_numChapterEnd.Value)
        Catch ex As Exception
            ' MsgBox("Unable to collect verse count. Please try again")
            ' Ignored
        End Try
    End Sub
    Private WithEvents _cboBookStart As New ComboBox
    Private WithEvents _cboBookEnd As New ComboBox
    Private WithEvents _numChapterStart As New NumericUpDown
    Private WithEvents _numChapterEnd As New NumericUpDown
    Private WithEvents _numVerseStart As New NumericUpDown
    Private WithEvents _numVerseEnd As New NumericUpDown
    Private Shared Function GetBookIndex(nameStr As String) As Integer
        Dim loopCount = 0
        For Each b As Book In Bible.AllBooks()
            If b.Name = nameStr Then
                Return loopCount
            End If
            loopCount += 1
        Next
        Return -1
    End Function
    Public Function GetVerse(v1Obj As VerseObj, v2Obj As VerseObj) As String

        For Each bookItem In Bible.AllBooks()
            _cboBookStart.Items.Add(bookItem.Name)
            _cboBookEnd.Items.Add(bookItem.Name)
        Next
        _cboBookStart.SelectedItem = v1Obj.Book
        _cboBookEnd.SelectedItem = v2Obj.Book
        _numChapterStart.Value = v1Obj.Chapter
        _numChapterEnd.Value = v2Obj.Chapter
        _numVerseStart.Value = v1Obj.Verse
        _numVerseEnd.Value = v2Obj.Verse

        Dim verseStartString = _cboBookStart.SelectedItem & " " & _numChapterStart.Value & ":" & _numVerseStart.Value
        Dim verseEndString = _cboBookEnd.SelectedItem & " " & _numChapterEnd.Value & ":" & _numVerseEnd.Value

        ' Dim v1 = v1Obj
        'Dim v2 = v2Obj
        'v1.Book = _cboBookStart.SelectedItem
        'v1.Chapter = _numChapterStart.Value
        'v1.Verse = _numVerseStart.Value
        'v2.Book = _cboBookEnd.SelectedItem
        'v2.Chapter = _numChapterEnd.Value
        'v2.Verse = _numVerseEnd.Value


        Dim book1Int = GetBookIndex(_cboBookStart.SelectedItem)
        Dim book2Int = GetBookIndex(_cboBookEnd.SelectedItem)
        Dim maxVerses1 = _numVerseStart.Maximum

        If book1Int > book2Int Then
            MsgBox("Selected Start Verse cannot be before Selected End Verse")
            Return Nothing
        ElseIf (book2Int - book1Int) > 1
            MsgBox("Sorry, there cannot be that big of gap between books. Too many verses!")
            Return Nothing
        Else
            If book1Int = book2Int Then
                If _numChapterStart.Value > _numChapterEnd.Value Then
                    MsgBox("Selected Start Verse cannot be before Selected End Verse")
                    Return Nothing
                Else
                    If _numChapterStart.Value = _numChapterEnd.Value Then
                        If _numVerseStart.Value > _numVerseEnd.Value Then
                            MsgBox("Selected Start Verse cannot be before Selected End Verse")
                            Return Nothing
                        End If
                    End If
                End If
            End If
        End If
        ' Should only reach this point if the verses selected for a day are OK
        Dim strContent As String = verseStartString & " - " & verseEndString & " (KJV) - "
        If book1Int = book2Int Then ' Books are the same
            If _numChapterStart.Value = _numChapterEnd.Value Then
                For x = _numVerseStart.Value To _numVerseEnd.Value
                    strContent &= _selectedBookStart.ReadPlainVerse(_numChapterStart.Value, x) & " "
                Next
            ElseIf _numChapterStart.Value < _numChapterEnd.Value Then
                Dim y = _numChapterEnd.Value - _numChapterStart.Value
                For z = 0 To y
                    Select Case z
                        Case 0
                            For x = _numVerseStart.Value To maxVerses1
                                strContent &= _selectedBookStart.ReadPlainVerse(_numChapterStart.Value, x) & " "
                            Next
                        Case _numChapterEnd.Value
                            For x = 1 To _numVerseEnd.Value
                                strContent &= _selectedBookStart.ReadPlainVerse(_numChapterEnd.Value, x) & " "
                            Next
                        Case Else
                            If (_numChapterEnd.Value - _numChapterStart.Value) > 1 Then
                                For x = 1 To _selectedBookStart.VerseCount(y + z)
                                    strContent &= _selectedBookStart.ReadPlainVerse(_numChapterEnd.Value, x) & " "
                                Next
                            Else
                                For x = 1 To _numVerseEnd.Value
                                    strContent &= _selectedBookStart.ReadPlainVerse(_numChapterEnd.Value, x) & " "
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
                For a = _numChapterStart.Value To bookList.ElementAt(0).ChapterCount
                    Select Case a
                        Case _numChapterStart.Value
                            For x = _numVerseStart.Value To bookList.ElementAt(0).VerseCount(a)
                                strContent &= bookList.ElementAt(0).ReadPlainVerse(a, x) & " "
                            Next
                        Case Else
                            For x = 1 To bookList.ElementAt(0).VerseCount(a)
                                strContent &= bookList.ElementAt(0).ReadPlainVerse(a, x) & " "
                            Next
                    End Select
                Next
                For a = 1 To _numChapterEnd.Value
                    Select Case a
                        Case _numChapterEnd.Value
                            For x = 1 To _numVerseEnd.Value
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
        Return strContent
    End Function
End Class
