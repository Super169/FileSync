<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        Me.lblCopyrightMsg = New System.Windows.Forms.Label()
        Me.lblWarning = New System.Windows.Forms.Label()
        Me.lblNoRight = New System.Windows.Forms.Label()
        Me.lblCopyright = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pbLogo = New System.Windows.Forms.PictureBox()
        Me.txtSyntax = New System.Windows.Forms.TextBox()
        Me.pbIcon = New System.Windows.Forms.PictureBox()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCopyrightMsg
        '
        Me.lblCopyrightMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCopyrightMsg.ForeColor = System.Drawing.Color.White
        Me.lblCopyrightMsg.Location = New System.Drawing.Point(28, 217)
        Me.lblCopyrightMsg.Name = "lblCopyrightMsg"
        Me.lblCopyrightMsg.Size = New System.Drawing.Size(360, 100)
        Me.lblCopyrightMsg.TabIndex = 14
        Me.lblCopyrightMsg.Text = resources.GetString("lblCopyrightMsg.Text")
        Me.lblCopyrightMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblWarning
        '
        Me.lblWarning.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWarning.ForeColor = System.Drawing.Color.Red
        Me.lblWarning.Location = New System.Drawing.Point(8, 175)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Size = New System.Drawing.Size(401, 20)
        Me.lblWarning.TabIndex = 13
        Me.lblWarning.Text = "NOT A WARNING"
        Me.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNoRight
        '
        Me.lblNoRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoRight.ForeColor = System.Drawing.Color.White
        Me.lblNoRight.Location = New System.Drawing.Point(171, 122)
        Me.lblNoRight.Name = "lblNoRight"
        Me.lblNoRight.Size = New System.Drawing.Size(238, 20)
        Me.lblNoRight.TabIndex = 12
        Me.lblNoRight.Text = "No right reserved"
        Me.lblNoRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCopyright
        '
        Me.lblCopyright.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCopyright.ForeColor = System.Drawing.Color.White
        Me.lblCopyright.Location = New System.Drawing.Point(168, 98)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(241, 20)
        Me.lblCopyright.TabIndex = 11
        Me.lblCopyright.Text = "(S) Super169 Group 2013"
        Me.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblVersion
        '
        Me.lblVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.Color.White
        Me.lblVersion.Location = New System.Drawing.Point(168, 61)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(241, 20)
        Me.lblVersion.TabIndex = 10
        Me.lblVersion.Text = "(Version 0.0.0.0 Build 0000)"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Gold
        Me.lblTitle.Location = New System.Drawing.Point(175, 22)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(234, 39)
        Me.lblTitle.TabIndex = 9
        Me.lblTitle.Text = "FileSync"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbLogo
        '
        Me.pbLogo.Image = CType(resources.GetObject("pbLogo.Image"), System.Drawing.Image)
        Me.pbLogo.InitialImage = CType(resources.GetObject("pbLogo.InitialImage"), System.Drawing.Image)
        Me.pbLogo.Location = New System.Drawing.Point(12, 12)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Size = New System.Drawing.Size(150, 130)
        Me.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbLogo.TabIndex = 8
        Me.pbLogo.TabStop = False
        '
        'txtSyntax
        '
        Me.txtSyntax.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSyntax.Location = New System.Drawing.Point(12, 202)
        Me.txtSyntax.Multiline = True
        Me.txtSyntax.Name = "txtSyntax"
        Me.txtSyntax.ReadOnly = True
        Me.txtSyntax.Size = New System.Drawing.Size(394, 136)
        Me.txtSyntax.TabIndex = 15
        Me.txtSyntax.TabStop = False
        Me.txtSyntax.Text = "Command Line Syntax:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FileSync " & Global.Microsoft.VisualBasic.ChrW(9) & "-s <sourcePath> -t <targetPath>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(9) & "[-b <backupPa" & _
            "th>]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(9) & "[-c | -CheckFolderOnly]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(9) & "[-n | -NoUI]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(9) & "[-f | -FullLog]"
        Me.txtSyntax.Visible = False
        '
        'pbIcon
        '
        Me.pbIcon.Location = New System.Drawing.Point(175, 12)
        Me.pbIcon.Name = "pbIcon"
        Me.pbIcon.Size = New System.Drawing.Size(48, 49)
        Me.pbIcon.TabIndex = 16
        Me.pbIcon.TabStop = False
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(416, 350)
        Me.Controls.Add(Me.pbIcon)
        Me.Controls.Add(Me.lblWarning)
        Me.Controls.Add(Me.lblNoRight)
        Me.Controls.Add(Me.lblCopyright)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.pbLogo)
        Me.Controls.Add(Me.txtSyntax)
        Me.Controls.Add(Me.lblCopyrightMsg)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAbout"
        Me.Text = "FileSync"
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCopyrightMsg As System.Windows.Forms.Label
    Friend WithEvents lblWarning As System.Windows.Forms.Label
    Friend WithEvents lblNoRight As System.Windows.Forms.Label
    Friend WithEvents lblCopyright As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pbLogo As System.Windows.Forms.PictureBox
    Friend WithEvents txtSyntax As System.Windows.Forms.TextBox
    Friend WithEvents pbIcon As System.Windows.Forms.PictureBox
End Class
