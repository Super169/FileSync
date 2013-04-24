Option Explicit On

Imports System.Threading

Public Class myApp
    Private WithEvents NotifyIcon As System.Windows.Forms.NotifyIcon
    Private mMenuItems() As MenuItem
    Private m_ThreadIcon As New System.Threading.Thread(AddressOf ThreadChangeIcon)
    Private m_ChangeIcon As Boolean = True
    Private m_IconIdx As Integer = 0
    Private m_ThreadFileSync As System.Threading.Thread

    Public Shared m_FileSync As New FileSync()

    Public Sub Start()
        Initialization()

        frmMain.SetMsgHandler(AddressOf MsgHandler)
        If oConfig.showUI Then
            frmMain.Show()
            If (Not oConfig.winApp) Then frmMain.goFileSyncThread(oConfig.syncData)
        Else
            AddHandler m_FileSync.StartExecution, AddressOf StartExecution
            AddHandler m_FileSync.UpdateAction, AddressOf UpdateAction
            AddHandler m_FileSync.FinishExecution, AddressOf FinishExecution
            m_FileSync.InitTask()

            m_ThreadFileSync = New System.Threading.Thread(AddressOf m_FileSync.Execute)
            m_ThreadFileSync.Start()

        End If
    End Sub



    Public Sub StartExecution()
        If (oConfig.syncData) Then
            UpdateInfo("FileSync [" & oConfig.sourcePath & "]")
        Else
            UpdateInfo("FileCheck [" & oConfig.sourcePath & "]")
        End If
        Me.m_ChangeIcon = True
        m_ThreadIcon = New System.Threading.Thread(AddressOf ThreadChangeIcon)
        m_ThreadIcon.Start()
    End Sub

    Private Sub UpdateAction(ByVal sLeft As String, ByVal sRight As String, Optional ByVal JobComplete As Boolean = False)
        myUtil.LogMsg("Info: {" & sLeft & "  |  " & sRight & "}")
    End Sub

    Public Sub FinishExecution()
        UpdateInfo("")
        Me.m_ChangeIcon = False
        m_ThreadIcon.Join()
        If Not oConfig.showUI Then AppExit()
    End Sub

    Private Sub Initialization()

        InitializeNotifyIcon()
    End Sub

    Public Sub InitializeNotifyIcon()
        NotifyIcon = New System.Windows.Forms.NotifyIcon
        NotifyIcon.Icon = oConfig.iconLogo
        NotifyIcon.Visible = True


        If (oConfig.showUI) Then
            AddMenuItem(New MenuItem("Show", AddressOf Me.ShowWin))
            AddMenuItem(New MenuItem("-"))
        End If
        AddMenuItem(New MenuItem("About", AddressOf Me.ShowAbout))
        AddMenuItem(New MenuItem("-"))
        AddMenuItem(New MenuItem("Exit", AddressOf Me.AppExit))
        Dim notifyiconMnu As ContextMenu = New ContextMenu(mMenuItems)
        NotifyIcon.ContextMenu = notifyiconMnu
    End Sub

    Public Sub AddMenuItem(ByVal menuItem As MenuItem)
        If mMenuItems Is Nothing Then
            ReDim mMenuItems(0)
        Else
            ReDim Preserve mMenuItems(mMenuItems.Length)
        End If
        mMenuItems(mMenuItems.Length - 1) = menuItem
    End Sub

    Public Sub ShowWin()
        frmMain.WindowState = System.Windows.Forms.FormWindowState.Normal
        frmMain.Show()
    End Sub

    Public Sub ShowAbout()
        frmAbout.SetAbout()
        frmAbout.Show()
    End Sub

    Public Sub AppExit()
        If oConfig.showUI Then
            frmMain.StopForExit()
            frmMain.Close()
        End If
        m_ThreadIcon.Abort()
        NotifyIcon.Dispose()
        myUtil.LogMsg("Exit FileSync")
        Application.Exit()
    End Sub

    Public Sub MsgHandler(ByVal msgId As MsgID, ByRef o As Object)
        Select Case msgId
            Case msgId.EXECUTION_START
                StartExecution()
            Case msgId.EXECUTION_END
                FinishExecution()
            Case Global.FileSync.MsgID.PROGRAM_EXIT
                Me.AppExit()
        End Select
    End Sub

    Private Sub UpdateInfo(ByVal info As String)
        NotifyIcon.Text = info
    End Sub

    Public Sub StartIconChange()
        m_ChangeIcon = True
        m_IconIdx = 0
        m_ThreadIcon.Start()
    End Sub

    Public Sub ThreadChangeIcon()
        Do While m_ChangeIcon
            NotifyIcon.Icon = oConfig.iconWorking(m_IconIdx)
            m_IconIdx = ((m_IconIdx + 1) Mod oConfig.iconCount)
            System.Threading.Thread.Sleep(200)
        Loop
        NotifyIcon.Icon = oConfig.iconLogo
    End Sub

End Class

Public Enum MsgID As Integer
    EXECUTION_START = 101
    EXECUTION_END = 199
    PROGRAM_EXIT = 999
End Enum