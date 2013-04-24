Option Explicit On

Imports System.Reflection

Public Class oConfig
    Public Shared winApp As Boolean = True
    Public Shared sourcePath As String = ""
    Public Shared targetPath As String = ""
    Public Shared backupPath As String = ""
    Public Shared showUI As Boolean = True
    Public Shared fullLog As Boolean = False
    Public Shared syncData As Boolean = True
    Public Shared ignoreRegex As String = ""

    Public Shared iconLogo As Drawing.Icon
    Public Shared iconWorking(7) As Drawing.Icon
    Public Shared iconCount As Integer = 8

    Public Shared Sub Initialization()
        oConfig.iconLogo = New Icon([Assembly].GetExecutingAssembly.GetManifestResourceStream("FileSync.FileSync.ico"))
        For idx = 0 To oConfig.iconCount - 1
            oConfig.iconWorking(idx) = New Icon([Assembly].GetExecutingAssembly.GetManifestResourceStream("FileSync.Sync-" & idx & ".ico"))
        Next

        Dim args As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Application.CommandLineArgs

    End Sub


End Class
