<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class teleSCM_GUI
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
        Me.btnDomeOpen = New System.Windows.Forms.Button()
        Me.grpDome = New System.Windows.Forms.GroupBox()
        Me.btnDomeStop = New System.Windows.Forms.Button()
        Me.lblDomeStatus = New System.Windows.Forms.Label()
        Me.btnDomeClose = New System.Windows.Forms.Button()
        Me.grpCoverM = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCoverMClose = New System.Windows.Forms.Button()
        Me.btnCoverMOpen = New System.Windows.Forms.Button()
        Me.txtMsg = New System.Windows.Forms.TextBox()
        Me.grpCoverS = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCoverSClose = New System.Windows.Forms.Button()
        Me.btnCoverSOpen = New System.Windows.Forms.Button()
        Me.grpRelay1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnPower1Discon = New System.Windows.Forms.Button()
        Me.btnPower1Con = New System.Windows.Forms.Button()
        Me.grpAir = New System.Windows.Forms.GroupBox()
        Me.btnCoolerDown = New System.Windows.Forms.Button()
        Me.btnCoolerUp = New System.Windows.Forms.Button()
        Me.btnCoolerPwr = New System.Windows.Forms.Button()
        Me.grpLED = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnLEDClose = New System.Windows.Forms.Button()
        Me.btnLEDOpen = New System.Windows.Forms.Button()
        Me.grpStatus = New System.Windows.Forms.GroupBox()
        Me.panSCM2 = New System.Windows.Forms.Panel()
        Me.btnGetCoverM = New System.Windows.Forms.LinkLabel()
        Me.btnGetCoverS = New System.Windows.Forms.LinkLabel()
        Me.txtStatus2 = New System.Windows.Forms.TextBox()
        Me.panSCM1 = New System.Windows.Forms.Panel()
        Me.txtStatus1 = New System.Windows.Forms.TextBox()
        Me.btnGetDome = New System.Windows.Forms.LinkLabel()
        Me.btnGetLED = New System.Windows.Forms.LinkLabel()
        Me.btnGetRelay1 = New System.Windows.Forms.LinkLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSetAddr = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAddr = New System.Windows.Forms.TextBox()
        Me.grpUtilities = New System.Windows.Forms.GroupBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.btnResetCOM = New System.Windows.Forms.Button()
        Me.grpTemp = New System.Windows.Forms.GroupBox()
        Me.btnHumGet = New System.Windows.Forms.Button()
        Me.txtTemp = New System.Windows.Forms.TextBox()
        Me.btnTempGet = New System.Windows.Forms.Button()
        Me.grpDome.SuspendLayout()
        Me.grpCoverM.SuspendLayout()
        Me.grpCoverS.SuspendLayout()
        Me.grpRelay1.SuspendLayout()
        Me.grpAir.SuspendLayout()
        Me.grpLED.SuspendLayout()
        Me.grpStatus.SuspendLayout()
        Me.panSCM2.SuspendLayout()
        Me.panSCM1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grpUtilities.SuspendLayout()
        Me.grpTemp.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnDomeOpen
        '
        Me.btnDomeOpen.Location = New System.Drawing.Point(6, 20)
        Me.btnDomeOpen.Name = "btnDomeOpen"
        Me.btnDomeOpen.Size = New System.Drawing.Size(75, 23)
        Me.btnDomeOpen.TabIndex = 0
        Me.btnDomeOpen.Text = "Open"
        Me.btnDomeOpen.UseVisualStyleBackColor = True
        '
        'grpDome
        '
        Me.grpDome.Controls.Add(Me.btnDomeStop)
        Me.grpDome.Controls.Add(Me.lblDomeStatus)
        Me.grpDome.Controls.Add(Me.btnDomeClose)
        Me.grpDome.Controls.Add(Me.btnDomeOpen)
        Me.grpDome.Location = New System.Drawing.Point(12, 11)
        Me.grpDome.Name = "grpDome"
        Me.grpDome.Size = New System.Drawing.Size(170, 80)
        Me.grpDome.TabIndex = 1
        Me.grpDome.TabStop = False
        Me.grpDome.Text = "Dome"
        '
        'btnDomeStop
        '
        Me.btnDomeStop.Location = New System.Drawing.Point(6, 49)
        Me.btnDomeStop.Name = "btnDomeStop"
        Me.btnDomeStop.Size = New System.Drawing.Size(75, 23)
        Me.btnDomeStop.TabIndex = 3
        Me.btnDomeStop.Text = "Stop"
        Me.btnDomeStop.UseVisualStyleBackColor = True
        '
        'lblDomeStatus
        '
        Me.lblDomeStatus.AutoSize = True
        Me.lblDomeStatus.Location = New System.Drawing.Point(6, 61)
        Me.lblDomeStatus.Name = "lblDomeStatus"
        Me.lblDomeStatus.Size = New System.Drawing.Size(0, 12)
        Me.lblDomeStatus.TabIndex = 2
        '
        'btnDomeClose
        '
        Me.btnDomeClose.Location = New System.Drawing.Point(87, 20)
        Me.btnDomeClose.Name = "btnDomeClose"
        Me.btnDomeClose.Size = New System.Drawing.Size(75, 23)
        Me.btnDomeClose.TabIndex = 1
        Me.btnDomeClose.Text = "Close"
        Me.btnDomeClose.UseVisualStyleBackColor = True
        '
        'grpCoverM
        '
        Me.grpCoverM.Controls.Add(Me.Label1)
        Me.grpCoverM.Controls.Add(Me.btnCoverMClose)
        Me.grpCoverM.Controls.Add(Me.btnCoverMOpen)
        Me.grpCoverM.Location = New System.Drawing.Point(12, 97)
        Me.grpCoverM.Name = "grpCoverM"
        Me.grpCoverM.Size = New System.Drawing.Size(170, 55)
        Me.grpCoverM.TabIndex = 2
        Me.grpCoverM.TabStop = False
        Me.grpCoverM.Text = "Main Cover"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 12)
        Me.Label1.TabIndex = 2
        '
        'btnCoverMClose
        '
        Me.btnCoverMClose.Location = New System.Drawing.Point(87, 20)
        Me.btnCoverMClose.Name = "btnCoverMClose"
        Me.btnCoverMClose.Size = New System.Drawing.Size(75, 23)
        Me.btnCoverMClose.TabIndex = 1
        Me.btnCoverMClose.Text = "Close"
        Me.btnCoverMClose.UseVisualStyleBackColor = True
        '
        'btnCoverMOpen
        '
        Me.btnCoverMOpen.Location = New System.Drawing.Point(6, 20)
        Me.btnCoverMOpen.Name = "btnCoverMOpen"
        Me.btnCoverMOpen.Size = New System.Drawing.Size(75, 23)
        Me.btnCoverMOpen.TabIndex = 0
        Me.btnCoverMOpen.Text = "Open"
        Me.btnCoverMOpen.UseVisualStyleBackColor = True
        '
        'txtMsg
        '
        Me.txtMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMsg.Location = New System.Drawing.Point(0, 243)
        Me.txtMsg.Name = "txtMsg"
        Me.txtMsg.ReadOnly = True
        Me.txtMsg.Size = New System.Drawing.Size(545, 21)
        Me.txtMsg.TabIndex = 3
        '
        'grpCoverS
        '
        Me.grpCoverS.Controls.Add(Me.Label2)
        Me.grpCoverS.Controls.Add(Me.btnCoverSClose)
        Me.grpCoverS.Controls.Add(Me.btnCoverSOpen)
        Me.grpCoverS.Location = New System.Drawing.Point(188, 97)
        Me.grpCoverS.Name = "grpCoverS"
        Me.grpCoverS.Size = New System.Drawing.Size(170, 55)
        Me.grpCoverS.TabIndex = 4
        Me.grpCoverS.TabStop = False
        Me.grpCoverS.Text = "Sub Cover"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 12)
        Me.Label2.TabIndex = 2
        '
        'btnCoverSClose
        '
        Me.btnCoverSClose.Location = New System.Drawing.Point(87, 20)
        Me.btnCoverSClose.Name = "btnCoverSClose"
        Me.btnCoverSClose.Size = New System.Drawing.Size(75, 23)
        Me.btnCoverSClose.TabIndex = 1
        Me.btnCoverSClose.Text = "Close"
        Me.btnCoverSClose.UseVisualStyleBackColor = True
        '
        'btnCoverSOpen
        '
        Me.btnCoverSOpen.Location = New System.Drawing.Point(6, 20)
        Me.btnCoverSOpen.Name = "btnCoverSOpen"
        Me.btnCoverSOpen.Size = New System.Drawing.Size(75, 23)
        Me.btnCoverSOpen.TabIndex = 0
        Me.btnCoverSOpen.Text = "Open"
        Me.btnCoverSOpen.UseVisualStyleBackColor = True
        '
        'grpRelay1
        '
        Me.grpRelay1.Controls.Add(Me.Label3)
        Me.grpRelay1.Controls.Add(Me.btnPower1Discon)
        Me.grpRelay1.Controls.Add(Me.btnPower1Con)
        Me.grpRelay1.Location = New System.Drawing.Point(188, 158)
        Me.grpRelay1.Name = "grpRelay1"
        Me.grpRelay1.Size = New System.Drawing.Size(170, 51)
        Me.grpRelay1.TabIndex = 5
        Me.grpRelay1.TabStop = False
        Me.grpRelay1.Text = "Power Relay 1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 12)
        Me.Label3.TabIndex = 2
        '
        'btnPower1Discon
        '
        Me.btnPower1Discon.Location = New System.Drawing.Point(87, 20)
        Me.btnPower1Discon.Name = "btnPower1Discon"
        Me.btnPower1Discon.Size = New System.Drawing.Size(75, 23)
        Me.btnPower1Discon.TabIndex = 1
        Me.btnPower1Discon.Text = "Disconnect"
        Me.btnPower1Discon.UseVisualStyleBackColor = True
        '
        'btnPower1Con
        '
        Me.btnPower1Con.Location = New System.Drawing.Point(6, 20)
        Me.btnPower1Con.Name = "btnPower1Con"
        Me.btnPower1Con.Size = New System.Drawing.Size(75, 23)
        Me.btnPower1Con.TabIndex = 0
        Me.btnPower1Con.Text = "Connect"
        Me.btnPower1Con.UseVisualStyleBackColor = True
        '
        'grpAir
        '
        Me.grpAir.Controls.Add(Me.btnCoolerDown)
        Me.grpAir.Controls.Add(Me.btnCoolerUp)
        Me.grpAir.Controls.Add(Me.btnCoolerPwr)
        Me.grpAir.Location = New System.Drawing.Point(188, 11)
        Me.grpAir.Name = "grpAir"
        Me.grpAir.Size = New System.Drawing.Size(170, 80)
        Me.grpAir.TabIndex = 6
        Me.grpAir.TabStop = False
        Me.grpAir.Text = "Air-conditioner (HGXnR)"
        '
        'btnCoolerDown
        '
        Me.btnCoolerDown.Location = New System.Drawing.Point(8, 49)
        Me.btnCoolerDown.Name = "btnCoolerDown"
        Me.btnCoolerDown.Size = New System.Drawing.Size(75, 23)
        Me.btnCoolerDown.TabIndex = 2
        Me.btnCoolerDown.Text = "Temp Down"
        Me.btnCoolerDown.UseVisualStyleBackColor = True
        '
        'btnCoolerUp
        '
        Me.btnCoolerUp.Location = New System.Drawing.Point(89, 20)
        Me.btnCoolerUp.Name = "btnCoolerUp"
        Me.btnCoolerUp.Size = New System.Drawing.Size(75, 23)
        Me.btnCoolerUp.TabIndex = 1
        Me.btnCoolerUp.Text = "Temp Up"
        Me.btnCoolerUp.UseVisualStyleBackColor = True
        '
        'btnCoolerPwr
        '
        Me.btnCoolerPwr.Location = New System.Drawing.Point(8, 20)
        Me.btnCoolerPwr.Name = "btnCoolerPwr"
        Me.btnCoolerPwr.Size = New System.Drawing.Size(75, 23)
        Me.btnCoolerPwr.TabIndex = 0
        Me.btnCoolerPwr.Text = "Open/Close"
        Me.btnCoolerPwr.UseVisualStyleBackColor = True
        '
        'grpLED
        '
        Me.grpLED.Controls.Add(Me.Label4)
        Me.grpLED.Controls.Add(Me.btnLEDClose)
        Me.grpLED.Controls.Add(Me.btnLEDOpen)
        Me.grpLED.Location = New System.Drawing.Point(12, 158)
        Me.grpLED.Name = "grpLED"
        Me.grpLED.Size = New System.Drawing.Size(170, 51)
        Me.grpLED.TabIndex = 7
        Me.grpLED.TabStop = False
        Me.grpLED.Text = "LED"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 12)
        Me.Label4.TabIndex = 2
        '
        'btnLEDClose
        '
        Me.btnLEDClose.Location = New System.Drawing.Point(87, 20)
        Me.btnLEDClose.Name = "btnLEDClose"
        Me.btnLEDClose.Size = New System.Drawing.Size(75, 23)
        Me.btnLEDClose.TabIndex = 1
        Me.btnLEDClose.Text = "Close"
        Me.btnLEDClose.UseVisualStyleBackColor = True
        '
        'btnLEDOpen
        '
        Me.btnLEDOpen.Location = New System.Drawing.Point(6, 20)
        Me.btnLEDOpen.Name = "btnLEDOpen"
        Me.btnLEDOpen.Size = New System.Drawing.Size(75, 23)
        Me.btnLEDOpen.TabIndex = 0
        Me.btnLEDOpen.Text = "Open"
        Me.btnLEDOpen.UseVisualStyleBackColor = True
        '
        'grpStatus
        '
        Me.grpStatus.Controls.Add(Me.panSCM2)
        Me.grpStatus.Controls.Add(Me.panSCM1)
        Me.grpStatus.Location = New System.Drawing.Point(364, 14)
        Me.grpStatus.Name = "grpStatus"
        Me.grpStatus.Size = New System.Drawing.Size(170, 77)
        Me.grpStatus.TabIndex = 13
        Me.grpStatus.TabStop = False
        Me.grpStatus.Text = "Status"
        '
        'panSCM2
        '
        Me.panSCM2.Controls.Add(Me.btnGetCoverM)
        Me.panSCM2.Controls.Add(Me.btnGetCoverS)
        Me.panSCM2.Controls.Add(Me.txtStatus2)
        Me.panSCM2.Location = New System.Drawing.Point(6, 46)
        Me.panSCM2.Name = "panSCM2"
        Me.panSCM2.Size = New System.Drawing.Size(156, 24)
        Me.panSCM2.TabIndex = 1
        '
        'btnGetCoverM
        '
        Me.btnGetCoverM.AutoSize = True
        Me.btnGetCoverM.Location = New System.Drawing.Point(50, 5)
        Me.btnGetCoverM.Name = "btnGetCoverM"
        Me.btnGetCoverM.Size = New System.Drawing.Size(41, 12)
        Me.btnGetCoverM.TabIndex = 3
        Me.btnGetCoverM.TabStop = True
        Me.btnGetCoverM.Text = "CoverM"
        '
        'btnGetCoverS
        '
        Me.btnGetCoverS.AutoSize = True
        Me.btnGetCoverS.Location = New System.Drawing.Point(3, 5)
        Me.btnGetCoverS.Name = "btnGetCoverS"
        Me.btnGetCoverS.Size = New System.Drawing.Size(41, 12)
        Me.btnGetCoverS.TabIndex = 2
        Me.btnGetCoverS.TabStop = True
        Me.btnGetCoverS.Text = "CoverS"
        '
        'txtStatus2
        '
        Me.txtStatus2.Location = New System.Drawing.Point(114, 0)
        Me.txtStatus2.Name = "txtStatus2"
        Me.txtStatus2.ReadOnly = True
        Me.txtStatus2.Size = New System.Drawing.Size(42, 21)
        Me.txtStatus2.TabIndex = 1
        '
        'panSCM1
        '
        Me.panSCM1.Controls.Add(Me.txtStatus1)
        Me.panSCM1.Controls.Add(Me.btnGetDome)
        Me.panSCM1.Controls.Add(Me.btnGetLED)
        Me.panSCM1.Controls.Add(Me.btnGetRelay1)
        Me.panSCM1.Location = New System.Drawing.Point(6, 15)
        Me.panSCM1.Name = "panSCM1"
        Me.panSCM1.Size = New System.Drawing.Size(156, 25)
        Me.panSCM1.TabIndex = 0
        '
        'txtStatus1
        '
        Me.txtStatus1.Location = New System.Drawing.Point(112, 0)
        Me.txtStatus1.Name = "txtStatus1"
        Me.txtStatus1.ReadOnly = True
        Me.txtStatus1.Size = New System.Drawing.Size(44, 21)
        Me.txtStatus1.TabIndex = 4
        '
        'btnGetDome
        '
        Me.btnGetDome.AutoSize = True
        Me.btnGetDome.Location = New System.Drawing.Point(79, 2)
        Me.btnGetDome.Name = "btnGetDome"
        Me.btnGetDome.Size = New System.Drawing.Size(29, 12)
        Me.btnGetDome.TabIndex = 3
        Me.btnGetDome.TabStop = True
        Me.btnGetDome.Text = "Dome"
        '
        'btnGetLED
        '
        Me.btnGetLED.AutoSize = True
        Me.btnGetLED.Location = New System.Drawing.Point(50, 2)
        Me.btnGetLED.Name = "btnGetLED"
        Me.btnGetLED.Size = New System.Drawing.Size(23, 12)
        Me.btnGetLED.TabIndex = 2
        Me.btnGetLED.TabStop = True
        Me.btnGetLED.Text = "LED"
        '
        'btnGetRelay1
        '
        Me.btnGetRelay1.AutoSize = True
        Me.btnGetRelay1.Location = New System.Drawing.Point(3, 2)
        Me.btnGetRelay1.Name = "btnGetRelay1"
        Me.btnGetRelay1.Size = New System.Drawing.Size(41, 12)
        Me.btnGetRelay1.TabIndex = 1
        Me.btnGetRelay1.TabStop = True
        Me.btnGetRelay1.Text = "Relay1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnSetAddr)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtAddr)
        Me.Panel1.Controls.Add(Me.grpUtilities)
        Me.Panel1.Controls.Add(Me.grpTemp)
        Me.Panel1.Controls.Add(Me.grpStatus)
        Me.Panel1.Controls.Add(Me.txtMsg)
        Me.Panel1.Controls.Add(Me.grpLED)
        Me.Panel1.Controls.Add(Me.grpAir)
        Me.Panel1.Controls.Add(Me.grpRelay1)
        Me.Panel1.Controls.Add(Me.grpCoverS)
        Me.Panel1.Controls.Add(Me.grpCoverM)
        Me.Panel1.Controls.Add(Me.grpDome)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(545, 263)
        Me.Panel1.TabIndex = 14
        '
        'btnSetAddr
        '
        Me.btnSetAddr.Location = New System.Drawing.Point(469, 216)
        Me.btnSetAddr.Name = "btnSetAddr"
        Me.btnSetAddr.Size = New System.Drawing.Size(64, 23)
        Me.btnSetAddr.TabIndex = 17
        Me.btnSetAddr.Text = "Set"
        Me.btnSetAddr.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 219)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Address:"
        '
        'txtAddr
        '
        Me.txtAddr.Location = New System.Drawing.Point(70, 216)
        Me.txtAddr.Name = "txtAddr"
        Me.txtAddr.Size = New System.Drawing.Size(393, 21)
        Me.txtAddr.TabIndex = 15
        Me.txtAddr.Text = "http://localhost:19951/TabletServer/ServiceMessage"
        '
        'grpUtilities
        '
        Me.grpUtilities.Controls.Add(Me.btnLogin)
        Me.grpUtilities.Controls.Add(Me.btnResetCOM)
        Me.grpUtilities.Location = New System.Drawing.Point(364, 158)
        Me.grpUtilities.Name = "grpUtilities"
        Me.grpUtilities.Size = New System.Drawing.Size(170, 51)
        Me.grpUtilities.TabIndex = 6
        Me.grpUtilities.TabStop = False
        Me.grpUtilities.Text = "Utilities"
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnLogin.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnLogin.ForeColor = System.Drawing.SystemColors.Info
        Me.btnLogin.Location = New System.Drawing.Point(88, 21)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(75, 23)
        Me.btnLogin.TabIndex = 1
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'btnResetCOM
        '
        Me.btnResetCOM.Location = New System.Drawing.Point(6, 20)
        Me.btnResetCOM.Name = "btnResetCOM"
        Me.btnResetCOM.Size = New System.Drawing.Size(75, 23)
        Me.btnResetCOM.TabIndex = 0
        Me.btnResetCOM.Text = "Reset COM"
        Me.btnResetCOM.UseVisualStyleBackColor = True
        '
        'grpTemp
        '
        Me.grpTemp.Controls.Add(Me.btnHumGet)
        Me.grpTemp.Controls.Add(Me.txtTemp)
        Me.grpTemp.Controls.Add(Me.btnTempGet)
        Me.grpTemp.Location = New System.Drawing.Point(364, 97)
        Me.grpTemp.Name = "grpTemp"
        Me.grpTemp.Size = New System.Drawing.Size(170, 55)
        Me.grpTemp.TabIndex = 14
        Me.grpTemp.TabStop = False
        Me.grpTemp.Text = "Temp|Hum"
        '
        'btnHumGet
        '
        Me.btnHumGet.Location = New System.Drawing.Point(54, 20)
        Me.btnHumGet.Name = "btnHumGet"
        Me.btnHumGet.Size = New System.Drawing.Size(45, 23)
        Me.btnHumGet.TabIndex = 2
        Me.btnHumGet.Text = "Hum."
        Me.btnHumGet.UseVisualStyleBackColor = True
        '
        'txtTemp
        '
        Me.txtTemp.Location = New System.Drawing.Point(105, 21)
        Me.txtTemp.Name = "txtTemp"
        Me.txtTemp.ReadOnly = True
        Me.txtTemp.Size = New System.Drawing.Size(56, 21)
        Me.txtTemp.TabIndex = 1
        '
        'btnTempGet
        '
        Me.btnTempGet.Location = New System.Drawing.Point(6, 20)
        Me.btnTempGet.Name = "btnTempGet"
        Me.btnTempGet.Size = New System.Drawing.Size(42, 23)
        Me.btnTempGet.TabIndex = 0
        Me.btnTempGet.Text = "Temp."
        Me.btnTempGet.UseVisualStyleBackColor = True
        '
        'teleSCM_GUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(545, 263)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "teleSCM_GUI"
        Me.Text = "TABLET SCM"
        Me.grpDome.ResumeLayout(False)
        Me.grpDome.PerformLayout()
        Me.grpCoverM.ResumeLayout(False)
        Me.grpCoverM.PerformLayout()
        Me.grpCoverS.ResumeLayout(False)
        Me.grpCoverS.PerformLayout()
        Me.grpRelay1.ResumeLayout(False)
        Me.grpRelay1.PerformLayout()
        Me.grpAir.ResumeLayout(False)
        Me.grpLED.ResumeLayout(False)
        Me.grpLED.PerformLayout()
        Me.grpStatus.ResumeLayout(False)
        Me.panSCM2.ResumeLayout(False)
        Me.panSCM2.PerformLayout()
        Me.panSCM1.ResumeLayout(False)
        Me.panSCM1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grpUtilities.ResumeLayout(False)
        Me.grpTemp.ResumeLayout(False)
        Me.grpTemp.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnDomeOpen As System.Windows.Forms.Button
    Friend WithEvents grpDome As System.Windows.Forms.GroupBox
    Friend WithEvents lblDomeStatus As System.Windows.Forms.Label
    Friend WithEvents btnDomeClose As System.Windows.Forms.Button
    Friend WithEvents grpCoverM As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCoverMClose As System.Windows.Forms.Button
    Friend WithEvents btnCoverMOpen As System.Windows.Forms.Button
    Friend WithEvents txtMsg As System.Windows.Forms.TextBox
    Friend WithEvents grpCoverS As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCoverSClose As System.Windows.Forms.Button
    Friend WithEvents btnCoverSOpen As System.Windows.Forms.Button
    Friend WithEvents grpRelay1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnPower1Discon As System.Windows.Forms.Button
    Friend WithEvents btnPower1Con As System.Windows.Forms.Button
    Friend WithEvents grpAir As System.Windows.Forms.GroupBox
    Friend WithEvents btnCoolerPwr As System.Windows.Forms.Button
    Friend WithEvents grpLED As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnLEDClose As System.Windows.Forms.Button
    Friend WithEvents btnLEDOpen As System.Windows.Forms.Button
    Friend WithEvents grpStatus As System.Windows.Forms.GroupBox
    Friend WithEvents panSCM2 As System.Windows.Forms.Panel
    Friend WithEvents txtStatus2 As System.Windows.Forms.TextBox
    Friend WithEvents panSCM1 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grpTemp As System.Windows.Forms.GroupBox
    Friend WithEvents txtTemp As System.Windows.Forms.TextBox
    Friend WithEvents btnTempGet As System.Windows.Forms.Button
    Friend WithEvents btnDomeStop As System.Windows.Forms.Button
    Friend WithEvents btnCoolerUp As System.Windows.Forms.Button
    Friend WithEvents btnCoolerDown As System.Windows.Forms.Button
    Friend WithEvents grpUtilities As System.Windows.Forms.GroupBox
    Friend WithEvents btnResetCOM As System.Windows.Forms.Button
    Friend WithEvents btnGetCoverM As System.Windows.Forms.LinkLabel
    Friend WithEvents btnGetCoverS As System.Windows.Forms.LinkLabel
    Friend WithEvents txtStatus1 As System.Windows.Forms.TextBox
    Friend WithEvents btnGetDome As System.Windows.Forms.LinkLabel
    Friend WithEvents btnGetLED As System.Windows.Forms.LinkLabel
    Friend WithEvents btnGetRelay1 As System.Windows.Forms.LinkLabel
    Friend WithEvents btnHumGet As System.Windows.Forms.Button
    Friend WithEvents btnSetAddr As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAddr As System.Windows.Forms.TextBox
    Friend WithEvents btnLogin As System.Windows.Forms.Button
End Class
