Option Explicit On

Imports System.IO
Imports System.Text.RegularExpressions

Public Class myUtil

    Private Shared m_LogFile As String
    Private Shared msgLocker As Object = New Object()

    Public Shared Sub makeFolder(ByVal sPath As String)
        If System.IO.Directory.Exists(sPath) Then Return
        Dim iPos = sPath.LastIndexOf("\")
        If (iPos > 2) Then
            makeFolder(sPath.Substring(0, iPos))
        End If
        System.IO.Directory.CreateDirectory(sPath)
    End Sub

    Public Shared Sub InitLog()
        Dim logPath = Path.Combine(Directory.GetCurrentDirectory, "LOG")
        Dim dNow As Date = Now()
        logPath = Path.Combine(logPath, dNow.ToString("yyyy"), dNow.ToString("yyyyMM"))
        makeFolder(logPath)
        m_LogFile = Path.Combine(logPath, Now().ToString("yyyyMMdd") & ".log")
    End Sub

    Public Shared Sub LogEmptyLine(Optional ByVal lines As Integer = 1)
        Dim f As StreamWriter
        SyncLock msgLocker
            f = New StreamWriter(m_LogFile, FileMode.Append)
            If (lines < 1) Then lines = 1
            Dim s = New String(vbCrLf, lines)
            f.Write(s)
            f.Close()
        End SyncLock
    End Sub


    Public Shared Sub LogMsg(ByVal msg As String)
        Dim f As StreamWriter
        Dim s As String
        SyncLock msgLocker
            s = D2S(Now()) + " - " + msg
            f = New StreamWriter(m_LogFile, FileMode.Append)
            f.WriteLine(s)
            f.Close()
        End SyncLock
    End Sub

    Public Shared Function D2S(ByRef data As DateTime, Optional ByVal emptyString As String = "", Optional ByVal checkDateOnly As Boolean = False) As String
        If data = Nothing Then Return emptyString
        If checkDateOnly AndAlso ((data.Hour = 0) And (data.Minute = 0) And (data.Second = 0)) Then
            Return data.ToString("yyyy-MM-dd")
        End If
        Return data.ToString("yyyy-MM-dd HH:mm:ss")
    End Function

    Public Shared Function validPath(ByVal filePath As String) As Boolean
        Dim regex As Regex = New Regex("^(([a-zA-Z]:)|(\\{2}\w+)\$?(\\[ \w-@#\$%]*([\w-@#\$%])+(\.[ \w-@#\$%]*([\w-@#\$%])+)*))(\\[ \w-@#\$%]*([\w-@#\$%])+(\.[ \w-@#\$%]*([\w-@#\$%])+)*)*\\?$")
        Dim match As Match = regex.Match(filePath)
        Return match.Success
    End Function

End Class
