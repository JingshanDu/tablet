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
        Me.txtInputCmd = New System.Windows.Forms.TextBox()
        Me.btnSendInputCmd = New System.Windows.Forms.Button()
        Me.txtReceive = New System.Windows.Forms.TextBox()
        Me.btnReceive = New System.Windows.Forms.Button()
        Me.grpDebug = New System.Windows.Forms.GroupBox()
        Me.dropDebugChoose = New System.Windows.Forms.ComboBox()
        Me.grpStatus = New System.Windows.Forms.GroupBox()
        Me.panSCM2 = New System.Windows.Forms.Panel()
        Me.btnAll2Get = New System.Windows.Forms.Button()
        Me.txtAll2Status = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.panSCM1 = New System.Windows.Forms.Panel()
        Me.btnAll1Get = New System.Windows.Forms.Button()
        Me.txtAll1Status = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grpUtilities = New System.Windows.Forms.GroupBox()
        Me.btnResetCOM = New System.Windows.Forms.Button()
        Me.grpTemp = New System.Windows.Forms.GroupBox()
        Me.txtTemp = New System.Windows.Forms.TextBox()
        Me.btnTempGet = New System.Windows.Forms.Button()
        Me.grpDome.SuspendLayout()
        Me.grpCoverM.SuspendLayout()
        Me.grpCoverS.SuspendLayout()
        Me.grpRelay1.SuspendLayout()
        Me.grpAir.SuspendLayout()
        Me.grpLED.SuspendLayout()
        Me.grpDebug.SuspendLayout()
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
        Me.txtMsg.Location = New System.Drawing.Point(0, 276)
        Me.txtMsg.Name = "txtMsg"
        Me.txtMsg.ReadOnly = True
        Me.txtMsg.Size = New System.Drawing.Size(548, 21)
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
        Me.btnCoolerDown.Text = "Temp Dw"
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
        'txtInputCmd
        '
        Me.txtInputCmd.Location = New System.Drawing.Point(6, 20)
        Me.txtInputCmd.Name = "txtInputCmd"
        Me.txtInputCmd.Size = New System.Drawing.Size(81, 21)
        Me.txtInputCmd.TabIndex = 8
        '
        'btnSendInputCmd
        '
        Me.btnSendInputCmd.Location = New System.Drawing.Point(93, 20)
        Me.btnSendInputCmd.Name = "btnSendInputCmd"
        Me.btnSendInputCmd.Size = New System.Drawing.Size(64, 23)
        Me.btnSendInputCmd.TabIndex = 9
        Me.btnSendInputCmd.Text = "Send"
        Me.btnSendInputCmd.UseVisualStyleBackColor = True
        '
        'txtReceive
        '
        Me.txtReceive.Location = New System.Drawing.Point(6, 49)
        Me.txtReceive.Multiline = True
        Me.txtReceive.Name = "txtReceive"
        Me.txtReceive.ReadOnly = True
        Me.txtReceive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtReceive.Size = New System.Drawing.Size(81, 59)
        Me.txtReceive.TabIndex = 10
        '
        'btnReceive
        '
        Me.btnReceive.Location = New System.Drawing.Point(93, 49)
        Me.btnReceive.Name = "btnReceive"
        Me.btnReceive.Size = New System.Drawing.Size(64, 23)
        Me.btnReceive.TabIndex = 11
        Me.btnReceive.Text = "Receive"
        Me.btnReceive.UseVisualStyleBackColor = True
        '
        'grpDebug
        '
        Me.grpDebug.Controls.Add(Me.dropDebugChoose)
        Me.grpDebug.Controls.Add(Me.txtInputCmd)
        Me.grpDebug.Controls.Add(Me.btnReceive)
        Me.grpDebug.Controls.Add(Me.btnSendInputCmd)
        Me.grpDebug.Controls.Add(Me.txtReceive)
        Me.grpDebug.Location = New System.Drawing.Point(364, 150)
        Me.grpDebug.Name = "grpDebug"
        Me.grpDebug.Size = New System.Drawing.Size(170, 120)
        Me.grpDebug.TabIndex = 12
        Me.grpDebug.TabStop = False
        Me.grpDebug.Text = "Debug"
        '
        'dropDebugChoose
        '
        Me.dropDebugChoose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.dropDebugChoose.FormattingEnabled = True
        Me.dropDebugChoose.Items.AddRange(New Object() {"SCM1", "SCM2"})
        Me.dropDebugChoose.Location = New System.Drawing.Point(93, 78)
        Me.dropDebugChoose.Name = "dropDebugChoose"
        Me.dropDebugChoose.Size = New System.Drawing.Size(64, 20)
        Me.dropDebugChoose.TabIndex = 13
        '
        'grpStatus
        '
        Me.grpStatus.Controls.Add(Me.panSCM2)
        Me.grpStatus.Controls.Add(Me.panSCM1)
        Me.grpStatus.Location = New System.Drawing.Point(364, 14)
        Me.grpStatus.Name = "grpStatus"
        Me.grpStatus.Size = New System.Drawing.Size(170, 130)
        Me.grpStatus.TabIndex = 13
        Me.grpStatus.TabStop = False
        Me.grpStatus.Text = "Status"
        '
        'panSCM2
        '
        Me.panSCM2.Controls.Add(Me.btnAll2Get)
        Me.panSCM2.Controls.Add(Me.txtAll2Status)
        Me.panSCM2.Controls.Add(Me.Label6)
        Me.panSCM2.Location = New System.Drawing.Point(6, 69)
        Me.panSCM2.Name = "panSCM2"
        Me.panSCM2.Size = New System.Drawing.Size(156, 48)
        Me.panSCM2.TabIndex = 1
        '
        'btnAll2Get
        '
        Me.btnAll2Get.Location = New System.Drawing.Point(116, 0)
        Me.btnAll2Get.Name = "btnAll2Get"
        Me.btnAll2Get.Size = New System.Drawing.Size(37, 23)
        Me.btnAll2Get.TabIndex = 2
        Me.btnAll2Get.Text = "Get"
        Me.btnAll2Get.UseVisualStyleBackColor = True
        '
        'txtAll2Status
        '
        Me.txtAll2Status.Location = New System.Drawing.Point(3, 20)
        Me.txtAll2Status.Name = "txtAll2Status"
        Me.txtAll2Status.ReadOnly = True
        Me.txtAll2Status.Size = New System.Drawing.Size(107, 21)
        Me.txtAll2Status.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 12)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "CoverS.CoverM"
        '
        'panSCM1
        '
        Me.panSCM1.Controls.Add(Me.btnAll1Get)
        Me.panSCM1.Controls.Add(Me.txtAll1Status)
        Me.panSCM1.Controls.Add(Me.Label5)
        Me.panSCM1.Location = New System.Drawing.Point(6, 15)
        Me.panSCM1.Name = "panSCM1"
        Me.panSCM1.Size = New System.Drawing.Size(156, 48)
        Me.panSCM1.TabIndex = 0
        '
        'btnAll1Get
        '
        Me.btnAll1Get.Location = New System.Drawing.Point(116, 3)
        Me.btnAll1Get.Name = "btnAll1Get"
        Me.btnAll1Get.Size = New System.Drawing.Size(37, 23)
        Me.btnAll1Get.TabIndex = 2
        Me.btnAll1Get.Text = "Get"
        Me.btnAll1Get.UseVisualStyleBackColor = True
        '
        'txtAll1Status
        '
        Me.txtAll1Status.Location = New System.Drawing.Point(3, 20)
        Me.txtAll1Status.Name = "txtAll1Status"
        Me.txtAll1Status.ReadOnly = True
        Me.txtAll1Status.Size = New System.Drawing.Size(107, 21)
        Me.txtAll1Status.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 12)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Relay1.LED.Dome"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grpUtilities)
        Me.Panel1.Controls.Add(Me.grpTemp)
        Me.Panel1.Controls.Add(Me.grpStatus)
        Me.Panel1.Controls.Add(Me.txtMsg)
        Me.Panel1.Controls.Add(Me.grpDebug)
        Me.Panel1.Controls.Add(Me.grpLED)
        Me.Panel1.Controls.Add(Me.grpAir)
        Me.Panel1.Controls.Add(Me.grpRelay1)
        Me.Panel1.Controls.Add(Me.grpCoverS)
        Me.Panel1.Controls.Add(Me.grpCoverM)
        Me.Panel1.Controls.Add(Me.grpDome)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(545, 296)
        Me.Panel1.TabIndex = 14
        '
        'grpUtilities
        '
        Me.grpUtilities.Controls.Add(Me.btnResetCOM)
        Me.grpUtilities.Location = New System.Drawing.Point(188, 215)
        Me.grpUtilities.Name = "grpUtilities"
        Me.grpUtilities.Size = New System.Drawing.Size(170, 54)
        Me.grpUtilities.TabIndex = 6
        Me.grpUtilities.TabStop = False
        Me.grpUtilities.Text = "Utilities"
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
        Me.grpTemp.Controls.Add(Me.txtTemp)
        Me.grpTemp.Controls.Add(Me.btnTempGet)
        Me.grpTemp.Location = New System.Drawing.Point(12, 215)
        Me.grpTemp.Name = "grpTemp"
        Me.grpTemp.Size = New System.Drawing.Size(170, 55)
        Me.grpTemp.TabIndex = 14
        Me.grpTemp.TabStop = False
        Me.grpTemp.Text = "Temp|Hum"
        '
        'txtTemp
        '
        Me.txtTemp.Location = New System.Drawing.Point(90, 21)
        Me.txtTemp.Name = "txtTemp"
        Me.txtTemp.ReadOnly = True
        Me.txtTemp.Size = New System.Drawing.Size(71, 21)
        Me.txtTemp.TabIndex = 1
        '
        'btnTempGet
        '
        Me.btnTempGet.Location = New System.Drawing.Point(6, 20)
        Me.btnTempGet.Name = "btnTempGet"
        Me.btnTempGet.Size = New System.Drawing.Size(75, 23)
        Me.btnTempGet.TabIndex = 0
        Me.btnTempGet.Text = "Get"
        Me.btnTempGet.UseVisualStyleBackColor = True
        '
        'teleSCM_GUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(545, 296)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "teleSCM_GUI"
        Me.Text = "teleSCM GUI "
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
        Me.grpDebug.ResumeLayout(False)
        Me.grpDebug.PerformLayout()
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
    Friend WithEvents txtInputCmd As System.Windows.Forms.TextBox
    Friend WithEvents btnSendInputCmd As System.Windows.Forms.Button
    Friend WithEvents txtReceive As System.Windows.Forms.TextBox
    Friend WithEvents btnReceive As System.Windows.Forms.Button
    Friend WithEvents grpDebug As System.Windows.Forms.GroupBox
    Friend WithEvents dropDebugChoose As System.Windows.Forms.ComboBox
    Friend WithEvents grpStatus As System.Windows.Forms.GroupBox
    Friend WithEvents panSCM2 As System.Windows.Forms.Panel
    Friend WithEvents btnAll2Get As System.Windows.Forms.Button
    Friend WithEvents txtAll2Status As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents panSCM1 As System.Windows.Forms.Panel
    Friend WithEvents btnAll1Get As System.Windows.Forms.Button
    Friend WithEvents txtAll1Status As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grpTemp As System.Windows.Forms.GroupBox
    Friend WithEvents txtTemp As System.Windows.Forms.TextBox
    Friend WithEvents btnTempGet As System.Windows.Forms.Button
    Friend WithEvents btnDomeStop As System.Windows.Forms.Button
    Friend WithEvents btnCoolerUp As System.Windows.Forms.Button
    Friend WithEvents btnCoolerDown As System.Windows.Forms.Button
    Friend WithEvents grpUtilities As System.Windows.Forms.GroupBox
    Friend WithEvents btnResetCOM As System.Windows.Forms.Button
End Class
