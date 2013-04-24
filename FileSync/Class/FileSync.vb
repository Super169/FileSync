Option Explicit On

Imports System.IO
Imports System.Text.RegularExpressions

Public Class FileSync
    Public Event StartExecution()
    Public Event UpdateAction(ByVal sourceAction As String, ByVal targetAction As String)
    Public Event FinishExecution()

    Private m_SourcePath As String = ""
    Private m_TargetPath As String = ""
    Private m_BackupPath As String = ""
    Private m_GoBackup As Boolean = False
    Private m_SyncData As Boolean = False
    Private m_FullLog As Boolean = False
    Private m_IgnoreRegex As String = ""

    Private Class SortFiles
        Implements IComparer

        Public Function Compare( _
         ByVal x As Object, ByVal y As Object) As Integer _
         Implements System.Collections.IComparer.Compare
            Dim file1 As FileInfo = CType(x, FileInfo)
            Dim file2 As FileInfo = CType(y, FileInfo)

            Return file1.Name.CompareTo(file2.Name)
        End Function
    End Class

    Private Class SortDirectory
        Implements IComparer

        Public Function Compare( _
         ByVal x As Object, ByVal y As Object) As Integer _
         Implements System.Collections.IComparer.Compare
            Dim file1 As DirectoryInfo = CType(x, DirectoryInfo)
            Dim file2 As DirectoryInfo = CType(y, DirectoryInfo)
            Return file1.Name.CompareTo(file2.Name)
        End Function
    End Class

    Public Sub New()
    End Sub

    'Public Sub InitTask(ByVal sourcePath As String, ByVal targetPath As String, ByVal backupPath As String, ByVal syncData As Boolean, ByVal showIgnore As Boolean)
    '    m_SourcePath = sourcePath.Trim
    '    m_TargetPath = targetPath.Trim
    '    m_BackupPath = backupPath.Trim
    '    m_GoBackup = (m_BackupPath > "")
    '    If m_GoBackup Then m_BackupPath = Path.Combine(m_BackupPath, Now().ToString("yyyyMMdd.HHmmss"))
    '    m_SyncData = syncData
    '    m_FullLog = showIgnore
    'End Sub

    Public Sub InitTask()
        m_SourcePath = oConfig.sourcePath
        m_TargetPath = oConfig.targetPath
        m_BackupPath = oConfig.backupPath
        m_GoBackup = (m_BackupPath > "")
        If m_GoBackup Then m_BackupPath = Path.Combine(m_BackupPath, Now().ToString("yyyyMMdd.HHmmss"))
        m_SyncData = oConfig.syncData
        m_FullLog = oConfig.fullLog
        m_IgnoreRegex = oConfig.ignoreRegex
    End Sub

    Public Sub Execute()
        LogInfo()
        Dim actionName As String
        If (oConfig.syncData) Then
            actionName = "FileSync"
        Else
            actionName = "FileCheck"
        End If
        myUtil.LogMsg(actionName & " Start")
        RaiseEvent StartExecution()
        goFileSync()
        myUtil.LogMsg(actionName & " Completed")
        RaiseEvent FinishExecution()
    End Sub


    Private Sub LogInfo()
        myUtil.LogMsg("Execution configuration:")
        myUtil.LogMsg("    - Source Folder: " & oConfig.sourcePath)
        myUtil.LogMsg("    - Target Folder: " & oConfig.targetPath)
        If (oConfig.backupPath > "") Then
            myUtil.LogMsg("    - Backup Folder: " & oConfig.backupPath)
        Else
            myUtil.LogMsg("    - No backup")
        End If

        If (oConfig.syncData) Then
            myUtil.LogMsg("    - Data synchronization")
        Else
            myUtil.LogMsg("    - Check folder only")
        End If

        If (oConfig.ignoreRegex > "") Then
            myUtil.LogMsg("    - Extra ignore file pattern: " & oConfig.ignoreRegex)
        Else
            myUtil.LogMsg("    - No extra ignore file pattern")
        End If

        If (oConfig.fullLog) Then
            myUtil.LogMsg("    - Full log include ignored files")
        Else
            myUtil.LogMsg("    - Partial log exclude ignored files")
        End If

        If (oConfig.showUI) Then
            myUtil.LogMsg("    - Show window")
        Else
            myUtil.LogMsg("    - Silent mode without UI")
        End If
        myUtil.LogMsg("")
    End Sub

    Private Sub goFileSync()
        Dim msgSource As String = ""
        Dim msgTarget As String = ""

        If (m_SourcePath = "") Or (m_TargetPath = "") Then
            If (m_SourcePath = "") Then msgSource = "ERROR: Missing source path"
            If (m_TargetPath = "") Then msgTarget = "ERROR: Missing source path"
            RaiseEvent UpdateAction(msgSource, msgTarget)
            Return
        End If


        Dim isSourceExists As Boolean = Directory.Exists(m_SourcePath)

        If Not Directory.Exists(m_TargetPath) Then
            myUtil.makeFolder(m_TargetPath)
        End If
        Dim isTargetexists As Boolean = Directory.Exists(m_TargetPath)

        If Not (isSourceExists And isTargetexists) Then
            If (Not isSourceExists) Then msgSource = "ERROR: Source folder not found"
            If (Not isTargetexists) Then msgTarget = "ERROR: Cannot create target folder"
            RaiseEvent UpdateAction(msgSource, msgTarget)
            Return
        End If

        CheckFolder("")


    End Sub


    Sub CheckFolder(ByVal sSubFolder As String)

        On Error GoTo ShowError

        Dim currSource = Path.Combine(m_SourcePath, sSubFolder)
        Dim currTarget = Path.Combine(m_TargetPath, sSubFolder)
        Dim currBackup = Path.Combine(m_BackupPath, sSubFolder)

        Dim diSource As New DirectoryInfo(currSource)
        Dim diTarget As New DirectoryInfo(currTarget)
        Dim fiSource As FileInfo() = diSource.GetFiles()
        Dim fiTarget As FileInfo() = diTarget.GetFiles()
        Dim dsSource As DirectoryInfo() = diSource.GetDirectories()
        Dim dsTarget As DirectoryInfo() = diTarget.GetDirectories()
        Dim idxSource, idxTarget As Integer

        Array.Sort(fiSource, New SortFiles)
        Array.Sort(fiTarget, New SortFiles)

        Array.Sort(dsSource, New SortDirectory)
        Array.Sort(dsTarget, New SortDirectory)

        idxSource = 0
        idxTarget = 0

        Do While ((idxSource < fiSource.Length) Or (idxTarget < fiTarget.Length))

            Dim bFindSource, bFindTarget, bIgnoreSource, bIgnoreTarget As Boolean
            Dim sSourceFile, sTargetFile As String
            Dim iCompare As Integer = 0

            sSourceFile = ""
            sTargetFile = ""
            bFindSource = (idxSource < fiSource.Length)
            If bFindSource Then sSourceFile = fiSource(idxSource).Name
            bIgnoreSource = (Not bFindSource) Or IgnoreFile(sSourceFile)

            bFindTarget = (idxTarget < fiTarget.Length)
            If bFindTarget Then sTargetFile = fiTarget(idxTarget).Name
            bIgnoreTarget = (Not bFindTarget) Or IgnoreFile(sTargetFile)

            If (bFindSource And bFindTarget) Then
                iCompare = sSourceFile.CompareTo(sTargetFile)
            End If

            If (bFindSource And bIgnoreSource And bFindTarget And bIgnoreTarget) Then
                If m_FullLog Then RaiseEvent UpdateAction("[I] " & Path.Combine(sSubFolder, sSourceFile), "[I] " & Path.Combine(sSubFolder, sTargetFile))
                idxSource = idxSource + 1
                idxTarget = idxTarget + 1
            ElseIf (bFindSource And bIgnoreSource) Then
                If m_FullLog Then RaiseEvent UpdateAction("[I] " & Path.Combine(sSubFolder, sSourceFile), "")
                idxSource = idxSource + 1
            ElseIf (bFindTarget And bIgnoreTarget) Then
                If m_FullLog Then RaiseEvent UpdateAction("", "[I] " & Path.Combine(sSubFolder, sTargetFile))
                idxTarget = idxTarget + 1
            ElseIf (Not bFindSource) Or (iCompare > 0) Then
                RaiseEvent UpdateAction("", "[D] " & Path.Combine(sSubFolder, sTargetFile))
                If m_SyncData Then
                    If (m_GoBackup) Then
                        myUtil.makeFolder(currBackup)
                        File.Copy(Path.Combine(currTarget, sTargetFile), Path.Combine(currBackup, sTargetFile))
                    End If
                    File.Delete(Path.Combine(currTarget, sTargetFile))
                End If
                idxTarget = idxTarget + 1
            ElseIf (Not bFindTarget) Or (iCompare < 0) Then
                RaiseEvent UpdateAction("[A] " & Path.Combine(sSubFolder, sSourceFile), "")
                If m_SyncData Then
                    ' TODO: handle 8.3 filename in source DEN_SP~1.BMP, use overwrite mode, but not recommended
                    File.Copy(Path.Combine(currSource, sSourceFile), Path.Combine(currTarget, sSourceFile), True)
                End If
                idxSource = idxSource + 1
            Else
                CheckFile(fiSource(idxSource), fiTarget(idxTarget), sSubFolder)
                idxSource = idxSource + 1
                idxTarget = idxTarget + 1
            End If


        Loop

        idxSource = 0
        idxTarget = 0

        Do While ((idxSource < dsSource.Length) Or (idxTarget < dsTarget.Length))
            If (idxSource >= dsSource.Length) Then
                RaiseEvent UpdateAction("", "[D] [" & Path.Combine(sSubFolder, dsTarget(idxTarget).Name) & "]")
                If m_SyncData Then
                    If (m_GoBackup) Then
                        myUtil.makeFolder(currBackup)
                        My.Computer.FileSystem.CopyDirectory(Path.Combine(currTarget, dsTarget(idxTarget).Name), _
                                                             Path.Combine(currBackup, dsTarget(idxTarget).Name))
                    End If
                    System.IO.Directory.Delete(Path.Combine(currTarget, dsTarget(idxTarget).Name))  ' i.e. dsTarget(idxTarget).FullName
                End If
                idxTarget = idxTarget + 1
            ElseIf (idxTarget >= dsTarget.Length) Then
                RaiseEvent UpdateAction("[A] [" & Path.Combine(sSubFolder, dsSource(idxSource).Name) & "]", "")
                If m_SyncData Then
                    CopyFolder(Path.Combine(sSubFolder, dsSource(idxSource).Name))
                End If
                idxSource = idxSource + 1
            ElseIf String.Equals(dsSource(idxSource).Name, dsTarget(idxTarget).Name) Then
                'Dim sNewPath
                'If (sSubFolder > "") Then
                '    sNewPath = Path.Combine(sSubFolder, dsSource(idxSource).Name)
                'Else
                '    sNewPath = dsSource(idxSource).Name
                'End If
                CheckFolder(Path.Combine(sSubFolder, dsSource(idxSource).Name))
                idxSource = idxSource + 1
                idxTarget = idxTarget + 1
            ElseIf (idxTarget > dsTarget.Length) Or (dsSource(idxSource).Name.CompareTo(dsTarget(idxTarget).Name) < 0) Then
                RaiseEvent UpdateAction("[A] [" & Path.Combine(sSubFolder, dsSource(idxSource).Name) & "]", "")
                If m_SyncData Then
                    CopyFolder(Path.Combine(sSubFolder, dsSource(idxSource).Name))
                End If
                idxSource = idxSource + 1
            Else
                RaiseEvent UpdateAction("", "[D] [" & Path.Combine(sSubFolder, dsTarget(idxTarget).Name) & "]")
                If m_SyncData Then
                    If (m_GoBackup) Then
                        myUtil.makeFolder(currBackup)
                        My.Computer.FileSystem.CopyDirectory(Path.Combine(currTarget, dsTarget(idxTarget).Name), _
                                                             Path.Combine(currBackup, dsTarget(idxTarget).Name))
                    End If
                    System.IO.Directory.Delete(Path.Combine(currTarget, dsTarget(idxTarget).Name), True)
                End If
                idxTarget = idxTarget + 1
            End If
        Loop

        Return

