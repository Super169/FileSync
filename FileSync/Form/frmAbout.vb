Imports System.Reflection

Public Class frmAbout

    Private m_IconIdx As Integer = 8 ' satrt from normal
    Private m_changeIcon As Boolean = True
    Private m_ThreadIcon As New System.Threading.Thread(AddressOf ThreadChangeIcon)
    Private m_IconBMP = New Bitmap([Assembly].GetExecutingAssembly.GetManifestResourceStream("FileSync.FileSyncIcon.gif"))

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim myAssInfo As System.Reflection.Assembly
        'myAssInfo = System.Reflection.Assembly.GetExecutingAssembly

        'lblVersion.Text = "(Version " + myAssInfo.GetName.Version.ToString + ")"
        Me.Text = "FileSync v" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor
        lblVersion.Text = "(Version " + My.Application.Info.Version.ToString() + ")"
        m_ThreadIcon.Start()
    End Sub

    Public Sub SetAbout()
        lblWarning.Text = "NOT A WARNING"
        lblCopyrightMsg.Visible = True
        txtSyntax.Visible = False
    End Sub

    Public Sub SetError(ByVal errMsg As String)
        lblWarning.Text = errMsg
        lblCopyrightMsg.Visible = False
        txtSyntax.Visible = True
    End Sub

    Public Sub ThreadChangeIcon()
        ' 0 - 7 - roulling 
        ' 8 - 9 - icon
        ' 10 - 17 - Normal
        ' 18 - 19 - icon
        Do While m_changeIcon
            If (m_IconIdx < 8) Then
                pbIcon.Image = oConfig.iconWorking(m_IconIdx).ToBitmap
            ElseIf (m_IconIdx < 10) Or (m_IconIdx > 17) Then
                pbIcon.Image = oConfig.iconLogo.ToBitmap
            Else
                pbIcon.Image = m_IconBMP
            End If
            m_IconIdx = ((m_IconIdx + 1) Mod 10)
            System.Threading.Thread.Sleep(200)
        Loop
    End Sub

    Private Sub frmAbout_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        m_changeIcon = False
        m_ThreadIcon.Abort()
    End Sub

End Class