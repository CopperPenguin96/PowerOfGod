Imports System.IO
Imports System.IO.Compression
Imports System.Reflection
Imports ICSharpCode.SharpZipLib
Imports ICSharpCode.SharpZipLib.Core
Imports ICSharpCode.SharpZipLib.Zip
Imports Ionic.Zip


Module Main

    Sub Main()
        'Const folderPath As String = "power.of.god/temp_updates/UpdateFolder/"
        Const dir = "power.of.god/temp_updates/"
        Directory.CreateDirectory(dir)
        Const zipPath = "power.of.god/temp_updates/update.zip"

        Dim mainFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace("\\", "/")
        Dim entries As New List(Of ZipEntry)
        Dim archive = New ZipFile(zipPath)
        For x = 0 To archive.Count
            Try
                entries.Add(archive.EntryByIndex(x))
            Catch e As IndexOutOfRangeException
                ' Ignored
            End Try
        Next
        Using archive
            Try
                For Each entry As ZipEntry In archive
                    Dim entryPath = dir & entry.Name
                    If entry.IsDirectory Then
                        If Not Directory.Exists(entryPath) Then
                            Directory.CreateDirectory(entryPath)
                        End If
                    Else
                        'entry.Extract(entryFullname True)
                        Dim buffer(4096) As Byte
                        Dim zipStream As Stream = archive.GetInputStream(entry)
                        Using streamWriter As FileStream = File.Create(entryPath)
                            StreamUtils.Copy(zipStream, streamWriter, buffer)
                        End Using
                    End If

                Next
            Finally

                If Not archive.Equals(Nothing) Then
                    archive.IsStreamOwner = True
                    archive.Close()
                End If

            End Try

        End Using
        File.Delete("power.of.god/temp_updates/update.zip")
        For Each fileStr In Directory.GetFiles("power.of.god/temp_updates/")
            Try
                Dim fileSub = fileStr.Substring(26)
                File.Move(fileStr, fileSub)
                Console.WriteLine("Moved " & fileStr)
            Catch ex As Exception
                Try
                    File.Delete(fileStr.Substring(26))
                Catch ex2 As Exception
                    MsgBox("Update failed.")
                End Try
            End Try
        Next
        For Each dirStr In Directory.GetDirectories("power.of.god/temp_updates/")
            Try
                Dim dirSub = dirStr.Substring(26)
                Directory.Move(dirStr, dirSub)
                Console.WriteLine("Moved " & dirStr)
            Catch ex As Exception
                MsgBox("Update failed.")
            End Try
        Next
        MsgBox("The update was successfully finished.")
    End Sub

End Module
