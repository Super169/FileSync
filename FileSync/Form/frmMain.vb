Imports System.IO
Imports System.Text.RegularExpressions

Public Class frmMain

    Dim sBackupFolder As String = ""
    Dim bSyncData As Boolean = False
    Dim bRunning As Boolean = False
    Dim m_FileSync As FileSync
    Dim m_Thread As System.Threading.Thread

    Private Delegate Sub showActionDelegate(ByVal sLeft As String, ByVal sRight As String, ByVal JobComplete As Boolean)

    Public Delegate Sub MsgHandler(ByVal msgId As MsgID, ByRef o As Object)
    Private m_EnableMsgHandler As Boolean = False
    Private m_MsgHandler As MsgHandler

    Public Sub SetMsgHandler(ByVal fxMsgHandler As MsgHandler)
        Me.m_EnableMsgHandler = True
        Me.m_MsgHandler = fxMsgHandler
    End Sub

    Public Sub SendMsg(ByVal MsgId As MsgID)
        SendMsg(MsgId, Nothing)
    End Sub

    Public Sub SendMsg(ByVal MsgId As MsgID, ByRef o As Object)
        If m_EnableMsgHandler Then
            Me.m_MsgHandler.Invoke(MsgId, o)
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim args As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Application.CommandLineArgs

        Me.Text = "FileSync (v " + My.Application.Info.Version.ToString() + ")"

        lvAction.View = System.Windows.Forms.View.Details
        lvAction.GridLines = True
        lvAction.FullRowSelect = True

        txtSource.Text = oConfig.sourcePath
        txtTarget.Text = oConfig.targetPath
        txtBackup.Text = oConfig.backupPath
        cbxShowIgnore.Checked = oConfig.fullLog
        txtRegex.Text = oConfig.ignoreRegex

    End Sub

    Private Sub btnCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheck.Click
        myUtil.LogMsg("FileCheck started for [" & txtSource.Text & "] [" & txtTarget.Text & "] [" & txtBackup.Text & "]")
        goFileSyncThread(False)
    End Sub

    Private Sub btnSync_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSync.Click
        myUtil.LogMsg("FileSync started for [" & txtSource.Text & "] [" & txtTarget.Text & "] [" & txtBackup.Text & "]")
        goFileSyncThread(True)
    End Sub

    Public Sub goFileSyncThread(ByVal syncData As Boolean)
        If bRunning Then Return
        bRunning = True

        lblMsg.Text = "Working......Please Wait......"
        btnClose.Text = "Hide"
        btnStop.Enabled = True

        Dim sourcePath = txtSource.Text.Trim
        Dim targetPath = txtTarget.Text.Trim
        lvAction.Clear()
        lvAction.Columns.Clear()
        lvAction.Columns.Add(sourcePath, 450)
        lvAction.Columns.Add(targetPath, 450)

        oConfig.sourcePath = txtSource.Text.Trim
        oConfig.targetPath = txtTarget.Text.Trim
        oConfig.backupPath = txtBackup.Text.Trim
        oConfig.fullLog = cbxShowIgnore.Checked
        oConfig.ignoreRegex = txtRegex.Text.Trim
        oConfig.syncData = syncData

        m_FileSync = New FileSync()
        m_FileSync.InitTask()
        AddHandler m_FileSync.StartExecution, AddressOf StartExecution
        AddHandler m_FileSync.UpdateAction, AddressOf UpdateAction
        AddHandler m_FileSync.FinishExecution, AddressOf FinishExecution
        m_Thread = New System.Threading.Thread(AddressOf m_FileSync.Execute)
        m_Thread.Start()

    End Sub

    Private Sub StartExecution()
        SendMsg(MsgID.EXECUTION_START)
    End Sub

    Private Sub FinishExecution()
        bRunning = False
        UpdateAction("<<------ Completed ------>>", "<<------ Completed ------>>", True)
        SendMsg(MsgID.EXECUTION_END)
        If (Not oConfig.winApp) Then
            SendMsg(MsgID.PROGRAM_EXIT)
        End If
    End Sub

    Private Sub UpdateAction(ByVal sLeft As String, ByVal sRight As String, Optional ByVal JobComplete As Boolean = False)
        myUtil.LogMsg("Info: {" & sLeft & "  |  " & sRight & "}")
        If (lvAction.InvokeRequired) Then
            Me.BeginInvoke(New showActionDelegate(AddressOf showAction), sLeft, sRight, JobComplete)
        Else
            showAction(sLeft, sRight, JobComplete)
        End If
    End Sub

    Private Sub showAction(ByVal sLeft As String, ByVal sRight As String, ByVal JobComplete As Boolean)
        lvAction.Items.Add(New ListViewItem({sLeft, sRight}))
        If JobComplete Then
            lblMsg.Text = ""
            btnClose.Text = "Exit"
            btnStop.Enabled = False
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If bRunning Then
            Me.Hide()
        Else
            SendMsg(MsgID.PROGRAM_EXIT)
            Me.Close()
        End If
    End Sub

    Private Sub GetFolder(ByRef tbPath As TextBox)
        Dim ffd As New FileFolderDialog
        ffd.SelectedPath = tbPath.Text
        If ffd.ShowDialog() = DialogResult.OK Then
            tbPath.Text = ffd.SelectedPath
        End If
        ffd.Dispose()
        tbPath.Focus()
    End Sub

    Private Sub btnSourceFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSourceFile.Click
        GetFolder(txtSource)
    End Sub

    Private Sub btnTargetFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTargetFile.Click
        GetFolder(txtTarget)
    End Sub

    Private Sub btnBackupPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackupPath.Click
        GetFolder(txtBackup)
    End Sub

    Public Sub StopForExit()
        If bRunning Then
            m_Thread.Abort()
            bRunning = False
        End If
        lblMsg.Text = ""
        Me.Dispose()
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        If bRunning Then
            m_Thread.Abort()
            bRunning = False
        End If
        lblMsg.Text = ""
        btnClose.Text = "Exit"
        btnStop.Enabled = False
    End Sub


End Class
