Option Explicit On

Imports System.IO
Imports System.Reflection

Module modMain

    Public m_App As myApp
    Private errMsg As String = ""
    Private oFileSyncEngine As New FileSync

    Public Sub Main()

        If Not Initization() Then
            myUtil.LogMsg(errMsg)
            frmAbout.SetError(errMsg)
            frmAbout.ShowDialog()
            Return
        End If

        m_App = New myApp
        m_App.Start()

        Application.Run()
    End Sub

    Private Function Initization() As Boolean


        myUtil.InitLog()
        myUtil.LogEmptyLine(3)
        myUtil.LogMsg("Start FileSync v" + My.Application.Info.Version.ToString())

        oConfig.Initialization()

        Dim args As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Application.CommandLineArgs

        errMsg = ""
        If (args.Count = 0) Then
            oConfig.winApp = True
            oConfig.showUI = True
            Return True
        End If

        oConfig.winApp = False
        myUtil.LogMsg(Environment.CommandLine)
        Dim idx As Integer = 0
        Do While idx < args.Count
            Dim argOption As String = args(idx).ToLower
            idx = idx + 1
            Dim c As Char = argOption.Substring(0, 1)
            If (c <> "-") Then
                errMsg = "Invalid option: " & argOption
                Return False
            End If
            Dim flag As String = argOption.Substring(1, argOption.Length - 1)
            Select Case flag
                Case "s", "t", "b"
                    If (idx = args.Count) Then
                        errMsg = "Missing file path for option " & argOption
                        Return False
                    End If
                    Dim filePath = args(idx)
                    idx = idx + 1
                    If Not myUtil.validPath(filePath) Then
                        errMsg = "Invalid path: " & filePath
                        Return False
                    End If
                    Select Case flag
                        Case "s"
                            If Not Directory.Exists(filePath) Then
                                errMsg = "Source path [" & filePath & "] not found"
                                Return False
                            End If
                            oConfig.sourcePath = filePath
                        Case "t"
                            oConfig.targetPath = filePath
                        Case "b"
                            oConfig.backupPath = filePath
                    End Select
                Case "c", "checkfolderonly"
                    oConfig.syncData = False
                Case "n", "noui"
                    oConfig.showUI = False
                Case "f", "fulllog"
                    oConfig.fullLog = True
                Case "?", "h", "help"
                    errMsg = "FileSync"
                    Return False
                Case Else
                    errMsg = "Invalid option: " & argOption
                    Return False
            End Select
        Loop

        If oConfig.sourcePath = "" Then
            If oConfig.targetPath = "" Then
                errMsg = "Source and target path not defined"
                Return False
            End If
            errMsg = "Source path not defined"
            Return False
        End If

        If oConfig.targetPath = "" Then
            errMsg = "Target path not defined"
            Return False
        End If

        Return True
    End Function



    Private Function CheckPath(ByVal filePath As String, ByVal mustExists As Boolean) As Boolean
        If filePath.Length < 3 Then Return False
        Dim c As Char = filePath.Substring(1, 1)
        If ((c <> ":") And (c <> "\")) Then Return False
        Return True
    End Function

End Module
