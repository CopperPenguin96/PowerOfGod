Imports System.IO
Imports System.Reflection

Module Main

    Sub Main()
        Const folderPath As String = "power.of.god/temp_updates/UpdateFolder/"
        Dim mainFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace("\\", "/")
        For Each i In Directory.GetFiles(folderPath)
            My.Computer.FileSystem.CopyFile(folderPath & i, mainFolder & "/" & i,
                                            Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                                            Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
            Console.WriteLine("Moved " & i)
            Console.ReadKey()
        Next
    End Sub

End Module
