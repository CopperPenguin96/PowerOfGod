Imports System.IO
Imports System.IO.Compression
Imports System.Reflection

Module Main

    Sub Main()
        'Const folderPath As String = "power.of.god/temp_updates/UpdateFolder/"
        Const zipPath = "power.of.god/temp_updates/update.zip"
        Dim mainFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace("\\", "/")
        Using archive As ZipArchive = ZipFile.OpenRead(zipPath)
            For Each entry As ZipArchiveEntry In archive.Entries
                Dim entryFullname = Path.Combine(mainFolder, entry.FullName)
                Dim entryPath = Path.GetDirectoryName(entryFullname)
                If (Not (Directory.Exists(entryPath))) Then
                    Directory.CreateDirectory(entryPath)
                End If

                Dim entryFn = Path.GetFileName(entryFullname)
                If (Not String.IsNullOrEmpty(entryFn)) Then
                    entry.ExtractToFile(entryFullname, True)
                End If
            Next
        End Using
        MsgBox("The update was successfully finished.")
    End Sub

End Module
