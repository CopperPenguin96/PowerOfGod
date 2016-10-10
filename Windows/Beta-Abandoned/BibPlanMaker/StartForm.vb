Imports System.IO
Imports System.Management

Public Class StartForm
    Public Shared IsNewFile As Boolean
    Public Shared EditorPath As String
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        EditorForm.Show()
        Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OpenFileDialog.ShowDialog()
    End Sub

    Private Sub OpenFileDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog.FileOk
        If Not GoodExt(OpenFileDialog.FileName) Then
            MsgBox("Sorry, but the file you selected is not a valid bible plan. Be select a valid .bibplan file.")
        Else
            IsNewFile = True
            EditorPath = OpenFileDialog.FileName
            EditorForm.Show()
            Hide()
        End If
    End Sub

    Private Function GoodExt(pathf As String) As Boolean
        Return Path.GetExtension(pathf.ToLower()) = ".bibplan"
    End Function
    Private Sub StartForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
