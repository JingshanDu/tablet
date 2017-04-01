<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NativeOperator
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NativeOperator))
        Me.txtScriptInput = New System.Windows.Forms.TextBox()
        Me.btnScriptDo = New System.Windows.Forms.Button()
        Me.btnScriptClear = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtNamePath = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnCmdHisClear = New System.Windows.Forms.LinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCommandDo = New System.Windows.Forms.Button()
        Me.txtCommandInput = New System.Windows.Forms.TextBox()
        Me.txtCommandHistory = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSetNamePath = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTABLETV = New System.Windows.Forms.Label()
        Me.lblTABLETC = New System.Windows.Forms.Label()
        Me.NotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.TrayMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TrayMenuShow = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrayMenuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAbout = New System.Windows.Forms.LinkLabel()
        Me.timerCheckRain = New System.Windows.Forms.Timer(Me.components)
        Me.lblRainDrop = New System.Windows.Forms.Label()
        Me.lblRainDetectErr = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TrayMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtScriptInput
        '
        Me.txtScriptInput.Location = New System.Drawing.Point(6, 20)
        Me.txtScriptInput.Multiline = True
        Me.txtScriptInput.Name = "txtScriptInput"
        Me.txtScriptInput.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtScriptInput.Size = New System.Drawing.Size(317, 301)
        Me.txtScriptInput.TabIndex = 0
        Me.txtScriptInput.WordWrap = False
        '
        'btnScriptDo
        '
        Me.btnScriptDo.Location = New System.Drawing.Point(7, 327)
        Me.btnScriptDo.Name = "btnScriptDo"
        Me.btnScriptDo.Size = New System.Drawing.Size(93, 24)
        Me.btnScriptDo.TabIndex = 1
        Me.btnScriptDo.Text = "Do"
        Me.btnScriptDo.UseVisualStyleBackColor = True
        '
        'btnScriptClear
        '
        Me.btnScriptClear.Location = New System.Drawing.Point(106, 327)
        Me.btnScriptClear.Name = "btnScriptClear"
        Me.btnScriptClear.Size = New System.Drawing.Size(93, 24)
        Me.btnScriptClear.TabIndex = 2
        Me.btnScriptClear.Text = "Clear"
        Me.btnScriptClear.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtScriptInput)
        Me.GroupBox1.Controls.Add(Me.btnScriptClear)
        Me.GroupBox1.Controls.Add(Me.btnScriptDo)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(330, 359)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "TABLET Script"
        '
        'txtNamePath
        '
        Me.txtNamePath.Location = New System.Drawing.Point(77, 378)
        Me.txtNamePath.Name = "txtNamePath"
        Me.txtNamePath.Size = New System.Drawing.Size(278, 21)
        Me.txtNamePath.TabIndex = 3
        Me.txtNamePath.Text = "D:\Data\Yourname"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnCmdHisClear)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.btnCommandDo)
        Me.GroupBox2.Controls.Add(Me.txtCommandInput)
        Me.GroupBox2.Controls.Add(Me.txtCommandHistory)
        Me.GroupBox2.Location = New System.Drawing.Point(347, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(274, 358)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "TABLET Command"
        '
        'btnCmdHisClear
        '
        Me.btnCmdHisClear.AutoSize = True
        Me.btnCmdHisClear.Location = New System.Drawing.Point(232, 0)
        Me.btnCmdHisClear.Name = "btnCmdHisClear"
        Me.btnCmdHisClear.Size = New System.Drawing.Size(35, 12)
        Me.btnCmdHisClear.TabIndex = 4
        Me.btnCmdHisClear.TabStop = True
        Me.btnCmdHisClear.Text = "Clear"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 333)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = ">"
        '
        'btnCommandDo
        '
        Me.btnCommandDo.Location = New System.Drawing.Point(245, 326)
        Me.btnCommandDo.Name = "btnCommandDo"
        Me.btnCommandDo.Size = New System.Drawing.Size(22, 21)
        Me.btnCommandDo.TabIndex = 2
        Me.btnCommandDo.Text = "↑"
        Me.btnCommandDo.UseVisualStyleBackColor = True
        '
        'txtCommandInput
        '
        Me.txtCommandInput.Location = New System.Drawing.Point(22, 327)
        Me.txtCommandInput.Name = "txtCommandInput"
        Me.txtCommandInput.Size = New System.Drawing.Size(217, 21)
        Me.txtCommandInput.TabIndex = 1
        '
        'txtCommandHistory
        '
        Me.txtCommandHistory.Location = New System.Drawing.Point(6, 20)
        Me.txtCommandHistory.Multiline = True
        Me.txtCommandHistory.Name = "txtCommandHistory"
        Me.txtCommandHistory.ReadOnly = True
        Me.txtCommandHistory.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtCommandHistory.Size = New System.Drawing.Size(262, 301)
        Me.txtCommandHistory.TabIndex = 0
        Me.txtCommandHistory.WordWrap = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 381)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "NamePath:"
        '
        'btnSetNamePath
        '
        Me.btnSetNamePath.Location = New System.Drawing.Point(361, 376)
        Me.btnSetNamePath.Name = "btnSetNamePath"
        Me.btnSetNamePath.Size = New System.Drawing.Size(34, 23)
        Me.btnSetNamePath.TabIndex = 6
        Me.btnSetNamePath.Text = "Set"
        Me.btnSetNamePath.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(442, 381)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(179, 12)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "TABLET v   , Core     loaded."
        '
        'lblTABLETV
        '
        Me.lblTABLETV.AutoSize = True
        Me.lblTABLETV.Location = New System.Drawing.Point(495, 381)
        Me.lblTABLETV.Name = "lblTABLETV"
        Me.lblTABLETV.Size = New System.Drawing.Size(0, 12)
        Me.lblTABLETV.TabIndex = 8
        '
        'lblTABLETC
        '
        Me.lblTABLETC.AutoSize = True
        Me.lblTABLETC.Location = New System.Drawing.Point(552, 381)
        Me.lblTABLETC.Name = "lblTABLETC"
        Me.lblTABLETC.Size = New System.Drawing.Size(0, 12)
        Me.lblTABLETC.TabIndex = 9
        '
        'NotifyIcon
        '
        Me.NotifyIcon.ContextMenuStrip = Me.TrayMenu
        Me.NotifyIcon.Icon = CType(resources.GetObject("NotifyIcon.Icon"), System.Drawing.Icon)
        Me.NotifyIcon.Text = "TABLET Server"
        Me.NotifyIcon.Visible = True
        '
        'TrayMenu
        '
        Me.TrayMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TrayMenuShow, Me.TrayMenuExit})
        Me.TrayMenu.Name = "TrayMenu"
        Me.TrayMenu.Size = New System.Drawing.Size(109, 48)
        '
        'TrayMenuShow
        '
        Me.TrayMenuShow.Name = "TrayMenuShow"
        Me.TrayMenuShow.Size = New System.Drawing.Size(108, 22)
        Me.TrayMenuShow.Text = "Open"
        '
        'TrayMenuExit
        '
        Me.TrayMenuExit.Name = "TrayMenuExit"
        Me.TrayMenuExit.Size = New System.Drawing.Size(108, 22)
        Me.TrayMenuExit.Text = "Exit"
        '
        'btnAbout
        '
        Me.btnAbout.AutoSize = True
        Me.btnAbout.Location = New System.Drawing.Point(401, 381)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(35, 12)
        Me.btnAbout.TabIndex = 10
        Me.btnAbout.TabStop = True
        Me.btnAbout.Text = "About"
        '
        'timerCheckRain
        '
        Me.timerCheckRain.Enabled = True
        Me.timerCheckRain.Interval = 100000
        '
        'lblRainDrop
        '
        Me.lblRainDrop.AutoSize = True
        Me.lblRainDrop.BackColor = System.Drawing.SystemColors.Highlight
        Me.lblRainDrop.Font = New System.Drawing.Font("Arial Black", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRainDrop.ForeColor = System.Drawing.Color.Red
        Me.lblRainDrop.Location = New System.Drawing.Point(241, 180)
        Me.lblRainDrop.Name = "lblRainDrop"
        Me.lblRainDrop.Size = New System.Drawing.Size(185, 38)
        Me.lblRainDrop.TabIndex = 11
        Me.lblRainDrop.Text = "RAIN DROP"
        '
        'lblRainDetectErr
        '
        Me.lblRainDetectErr.AutoSize = True
        Me.lblRainDetectErr.Font = New System.Drawing.Font("宋体", 20.0!)
        Me.lblRainDetectErr.Location = New System.Drawing.Point(140, 153)
        Me.lblRainDetectErr.Name = "lblRainDetectErr"
        Me.lblRainDetectErr.Size = New System.Drawing.Size(376, 27)
        Me.lblRainDetectErr.TabIndex = 3
        Me.lblRainDetectErr.Text = "Rain Drop Detection Failed"
        Me.lblRainDetectErr.Visible = False
        '
        'NativeOperator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(633, 405)
        Me.Controls.Add(Me.lblRainDetectErr)
        Me.Controls.Add(Me.lblRainDrop)
        Me.Controls.Add(Me.btnAbout)
        Me.Controls.Add(Me.lblTABLETC)
        Me.Controls.Add(Me.lblTABLETV)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNamePath)
        Me.Controls.Add(Me.btnSetNamePath)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "NativeOperator"
        Me.Text = "TABLET Server | Native Operator"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TrayMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtScriptInput As System.Windows.Forms.TextBox
    Friend WithEvents btnScriptDo As System.Windows.Forms.Button
    Friend WithEvents btnScriptClear As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCommandDo As System.Windows.Forms.Button
    Friend WithEvents txtCommandInput As System.Windows.Forms.TextBox
    Friend WithEvents txtCommandHistory As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNamePath As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSetNamePath As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTABLETV As System.Windows.Forms.Label
    Friend WithEvents lblTABLETC As System.Windows.Forms.Label
    Friend WithEvents NotifyIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents TrayMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TrayMenuShow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrayMenuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAbout As System.Windows.Forms.LinkLabel
    Friend WithEvents btnCmdHisClear As System.Windows.Forms.LinkLabel
    Friend WithEvents timerCheckRain As System.Windows.Forms.Timer
    Friend WithEvents lblRainDrop As System.Windows.Forms.Label
    Friend WithEvents lblRainDetectErr As System.Windows.Forms.Label
End Class
