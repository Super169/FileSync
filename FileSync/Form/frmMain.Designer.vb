<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.btnSync = New System.Windows.Forms.Button()
        Me.txtSource = New System.Windows.Forms.TextBox()
        Me.txtTarget = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lvAction = New System.Windows.Forms.ListView()
        Me.txtBackup = New System.Windows.Forms.TextBox()
        Me.btnCheck = New System.Windows.Forms.Button()
        Me.cbxShowIgnore = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSourceFile = New System.Windows.Forms.Button()
        Me.btnTargetFile = New System.Windows.Forms.Button()
        Me.btnBackupPath = New System.Windows.Forms.Button()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.txtRegex = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnSync
        '
        Me.btnSync.Location = New System.Drawing.Point(713, 451)
        Me.btnSync.Name = "btnSync"
        Me.btnSync.Size = New System.Drawing.Size(75, 23)
        Me.btnSync.TabIndex = 0
        Me.btnSync.TabStop = False
        Me.btnSync.Text = "Sync"
        Me.btnSync.UseVisualStyleBackColor = True
        '
        'txtSource
        '
        Me.txtSource.Location = New System.Drawing.Point(68, 13)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.Size = New System.Drawing.Size(199, 20)
        Me.txtSource.TabIndex = 0
        '
        'txtTarget
        '
        Me.txtTarget.Location = New System.Drawing.Point(360, 12)
        Me.txtTarget.Name = "txtTarget"
        Me.txtTarget.Size = New System.Drawing.Size(255, 20)
        Me.txtTarget.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(874, 451)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 5
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "Exit"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lvAction
        '
        Me.lvAction.Location = New System.Drawing.Point(12, 63)
        Me.lvAction.Name = "lvAction"
        Me.lvAction.Size = New System.Drawing.Size(937, 381)
        Me.lvAction.TabIndex = 3
        Me.lvAction.UseCompatibleStateImageBehavior = False
        Me.lvAction.View = System.Windows.Forms.View.Details
        '
        'txtBackup
        '
        Me.txtBackup.Location = New System.Drawing.Point(711, 12)
        Me.txtBackup.Name = "txtBackup"
        Me.txtBackup.Size = New System.Drawing.Size(204, 20)
        Me.txtBackup.TabIndex = 2
        '
        'btnCheck
        '
        Me.btnCheck.Location = New System.Drawing.Point(632, 451)
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.Size = New System.Drawing.Size(75, 23)
        Me.btnCheck.TabIndex = 9
        Me.btnCheck.TabStop = False
        Me.btnCheck.Text = "Check"
        Me.btnCheck.UseVisualStyleBackColor = True
        '
        'cbxShowIgnore
        '
        Me.cbxShowIgnore.AutoSize = True
        Me.cbxShowIgnore.Location = New System.Drawing.Point(16, 40)
        Me.cbxShowIgnore.Name = "cbxShowIgnore"
        Me.cbxShowIgnore.Size = New System.Drawing.Size(116, 17)
        Me.cbxShowIgnore.TabIndex = 10
        Me.cbxShowIgnore.Text = "Show Ignored Files"
        Me.cbxShowIgnore.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Source:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(306, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Target:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(651, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Backup:"
        '
        'btnSourceFile
        '
        Me.btnSourceFile.BackgroundImage = CType(resources.GetObject("btnSourceFile.BackgroundImage"), System.Drawing.Image)
        Me.btnSourceFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSourceFile.Location = New System.Drawing.Point(273, 12)
        Me.btnSourceFile.Name = "btnSourceFile"
        Me.btnSourceFile.Size = New System.Drawing.Size(28, 23)
        Me.btnSourceFile.TabIndex = 14
        Me.btnSourceFile.TabStop = False
        Me.btnSourceFile.UseVisualStyleBackColor = True
        '
        'btnTargetFile
        '
        Me.btnTargetFile.BackgroundImage = CType(resources.GetObject("btnTargetFile.BackgroundImage"), System.Drawing.Image)
        Me.btnTargetFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnTargetFile.Location = New System.Drawing.Point(621, 11)
        Me.btnTargetFile.Name = "btnTargetFile"
        Me.btnTargetFile.Size = New System.Drawing.Size(28, 23)
        Me.btnTargetFile.TabIndex = 15
        Me.btnTargetFile.TabStop = False
        Me.btnTargetFile.UseVisualStyleBackColor = True
        '
        'btnBackupPath
        '
        Me.btnBackupPath.BackgroundImage = CType(resources.GetObject("btnBackupPath.BackgroundImage"), System.Drawing.Image)
        Me.btnBackupPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBackupPath.Location = New System.Drawing.Point(921, 11)
        Me.btnBackupPath.Name = "btnBackupPath"
        Me.btnBackupPath.Size = New System.Drawing.Size(28, 23)
        Me.btnBackupPath.TabIndex = 16
        Me.btnBackupPath.TabStop = False
        Me.btnBackupPath.UseVisualStyleBackColor = True
        '
        'lblMsg
        '
        Me.lblMsg.ForeColor = System.Drawing.Color.Red
        Me.lblMsg.Location = New System.Drawing.Point(13, 456)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(604, 14)
        Me.lblMsg.TabIndex = 17
        '
        'btnStop
        '
        Me.btnStop.Enabled = False
        Me.btnStop.Location = New System.Drawing.Point(794, 451)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 23)
        Me.btnStop.TabIndex = 18
        Me.btnStop.TabStop = False
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'txtRegex
        '
        Me.txtRegex.Location = New System.Drawing.Point(313, 38)
        Me.txtRegex.Name = "txtRegex"
        Me.txtRegex.Size = New System.Drawing.Size(637, 20)
        Me.txtRegex.TabIndex = 19
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(194, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Additional Regex:"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(961, 477)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtRegex)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.btnBackupPath)
        Me.Controls.Add(Me.btnTargetFile)
        Me.Controls.Add(Me.btnSourceFile)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbxShowIgnore)
        Me.Controls.Add(Me.btnCheck)
        Me.Controls.Add(Me.txtBackup)
        Me.Controls.Add(Me.lvAction)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtTarget)
        Me.Controls.Add(Me.txtSource)
        Me.Controls.Add(Me.btnSync)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "FileSync"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSync As System.Windows.Forms.Button
    Friend WithEvents txtSource As System.Windows.Forms.TextBox
    Friend WithEvents txtTarget As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lvAction As System.Windows.Forms.ListView
    Friend WithEvents txtBackup As System.Windows.Forms.TextBox
    Friend WithEvents btnCheck As System.Windows.Forms.Button
    Friend WithEvents cbxShowIgnore As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSourceFile As System.Windows.Forms.Button
    Friend WithEvents btnTargetFile As System.Windows.Forms.Button
    Friend WithEvents btnBackupPath As System.Windows.Forms.Button
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents txtRegex As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
