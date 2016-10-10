Imports System.IO
Imports Lesson
Imports Newtonsoft.Json

Module Module1
    ReadOnly DirStr = "pluginfiles/"
    Sub Main()
        If Not Directory.Exists(DirStr) Then
            Directory.CreateDirectory(DirStr)
        End If
        Dim pluginList As New List(Of Power_of_God_Lib.Plugins.Plugin)
        pluginList.Add(New Purpose.Plugin())
        pluginList.Add(New Lesson.Plugin())
        pluginList.Add(New BiblePlanPlugin.Plugin())
        pluginList.Add(New DailyScripture.Plugin())
        Console.WriteLine("Deleting any old files...")

        For Each f In Directory.GetFiles(DirStr)
            File.Delete(f)
        Next
        For Each p In pluginList
            Write(p)
        Next
        Console.ReadKey()
    End Sub

    Sub Write(p As Power_of_God_Lib.Plugins.Plugin)
        Console.WriteLine("Creating file " & p.Name & ".pogplugin")
        Dim x As StreamWriter = File.CreateText(DirStr & p.Name & ".pogplugin")
        x.Write(JsonConvert.SerializeObject(p))
        x.Flush()
        x.Close()
        Threading.Thread.Sleep(3000)
        Console.WriteLine("File write was success. Moving on to next if there is one")
    End Sub
End Module
