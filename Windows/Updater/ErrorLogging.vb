
Imports System.Collections.Generic
Imports System.IO

Public Class ErrorLogging
    Private Shared _now As DateTime = DateTime.Now
    Private Shared ReadOnly Nl As String = Environment.NewLine
    Public Shared Sub Write(ex As Exception)
        If Not Directory.Exists("Logs/") Then
            Directory.CreateDirectory("Logs/")
        End If
        Dim fileLines = New List(Of String)() From {
                Convert.ToString("-----Power of God Error Log (Updater)-----") & Nl
                }
        Try
            fileLines.Add("Exception Message: " + ex.Message)
        Catch generatedExceptionName As Exception
            fileLines.Add(Nl)
        End Try
        fileLines.Add(ex.ToString())
        fileLines.Add(Nl & Nl)
        fileLines.Add(ex.StackTrace)
        fileLines.Add("Log wrote at " + _now.ToLongDateString())
        Dim writingPath = "Logs/" & "Updater" & _now.ToLongDateString() & "." & _now.Hour & "." & _now.Minute & "." + _now.Second & ".txt"
        Dim fWriter = File.CreateText(writingPath)

        For Each f In fileLines
            fWriter.Write(Convert.ToString(f) & Nl)

        Next
        fWriter.Flush()
        fWriter.Close()
    End Sub
End Class

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
