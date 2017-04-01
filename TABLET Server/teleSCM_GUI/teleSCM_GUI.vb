Imports teleSCM.mainSCM
Public Class teleSCM_GUI
    Public WithEvents M As New teleSCM.mainSCM
    Public N_FINISHED = "Action FINISHED."
    Public N_FAILED = "Action FAILED."
    Public N_ACTING = "Acting..."

    Private Property pCa As Integer
    Private Property pCb As Integer

    Private Sub GUI_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim Ca, Cb As Integer
        Dim longHandle As Long
        Dim strLine As String
        Dim I As Integer
        Dim title As String = Me.Text
        longHandle = FreeFile()
        FileOpen(longHandle, "Server.HGAO-CFG", OpenMode.Input, OpenAccess.Read)
        Do While Not EOF(longHandle)
            strLine = LineInput(longHandle)
            If Not strLine = Nothing Then
                'separate name and org
                I = InStr(strLine, "$")
                If Not I <= 0 Then
                    Dim aI As Integer = strLine.Length
                    Dim item As String = Strings.Left(strLine, I - 1)
                    Dim value As String = Strings.Right(strLine, aI - I)
                    Select Case item
                        Case "STATION"
                            If value = "HGTHP" Then
                                grpAir.Visible = False
                                title &= "[HGTHP]"
                            Else
                                title &= "[HGXnR}"
                            End If
                        Case "COMa"
                            If value = "x" Then
                                grpRelay1.Visible = False
                                grpLED.Visible = False
                                grpDome.Visible = False
                                grpAir.Visible = False
                                grpTemp.Visible = False
                                panSCM1.Visible = False
                                title &= "[SCM1-disable]"
                            Else
                                Ca = value
                            End If
                        Case "COMb"
                            If value = "x" Then
                                grpCoverM.Visible = False
                                grpCoverS.Visible = False
                                panSCM2.Visible = False
                                title &= "[SCM2-disable]"
                            Else
                                Cb = value
                            End If
                        Case "DEBUG"
                            If Not value = "1" Then grpDebug.Visible = False
                    End Select
                End If
            End If
        Loop
        pCa = Ca
        pCb = Cb
        M.Inti(Ca, Cb)
        Me.Text = title
        FileClose(longHandle)
        dropDebugChoose.SelectedIndex = 0

        Control.CheckForIllegalCrossThreadCalls = False
    End Sub
    Private Sub GUI_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        M.Quit()
    End Sub
    Private Sub btnDomeOpen_Click(sender As System.Object, e As System.EventArgs) Handles btnDomeOpen.Click
        txtMsg.Text = N_ACTING
        btnDomeOpen.Enabled = False
        btnDomeClose.Enabled = False
        Dim r As Boolean = M.DomeOpen()
        If r = True Then
            txtMsg.Text = N_ACTING
        Else
            txtMsg.Text = N_FAILED
            btnDomeOpen.Enabled = True
            btnDomeClose.Enabled = True
        End If
    End Sub
    Private Sub btnDomeClose_Click(sender As System.Object, e As System.EventArgs) Handles btnDomeClose.Click
        btnDomeOpen.Enabled = False
        btnDomeClose.Enabled = False
        txtMsg.Text = N_ACTING
        Dim r As Boolean = M.DomeClose()
        If r = True Then
            txtMsg.Text = N_ACTING
        Else
            txtMsg.Text = N_FAILED
            btnDomeOpen.Enabled = True
            btnDomeClose.Enabled = True
        End If
    End Sub
    Private Sub btnDomeStop_Click(sender As System.Object, e As System.EventArgs) Handles btnDomeStop.Click
        txtMsg.Text = N_ACTING
        Dim r As Boolean = M.DomeStop()
        If r = True Then
            txtMsg.Text = N_FINISHED
        Else
            txtMsg.Text = N_FAILED
        End If
        btnDomeOpen.Enabled = True
        btnDomeClose.Enabled = True
    End Sub
    Private Sub btnCoverMOpen_Click(sender As System.Object, e As System.EventArgs) Handles btnCoverMOpen.Click
        txtMsg.Text = N_ACTING
        Dim r As Boolean = M.CoverMOpen()
        If r = True Then
            txtMsg.Text = N_ACTING

        Else
            txtMsg.Text = N_FAILED
        End If
    End Sub
    Private Sub btnCoverMClose_Click(sender As System.Object, e As System.EventArgs) Handles btnCoverMClose.Click
        txtMsg.Text = N_ACTING
        Dim r As Boolean = M.CoverMClose()
        If r = True Then
            txtMsg.Text = N_ACTING
        Else
            txtMsg.Text = N_FAILED
        End If
    End Sub
    Private Sub btnCoverSOpen_Click(sender As System.Object, e As System.EventArgs) Handles btnCoverSOpen.Click
        txtMsg.Text = N_ACTING
        Dim r As Boolean = M.CoverSOpen()
        If r = True Then
            txtMsg.Text = N_ACTING
        Else
            txtMsg.Text = N_FAILED
        End If
    End Sub
    Private Sub btnCoverSClose_Click(sender As System.Object, e As System.EventArgs) Handles btnCoverSClose.Click
        txtMsg.Text = N_ACTING
        Dim r As Boolean = M.CoverSClose()
        If r = True Then
            txtMsg.Text = N_ACTING
        Else
            txtMsg.Text = N_FAILED
        End If
    End Sub
    Private Sub btnPower1Con_Click(sender As System.Object, e As System.EventArgs) Handles btnPower1Con.Click
        txtMsg.Text = N_ACTING
        Dim r As Boolean = M.Power1Con()
        If r = True Then
            txtMsg.Text = N_FINISHED
        Else
            txtMsg.Text = N_FAILED
        End If
    End Sub
    Private Sub btnPower1Discon_Click(sender As System.Object, e As System.EventArgs) Handles btnPower1Discon.Click
        txtMsg.Text = N_ACTING
        Dim r As Boolean = M.Power1Discon()
        If r = True Then
            txtMsg.Text = N_FINISHED
        Else
            txtMsg.Text = N_FAILED
        End If
    End Sub
    Private Sub btnCoolerPwr_Click(sender As System.Object, e As System.EventArgs) Handles btnCoolerPwr.Click
        txtMsg.Text = N_ACTING
        Dim r As Boolean = M.CoolerPwr()
        If r = True Then
            txtMsg.Text = N_FINISHED
        Else
            txtMsg.Text = N_FAILED
        End If
    End Sub
    Private Sub btnCoolerUp_Click(sender As System.Object, e As System.EventArgs) Handles btnCoolerUp.Click
        txtMsg.Text = N_ACTING
        Dim r As Boolean = M.CoolerUp()
        If r = True Then
            txtMsg.Text = N_FINISHED
        Else
            txtMsg.Text = N_FAILED
        End If
    End Sub
    Private Sub btnCoolerDown_Click(sender As System.Object, e As System.EventArgs) Handles btnCoolerDown.Click
        txtMsg.Text = N_ACTING
        Dim r As Boolean = M.CoolerDown()
        If r = True Then
            txtMsg.Text = N_FINISHED
        Else
            txtMsg.Text = N_FAILED
        End If
    End Sub
    Private Sub btnLEDOpen_Click(sender As System.Object, e As System.EventArgs) Handles btnLEDOpen.Click
        txtMsg.Text = N_ACTING
        Dim r As Boolean = M.LEDOpen()
        If r = True Then
            txtMsg.Text = N_FINISHED
        Else
            txtMsg.Text = N_FAILED
        End If
    End Sub
    Private Sub btnLEDClose_Click(sender As System.Object, e As System.EventArgs) Handles btnLEDClose.Click
        txtMsg.Text = N_ACTING
        Dim r As Boolean = M.LEDClose()
        If r = True Then
            txtMsg.Text = N_FINISHED
        Else
            txtMsg.Text = N_FAILED
        End If
    End Sub
    Private Sub btnAll1Get_Click(sender As System.Object, e As System.EventArgs) Handles btnAll1Get.Click
        txtMsg.Text = N_ACTING
        txtAll1Status.Text = M.All1Status()
        txtMsg.Text = N_FINISHED
    End Sub
    Private Sub btnAll2Get_Click(sender As System.Object, e As System.EventArgs) Handles btnAll2Get.Click
        txtMsg.Text = N_ACTING
        txtAll2Status.Text = M.All2Status()
        txtMsg.Text = N_FINISHED
    End Sub
    Private Sub btnTempGet_Click(sender As System.Object, e As System.EventArgs) Handles btnTempGet.Click
        Dim data() As Single = M.TempGet()
        Dim txt As String = data(0).ToString & "|" & data(1).ToString
        Replace(txt, "-99", "err")
        txtTemp.Text = txt
    End Sub
    'Debug
    Private Sub btnSendInputCmd_Click(sender As System.Object, e As System.EventArgs) Handles btnSendInputCmd.Click
        Dim n As Integer = dropDebugChoose.SelectedIndex + 1
        M.ISend(txtInputCmd.Text, n)
    End Sub
    Private Sub btnReceive_Click(sender As System.Object, e As System.EventArgs) Handles btnReceive.Click
        Dim n As Integer = dropDebugChoose.SelectedIndex + 1
        txtReceive.Text &= vbCrLf & M.IReceive(n)
    End Sub
    Private Sub objmainSCM_Reached(ByVal API_name As String, ByVal IfSuccess As Boolean) Handles M.Reached
        Dim x As String
        If IfSuccess Then
            x = "succeeded."
        Else
            x = "failed."
        End If
        txtMsg.Text = API_name & " " & x
        btnDomeOpen.Enabled = True
        btnDomeClose.Enabled = True
    End Sub
    Private Sub btnResetCOM_Click(sender As System.Object, e As System.EventArgs) Handles btnResetCOM.Click
        M.Quit()
        M.Inti(pCa, pCb)
    End Sub
End Class