ShowError:

        RaiseEvent UpdateAction("#### Exceution Error ####", Err.GetException.Message)

    End Sub

    Public Sub CheckFile(ByVal fiSource As FileInfo, ByVal fiTarget As FileInfo, ByVal sSubFolder As String)

        If (fiSource.Length <> fiTarget.Length) Or (fiSource.LastWriteTime <> fiTarget.LastWriteTime) Then
            RaiseEvent UpdateAction("[U] " & Path.Combine(sSubFolder, fiSource.Name), "[U] " & Path.Combine(sSubFolder, fiSource.Name))
            If m_SyncData Then
                If (m_GoBackup) Then
                    myUtil.makeFolder(Path.Combine(m_BackupPath, sSubFolder))
                    File.Copy(fiTarget.FullName, Path.Combine(m_BackupPath, sSubFolder, fiTarget.Name))
                End If
                File.Copy(fiSource.FullName, fiTarget.FullName, True)
            End If
        End If
    End Sub

    Private Sub CopyFolder(ByVal sSubFolder As String)
        Dim currSource = Path.Combine(m_SourcePath, sSubFolder)
        Dim currTarget = Path.Combine(m_TargetPath, sSubFolder)
        Dim currBackup = Path.Combine(m_BackupPath, sSubFolder)

        Dim diSource As New DirectoryInfo(currSource)
        Dim fiSource As FileInfo() = diSource.GetFiles()
        Dim dsSource As DirectoryInfo() = diSource.GetDirectories()
        Dim idxSource As Integer = 0

        myUtil.makeFolder(currTarget)

        For Each o In fiSource
            Dim currFile As String = Path.Combine(sSubFolder, o.Name)
            If IgnoreFile(o.Name) Then
                If m_FullLog Then RaiseEvent UpdateAction("[I] " & currFile, "")
            Else
                RaiseEvent UpdateAction("[A] " & currFile, "")
                If m_SyncData Then
                    ' TODO: handle 8.3 filename in source DEN_SP~1.BMP, use overwrite mode, but not recommended
                    File.Copy(Path.Combine(currSource, o.Name), Path.Combine(currTarget, o.Name))
                End If
            End If
        Next

        For Each o In dsSource
            RaiseEvent UpdateAction("[A] [" & Path.Combine(sSubFolder, o.Name) & "]", "")
            CopyFolder(Path.Combine(sSubFolder, o.Name))
        Next

    End Sub

    Private Function IgnoreFile(ByVal filename As String) As Boolean

        If ((filename.Length > 2) AndAlso ((filename.Substring(0, 2) = "~$") Or (filename = "Thumbs.db"))) Then
            Return True
        End If

        If (oConfig.ignoreRegex = "") Then Return False

        Dim regex As Regex = New Regex(oConfig.ignoreRegex)
        Dim match As Match = regex.Match(filename)
        Return match.Success

    End Function




End Class
